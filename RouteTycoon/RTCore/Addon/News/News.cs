using System;
using System.Drawing;

namespace RouteTycoon.RTCore
{
	public class News
	{
		private Plugin.INews _plug = null;
		private bool isLoad = false;

		internal Plugin.INews Plugin
		{
			get
			{
				return _plug;
			}
		}

		public string Message
		{
			get
			{
				return Plugin.Message;
			}
		}

		public Image Image
		{
			get
			{
				if (Plugin.Image == null) return RTAPI.ResourceAPI.NoImage;
				else return Plugin.Image;
			}
		}

		public News()
		{

		}

		public News(Plugin.INews plug)
		{
			_plug = plug;
			isLoad = true;
		}

		public void Load(string name)
		{
			try
			{
				if (isLoad) throw new NewsLoadedException();
				_plug = PluginManager.CreateObject<Plugin.INews>(name, "News");
				isLoad = true;
			}catch(Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
