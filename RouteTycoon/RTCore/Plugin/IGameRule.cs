namespace RouteTycoon.RTCore.Plugin
{
	public interface IGameRule : IPlugin
	{
		//money.lua
		decimal CalcTax(decimal moneys);
		decimal CalcLoanRate();
		long CalcCityPrice(long price);
		long CalcStationPrice(long city_price, long price);
		long CalcVisitor(long city_population, long city_prefrence, long city_stationcount);
		int MaxRouteMoneyUser
		{
			get;
		}
		int MaxRouteMoney
		{
			get;
		}
        long CalcMinusStationVistor(long city_population, long station_visitor, int routemoney);
		long CalcRouteIncome(long sta_vistior, long carrying, int routemoney);

		//route.lua
		long GetRailLength(int x1, int y1, int x2, int y2);
		long CalcRailBuildPrice(int x1, int y1, int x2, int y2, long price);
		long CalcRailBuildPriceForSameRegion(long city_price);
	}
}
