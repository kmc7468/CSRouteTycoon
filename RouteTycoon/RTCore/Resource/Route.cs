using System;
using System.Collections.Generic;
using System.Drawing;

namespace RouteTycoon.RTCore
{
	public class Route
	{
		private List<Station> _sta = new List<Station>();

		public enum RouteType
		{
			DEFAULT, //일반선
			HIGH //고속선
		}

		public RouteType Type
		{
			get;
			set;
		}

		public Color RouteColor
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public List<Station> Stations
		{
			get
			{
				return _sta;
			}
		}

		public List<Train> Trains
		{
			get
			{
				List<Train> r = new List<Train>();

				foreach (var it in TrainManager.Trains)
				{
					if (it.Route == this) r.Add(it);
				}

				return r;
			}
		}

		private Dictionary<string, List<Station>> _ways = new Dictionary<string, List<Station>>();

		public Dictionary<string, List<Station>> Ways
		{
			get
			{
				return _ways;
			}
		}

		public long Visitor
		{
			get
			{
				long res = 0;

				foreach (var it in Stations)
				{
					res += it.Visitor;
				}

				return res;
			}
		}

		public Company Owner
		{
			get;
			set;
		}

		public int UseMoney
		{
			get;
			set;
		}

		public DateTime Open
		{
			get;
			set;
		}

		public bool MainDraw
		{
			get;
			set;
		} = true;
	}
}
