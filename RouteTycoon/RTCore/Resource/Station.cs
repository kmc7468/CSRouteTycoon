using System;
using System.Collections.Generic;

namespace RouteTycoon.RTCore
{
	public class Station
	{
		public string Name
		{
			get;
			set;
		}

		public City Parent
		{
			get;
			set;
		} = null;

		public long Visitor
		{
			get;
			set;
		} = 0;

		public enum StationRank
		{
			RANK1,
			RANK2,
			RANK3,
			RANK4,
			RANK5
		}

		public StationRank Rank
		{
			get;
			set;
		}

		public enum StationType
		{
			PASSENGER, //여객
			FREIGHT, //화물
			DOUBLE, //공용
			NULL //빈 값
		}

		public StationType Type
		{
			get;
			set;
		}

		public List<Route> GetRoutes(bool OnlyUserCompany = false)
		{
			try
			{
				List<Route> res = new List<Route>();

				foreach (Route r in GameManager.RouteMgr.Routes)
				{
					if (OnlyUserCompany && r.Owner != GameManager.Company) continue;
					if (r.Stations.Contains(this))
						res.Add(r);
				}

				return res;
			}
			catch(Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
				return null;
			}
		}

		public DateTime Open
		{
			get;
			set;
		}
	}
}
