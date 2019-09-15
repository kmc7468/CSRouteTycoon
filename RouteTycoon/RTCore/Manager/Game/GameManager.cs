using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace RouteTycoon.RTCore
{
	public struct GameInitParams
	{
		public string CompanyName;
		public string PresidentName;
		public bool useDefaultLogo;
		public string MapName;
		public long Money;
		public bool Sandbox;
		public int NulAI; // 0 to 9
		public string Filename;
		public DateTime CreateTime;
	}

	public static class GameManager
	{
		public const int SAV_VERSION = 216;
		public static RouteManager RouteMgr = new RouteManager();
		public static ChatManager ChatMgr = new ChatManager();
		public static GameRule GameRule = new GameRule();

		public static List<Company> Companies = new List<Company>();

		public static int LastSelectRegion
		{
			get;
			internal set;
		}

		public static int LastSelectCity
		{
			get;
			internal set;
		}

		public static int LastSelectTrainData
		{
			get;
			internal set;
		}

		private static string _filename = string.Empty;

		public static string Filename
		{
			get
			{
				return _filename;
			}
		}

		public static int NumAI
		{
			get;
			internal set;
		}

		public static int CompanyIndex
		{
			get;
			internal set;
		} = 0;

		public static Company Company
		{
			get
			{
				return Companies[CompanyIndex];
			}
		}

		private static List<NEWS_SAV> _News = new List<NEWS_SAV>();

		public static List<NEWS_SAV> News
		{
			get
			{
				return _News;
			}
		}

		public static bool UseCheat
		{
			get;
			internal set;
		}

		public static Map Map
		{
			get;
			internal set;
		}

		public static DateTime Time
		{
			get;
			internal set;
		}

		public static decimal LoanRate
		{
			get
			{
				return GameRule.CalcLoanRate();
			}
		}

		public static bool Sandbox
		{
			get;
			internal set;
		}

		public static bool isBuild
		{
			get;
			internal set;
		}

		public static string SaveInfo
		{
			get;
			internal set;
		}

		private static DateTime _ct;
		private static DateTime _lst;
		private static DateTime _llt;

		public static DateTime CreateTime
		{
			get
			{
				DateTime dt = new DateTime(_ct.Year, _ct.Month, _ct.Day, _ct.Hour, _ct.Minute, _ct.Second);
				return dt;
			}
		}

		public static DateTime LastSaveTime
		{
			get
			{
				DateTime dt = new DateTime(_lst.Year, _lst.Month, _lst.Day, _lst.Hour, _lst.Minute, _lst.Second);
				return dt;
			}
			internal set
			{
				_lst = value;
			}
		}

		public static DateTime LastLoadTime
		{
			get
			{
				DateTime dt = new DateTime(_llt.Year, _llt.Month, _llt.Day, _llt.Hour, _llt.Minute, _llt.Second);
				return dt;
			}
			internal set
			{
				_llt = value;
			}
		}

		internal static void NewGame(GameInitParams parm)
		{
			try
			{
				Companies.Clear();
				News.Clear();
				RouteMgr = new RouteManager();
				ChatMgr = new ChatManager();
				GameRule = new GameRule();
				TrainManager.Trains.Clear();
				AchievementManager.Init();
				NewsManager.Init();
				LastSelectRegion = -1;
				LastSelectCity = -1;
				LastSelectTrainData = -1;

				Sandbox = parm.Sandbox;
				_filename = parm.Filename;
				_ct = parm.CreateTime;
				LastLoadTime = CreateTime;

				Time = new DateTime(1, 1, 1);

				Companies.Add(new Company(null) { Name = parm.CompanyName, PresidentName = parm.PresidentName, IncomeAdd = 0, Money = parm.Money, Loan = 0, useDefaultLogo = parm.useDefaultLogo });
				NumAI = parm.NulAI;

				List<Plugin.IPlugin> plug = new List<Plugin.IPlugin>();

				foreach (var it in PluginManager.GetPluginList())
					if (it is Plugin.ICompanyPlugin)
						plug.Add(it);

				List<string> Names = new List<string>();

				XmlDocument root = new XmlDocument();

				using (StreamReader sr = new StreamReader(ResourceManager.Get($".\\data\\system\\company.npk", "companys.xml", 5, 7, 1, 6), Encoding.Default))
				{
					root.LoadXml(sr.ReadToEnd());
				}

				XmlNode companys = root.SelectNodes("Companys")[0];

				foreach (XmlNode it in companys.SelectNodes("Company"))
					Names.Add(it.Attributes["Name"].Value);

				for (int i = 0; i < NumAI; i++)
				{
					if (plug.Count <= 0) throw new Exception("AI가 없습니다.");

					Company comp = new Company(plug[new Random().Next(0, plug.Count)] as Plugin.ICompanyPlugin);
					int inx = new Random().Next(0, Names.Count);
					comp.Name = Names[inx];
					Names.Remove(comp.Name);
					comp.PresidentName = "CPU";
					comp.Money = 30000000;
					comp.useDefaultLogo = true;

					Companies.Add(comp);
				}

				Map = new Map();
				Map.Load(".\\data\\maps\\" + parm.MapName + ".dat");

				foreach (Region r in Map.Regions)
				{
					foreach (City c in r.Childs)
					{
						c.Preference.Add(0);
						for (int i = 0; i < NumAI; i++)
							c.Preference.Add(0);
					}
				}

				Company.Bankbooks.Add(0);

				PluginManager.NewGame();

				Save(Filename);
			}
			catch (Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
			}
		}

		internal static void UpdateMap()
		{
			try
			{
				foreach (Region reg in Map.Regions)
				{
					foreach (City city in reg.Childs)
					{
						city.Price = GameRule.CalcCityPrice(city.Price);
					}
				}
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		internal static void Update()
		{
			try
			{
				foreach (Company comp in Companies)
					if (comp.Plugin != null) comp.Plugin.Update(comp);

				foreach (Route route in RouteMgr.Routes)
				{
					foreach (Train car in route.Trains)
					{
						if (car.NowStation == route.Stations.Last() && route.Stations.First() == route.Stations.Last()) // 순환선
						{
							car.NowStation = route.Stations[1];
							continue;
						}

						if (car.NowStation == route.Stations.Last() && !car.RunMode)
						{
							car.RunMode = false;
						}
						else if (car.NowStation == route.Stations.First() && car.RunMode)
						{
							car.RunMode = true;
						}

						car.Progress += car.Data.Speed * 0.001;

						if (car.Progress >= 100)
						{
							if (car.RunMode) //하행 (시작역->종착역)
							{
								if (car.NowStation != route.Stations.Last())
								{
									car.NowStation = route.Stations[route.Stations.IndexOf(car.NowStation) + 1];
								}
							}
							else //상행 (종착역->시작역)
							{
								if (car.NowStation != route.Stations.First())
								{
									car.NowStation = route.Stations[route.Stations.IndexOf(car.NowStation) - 1];
								}
							}

							car.Progress = 0;
						}
					}
				}
			}
			catch (Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
			}
		}

		public static List<Station> GetAllStations()
		{
			try
			{
				List<Station> stas = new List<Station>();

				foreach (Region reg in Map.Regions)
				{
					foreach (City city in reg.Childs)
					{
						foreach (Station s in city.Childs)
						{
							stas.Add(s);
						}
					}
				}

				return stas;
			}
			catch (Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
				return null;
			}
		}

		public static void Save(string name)
		{
			try
			{
				SaveExtraPath(".\\data\\saves\\" + name);
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public static void SaveExtraPath(string PathWithoutExtension)
		{
			try
			{
				using (BinaryWriter sw = new BinaryWriter(File.Open(PathWithoutExtension + ".tmp", FileMode.Create)))
				{
					LastSaveTime = DateTime.Now;

					byte[] mark = Encoding.UTF8.GetBytes("RTSF");
					sw.Write(mark);
					sw.Write(SAV_VERSION);

					sw.Write(UseCheat);
					sw.Write(isBuild);
					if (isBuild)
					{
						sw.Write(SaveInfo);
					}

					// GameData
					sw.Write(Map.Name);
					sw.Write(Time.Year);
					sw.Write(Time.Month);
					sw.Write(Time.Day);
					sw.Write(Sandbox);
					sw.Write(NumAI);

					sw.Write(CreateTime.Year);
					sw.Write(CreateTime.Month);
					sw.Write(CreateTime.Day);
					sw.Write(CreateTime.Hour);
					sw.Write(CreateTime.Minute);
					sw.Write(CreateTime.Second);

					sw.Write(LastLoadTime.Year);
					sw.Write(LastLoadTime.Month);
					sw.Write(LastLoadTime.Day);
					sw.Write(LastLoadTime.Hour);
					sw.Write(LastLoadTime.Minute);
					sw.Write(LastLoadTime.Second);

					sw.Write(LastSaveTime.Year);
					sw.Write(LastSaveTime.Month);
					sw.Write(LastSaveTime.Day);
					sw.Write(LastSaveTime.Hour);
					sw.Write(LastSaveTime.Minute);
					sw.Write(LastSaveTime.Second);

					sw.Write(Companies.Count);
					foreach (Company c in Companies)
					{
						if (c.Plugin != null) sw.Write(c.Plugin.Name);
						sw.Write(c.Name);
						sw.Write(c.PresidentName);
						sw.Write(c.useDefaultLogo);
						sw.Write(c.Money);
						sw.Write(c.Loan);
						sw.Write(c.IncomeAdd);
						sw.Write(c.Bankbooks.Count);
						foreach (var it in c.Bankbooks)
							sw.Write(it);
					}

					sw.Write(GetAllStations().Count);
					foreach (Station sta in GetAllStations())
					{
						sw.Write(sta.Parent.Parent.Name);
						sw.Write(sta.Parent.Name);
						sw.Write(sta.Name);

						sw.Write(sta.Visitor);
						sw.Write((int)sta.Rank);
						sw.Write((int)sta.Type);

						sw.Write(sta.Open.Year);
						sw.Write(sta.Open.Month);
						sw.Write(sta.Open.Day);
					}

					sw.Write(RouteMgr.Routes.Count);
					foreach (Route route in RouteMgr.Routes)
					{
						sw.Write(route.Name);
						sw.Write(route.Owner.Name);
						sw.Write(Convert.ToInt32(route.Type));

						sw.Write(ColorTranslator.ToHtml(route.RouteColor));

						sw.Write(route.Open.Year);
						sw.Write(route.Open.Month);
						sw.Write(route.Open.Day);

						sw.Write(route.UseMoney);

						sw.Write(route.MainDraw);

						sw.Write(route.Stations.Count);
						foreach (Station sta in route.Stations)
						{
							sw.Write(sta.Parent.Parent.Name);
							sw.Write(sta.Parent.Name);
							sw.Write(sta.Name);
						}

						sw.Write(route.Ways.Count);
						foreach (var w in route.Ways)
						{
							sw.Write(w.Key);
							sw.Write(w.Value.Count);
							foreach (var s in w.Value)
							{
								sw.Write(s.Parent.Parent.Name);
								sw.Write(s.Parent.Name);
								sw.Write(s.Name);
							}
						}
					}

					sw.Write(TrainManager.Trains.Count);
					foreach (Train it in TrainManager.Trains)
					{
						sw.Write(it.Data.Name);
						if (it.Route == null)
						{
							sw.Write(true);
							sw.Write(it.RunMode);
							sw.Write(it.Name);
							sw.Write(it.Owner.Name);
							sw.Write(it.WayIndex);
						}
						else
						{
							sw.Write(false);
							sw.Write(it.NowStation.Name);
							sw.Write(it.Progress);
							sw.Write(it.RunMode);
							sw.Write(it.Name);
							sw.Write(it.Route.Name);
							sw.Write(it.Owner.Name);
							sw.Write(it.WayIndex);
						}
					}

					foreach (Region reg in Map.Regions)
					{
						foreach (City city in reg.Childs)
						{
							sw.Write(city.Price);
							sw.Write(city.Preference.Count);
							foreach (var it in city.Preference)
								sw.Write(it);
						}
					}

					sw.Write(News.Count);
					foreach (var it in News)
					{
						sw.Write(it.Data.Plugin.Name);
						sw.Write(it.Time.Year);
						sw.Write(it.Time.Month);
						sw.Write(it.Time.Day);
						sw.Write(it.Data.Plugin.AlreadyDo);
						sw.Write(it.Message);
					}

					List<Chat> chats = ChatMgr.GetChats();
					sw.Write(chats.Count);
					foreach (var it in chats)
					{
						sw.Write(it.Name);
						sw.Write(it.Message);
						sw.Write(it.GameTime.Year);
						sw.Write(it.GameTime.Month);
						sw.Write(it.GameTime.Day);
						sw.Write(it.LocalTime.Year);
						sw.Write(it.LocalTime.Month);
						sw.Write(it.LocalTime.Day);
						sw.Write(it.LocalTime.Hour);
						sw.Write(it.LocalTime.Minute);
						sw.Write(it.LocalTime.Second);
					}

					int ac = 0;
					foreach (var it in AchievementManager.Achievements)
						if (it.Clear) ac++;

					sw.Write(ac);
					foreach (var it in AchievementManager.Achievements)
					{
						if (!it.Clear) continue;
						sw.Write(it.Name);
					}
				}

				if (File.Exists(PathWithoutExtension + ".sav")) File.Delete(PathWithoutExtension + ".sav");
				File.Move(PathWithoutExtension + ".tmp", PathWithoutExtension + ".sav");

				PluginManager.SaveGame();
			}
			catch (Exception e)
			{
				LogManager.Add(new Log() { type = Log.Type.ERROR, evt = Log.Event.THROW, exp = e });

				File.Delete(".\\data\\saves\\" + Filename + ".tmp");

				MessageBox.Show(TextManager.Get().Text("saveerr"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		internal static void Load(string name, Label lb = null)
		{
			try
			{
				Companies.Clear();
				News.Clear();
				RouteMgr = new RouteManager();
				ChatMgr = new ChatManager();
				GameRule = new GameRule();
				TrainManager.Trains.Clear();
				AchievementManager.Init();
				NewsManager.Init();
				LastSelectRegion = -1;
				LastSelectCity = -1;
				LastSelectTrainData = -1;

				_filename = name;

				Map = new Map();

				using (BinaryReader sr = new BinaryReader(File.Open(".\\data\\saves\\" + name + ".sav", FileMode.Open)))
				{
					byte[] mark = sr.ReadBytes(4);
					if (Encoding.UTF8.GetString(mark) != "RTSF")
					{
						if (lb == null)
							throw new NotSaveException();
						else
							lb.Text = TextManager.Get().Text("notsavefile");
						return;
					}

					int version = sr.ReadInt32();

					#region CheckVer and ConvertCheck
					Dictionary<string, string> d = new Dictionary<string, string>();
					d.Add("%NAME%", Filename + "_convert");
					string convert = TextManager.Get().Text("savconvert", true, d);

					switch (version)
					{
						case SAV_VERSION: break;

						case 160: // Alpha 5
							if (MessageBox.Show(convert, "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							{
								try
								{
									ConvertFromAlpha5(name, sr);

									if (lb != null) (lb.Parent as RTUI.GameLoadScene).LoadSaves();
									return;
								}
								catch (Exception ex)
								{
									LogManager.Add(new Log() { evt = Log.Event.THROW, exp = ex, type = Log.Type.ERROR });
									MessageBox.Show(TextManager.Get().Text("errconvert"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
							}
							break;

						case 212: // Beta 1
							if (MessageBox.Show(convert, "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							{
								try
								{
									ConvertFromBeta1(name, sr);

									if (lb != null) (lb.Parent as RTUI.GameLoadScene).LoadSaves();
									return;
								}
								catch (Exception ex)
								{
									LogManager.Add(new Log() { evt = Log.Event.THROW, exp = ex, type = Log.Type.ERROR });
									MessageBox.Show(TextManager.Get().Text("errconvert"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
							}
							break;

						case 213: // Beta 1.1
							if (MessageBox.Show(convert, "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							{
								try
								{
									ConvertFromBeta1_1(name, sr);

									if (lb != null) (lb.Parent as RTUI.GameLoadScene).LoadSaves();
									return;
								}
								catch (Exception ex)
								{
									LogManager.Add(new Log() { evt = Log.Event.THROW, exp = ex, type = Log.Type.ERROR });
									MessageBox.Show(TextManager.Get().Text("errconvert"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
							}
							break;

						case 214: // Beta 2 (01)
							if (MessageBox.Show(convert, "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							{
								try
								{
									ConvertFromBeta2_01(name, sr);

									if (lb != null) (lb.Parent as RTUI.GameLoadScene).LoadSaves();
									return;
								}
								catch (Exception ex)
								{
									LogManager.Add(new Log() { evt = Log.Event.THROW, exp = ex, type = Log.Type.ERROR });
									MessageBox.Show(TextManager.Get().Text("errconvert"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
							}
							break;

						case 215: // Beta 2 (02)
							if (MessageBox.Show(convert, "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							{
								try
								{
									ConvertFromBeta2_02(name, sr);

									if (lb != null) (lb.Parent as RTUI.GameLoadScene).LoadSaves();
									return;
								}
								catch (Exception ex)
								{
									LogManager.Add(new Log() { evt = Log.Event.THROW, exp = ex, type = Log.Type.ERROR });
									MessageBox.Show(TextManager.Get().Text("errconvert"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
							}
							break;

						default:
							if (lb == null)
								throw new CanNotSupportVersionSaveException();
							else
								lb.Text = TextManager.Get().Text("savevernot");
							break;
					}
					#endregion

					if (lb != null) lb.Text = "";

					UseCheat = sr.ReadBoolean();
					isBuild = sr.ReadBoolean();
					if (isBuild)
					{
						SaveInfo = sr.ReadString();
					}

					Map.Load(Application.StartupPath + "\\data\\maps\\" + sr.ReadString() + ".dat", lb);

					Time = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
					Sandbox = sr.ReadBoolean();
					NumAI = sr.ReadInt32();

					_ct = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
					LastLoadTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
					LastLoadTime = DateTime.Now;
					LastSaveTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());

					int count = sr.ReadInt32();
					for (int i = 0; i < count; i++)
					{
						if (i == 0)
						{
							Company c = new Company(null);
							c.Name = sr.ReadString();
							c.PresidentName = sr.ReadString();
							c.useDefaultLogo = sr.ReadBoolean();
							c.Money = sr.ReadDecimal();
							c.Loan = sr.ReadDecimal();
							c.IncomeAdd = sr.ReadDecimal();
							int b_count = sr.ReadInt32();
							for (int j = 0; j < b_count; j++)
								c.Bankbooks.Add(sr.ReadDecimal());
							Companies.Add(c);
						}
						else
						{
							Company c = new Company(PluginManager.FindPluginByName(sr.ReadString()) as Plugin.ICompanyPlugin);
							c.Name = sr.ReadString();
							c.PresidentName = sr.ReadString();
							c.useDefaultLogo = sr.ReadBoolean();
							c.Money = sr.ReadDecimal();
							c.Loan = sr.ReadDecimal();
							c.IncomeAdd = sr.ReadDecimal();
							int b_count = sr.ReadInt32();
							for (int j = 0; j < b_count; j++)
								c.Bankbooks.Add(sr.ReadDecimal());
							Companies.Add(c);
						}
					}

					count = sr.ReadInt32();
					for (int i = 0; i < count; i++)
					{
						Station sta = new Station();

						string reg_name = sr.ReadString();
						string city_name = sr.ReadString();

						Region reg = Map.Regions.First(x => x.Name == reg_name);
						City city = reg.Childs.First(x => x.Name == city_name);

						sta.Name = sr.ReadString();

						sta.Visitor = sr.ReadInt64();
						sta.Rank = (Station.StationRank)sr.ReadInt32();
						sta.Type = (Station.StationType)sr.ReadInt32();

						sta.Open = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());

						sta.Parent = city;

						city.Childs.Add(sta);
					}

					count = sr.ReadInt32();
					for (int i = 0; i < count; i++)
					{
						Route route = new Route();
						route.Name = sr.ReadString();
						route.Owner = Companies[Companies.IndexOf(Companies.First(x => x.Name == sr.ReadString()))];
						route.Type = (Route.RouteType)sr.ReadInt32();
						route.RouteColor = ColorTranslator.FromHtml(sr.ReadString());
						route.Open = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
						route.UseMoney = sr.ReadInt32();
						route.MainDraw = sr.ReadBoolean();

						int sta_count = sr.ReadInt32();
						for (int j = 0; j < sta_count; j++)
						{
							string reg_name = sr.ReadString();
							string city_name = sr.ReadString();
							string sta_name = sr.ReadString();

							Region reg = Map.Regions.First(x => x.Name == reg_name);
							City city = reg.Childs.First(x => x.Name == city_name);
							Station sta = city.Childs.First(x => x.Name == sta_name);

							route.Stations.Add(sta);
						}

						int way_count = sr.ReadInt32();
						for (int j = 0; j < way_count; j++)
						{
							string way_name = sr.ReadString();
							int s_count = sr.ReadInt32();
							List<Station> stas = new List<Station>();
							for (int s = 0; s < s_count; s++)
							{
								string reg_name = sr.ReadString();
								string city_name = sr.ReadString();
								string sta_name = sr.ReadString();

								Region reg = Map.Regions.First(x => x.Name == reg_name);
								City city = reg.Childs.First(x => x.Name == city_name);
								Station sta = city.Childs.First(x => x.Name == sta_name);

								stas.Add(sta);
							}
							route.Ways.Add(way_name, stas);
						}

						RouteMgr.Routes.Add(route);
					}

					int car_count = sr.ReadInt32();
					for (int j = 0; j < car_count; j++)
					{
						Train t = new Train(sr.ReadString());
						bool isRouteNull = sr.ReadBoolean();

						if (isRouteNull)
						{
							t.RunMode = sr.ReadBoolean();
							t.Name = sr.ReadString();
							t.Progress = 0.0;
							t.Route = null;
							t.NowStation = null;
							t.Owner = Companies.First(x => x.Name == sr.ReadString());
							t.WayIndex = sr.ReadInt32();
						}
						else
						{
							string sta_name = sr.ReadString();
							t.Progress = sr.ReadDouble();
							t.RunMode = sr.ReadBoolean();
							t.Name = sr.ReadString();
							string route_name = sr.ReadString();
							t.Route = RouteMgr.Routes.First(x => x.Name == route_name);
							t.NowStation = t.Route.Stations.First(x => x.Name == sta_name);
							t.Owner = Companies.First(x => x.Name == sr.ReadString());
							t.WayIndex = sr.ReadInt32();
						}

						TrainManager.Trains.Add(t);
					}

					foreach (Region reg in Map.Regions)
					{
						foreach (City city in reg.Childs)
						{
							city.Price = sr.ReadInt64();
							int c = sr.ReadInt32();
							for (int j = 0; j < c; j++)
								city.Preference.Add(sr.ReadInt32());
						}
					}

					count = sr.ReadInt32();
					for (int i = 0; i < count; i++)
					{
						NEWS_SAV n = new NEWS_SAV();

						string n_name = sr.ReadString();
						n.Data = NewsManager.News.First(x => x.Plugin.Name == n_name);
						n.Time = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
						n.Data.Plugin.AlreadyDo = sr.ReadBoolean();
						n.Message = sr.ReadString();

						News.Add(n);
					}

					count = sr.ReadInt32();
					for (int i = 0; i < count; i++)
					{
						Chat c = new Chat();

						c.Name = sr.ReadString();
						c.Message = sr.ReadString();
						c.GameTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
						c.LocalTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());

						ChatMgr.AppendChat(c);
					}

					count = sr.ReadInt32();
					for (int i = 0; i < count; i++)
					{
						string _name = sr.ReadString();
						AchievementManager.Achievements.First(x => x.Name == _name).Clear = true;
					}
				}

				if (isBuild)
				{
					Company.Money = 0;
					Sandbox = false;
				}

				PluginManager.LoadGame();
			}
			catch (Exception e)
			{
				if (lb != null)
				{
					LogManager.Add(new Log() { type = Log.Type.ERROR, evt = Log.Event.THROW, exp = e });
					lb.Text = TextManager.Get().Text("readerr");
					return;
				}
				Environment.ReportError(e, AccessManager.AccessKey);
			}
		}

		#region Convert

		private static void ConvertFromBeta2_02(string name, BinaryReader br)
		{
			using (BinaryReader sr = br)
			{
				UseCheat = sr.ReadBoolean();
				isBuild = sr.ReadBoolean();
				if (isBuild)
				{
					SaveInfo = sr.ReadString();
				}

				Map.Load(Application.StartupPath + "\\data\\maps\\" + sr.ReadString() + ".dat");

				Time = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
				Sandbox = sr.ReadBoolean();
				NumAI = sr.ReadInt32();

				_ct = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
				LastLoadTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
				LastLoadTime = DateTime.Now;
				LastSaveTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());

				int count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					if (i == 0)
					{
						Company c = new Company(null);
						c.Name = sr.ReadString();
						c.PresidentName = sr.ReadString();
						c.useDefaultLogo = sr.ReadBoolean();
						c.Money = sr.ReadDecimal();
						c.Loan = sr.ReadDecimal();
						c.IncomeAdd = sr.ReadDecimal();
						int b_count = sr.ReadInt32();
						for (int j = 0; j < b_count; j++)
							c.Bankbooks.Add(sr.ReadDecimal());
						Companies.Add(c);
					}
					else
					{
						Company c = new Company(PluginManager.FindPluginByName(sr.ReadString()) as Plugin.ICompanyPlugin);
						c.Name = sr.ReadString();
						c.PresidentName = sr.ReadString();
						c.useDefaultLogo = sr.ReadBoolean();
						c.Money = sr.ReadDecimal();
						c.Loan = sr.ReadDecimal();
						c.IncomeAdd = sr.ReadDecimal();
						int b_count = sr.ReadInt32();
						for (int j = 0; j < b_count; j++)
							c.Bankbooks.Add(sr.ReadDecimal());
						Companies.Add(c);
					}
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					Station sta = new Station();

					string reg_name = sr.ReadString();
					string city_name = sr.ReadString();

					Region reg = Map.Regions.First(x => x.Name == reg_name);
					City city = reg.Childs.First(x => x.Name == city_name);

					sta.Name = sr.ReadString();

					sta.Visitor = sr.ReadInt64();
					sta.Rank = (Station.StationRank)sr.ReadInt32();
					sta.Type = (Station.StationType)sr.ReadInt32();

					sta.Open = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());

					sta.Parent = city;

					city.Childs.Add(sta);
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					Route route = new Route();
					route.Name = sr.ReadString();
					route.Owner = Companies[Companies.IndexOf(Companies.First(x => x.Name == sr.ReadString()))];
					route.Type = (Route.RouteType)sr.ReadInt32();
					route.RouteColor = ColorTranslator.FromHtml(sr.ReadString());
					route.Open = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
					route.UseMoney = sr.ReadInt32();
					route.MainDraw = sr.ReadBoolean();

					int sta_count = sr.ReadInt32();
					for (int j = 0; j < sta_count; j++)
					{
						string reg_name = sr.ReadString();
						string city_name = sr.ReadString();
						string sta_name = sr.ReadString();

						Region reg = Map.Regions.First(x => x.Name == reg_name);
						City city = reg.Childs.First(x => x.Name == city_name);
						Station sta = city.Childs.First(x => x.Name == sta_name);

						route.Stations.Add(sta);
					}

					RouteMgr.Routes.Add(route);
				}

				int car_count = sr.ReadInt32();
				for (int j = 0; j < car_count; j++)
				{
					Train t = new Train(sr.ReadString());
					bool isRouteNull = sr.ReadBoolean();

					if (isRouteNull)
					{
						t.RunMode = sr.ReadBoolean();
						t.Name = sr.ReadString();
						t.Progress = 0.0;
						t.Route = null;
						t.NowStation = null;
						t.Owner = Companies.First(x => x.Name == sr.ReadString());
					}
					else
					{
						string sta_name = sr.ReadString();
						t.Progress = sr.ReadDouble();
						t.RunMode = sr.ReadBoolean();
						t.Name = sr.ReadString();
						string route_name = sr.ReadString();
						t.Route = RouteMgr.Routes.First(x => x.Name == route_name);
						t.NowStation = t.Route.Stations.First(x => x.Name == sta_name);
						t.Owner = Companies.First(x => x.Name == sr.ReadString());
					}

					TrainManager.Trains.Add(t);
				}

				foreach (Region reg in Map.Regions)
				{
					foreach (City city in reg.Childs)
					{
						city.Price = sr.ReadInt64();
						int c = sr.ReadInt32();
						for (int j = 0; j < c; j++)
							city.Preference.Add(sr.ReadInt32());
					}
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					NEWS_SAV n = new NEWS_SAV();

					string n_name = sr.ReadString();
					n.Data = NewsManager.News.First(x => x.Plugin.Name == n_name);
					n.Time = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
					n.Data.Plugin.AlreadyDo = sr.ReadBoolean();
					n.Message = sr.ReadString();

					News.Add(n);
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					Chat c = new Chat();

					c.Name = sr.ReadString();
					c.Message = sr.ReadString();
					c.GameTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
					c.LocalTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());

					ChatMgr.AppendChat(c);
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					string _name = sr.ReadString();
					AchievementManager.Achievements.First(x => x.Name == _name).Clear = true;
				}

				Save(name + "_convert");
			}
		}

		private static void ConvertFromBeta2_01(string name, BinaryReader br)
		{
			using (BinaryReader sr = br)
			{
				_filename = name + "_convert";

				UseCheat = sr.ReadBoolean();
				isBuild = sr.ReadBoolean();

				Map.Load(Application.StartupPath + "\\data\\maps\\" + sr.ReadString() + ".dat");

				Time = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
				Sandbox = sr.ReadBoolean();
				NumAI = sr.ReadInt32();

				_ct = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
				LastLoadTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
				LastLoadTime = DateTime.Now;
				LastSaveTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());

				int count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					if (i == 0)
					{
						Company c = new Company(null);
						c.Name = sr.ReadString();
						c.PresidentName = sr.ReadString();
						c.useDefaultLogo = sr.ReadBoolean();
						c.Money = sr.ReadDecimal();
						c.Loan = sr.ReadDecimal();
						c.IncomeAdd = sr.ReadDecimal();
						int b_count = sr.ReadInt32();
						for (int j = 0; j < b_count; j++)
							c.Bankbooks.Add(sr.ReadDecimal());
						Companies.Add(c);
					}
					else
					{
						Company c = new Company(PluginManager.FindPluginByName(sr.ReadString()) as Plugin.ICompanyPlugin);
						c.Name = sr.ReadString();
						c.PresidentName = sr.ReadString();
						c.useDefaultLogo = sr.ReadBoolean();
						c.Money = sr.ReadDecimal();
						c.Loan = sr.ReadDecimal();
						c.IncomeAdd = sr.ReadDecimal();
						int b_count = sr.ReadInt32();
						for (int j = 0; j < b_count; j++)
							c.Bankbooks.Add(sr.ReadDecimal());
						Companies.Add(c);
					}
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					Station sta = new Station();

					string reg_name = sr.ReadString();
					string city_name = sr.ReadString();

					Region reg = Map.Regions.First(x => x.Name == reg_name);
					City city = reg.Childs.First(x => x.Name == city_name);

					sta.Name = sr.ReadString();

					sta.Visitor = sr.ReadInt64();
					sta.Rank = (Station.StationRank)sr.ReadInt32();
					sta.Type = (Station.StationType)sr.ReadInt32();

					sta.Open = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());

					sta.Parent = city;

					city.Childs.Add(sta);
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					Route route = new Route();
					route.Name = sr.ReadString();
					route.Owner = Companies[Companies.IndexOf(Companies.First(x => x.Name == sr.ReadString()))];
					route.Type = (Route.RouteType)sr.ReadInt32();
					route.RouteColor = ColorTranslator.FromHtml(sr.ReadString());
					route.Open = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
					route.UseMoney = sr.ReadInt32();
					route.MainDraw = sr.ReadBoolean();

					int sta_count = sr.ReadInt32();
					for (int j = 0; j < sta_count; j++)
					{
						string reg_name = sr.ReadString();
						string city_name = sr.ReadString();
						string sta_name = sr.ReadString();

						Region reg = Map.Regions.First(x => x.Name == reg_name);
						City city = reg.Childs.First(x => x.Name == city_name);
						Station sta = city.Childs.First(x => x.Name == sta_name);

						route.Stations.Add(sta);
					}

					RouteMgr.Routes.Add(route);
				}

				int car_count = sr.ReadInt32();
				for (int j = 0; j < car_count; j++)
				{
					Train t = new Train(sr.ReadString());
					bool isRouteNull = sr.ReadBoolean();

					if (isRouteNull)
					{
						t.RunMode = sr.ReadBoolean();
						t.Name = sr.ReadString();
						t.Progress = 0.0;
						t.Route = null;
						t.NowStation = null;
						t.Owner = Companies.First(x => x.Name == sr.ReadString());
					}
					else
					{
						string sta_name = sr.ReadString();
						t.Progress = sr.ReadDouble();
						t.RunMode = sr.ReadBoolean();
						t.Name = sr.ReadString();
						string route_name = sr.ReadString();
						t.Route = RouteMgr.Routes.First(x => x.Name == route_name);
						t.NowStation = t.Route.Stations.First(x => x.Name == sta_name);
						t.Owner = Companies.First(x => x.Name == sr.ReadString());
					}

					TrainManager.Trains.Add(t);
				}

				foreach (Region reg in Map.Regions)
				{
					foreach (City city in reg.Childs)
					{
						city.Price = sr.ReadInt64();
						int c = sr.ReadInt32();
						for (int j = 0; j < c; j++)
							city.Preference.Add(sr.ReadInt32());
					}
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					NEWS_SAV n = new NEWS_SAV();

					string n_name = sr.ReadString();
					n.Data = NewsManager.News.First(x => x.Plugin.Name == n_name);
					n.Time = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
					n.Data.Plugin.AlreadyDo = sr.ReadBoolean();
					n.Message = sr.ReadString();

					News.Add(n);
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					Chat c = new Chat();

					c.Name = sr.ReadString();
					c.Message = sr.ReadString();
					c.GameTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
					c.LocalTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());

					ChatMgr.AppendChat(c);
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					string _name = sr.ReadString();
					AchievementManager.Achievements.First(x => x.Name == _name).Clear = true;
				}

				Save(name + "_convert");
			}
		}

		private static void ConvertFromBeta1_1(string name, BinaryReader br)
		{
			using (BinaryReader sr = br)
			{
				_filename = name + "_convert";

				UseCheat = sr.ReadBoolean();

				Map.Load(Application.StartupPath + "\\data\\maps\\" + sr.ReadString() + ".dat");

				Time = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
				Sandbox = sr.ReadBoolean();
				NumAI = sr.ReadInt32();

				_ct = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
				LastLoadTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
				LastLoadTime = DateTime.Now;
				LastSaveTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());

				int count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					if (i == 0)
					{
						Company c = new Company(null);
						c.Name = sr.ReadString();
						c.PresidentName = sr.ReadString();
						c.useDefaultLogo = sr.ReadBoolean();
						c.Money = sr.ReadDecimal();
						c.Loan = sr.ReadDecimal();
						c.IncomeAdd = sr.ReadDecimal();
						int b_count = sr.ReadInt32();
						for (int j = 0; j < b_count; j++)
							c.Bankbooks.Add(sr.ReadDecimal());
						Companies.Add(c);
					}
					else
					{
						Company c = new Company(PluginManager.FindPluginByName(sr.ReadString()) as Plugin.ICompanyPlugin);
						c.Name = sr.ReadString();
						c.PresidentName = sr.ReadString();
						c.useDefaultLogo = sr.ReadBoolean();
						c.Money = sr.ReadDecimal();
						c.Loan = sr.ReadDecimal();
						c.IncomeAdd = sr.ReadDecimal();
						int b_count = sr.ReadInt32();
						for (int j = 0; j < b_count; j++)
							c.Bankbooks.Add(sr.ReadDecimal());
						Companies.Add(c);
					}
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					Station sta = new Station();

					string reg_name = sr.ReadString();
					string city_name = sr.ReadString();

					Region reg = Map.Regions.First(x => x.Name == reg_name);
					City city = reg.Childs.First(x => x.Name == city_name);

					sta.Name = sr.ReadString();

					sta.Visitor = sr.ReadInt64();
					sta.Rank = (Station.StationRank)sr.ReadInt32();
					sta.Type = (Station.StationType)sr.ReadInt32();

					sta.Open = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());

					sta.Parent = city;

					city.Childs.Add(sta);
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					Route route = new Route();
					route.Name = sr.ReadString();
					route.Owner = Companies[Companies.IndexOf(Companies.First(x => x.Name == sr.ReadString()))];
					route.Type = (Route.RouteType)sr.ReadInt32();
					route.RouteColor = ColorTranslator.FromHtml(sr.ReadString());
					route.Open = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
					route.UseMoney = sr.ReadInt32();
					route.MainDraw = sr.ReadBoolean();

					int sta_count = sr.ReadInt32();
					for (int j = 0; j < sta_count; j++)
					{
						string reg_name = sr.ReadString();
						string city_name = sr.ReadString();
						string sta_name = sr.ReadString();

						Region reg = Map.Regions.First(x => x.Name == reg_name);
						City city = reg.Childs.First(x => x.Name == city_name);
						Station sta = city.Childs.First(x => x.Name == sta_name);

						route.Stations.Add(sta);
					}

					RouteMgr.Routes.Add(route);
				}

				int car_count = sr.ReadInt32();
				for (int j = 0; j < car_count; j++)
				{
					Train t = new Train(sr.ReadString());
					bool isRouteNull = sr.ReadBoolean();

					if (isRouteNull)
					{
						t.RunMode = sr.ReadBoolean();
						t.Name = sr.ReadString();
						t.Progress = 0.0;
						t.Route = null;
						t.NowStation = null;
						t.Owner = Companies.First(x => x.Name == sr.ReadString());
					}
					else
					{
						string sta_name = sr.ReadString();
						t.Progress = sr.ReadDouble();
						t.RunMode = sr.ReadBoolean();
						t.Name = sr.ReadString();
						string route_name = sr.ReadString();
						t.Route = RouteMgr.Routes.First(x => x.Name == route_name);
						t.NowStation = t.Route.Stations.First(x => x.Name == sta_name);
						t.Owner = Companies.First(x => x.Name == sr.ReadString());
					}

					TrainManager.Trains.Add(t);
				}

				foreach (Region reg in Map.Regions)
				{
					foreach (City city in reg.Childs)
					{
						city.Price = sr.ReadInt64();
						int c = sr.ReadInt32();
						for (int j = 0; j < c; j++)
							city.Preference.Add(sr.ReadInt32());
					}
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					NEWS_SAV n = new NEWS_SAV();

					string n_name = sr.ReadString();
					n.Data = NewsManager.News.First(x => x.Plugin.Name == n_name);
					n.Time = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
					n.Data.Plugin.AlreadyDo = sr.ReadBoolean();
					n.Message = sr.ReadString();

					News.Add(n);
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					Chat c = new Chat();

					c.Name = sr.ReadString();
					c.Message = sr.ReadString();
					c.GameTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
					c.LocalTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());

					ChatMgr.AppendChat(c);
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					string _name = sr.ReadString();
					AchievementManager.Achievements.First(x => x.Name == _name).Clear = true;
				}

				Save(name + "_convert");
			}
		}

		private static void ConvertFromBeta1(string name, BinaryReader br)
		{
			using (BinaryReader sr = br)
			{
				_filename = name + "_convert";

				UseCheat = sr.ReadBoolean();

				Map.Load(Application.StartupPath + "\\data\\maps\\" + sr.ReadString() + ".dat");

				Time = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
				Sandbox = sr.ReadBoolean();
				NumAI = sr.ReadInt32();

				_ct = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
				LastLoadTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
				LastLoadTime = DateTime.Now;
				LastSaveTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());

				int count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					if (i == 0)
					{
						Company c = new Company(null);
						c.Name = sr.ReadString();
						c.PresidentName = sr.ReadString();
						c.useDefaultLogo = sr.ReadBoolean();
						c.Money = sr.ReadDecimal();
						c.Loan = sr.ReadDecimal();
						c.IncomeAdd = sr.ReadDecimal();
						int b_count = sr.ReadInt32();
						for (int j = 0; j < b_count; j++)
							c.Bankbooks.Add(sr.ReadDecimal());
						Companies.Add(c);
					}
					else
					{
						Company c = new Company(PluginManager.FindPluginByName(sr.ReadString()) as Plugin.ICompanyPlugin);
						c.Name = sr.ReadString();
						c.PresidentName = sr.ReadString();
						c.useDefaultLogo = sr.ReadBoolean();
						c.Money = sr.ReadDecimal();
						c.Loan = sr.ReadDecimal();
						c.IncomeAdd = sr.ReadDecimal();
						int b_count = sr.ReadInt32();
						for (int j = 0; j < b_count; j++)
							c.Bankbooks.Add(sr.ReadDecimal());
						Companies.Add(c);
					}
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					Station sta = new Station();

					string reg_name = sr.ReadString();
					string city_name = sr.ReadString();

					Region reg = Map.Regions.First(x => x.Name == reg_name);
					City city = reg.Childs.First(x => x.Name == city_name);

					sta.Name = sr.ReadString();

					sta.Visitor = sr.ReadInt64();
					sta.Rank = (Station.StationRank)sr.ReadInt32();
					sta.Type = (Station.StationType)sr.ReadInt32();

					sta.Open = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());

					sta.Parent = city;

					city.Childs.Add(sta);
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					Route route = new Route();
					route.Name = sr.ReadString();
					route.Owner = Companies[Companies.IndexOf(Companies.First(x => x.Name == sr.ReadString()))];
					route.Type = (Route.RouteType)sr.ReadInt32();
					route.RouteColor = ColorTranslator.FromHtml(sr.ReadString());
					route.Open = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
					route.UseMoney = sr.ReadInt32();

					int sta_count = sr.ReadInt32();
					for (int j = 0; j < sta_count; j++)
					{
						string reg_name = sr.ReadString();
						string city_name = sr.ReadString();
						string sta_name = sr.ReadString();

						Region reg = Map.Regions.First(x => x.Name == reg_name);
						City city = reg.Childs.First(x => x.Name == city_name);
						Station sta = city.Childs.First(x => x.Name == sta_name);

						route.Stations.Add(sta);
					}

					RouteMgr.Routes.Add(route);
				}

				int car_count = sr.ReadInt32();
				for (int j = 0; j < car_count; j++)
				{
					Train t = new Train(sr.ReadString());
					bool isRouteNull = sr.ReadBoolean();

					if (isRouteNull)
					{
						t.RunMode = sr.ReadBoolean();
						t.Name = sr.ReadString();
						t.Progress = 0.0;
						t.Route = null;
						t.NowStation = null;
						t.Owner = Companies.First(x => x.Name == sr.ReadString());
					}
					else
					{
						string sta_name = sr.ReadString();
						t.Progress = sr.ReadDouble();
						t.RunMode = sr.ReadBoolean();
						t.Name = sr.ReadString();
						string route_name = sr.ReadString();
						t.Route = RouteMgr.Routes.First(x => x.Name == route_name);
						t.NowStation = t.Route.Stations.First(x => x.Name == sta_name);
						t.Owner = Companies.First(x => x.Name == sr.ReadString());
					}

					TrainManager.Trains.Add(t);
				}

				foreach (Region reg in Map.Regions)
				{
					foreach (City city in reg.Childs)
					{
						city.Price = sr.ReadInt64();
						int c = sr.ReadInt32();
						for (int j = 0; j < c; j++)
							city.Preference.Add(sr.ReadInt32());
					}
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					NEWS_SAV n = new NEWS_SAV();

					string n_name = sr.ReadString();
					n.Data = NewsManager.News.First(x => x.Plugin.Name == n_name);
					n.Time = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
					n.Data.Plugin.AlreadyDo = sr.ReadBoolean();
					n.Message = sr.ReadString();

					News.Add(n);
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					Chat c = new Chat();

					c.Name = sr.ReadString();
					c.Message = sr.ReadString();
					c.GameTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
					c.LocalTime = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());

					ChatMgr.AppendChat(c);
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					string _name = sr.ReadString();
					AchievementManager.Achievements.First(x => x.Name == _name).Clear = true;
				}

				Save(name + "_convert");
			}
		}

		private static void ConvertFromAlpha5(string name, BinaryReader br)
		{
			using (BinaryReader sr = br)
			{
				_filename = name + "_convert";

				UseCheat = sr.ReadBoolean();

				Map.Load(Application.StartupPath + "\\data\\maps\\" + sr.ReadString() + ".dat");

				Time = new DateTime(sr.ReadInt32(), sr.ReadInt32(), sr.ReadInt32());
				Sandbox = sr.ReadBoolean();
				NumAI = sr.ReadInt32();

				_ct = DateTime.Now;
				LastLoadTime = DateTime.Now;
				LastSaveTime = DateTime.Now;

				int count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					if (i == 0)
					{
						Company c = new Company(null);
						c.Name = sr.ReadString();
						c.PresidentName = sr.ReadString();
						string logo = sr.ReadString();
						if (logo == "default") c.useDefaultLogo = true;
						else c.useDefaultLogo = false;
						c.Money = sr.ReadInt64();
						c.Loan = sr.ReadInt64();
						c.IncomeAdd = sr.ReadDecimal();
						c.Bankbooks.Add(0);
						Companies.Add(c);
					}
					else
					{
						Company c = new Company(PluginManager.FindPluginByName(sr.ReadString()) as Plugin.ICompanyPlugin);
						c.Name = sr.ReadString();
						c.PresidentName = sr.ReadString();
						string logo = sr.ReadString();
						if (logo == "default") c.useDefaultLogo = true;
						else c.useDefaultLogo = false;
						c.Money = sr.ReadInt64();
						c.Loan = sr.ReadInt64();
						c.Bankbooks.Add(0);
						Companies.Add(c);
					}
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					Station sta = new Station();

					string reg_name = sr.ReadString();
					string city_name = sr.ReadString();

					Region reg = Map.Regions.First(x => x.Name == reg_name);
					City city = reg.Childs.First(x => x.Name == city_name);

					sta.Name = sr.ReadString();

					sta.Visitor = sr.ReadInt64();

					sta.Rank = Station.StationRank.RANK1;
					sta.Type = Station.StationType.DOUBLE;

					sta.Parent = city;

					city.Childs.Add(sta);
				}

				count = sr.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					Route route = new Route();
					route.Name = sr.ReadString();
					route.Owner = Companies[Companies.IndexOf(Companies.First(x => x.Name == sr.ReadString()))];
					route.Type = (Route.RouteType)sr.ReadInt32();
					route.RouteColor = ColorTranslator.FromHtml(sr.ReadString());
					route.Open = Time;
					if (route.Type == Route.RouteType.DEFAULT) route.UseMoney = 50;
					else if (route.Type == Route.RouteType.HIGH) route.UseMoney = 100;

					int sta_count = sr.ReadInt32();
					for (int j = 0; j < sta_count; j++)
					{
						string reg_name = sr.ReadString();
						string city_name = sr.ReadString();
						string sta_name = sr.ReadString();

						Region reg = Map.Regions.First(x => x.Name == reg_name);
						City city = reg.Childs.First(x => x.Name == city_name);
						Station sta = city.Childs.First(x => x.Name == sta_name);

						route.Stations.Add(sta);
					}

					int car_count = sr.ReadInt32();
					for (int j = 0; j < car_count; j++)
					{
						Train car = new Train(sr.ReadString());

						string sta_name = sr.ReadString();
						car.NowStation = route.Stations.First(x => x.Name == sta_name);
						car.Progress = sr.ReadDouble();
						car.RunMode = sr.ReadBoolean();
						sr.ReadBoolean();
						car.Name = sr.ReadString();
						car.Route = route;

						TrainManager.Trains.Add(car);
					}

					RouteMgr.Routes.Add(route);
				}

				foreach (Region reg in Map.Regions)
				{
					foreach (City city in reg.Childs)
					{
						city.Price = sr.ReadInt64();
						city.Preference.Add(sr.ReadInt32());
					}
				}
			}

			Save(name + "_convert");
		}

		#endregion
	}
}
