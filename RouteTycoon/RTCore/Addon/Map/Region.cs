using System.Collections.Generic;
using System.Drawing;

namespace RouteTycoon.RTCore
{
	public class Region
	{
		private List<City> _Childs = new List<City>();

		public string Name
		{
			get;
			internal set;
		}

		public Point Location
		{
			get;
			internal set;
		}
		public Map Parent
		{
			get;
			internal set;
		}

		public List<City> Childs
		{
			get
			{
				return _Childs;
			}
		}
	}
}
