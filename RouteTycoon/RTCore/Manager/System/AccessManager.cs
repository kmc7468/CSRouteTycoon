using System;
using System.Xml;

namespace RouteTycoon.RTCore
{
	public static class AccessManager
	{
		public static void Init()
		{
			try
			{
				// permission.xml
				XmlDocument xml = new XmlDocument();
				xml.Load(".\\data\\system\\permission.xml");

				XmlNode root = xml.SelectNodes("permissions")[0];

				XmlNode plug = root.SelectNodes("plugin")[0];

				foreach (XmlNode it in plug.SelectNodes("permission"))
				{
					string type = it.Attributes["type"].Value;
					string data = it.Attributes["data"].Value;
					bool value = Convert.ToBoolean(it.Attributes["value"].Value);

					if (type == "access" && data == "SceneManager.SetScene") permission_plug_scenemanager_setscene = value;
					else if (type == "access" && data == "SceneManager.GetScene") permission_plug_scenemanager_getscene = value;
					else if (type == "access" && data == "OptionManager.Get") permission_plug_optionmanager_get = value;
					else if (type == "access" && data == "OptionManager.Save") permission_plug_optionmanager_save = value;
					else if (type == "access" && data == "OptionManager.SaveAll") permission_plug_optionmanager_saveall = value;
					else if (type == "access" && data == "OptionManager.Load") permission_plug_optionmanager_load = value;
					else if (type == "use" && data == "Environment.ReportError") permission_plug_environ_reporterr = value;
					else if (type == "access" && data == "PageManager.SetPage") permission_plug_pagemanager_setpage = value;
					else if (type == "access" && data == "PageManager.GetPage") permission_plug_pagemanager_getpage = value;
					else if (type == "access" && data == "Command.Append.Cheat") permission_plug_command_append_cheat = value;
					else if (type == "access" && data == "Command.Append.Command") permission_plug_command_append_command = value;
					else if (type == "access" && data == "Command.List.Cheat") permission_plug_command_list_cheat = value;
					else if (type == "access" && data == "Command.List.Command") permission_plug_command_list_command = value;
					else if (type == "access" && data == "Command.Remove.Cheat") permission_plug_command_remove_cheat = value;
					else if (type == "access" && data == "Command.Remove.Command") permission_plug_command_remove_command = value;
					else if (type == "access" && data == "PageManager.Close") permission_plug_pagemanager_close = value;
				}
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessKey);
			}
		}

		private static bool permission_plug_scenemanager_setscene = false;
		private static bool permission_plug_scenemanager_getscene = false;
		private static bool permission_plug_optionmanager_get = true;
		private static bool permission_plug_optionmanager_save = false;
		private static bool permission_plug_optionmanager_saveall = false;
		private static bool permission_plug_optionmanager_load = false;
		private static bool permission_plug_environ_reporterr = false;
		private static bool permission_plug_pagemanager_setpage = false;
		private static bool permission_plug_pagemanager_getpage = false;
		private static bool permission_plug_command_append_cheat = true;
		private static bool permission_plug_command_append_command = true;
		private static bool permission_plug_command_list_cheat = false;
		private static bool permission_plug_command_list_command = false;
		private static bool permission_plug_command_remove_cheat = false;
		private static bool permission_plug_command_remove_command = false;
		private static bool permission_plug_pagemanager_close = false;

		public enum PluginPermission
		{
			SceneManager_SetScene,
			SceneManager_GetScene,
			OptionManager_Get,
			OptionManager_Save,
			OptionManager_SaveAll,
			OptionManager_Load,
			Environment_ReportError,
			PageManager_SetPage,
			PageManager_GetPage,
			PageManager_Close,
			Command_Append_Cheat,
			Command_Append_Command,
			Command_List_Cheat,
			Command_List_Command,
			Command_Remove_Cheat,
			Command_Remove_Command
		}

		public static bool GetPluginPermission(PluginPermission per)
		{
			switch(per)
			{
				case PluginPermission.SceneManager_SetScene: return permission_plug_scenemanager_setscene;
				case PluginPermission.SceneManager_GetScene: return permission_plug_scenemanager_getscene;
				case PluginPermission.OptionManager_Get: return permission_plug_optionmanager_get;
				case PluginPermission.OptionManager_Save: return permission_plug_optionmanager_save;
				case PluginPermission.OptionManager_SaveAll: return permission_plug_optionmanager_saveall;
				case PluginPermission.OptionManager_Load: return permission_plug_optionmanager_load;
				case PluginPermission.Environment_ReportError: return permission_plug_environ_reporterr;
				case PluginPermission.PageManager_SetPage: return permission_plug_pagemanager_setpage;
				case PluginPermission.PageManager_GetPage: return permission_plug_pagemanager_getpage;
				case PluginPermission.PageManager_Close: return permission_plug_pagemanager_close;
				case PluginPermission.Command_Append_Cheat: return permission_plug_command_append_cheat;
				case PluginPermission.Command_Append_Command: return permission_plug_command_append_command;
				case PluginPermission.Command_List_Cheat: return permission_plug_command_list_cheat;
				case PluginPermission.Command_List_Command: return permission_plug_command_list_command;
				case PluginPermission.Command_Remove_Cheat: return permission_plug_command_remove_cheat;
				case PluginPermission.Command_Remove_Command: return permission_plug_command_remove_command;
				default:
					throw new Exception("없는 펄미션 입니다.");
			}
		}

		internal static string AccessKey
		{
			get
			{
				return "SteveSmartRouteTycoonHoneyJamBasixUgly";
			}
		}

		internal static string RTRMPassword
		{
			get
			{
				return "RTRMPASSWORD-RTHONEYJAM";
            }
		}
	}
}
