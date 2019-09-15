using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RouteTycoon.RTAPI
{
	/// <summary>
	/// 시간과 관련된 기능을 제공합니다.
	/// </summary>
	public static class TimeAPI
	{
		/// <summary>
		/// 시간을 받아 올 지역을 나타냅니다.
		/// </summary>
		public enum Region
		{
			/// <summary>
			/// 세계 협정 시 (+0) 입니다.
			/// </summary>
			UTC,
			/// <summary>
			/// 대한민국 서울특별시 (+9) 입니다.
			/// </summary>
			Seoul,
			/// <summary>
			/// 조선 민주주의 인민공화국 평양직할시 (+8.5) 입니다.
			/// </summary>
			Pyongyang,
			/// <summary>
			/// 중화 인민 공화국 베이징(北京) (+8) 입니다.
			/// </summary>
			Beijing,
			/// <summary>
			/// 일본 도쿄(東京, とうきょう) (+9) 입니다.
			/// </summary>
			Tokyo,
			/// <summary>
			/// 미국 워싱턴D.C.(Washington D.C.) (-4) 입니다.
			/// </summary>
			WashingtonDC
		}

		/// <summary>
		/// 로컬 시간을 받아 옵니다. (세계 협정 시)
		/// </summary>
		public static DateTime NowUTCTime
		{
			get
			{
				return DateTime.UtcNow;
			}
		}

		/// <summary>
		/// 로컬 시간을 받아 옵니다.
		/// </summary>
		/// <param name="reg">받아올 지역입니다.</param>
		/// <returns>그 지역의 시간을 로컬 시간을 바탕으로 계산한 시간입니다.</returns>
		public static DateTime NowTime(Region reg)
		{
			switch (reg)
			{
				case Region.UTC: return NowUTCTime;
				case Region.Seoul: return NowUTCTime.AddHours(9);
				case Region.Pyongyang: return NowUTCTime.AddHours(8.5);
				case Region.Beijing: return NowUTCTime.AddHours(8);
				case Region.Tokyo: return NowUTCTime.AddHours(9);
				case Region.WashingtonDC: return NowUTCTime.AddHours(-4);
				default: throw new ArgumentException("없는 선택지 입니다.");
			}
		}

		/// <summary>
		/// 그 년, 그 달의 총 일수를 가져옵니다.
		/// </summary>
		/// <param name="year">계산할 년입니다.</param>
		/// <param name="month">계산할 달입니다.</param>
		/// <returns>총 일수 입니다.</returns>
		public static int LastDay(int year, int month)
		{
			int result = 0;

			DateTime tmp = new DateTime(year, month, 1);

			for (int i = 1; i < 40; i++)
			{
				tmp = tmp.AddDays(1);
				result++;

				if (tmp.Month != month)
					break;
			}

			return result;
		}
	}
}
