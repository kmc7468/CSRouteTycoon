using System.Drawing;
using System.Windows.Forms;

namespace RouteTycoon.RTCore
{
	public class GameRule
	{
		Plugin.IGameRule _script;

		public GameRule()
		{
			_script = PluginManager.CreateObject<Plugin.IGameRule>(Application.StartupPath + "\\data\\system\\gamerule.dll", "GameRule.GameRule");
		}

		public decimal CalcLoanRate()
		{
			decimal res = _script.CalcLoanRate();

			if (res <= 0) return 0;
			return res;
		}

		public long CalcRailBuildPrice(Point reg1, Point reg2, int price)
		{
			long res = _script.CalcRailBuildPrice(reg1.X, reg1.Y, reg2.X, reg2.Y, price);

			if (res <= 0) return 0;
			return res;
		}

		public long CalcStationPrice(City city, long price)
		{
			long res = _script.CalcStationPrice(city.Price, price);

			if (res <= 0) return 0;
			return res;
		}

		public long CalcCityPrice(long price)
		{
			long res = _script.CalcCityPrice(price);

			if (res <= 0) return 0;
			return res;
		}

		public decimal CalcTax(Company comp)
		{
			decimal moneys = comp.Money;

			foreach (var it in comp.Bankbooks)
				moneys += it;

			decimal res = _script.CalcTax(moneys);

			if (res <= 0) return 0;
			return res;
		}

		public long CalcVisitor(long city_population, long city_prefrence, long city_stationcount)
		{
			long res = _script.CalcVisitor(city_population, city_prefrence, city_stationcount);

			if (res <= 0) return 0;
			return res;
		}

		public long MaxRouteMoneyUser
		{
			get
			{
				long res = _script.MaxRouteMoneyUser;

				if (res <= 0) return 0;
				return res;
			}
		}

		public long MaxRouteMoney
		{
			get
			{
				long res = _script.MaxRouteMoney;

				if (res <= 0) return 0;
				return res;
			}
		}

		public long CalcMinusStationVistor(long city_population, long station_visitor, int routemoney)
		{
			long res = _script.CalcMinusStationVistor(city_population, station_visitor, routemoney);

			if (res <= 0) return 0;
			return res;
		}

		public long CalcRouteIncome(long visitor, long carrying, int routemoney)
		{
			long res = _script.CalcRouteIncome(visitor, carrying, routemoney);

			if (res <= 0) return 0;
			return res;
		}

		public long CalcRailBuildPriceForSameRegion(long price)
		{
			long res = _script.CalcRailBuildPriceForSameRegion(price);

			if (res <= 0) return 0;
			return res;
		}
	}
}
