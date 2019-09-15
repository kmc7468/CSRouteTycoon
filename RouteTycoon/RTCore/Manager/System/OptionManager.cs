using System;

namespace RouteTycoon.RTCore
{
	public class OptionManager
	{
		public void Load(string password = "")
		{
			try
			{
				if (password != AccessManager.AccessKey)
				{
					if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.OptionManager_Load))
						throw new UnabletoAccessPermission();
				}

				if (!System.IO.File.Exists(".\\data\\system\\option.ini"))
				{
					Utility.SetIniValue("RTOption", "lang", "korean.txf", ".\\data\\system\\option.ini");
					Utility.SetIniValue("RTOption", "res", "default", ".\\data\\system\\option.ini");
					Utility.SetIniValue("RTOption", "sound", "true", ".\\data\\system\\option.ini");
					Utility.SetIniValue("RTOption", "autosave", "true", ".\\data\\system\\option.ini");
					Utility.SetIniValue("RTOption", "autosavesecond", "180", ".\\data\\system\\option.ini");
				}

				LangURL = Utility.GetIniValue("RTOption", "lang", ".\\data\\system\\option.ini");
				ResFolder = Utility.GetIniValue("RTOption", "res", ".\\data\\system\\option.ini");
				Sound = Convert.ToBoolean(Utility.GetIniValue("RTOption", "sound", ".\\data\\system\\option.ini"));
				AutoSave = Convert.ToBoolean(Utility.GetIniValue("RTOption", "autosave", ".\\data\\system\\option.ini"));
				AutoSaveSecond = Convert.ToInt32(Utility.GetIniValue("RTOption", "autosavesecond", ".\\data\\system\\option.ini"));
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		internal string LangURL
		{
			get;
			private set;
		}

		internal string ResFolder
		{
			get;
			private set;
		}

		internal bool Sound
		{
			get;
			private set;
		}

		internal bool AutoSave
		{
			get;
			private set;
		}

		internal int AutoSaveSecond
		{
			get;
			private set;
		}

		public string GetLangURL(string password = "")
		{
			try
			{
				if (password != AccessManager.AccessKey)
				{
					if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.OptionManager_Get))
						throw new UnabletoAccessPermission();
				}

				return LangURL;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
				return "";
			}
		}

		public string GetResFolder(string password = "")
		{
			try
			{
				if (password != AccessManager.AccessKey)
				{
					if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.OptionManager_Get))
						throw new UnabletoAccessPermission();
				}

				return ResFolder;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
				return "";
			}
		}

		public bool GetSound(string password = "")
		{
			try
			{
				if (password != AccessManager.AccessKey)
				{
					if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.OptionManager_Get))
						throw new UnabletoAccessPermission();
				}

				return Sound;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
				return true;
			}
		}

		public bool GetAutoSave(string password = "")
		{
			try
			{
				if (password != AccessManager.AccessKey)
				{
					if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.OptionManager_Get))
						throw new UnabletoAccessPermission();
				}

				return AutoSave;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
				return true;
			}
		}

		public int GetAutoSaveSecond(string password = "")
		{
			try
			{
				if (password != AccessManager.AccessKey)
				{
					if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.OptionManager_Get))
						throw new UnabletoAccessPermission();
				}

				return AutoSaveSecond;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
				return 0;
			}
		}

		public void Save(string key, string value, string password = "")
		{
			try
			{
				if (password != AccessManager.AccessKey)
				{
					if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.OptionManager_Save))
						throw new UnabletoAccessPermission();
				}

				Utility.SetIniValue("RTOption", key, value, ".\\data\\system\\option.ini");
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public void SaveAll(string password = "")
		{
			try
			{
				if (password != AccessManager.AccessKey)
				{
					if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.OptionManager_SaveAll))
						throw new UnabletoAccessPermission();
				}

				Utility.SetIniValue("RTOption", "lang", LangURL, ".\\data\\system\\option.ini");
				Utility.SetIniValue("RTOption", "res", ResFolder, ".\\data\\system\\option.ini");
				Utility.SetIniValue("RTOption", "sound", Sound.ToString().ToLower(), ".\\data\\system\\option.ini");
				Utility.SetIniValue("RTOption", "autosave", AutoSave.ToString().ToLower(), ".\\data\\system\\option.ini");
				Utility.SetIniValue("RTOption", "autosavesecond", AutoSaveSecond.ToString(), ".\\data\\system\\option.ini");
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private static OptionManager _Instance = null;
		public static OptionManager Get()
		{
			try
			{
				if (_Instance == null)
					_Instance = new OptionManager();

				return _Instance;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
				return null;
			}
		}
	}
}
