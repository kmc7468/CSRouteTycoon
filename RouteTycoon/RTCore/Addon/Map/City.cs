using System;
using System.Collections.Generic;
using System.Drawing;

namespace RouteTycoon.RTCore
{
	public class City
	{
		public string Name
		{
			get;
			internal set;
		}

		public long Population
		{
			get;
			set;
		}

		public long Price
		{
			get;
			set;
		}

		public Point Location
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		} = "";

		public Region Parent
		{
			get;
			internal set;
		}

		private List<Station> _Childs = new List<Station>();

		public List<Station> Childs
		{
			get
			{
				return _Childs;
			}
		}

		private List<int> _preference = new List<int>();

		public List<int> Preference
		{
			get
			{
				return _preference;
			}
		}

		public decimal GetIncome(Company comp)
		{
			try
			{
				return comp.GetCityIncome(this);
			}catch(Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
				return 0;
			}
		}
	}
}
