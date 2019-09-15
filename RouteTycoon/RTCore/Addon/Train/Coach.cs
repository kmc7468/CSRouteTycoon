using System;
using System.Xml;

namespace RouteTycoon.RTCore
{
	public class Coach : TrainParant
	{
		public enum CarriageRank
		{
			FIRST, //특실
			ECONOMY, //일반
			FREIGHT //화물
		}

		public CarriageRank Rank
		{
			get;
			set;
		}

		public long Carrying
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

				XmlNode root = xml.SelectNodes("coach")[0];
				Name = root.SelectNodes("name")[0].InnerText;
				Maintenance = Convert.ToInt64(root.SelectNodes("maintenance")[0].InnerText);
				Price = Convert.ToInt64(root.SelectNodes("price")[0].InnerText);
				switch (root.SelectNodes("rank")[0].InnerText.ToLower())
				{
					case "first": Rank = CarriageRank.FIRST; break;
					case "economy": Rank = CarriageRank.ECONOMY; break;
					case "freight": Rank = CarriageRank.FREIGHT; break;
					default: throw new WrongCoachException("rank 데이터가 올바르지 않습니다.");
				}
				Image = System.Drawing.Image.FromFile(path + "\\" + root.SelectNodes("image")[0].InnerText);
				Carrying = Convert.ToInt64(root.SelectNodes("carrying")[0].InnerText);
				if (Carrying <= 0) throw new WrongCoachException("수송량은 1 이상 이여야 합니다.");
				if (Price < 0) throw new WrongCoachException("구입 비용은 0 이상 이여야 합니다.");
				if (Maintenance < 0) throw new WrongCoachException("유지비는 0 이상 이여야 합니다.");
				if (Name.Trim() == string.Empty) throw new WrongCoachException("이름은 비어 있는 값일 수 없습니다.");
			}
			catch(Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
        }
	}
}
