using System;

namespace RouteTycoon.RTCore
{
	public class Achievement
	{
		private Plugin.IAchievement _plug = null;
		private bool isLoad = false;

		internal Plugin.IAchievement Plugin
		{
			get
			{
				return _plug;
			}
		}

		public string Name
		{
			get
			{
				return Plugin.Name;
			}
		}

		public string Description
		{
			get
			{
				return Plugin.Description;
			}
		}

		public bool Clear
		{
			get;
			set;
		}

		public Achievement()
		{

		}

		public Achievement(Plugin.IAchievement plug)
		{
			try
			{
				_plug = plug;
				isLoad = true;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public void Load(string name)
		{
			try
			{
				if (isLoad) throw new AchievementLoadedException();
				_plug = PluginManager.CreateObject<Plugin.IAchievement>(name, "Achievement");
				isLoad = true;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
