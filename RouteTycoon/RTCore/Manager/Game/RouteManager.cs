using System;
using System.Collections.Generic;

namespace RouteTycoon.RTCore
{
	public class RouteManager
	{
		private List<Route> _routes = new List<Route>();

		public List<Route> Routes
		{
			get
			{
				return _routes;
			}
		}

		public List<Route> GetRoutes(Company company)
		{
			try
			{
				List<Route> temp = new List<Route>();

				foreach (Route r in _routes)
					if (r.Owner == company)
						temp.Add(r);

				return temp;
			}
			catch(Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
				return null;
			}
		}
	}
}
