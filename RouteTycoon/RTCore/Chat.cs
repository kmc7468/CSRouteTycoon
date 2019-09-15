using System;

namespace RouteTycoon.RTCore
{
	public class Chat
	{
		public string Name
		{
			get;
			set;
		}

		public DateTime GameTime
		{
			get;
			set;
		}

		public DateTime LocalTime
		{
			get;
			set;
		}

		public string Message
		{
			get;
			set;
		}

		public string[] ToArray()
		{
			string[] res = new string[11] { Name, Message, GameTime.Year.ToString(), GameTime.Month.ToString(), GameTime.Day.ToString(), LocalTime.Year.ToString(), LocalTime.Month.ToString(), LocalTime.Day.ToString(), LocalTime.Hour.ToString(), LocalTime.Minute.ToString(), LocalTime.Second.ToString() };

			return res;
		}
	}
}
