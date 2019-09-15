using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml;

namespace RouteTycoon.RTCore
{
	public class TrainData
	{
		public string Name
		{
			get;
			set;
		}

		public long Maintenance
		{
			get
			{
				long res = 0;
				foreach (var it in Args)
				{
					res += it.Maintenance;
				}

				return res;
			}
		}

		public double Speed
		{
			get
			{
				try
				{
					List<double> tmp1 = new List<double>();
					foreach (var it in Args)
					{
						if (it is Locomotive)
							tmp1.Add((it as Locomotive).Speed);
						else if (it is EngineCoach)
							tmp1.Add((it as EngineCoach).Locomotive.Speed);
					}

					return tmp1.Min();
				}
				catch (Exception ex)
				{
					Environment.ReportError(ex, AccessManager.AccessKey);
					return 0.0;
				}
			}
		}

		public enum TrainRank
		{
			HIGH, //고속
			DEFAULT //일반
		}

		public TrainRank Rank
		{
			get
			{
				try
				{
					List<TrainParant> tp = new List<TrainParant>();
					foreach (var it in Args)
					{
						if (it is Locomotive || it is EngineCoach)
							tp.Add(it);
					}

					if (tp[0] is Locomotive)
					{
						switch ((tp[0] as Locomotive).Rank)
						{
							case Locomotive.LocomotiveRank.HIGH: return TrainRank.HIGH;
							case Locomotive.LocomotiveRank.DEFAULT: return TrainRank.DEFAULT;
							default: throw new ArgumentException();
						}
					}
					else if (tp[0] is EngineCoach)
					{
						switch ((tp[0] as EngineCoach).Locomotive.Rank)
						{
							case EngineCoach.LocomotiveData.LocomotiveRank.HIGH: return TrainRank.HIGH;
							case EngineCoach.LocomotiveData.LocomotiveRank.DEFAULT: return TrainRank.DEFAULT;
							default: throw new ArgumentException();
						}
					}
					else
					{
						throw new ArgumentException();
					}
				}
				catch (Exception ex)
				{
					Environment.ReportError(ex, AccessManager.AccessKey);
					return TrainRank.DEFAULT;
				}
			}
		}

		public long Price
		{
			get
			{
				long res = 0;
				foreach (var it in Args)
				{
					res += it.Price;
				}

				return res;
			}
		}

		public Image Image
		{
			get;
			set;
		}

		public long Carrying
		{
			get
			{
				List<Coach> car = new List<Coach>();
				List<EngineCoach> lc = new List<EngineCoach>();
				foreach (var it in Args)
				{
					if (it is Coach) car.Add((Coach)it);
					else if (it is EngineCoach) lc.Add((EngineCoach)it);
				}

				long res = 0;

				foreach (var it in car)
				{
					res += it.Carrying;
				}

				foreach (var it in lc)
				{
					res += it.Coach.Carrying;
				}

				return res;
			}
		}

		private List<TrainParant> _args = new List<TrainParant>();

		public List<TrainParant> Args
		{
			get
			{
				return _args;
			}
		}

		public void Load(string name)
		{
			try
			{
				string path = ".\\data\\trains\\datas\\" + name;

				XmlDocument xml = new XmlDocument();
				xml.Load(path + "\\data.xml");

				XmlNode root = xml.SelectNodes("traindata")[0];
				string args = root.SelectNodes("args")[0].InnerText;
				Name = root.SelectNodes("name")[0].InnerText;
				Image = Image.FromFile(path + @"\" + root.SelectNodes("image")[0].InnerText);

				XmlDocument arg = new XmlDocument();
				arg.Load(path + "\\" + args);

				XmlNode _args = arg.SelectNodes("args")[0];
				foreach (XmlNode it in _args.SelectNodes("arg"))
				{
					if (it.Attributes["type"].Value == "locomotive")
					{
						if (TrainManager.GetLocomotiveByName(it.Attributes["name"].Value) == null)
							throw new WrongTrainDataException("해당 이름을 가진 기관차가 없습니다.");

						Locomotive t = TrainManager.Locomotives.First(x => x.Name == it.Attributes["name"].Value);

						Args.Add(t);
					}
					else if (it.Attributes["type"].Value == "coach")
					{
						if (TrainManager.GetCoachByName(it.Attributes["name"].Value) == null)
							throw new WrongTrainDataException("해당 이름을 가진 객차가 없습니다.");

						Coach t = TrainManager.Coachs.First(x => x.Name == it.Attributes["name"].Value);

						Args.Add(t);
					}
					else if (it.Attributes["type"].Value == "enginecoach")
					{
						if (TrainManager.GetEngineCoachByName(it.Attributes["name"].Value) == null)
							throw new WrongTrainDataException("해당 이름을 가진 객차가 없습니다.");

						EngineCoach ec = TrainManager.GetEngineCoachByName(it.Attributes["name"].Value);

						Args.Add(ec);
					}
					else
						throw new WrongTrainDataException("'" + it.Attributes["type"].Value + "' 라는 type 은 없습니다.");
				}

				// 검사
				if (Args.Count <= 1) throw new WrongTrainDataException("기관차와 객차의 수를 합친 수가 1 이하 입니다. 최소한 2 이상이여야 합니다.");

				List<Locomotive> loc = new List<Locomotive>();
				List<EngineCoach> lc = new List<EngineCoach>();
				List<TrainParant> loclc = new List<TrainParant>();

				foreach (var it in Args)
				{
					if (it is Locomotive)
					{
						loc.Add((Locomotive)it);
						loclc.Add(it);
					}
					else if (it is EngineCoach)
					{
						lc.Add((EngineCoach)it);
						loclc.Add(it);
					}
				}

				if (loc.Count + lc.Count == 0) // 0일 경우
					throw new WrongTrainDataException("기관차의 수가 0 입니다.");

				long carry = 0;
				foreach (var it in loc)
				{
					carry += it.Carrying;
				}
				foreach (var it in lc)
				{
					carry += it.Locomotive.Carrying;
				}

				List<Coach> car = new List<Coach>();
				foreach (var it in Args)
				{
					if (it is Coach) car.Add((Coach)it);
				}

				if (car.Count > carry) //최대 연결 허용량보다 연결된게 더 높으면
					throw new WrongTrainDataException("기관차가 최대한 연결할 수 있는 객차 수보다 더 많은 객차가 연결 되었습니다.");

				if (loc.Count + lc.Count > 1) // 1보다 크면
				{
					int k = 0;
					if (loclc[0] is Locomotive) k = (int)((loclc[0] as Locomotive).Rank);
					else if (loclc[1] is EngineCoach) k = (int)((loclc[0] as EngineCoach).Locomotive.Rank);

					foreach (var it in loclc)
					{
						if (it is Locomotive)
						{
							if ((int)((it as Locomotive).Rank) != k)
								throw new WrongTrainDataException("기관차의 수가 1 보다 클 경우 기관차들의 등급이 같아야 합니다.");
						}
						else if (it is EngineCoach)
						{
							if ((int)((it as EngineCoach).Locomotive.Rank) != k)
								throw new WrongTrainDataException("기관차의 수가 1 보다 클 경우 기관차들의 등급이 같아야 합니다.");
						}
					}
				}
			}
			catch (Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
			}
		}
	}
}
