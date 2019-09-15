using System;

namespace RouteTycoon.RTCore
{
	public class Log
	{
		public enum Type
		{
			INFORMATION,
			WARNING,
			ERROR
		}

		public enum Event
		{
			MOUSE_CLICK,
			SCENE_LOAD,
			PAGE_LOAD,
			KEY_PRESS,
			THROW,
			WEBBROWSER,
			CLICK,
			USE_CHEAT,
			USE_COMMAND,
			MESSAGE
		}

		public Type type
		{
			get;
			set;
		}

		public Event evt
		{
			get;
			set;
		}

		public Exception exp
		{
			get;
			set;
		}

		public System.Windows.Forms.Control ctrl
		{
			get;
			set;
		}

		public System.Windows.Forms.MouseEventArgs MouseEventArgs
		{
			get;
			set;
		}

		public string Message
		{
			get;
			set;
		}
	}
}
