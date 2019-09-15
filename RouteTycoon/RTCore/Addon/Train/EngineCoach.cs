using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RouteTycoon.RTCore
{
	public class EngineCoach : TrainParant
	{
		public class LocomotiveData
		{
			public double Speed
			{
				get;
				set;
			}

			public enum LocomotiveRank
			{
				HIGH,
				DEFAULT
			}

			public LocomotiveRank Rank
			{
				get;
				set;
			}

			public long Carrying
			{
				get;
				set;
			}
		}

		public class CoachData
		{
			public enum CoachRank
			{
				FIRST, //특실
				ECONOMY, //일반
				FREIGHT //화물
			}

			public CoachRank Rank
			{
				get;
				set;
			}

			public long Carrying
			{
				get;
				set;
			}
		}

		public LocomotiveData Locomotive
		{
			get;
			set;
		}

		public CoachData Coach
		{
			get;
			set;
		}

		public void Load(string name)
		{
			try
			{
				string path = ".\\data\\trains\\resources\\" + name;

				XmlDocument xml = new XmlDocument();
				xml.Load(path + "\\data.xml");

				XmlNode root = xml.SelectNodes("enginecoach")[0];
				Name = root.SelectNodes("name")[0].InnerText;
				Maintenance = Convert.ToInt64(root.SelectNodes("maintenance")[0].InnerText);
				Price = Convert.ToInt64(root.SelectNodes("price")[0].InnerText);
				Image = System.Drawing.Image.FromFile(path + "\\" + root.SelectNodes("image")[0].InnerText);

				XmlNode loc = root.SelectNodes("locomotive")[0];
				Locomotive = new LocomotiveData()
				{
					Speed = Convert.ToDouble(loc.SelectNodes("speed")[0].InnerText),
					Carrying = Convert.ToInt64(loc.SelectNodes("carrying")[0].InnerText)
				};
				switch(loc.SelectNodes("rank")[0].InnerText.ToLower())
				{
					case "high": Locomotive.Rank = LocomotiveData.LocomotiveRank.HIGH; break;
					case "default": Locomotive.Rank = LocomotiveData.LocomotiveRank.DEFAULT; break;
					default: throw new WrongEngineCoachException("rank 데이터가 올바르지 않습니다.");
				}

				XmlNode car = root.SelectNodes("coach")[0];
				Coach = new CoachData()
				{
					Carrying = Convert.ToInt64(car.SelectNodes("carrying")[0].InnerText)
				};
				switch (car.SelectNodes("rank")[0].InnerText.ToLower())
				{
					case "first": Coach.Rank = CoachData.CoachRank.FIRST; break;
					case "economy": Coach.Rank = CoachData.CoachRank.ECONOMY; break;
					case "freight": Coach.Rank = CoachData.CoachRank.FREIGHT; break;
					default: throw new WrongEngineCoachException("rank 데이터가 올바르지 않습니다.");
				}
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
