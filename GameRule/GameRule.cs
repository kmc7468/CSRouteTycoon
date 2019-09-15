using RouteTycoon.RTCore.Plugin;
using System;
using RouteTycoon.RTCore;

namespace GameRule
{
	public class GameRule : IGameRule
	{
		public string Developer
		{
			get
			{
				return "kmc7468@naver.com (스티브)";
			}
		}

		public string Name
		{
			get
			{
				return "GameRule";
			}
		}

		public Version Ver
		{
			get
			{
				return new Version("1.3.0.0");
			}
		}

		public decimal CalcTax(decimal moneys) //세금계산
		{
			decimal tax = moneys * 0.1m;
			if (tax <= 0) return 0;
			return tax;
		}

		public decimal CalcLoanRate() //이자계산
		{
			return GameManager.Company.Loan * 0.18m;
		}

		public long CalcCityPrice(long price) //땅값
		{
			int updown = new Random().Next(0, 2);
			long result = price;

			if (updown == 0)
				result += new Random().Next(0, Convert.ToInt32(price * 0.001 + 1));
			else
				result -= new Random().Next(0, Convert.ToInt32(price * 0.001 + 1));

			if (result <= 0) return 0;
			return result;
		}

		public long CalcStationPrice(long city_price, long price) //역 건설 비용
		{
			long res = city_price + price;

			if (res <= 0) return 0;
			return res;
		}

		public long CalcVisitor(long city_population, long city_prefrence, long city_stationcount) //역 이용객
		{
			long max = Convert.ToInt64(city_population * (city_prefrence * 0.01) / city_stationcount);
			long min = (max - (max / 2));
			if (min < 0) min = 0;
			long res = 0;
			if (max == min)
				res = min;
			else if (min > max)
				res = new Random().Next(Convert.ToInt32(max), Convert.ToInt32(min) + 1);
			else if (max > min)
				res = new Random().Next(Convert.ToInt32(min), Convert.ToInt32(max) + 1);

			if (res <= 0) return 0;
			return res;
		}

		public int MaxRouteMoneyUser // 승객이 만족하는 최대 노선 이용료
		{
			get
			{
				return 5000;
			}
		}

		public int MaxRouteMoney // 최대 노선 이용료 상한선
		{
			get
			{
				return 5000;
			}
		}

		public long CalcMinusStationVistor(long city_population, long station_visitor,int routemoney) // 노선 이용료가 MaxRouteMoneyUser 의 값을 넘었을때 줄어드는 승객 수 계산
		{
			return 0;

			//if (routemoney - MaxRouteMoneyUser <= 0) return 0;

			// 식 원본
			// floor(min(y * (1 / 1 + e^(-x)), 2 / 3 * y))
			// e = lim x to inf (1 + x)^(1/x)
			// x = 금액
			// y = 인구

			//double e = Math.Exp(-routemoney);
			//double res = Math.Floor(Math.Min(city_population * (1 / 1 + e), 2 / 3 * city_population));
			//return Convert.ToInt64(res);
		}

		public long CalcRouteIncome(long sta_visitor, long carrying, int routemoney)
		{
			if (sta_visitor < carrying) return sta_visitor * routemoney;
			return Convert.ToInt64((sta_visitor - (sta_visitor - carrying)) * routemoney);
		}

		public long GetRailLength(int x1, int y1, int x2, int y2) //레일 길이 계산
		{
			long res = Convert.ToInt64(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)));
			if (res <= 0) return 0;
			return res;
		}

		public long CalcRailBuildPrice(int x1, int y1, int x2, int y2, long price) //레일 설치 비용
		{
			long res =  GetRailLength(x1, y1, x2, y2) * price;

			if (res <= 0) return 0;
			return res;
		}

		public long CalcRailBuildPriceForSameRegion(long city_price)
		{
			long res =  (long)(city_price * 0.8);
			if (res <= 0) return 0;
			return res;
		}
	}
}
