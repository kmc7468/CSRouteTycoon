using System.Drawing;

namespace RTMapTool
{
	public class City
	{
		public string Name
		{
			get;
			set;
		}

		public long Price
		{
			get;
			set;
		}

		public long Population
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
	}
}
