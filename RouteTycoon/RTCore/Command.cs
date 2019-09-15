using RouteTycoon.RTUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RouteTycoon.RTCore
{
	public static class Command
	{
		private static string _now = string.Empty;

		public delegate void CommandVoid();
		private static Dictionary<string, CommandVoid> Cheats = new Dictionary<string, CommandVoid>();
		private static Dictionary<string, CommandVoid> Commands = new Dictionary<string, CommandVoid>();

		internal static MainPlayScene main = null;

		internal static void Init()
		{
			Cheats.Clear();
			Commands.Clear();

			Cheats.Add("addmoney", addmoney);
			Cheats.Add("addday", addday);
			Cheats.Add("addmonth", addmonth);
			Cheats.Add("addyear", addyear);
			Cheats.Add("zeromoney", zeromoney);
			Cheats.Add("addincome", addincome);
			Cheats.Add("zeroincome", zeroincome);
			Cheats.Add("clearloan", clearloan);
			Cheats.Add("veryfast", veryfast);
			Cheats.Add("fast", fast);
			Cheats.Add("slow", slow);

			Commands.Add("something for nothing", oddevenminigame);
			Commands.Add("save", save);
		}

		public static void AppendCheat(string Key, CommandVoid func, string password = "")
		{
			try
			{
				if (password != AccessManager.AccessKey)
				{
					if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.Command_Append_Cheat))
						throw new UnabletoAccessPermission();
				}

				if (Cheats.Keys.ToList().Contains(Key))
					throw new UseCheatKeyException();

				Cheats.Add(Key, func);
			}
			catch(Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public static void AppendCommand(string Key, CommandVoid func, string password = "")
		{
			try
			{
				if (password != AccessManager.AccessKey)
				{
					if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.Command_Append_Command))
						throw new UnabletoAccessPermission();
				}

				if (Cheats.Keys.ToList().Contains(Key))
					throw new UseCommandKeyException();

				Cheats.Add(Key, func);
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public static void RemoveCheat(string Key, string password = "")
		{
			try
			{
				if (password != AccessManager.AccessKey)
				{
					if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.Command_Remove_Cheat))
						throw new UnabletoAccessPermission();
				}

				if (!Cheats.Keys.ToList().Contains(Key))
					throw new NotExistCheatKeyException();

				Cheats.Remove(Key);
			}
			catch(Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public static void RemoveCommand(string Key, string password = "")
		{
			try
			{
				if (password != AccessManager.AccessKey)
				{
					if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.Command_Remove_Command))
						throw new UnabletoAccessPermission();
				}

				if (!Commands.Keys.ToList().Contains(Key))
					throw new NotExistCommandKeyException();

				Commands.Remove(Key);
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public static Dictionary<string, CommandVoid> CheatList(string password = "")
		{
			try
			{
				if (password != AccessManager.AccessKey)
				{
					if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.Command_List_Cheat))
						throw new UnabletoAccessPermission();
				}

				Dictionary<string, CommandVoid> res = new Dictionary<string, CommandVoid>();

				foreach(var it in Cheats)
				{
					res.Add(it.Key, it.Value);
				}

				return res;
			}
			catch(Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);

				return null;
			}
		}

		public static Dictionary<string, CommandVoid> CommandList(string password = "")
		{
			try
			{
				if (password != AccessManager.AccessKey)
				{
					if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.Command_List_Command))
						throw new UnabletoAccessPermission();
				}

				Dictionary<string, CommandVoid> res = new Dictionary<string, CommandVoid>();

				foreach (var it in Commands)
				{
					res.Add(it.Key, it.Value);
				}

				return res;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);

				return null;
			}
		}

		internal static void AddChar(char c)
		{
			_now += c.ToString().ToLower();

			Process();
		}

		internal static void SetCommand(string s)
		{
			_now = s;

			Process();
		}

		private static void Process()
		{
			{ // 치트 확인
				KeyValuePair<string, CommandVoid> pair = Cheats.FirstOrDefault(x => _now.IndexOf(x.Key) != -1);

				if (!pair.Equals(default(KeyValuePair<string, CommandVoid>)))
				{
					if (GameManager.UseCheat == false)
					{
						if (MessageBox.Show(TextManager.Get().Text("realcheat"), "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
						{
							_now = string.Empty;
							return;
						}
					}

					GameManager.UseCheat = true;

					pair.Value();
					_now = string.Empty;

					return;
				}
			}

			{ // 커맨드 확인
				KeyValuePair<string, CommandVoid> pair = Commands.FirstOrDefault(x => _now.IndexOf(x.Key) != -1);

				if (!pair.Equals(default(KeyValuePair<string, CommandVoid>)))
				{
					pair.Value();
					_now = string.Empty;

					return;
				}
			}
		}

		#region Cheats
		// addmoney - 예산을 2억 추가 합니다.
		private static void addmoney()
		{
			LogManager._use_Cheat("addmoney");
			GameManager.Company.Money += 200000000;
		}

		// addday - 1일 시간을 워프 합니다.
		private static void addday()
		{
			LogManager._use_Cheat("addday");
			main.AddDate(MainPlayScene.DateType.Day);
		}

		// addmonth - 1일 시간을 워프 합니다.
		private static void addmonth()
		{
			LogManager._use_Cheat("addmonth");
			main.AddDate(MainPlayScene.DateType.Month);
		}

		// addyear - 1일 시간을 워프 합니다.
		private static void addyear()
		{
			LogManager._use_Cheat("addyear");
			main.AddDate(MainPlayScene.DateType.Year);
		}

		// zeromoney - 돈을 0 으로 만듭니다.
		private static void zeromoney()
		{
			LogManager._use_Cheat("zeromoney");
			GameManager.Company.Money = 0;
		}

		// addincome - 수익을 5천만 추가 합니다.
		private static void addincome()
		{
			LogManager._use_Cheat("addincome");
			GameManager.Company.IncomeAdd += 50000000;
		}

		// zeroincome - 수익을 0 으로 설정 합니다.
		private static void zeroincome()
		{
			LogManager._use_Cheat("zeromoney");
			if (GameManager.Company.Income < 0) // 0 보다 작음
			{
				GameManager.Company.IncomeAdd += Math.Abs(GameManager.Company.Income);
			}
			else if (GameManager.Company.Income > 0) // 0 보다 큼
			{
				GameManager.Company.IncomeAdd -= GameManager.Company.Income;
			}
		}

		// clearloan - 빚을 없앱니다.
		private static void clearloan()
		{
			LogManager._use_Cheat("clearloan");
			GameManager.Company.Loan = 0;
		}

		// veryfast - 하루를 1초로 합니다.
		private static void veryfast()
		{
			LogManager._use_Cheat("veryfast");
			main.tmDate.Interval = 1000;
		}

		// fast - 하루를 2초로 합니다.
		private static void fast()
		{
			LogManager._use_Cheat("fast");
			main.tmDate.Interval = 2000;
		}

		// slow - 하루를 5초 (기본)으로 합니다.
		private static void slow()
		{
			LogManager._use_Cheat("slow");
			main.tmDate.Interval = 5000;
		}
		#endregion

		#region Commands
		// something for nothing - 홀짝 미니게임을 엽니다.
		private static void oddevenminigame()
		{
			LogManager._use_Command("something for nothing");
			OddEvenPage page = new OddEvenPage();
			PageManager.SetPage(page, AccessManager.AccessKey);
		}

		// save - 저장 합니다.
		private static void save()
		{
			LogManager._use_Command("save");
			GameManager.Save(GameManager.Filename);
			MessageBox.Show(TextManager.Get().Text("savedone"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		#endregion
	}
}
