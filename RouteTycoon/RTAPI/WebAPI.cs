using System.Net;

namespace RouteTycoon.RTAPI
{
	/// <summary>
	/// 인터넷과 관련된 기능을 제공합니다.
	/// </summary>
	public static class WebAPI
	{
		/// <summary>
		/// 인터넷에 연결되어 있고 인터넷이 정상 작동하는지 확인합니다.
		/// </summary>
		/// <returns></returns>
		public static bool CheckInternetConnection()
		{
			try
			{
				using (var c = new WebClient())
				using (var s = c.OpenRead("http://www.google.com"))
				{
					return true;
				}
			}
			catch
			{
				return false;
			}
		}
	}
}
