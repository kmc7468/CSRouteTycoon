using System;
using System.Xml;

namespace RouteTycoon.RTCore
{
	public class Locomotive : TrainParant
	{
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

		public double Speed
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

				XmlNode root = xml.SelectNodes("locomotive")[0];
				Name = root.SelectNodes("name")[0].InnerText;
				Maintenance = Convert.ToInt64(root.SelectNodes("maintenance")[0].InnerText);
				Speed = Convert.ToDouble(root.SelectNodes("speed")[0].InnerText);
				Price = Convert.ToInt64(root.SelectNodes("price")[0].InnerText);
				switch (root.SelectNodes("rank")[0].InnerText.ToLower())
				{
					case "high": Rank = LocomotiveRank.HIGH; break;
					case "default": Rank = LocomotiveRank.DEFAULT; break;
					default: throw new Exception("rank 데이터가 올바르지 않습니다.");
				}
				Image = System.Drawing.Image.FromFile(path + "\\" + root.SelectNodes("image")[0].InnerText);
				Carrying = Convert.ToInt64(root.SelectNodes("carrying")[0].InnerText);
				if (Carrying <= 0) throw new WrongLocomotiveException("최대 연결량은 1 이상 이여야 합니다.");
				if (Price < 0) throw new WrongLocomotiveException("구입 비용은 0 이상이여야 합니다.");
				if (Maintenance < 0) throw new WrongLocomotiveException("유지비는 0 이상 이여야 합니다.");
				if (Speed <= 0) throw new WrongLocomotiveException("속도는 1km/h 이상 이여야 합니다.");
				if (Name.Trim() == string.Empty) throw new WrongLocomotiveException("이름은 비어 있는 값일 수 없습니다.");
			}
			catch(Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
        }
	}
}
