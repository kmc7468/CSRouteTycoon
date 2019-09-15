using System.Collections.Generic;

namespace RTMapTool
{
	class Region
	{
		public string Name
		{
			get;
			set;
		}

		private List<City> _childs = new List<City>();

		public List<City> Citys
		{
			get
			{
				return _childs;
			}
		}
	}
}
