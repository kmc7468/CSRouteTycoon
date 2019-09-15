using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace RouteTycoon.RTCore
{
	internal static class Utility
	{
		[DllImport("kernel32.dll")]
		private static extern int GetPrivateProfileString(
			String setion,
			String key,
			String def,
			StringBuilder retVal,
			int size,
			String filepath);

		[DllImport("kernel32.dll")]
		private static extern long WritePrivateProfileString(
			String section,
			String key,
			String val,
			String filePath);

		public static string GetIniValue(string section, string key, string filepath)
		{
			try
			{
				StringBuilder temp = new StringBuilder(255);
				GetPrivateProfileString(section, key, "", temp, 255, filepath);

				return temp.ToString();
			}
			catch(Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
				return null;
			}
		}

		public static void SetIniValue(string section, string key, string value, string filepath)
		{
			try
			{
				WritePrivateProfileString(section, key, value, filepath);
			}
			catch(Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
			}
		}
	}
}
