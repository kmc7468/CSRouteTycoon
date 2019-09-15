using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RouteTycoon.RTCore
{
	internal static class NetworkManager
	{
		public static void Init()
		{
			Assembly a = Assembly.LoadFile(Application.StartupPath + "\\data\\system\\networkmodule.dll");

			
		}
	}
}
