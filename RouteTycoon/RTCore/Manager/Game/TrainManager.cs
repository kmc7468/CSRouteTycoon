using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RouteTycoon.RTCore
{
	public class TrainManager
	{
		private static List<TrainData> _traindatas = new List<TrainData>();
		public static List<TrainData> TrainDatas
		{
			get
			{
				return _traindatas;
			}
		}

		private static List<Locomotive> _locomotives = new List<Locomotive>();
		public static List<Locomotive> Locomotives
		{
			get
			{
				return _locomotives;
			}
		}

		private static List<Coach> _coachs = new List<Coach>();
		public static List<Coach> Coachs
		{
			get
			{
				return _coachs;
			}
		}

		private static List<EngineCoach> _enginecoachs = new List<EngineCoach>();
		public static List<EngineCoach> EngineCoachs
		{
			get
			{
				return _enginecoachs;
			}
		}

		internal static void Reset()
		{
			_traindatas = new List<TrainData>();
			_locomotives = new List<Locomotive>();
			_coachs = new List<Coach>();
			_enginecoachs = new List<EngineCoach>();
			_trains = new List<Train>();
		}

		public static void Init()
		{
			try
			{
				Reset();

				foreach (string str in System.IO.Directory.GetDirectories(Application.StartupPath + "\\data\\trains\\resources"))
				{
					string[] l = System.IO.File.ReadAllLines(str + @"\data.xml", System.Text.Encoding.Default);
					if (l[0] == @"<locomotive>")
					{
						Locomotive loc = new Locomotive();
						loc.Load(str.Substring(str.LastIndexOf('\\') + 1, str.Length - str.LastIndexOf('\\') - 1));

						Locomotives.Add(loc);
						continue;
					}
					else if (l[0] == @"<coach>")
					{
						Coach car = new Coach();
						car.Load(str.Substring(str.LastIndexOf('\\') + 1, str.Length - str.LastIndexOf('\\') - 1));

						Coachs.Add(car);
						continue;
					}
					else if (l[0] == @"<enginecoach>")
					{
						EngineCoach lc = new EngineCoach();
						lc.Load(str.Substring(str.LastIndexOf('\\') + 1, str.Length - str.LastIndexOf('\\') - 1));

						EngineCoachs.Add(lc);
						continue;
					}
				}

				foreach (string str in System.IO.Directory.GetDirectories(".\\data\\trains\\datas"))
				{
					TrainData train = new TrainData();
					train.Load(str.Substring(str.LastIndexOf('\\') + 1, str.Length - str.LastIndexOf('\\') - 1));

					TrainDatas.Add(train);
				}
			}
			catch (Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
			}
		}

		public static Train GetTrainByName(string name, bool onlyplayercompany = true)
		{
			try
			{
				foreach (var it in Trains)
				{
					if (onlyplayercompany && it.Owner != GameManager.Company) continue;

					if (it.Name == name) return it;
				}

				return null;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
				return null;
			}
		}

		public static List<Train> GetTrainsByData(TrainData data, bool onlyplayercompany = true)
		{
			try
			{
				List<Train> train = new List<Train>();

				foreach (var it in Trains)
				{
					if (it.Owner != GameManager.Company && onlyplayercompany) continue;
					if (it.Data == data) train.Add(it);
				}

				return train;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
				return null;
			}
		}

		public static List<Train> GetAllPlayersTrain()
		{
			try
			{
				List<Train> t = new List<Train>();

				foreach (var it in Trains)
				{
					if (it.Owner == GameManager.Company) t.Add(it);
				}

				return t;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
				return null;
			}
		}

		private static List<Train> _trains = new List<Train>();
		public static List<Train> Trains
		{
			get
			{
				return _trains;
			}
		}

		public static string SetTrainNameAuto(TrainData data)
		{
			try
			{
				int idx = 1;

				while (true)
				{
					if (GetTrainByName(data.Name + " #" + idx, false) == null) break;
					idx++;
				}

				return data.Name + " #" + idx;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
				return "";
			}
		}

		public static Locomotive GetLocomotiveByName(string name)
		{
			try
			{
				return Locomotives.Find((e) => { return e.Name == name; });
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
				return null;
			}
		}

		public static Coach GetCoachByName(string name)
		{
			try
			{
				return Coachs.Find((e) => { return e.Name == name; });
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
				return null;
			}
		}

		public static EngineCoach GetEngineCoachByName(string name)
		{
			try
			{
				return EngineCoachs.Find((e) => { return e.Name == name; });
			}
			catch (Exception EX)
			{
				Environment.ReportError(EX, AccessManager.AccessKey);
				return null;
			}
		}
	}
}
