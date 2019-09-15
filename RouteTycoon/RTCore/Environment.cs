using RouteTycoon.RTUI;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Xml;

namespace RouteTycoon.RTCore
{
	public static class Environment
	{
		private static PrivateFontCollection fonts = new PrivateFontCollection();

		public static string Version
		{
			get;
			private set;
		} = "1.0.0 Beta 2 Preview 1 ServicePack 1";

		internal static int VersionInt
		{
			get;
			set;
		} = 9;

		internal static bool UpdateAccept
		{
			get;
			private set;
		} = false;

		public static bool DebugMode
		{
			get;
			set;
		} = false;

		public static bool DeveloperMode
		{
			get;
			private set;
		} = false;

		public static Color Blue
		{
			get { return Color.FromArgb(51, 153, 255); }
		}

		public static Color DarkBlue
		{
			get { return Color.FromArgb(0, 102, 204); }
		}

		public static FontFamily Font
		{
			get
			{
				return fonts.Families[0];
			}
		}

		public static string CommandLine
		{
			get;
			set;
		} = string.Empty;

		internal enum CommandLineResult
		{
			DEBUG_MODE,
			ERROR_LIST,
			TRAP,
			PICK_ICO,

			NONE
		}

		internal static CommandLineResult CheckEvent()
		{
			switch (CommandLine)
			{
				case "/debugmode": return CommandLineResult.DEBUG_MODE;
				case "/errorlist": return CommandLineResult.ERROR_LIST;
				case "/easteregg trap": return CommandLineResult.TRAP;
				case "/easteregg pickico": return CommandLineResult.PICK_ICO;
				default: return CommandLineResult.NONE;
			}
		}

		public static string Desktop
		{
			get
			{
				return System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
			}
		}

		internal static CommandLineResult InitRouteTycoon(LogoScene ls = null)
		{
			try
			{
				if (ls != null)
				{
					ls.Text = "Please wait...";
					System.Threading.Thread.Sleep(300);
				}
				if (!Directory.Exists(Application.StartupPath + @"\data") && File.Exists(Application.StartupPath + @"\data.zip"))
				{
					Directory.CreateDirectory(Application.StartupPath + @"\data");
					ZipFile.ExtractToDirectory(Application.StartupPath + @"\data.zip", Application.StartupPath + @"\data");
					File.Delete(Application.StartupPath + @"\data.zip");
				}
				else if (Directory.Exists(Application.StartupPath + @"\data") && File.Exists(Application.StartupPath + @"\data.zip"))
				{
					Directory.Delete(Application.StartupPath + @"\data", true);
					Directory.CreateDirectory(Application.StartupPath + @"\data");
					ZipFile.ExtractToDirectory(Application.StartupPath + @"\data.zip", Application.StartupPath + @"\data");
					File.Delete(Application.StartupPath + @"\data.zip");
				}
				else if (!Directory.Exists(Application.StartupPath + @"\\data"))
				{
					if (ls != null) ls.Text = "ERROR!";
					MessageBox.Show("ERROR - 0x000001\nNot exist data folder", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
					LogManager.Add(new Log() { Message = @"ROUTETYCOON BOOT ERROR\nERRCODE: 0x000001\nERRMESSAGE: Not exist data folder", type = Log.Type.ERROR, evt = Log.Event.MESSAGE });
					SceneManager.MainForm.ExitGame();
				}

				if (ls != null)
				{
					ls.Text = "Option Loading...";
					System.Threading.Thread.Sleep(300);
				}

				OptionManager.Get().Load(AccessManager.AccessKey);

				if (ls != null)
				{
					ls.Text = "Font Reading...";
					System.Threading.Thread.Sleep(200);
				}

				if (File.Exists(Application.StartupPath + $"\\data\\res\\{OptionManager.Get().ResFolder}\\font.otf"))
				{
					try
					{
						fonts.AddFontFile(Application.StartupPath + $"\\data\\res\\{OptionManager.Get().ResFolder}\\font.otf");
					}
					catch (FileNotFoundException)
					{
						if (File.Exists(Application.StartupPath + $"\\data\\res\\{OptionManager.Get().ResFolder}\\subfont.otf"))
						{
							fonts.AddFontFile(Application.StartupPath + $"\\data\\res\\{OptionManager.Get().ResFolder}\\subfont.otf");
						}
						else if (File.Exists(Application.StartupPath + $"\\data\\res\\{OptionManager.Get().ResFolder}\\subfont.ttf"))
						{
							fonts.AddFontFile(Application.StartupPath + $"\\data\\res\\{OptionManager.Get().ResFolder}\\subfont.ttf");
						}
						else
						{
							if (ls != null) ls.Text = "ERROR!";
							MessageBox.Show("ERROR - 0x000002\nNot exist font.otf file", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
							LogManager.Add(new Log() { Message = @"ROUTETYCOON BOOT ERROR\nERRCODE: 0x000002\nERRMESSAGE: Not exist font.otf file", type = Log.Type.ERROR, evt = Log.Event.MESSAGE });
							SceneManager.MainForm.ExitGame();
						}
					}
				}
				else if (File.Exists(Application.StartupPath + $"\\data\\res\\{OptionManager.Get().ResFolder}\\font.ttf"))
				{
					try
					{
						fonts.AddFontFile(Application.StartupPath + $"\\data\\res\\{OptionManager.Get().ResFolder}\\font.ttf");
					}
					catch (FileNotFoundException)
					{
						if (File.Exists(Application.StartupPath + $"\\data\\res\\{OptionManager.Get().ResFolder}\\subfont.otf"))
						{
							fonts.AddFontFile(Application.StartupPath + $"\\data\\res\\{OptionManager.Get().ResFolder}\\subfont.otf");
						}
						else if (File.Exists(Application.StartupPath + $"\\data\\res\\{OptionManager.Get().ResFolder}\\subfont.ttf"))
						{
							fonts.AddFontFile(Application.StartupPath + $"\\data\\res\\{OptionManager.Get().ResFolder}\\subfont.ttf");
						}
						else
						{
							if (ls != null) ls.Text = "ERROR!";
							MessageBox.Show("ERROR - 0x000002\nNot exist font.otf file", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
							LogManager.Add(new Log() { Message = @"ROUTETYCOON BOOT ERROR\nERRCODE: 0x000002\nERRMESSAGE: Not exist font.otf file", type = Log.Type.ERROR, evt = Log.Event.MESSAGE });
							SceneManager.MainForm.ExitGame();
						}
					}
				}
				else
				{
					if (File.Exists(Application.StartupPath + $"\\data\\res\\{OptionManager.Get().ResFolder}\\subfont.otf"))
					{
						fonts.AddFontFile(Application.StartupPath + $"\\data\\res\\{OptionManager.Get().ResFolder}\\subfont.otf");
					}
					else if (File.Exists(Application.StartupPath + $"\\data\\res\\{OptionManager.Get().ResFolder}\\subfont.ttf"))
					{
						fonts.AddFontFile(Application.StartupPath + $"\\data\\res\\{OptionManager.Get().ResFolder}\\subfont.ttf");
					}
					else
					{
						if (ls != null) ls.Text = "ERROR!";
						MessageBox.Show("ERROR - 0x000002\nNot exist font.otf file", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
						LogManager.Add(new Log() { Message = @"ROUTETYCOON BOOT ERROR\nERRCODE: 0x000002\nERRMESSAGE: Not exist font.otf file", type = Log.Type.ERROR, evt = Log.Event.MESSAGE });
						SceneManager.MainForm.ExitGame();
					}
				}

				if (ls != null)
				{
					ls.Text = "Initialize Managers...";
					System.Threading.Thread.Sleep(300);
				}
				PluginManager.LoadPlugins();
				ResourceManager.Init();
				NewsManager.Init();
				AccessManager.Init();
				AchievementManager.Init();
				TrainManager.Init();
				Command.Init();
				NetworkManager.Init();
				//SoundManager.Init();

				if (ls != null)
				{
					ls.Text = "Checking Event...";
					System.Threading.Thread.Sleep(400);
				}

				CommandLineResult res = CheckEvent();
				if (res == CommandLineResult.DEBUG_MODE) DebugMode = true;
				else if (res == CommandLineResult.ERROR_LIST) System.Diagnostics.Process.Start("https://docs.google.com/spreadsheets/d/1w513ZXYd-YIZrn9Y9OMI86JGK1Cr3V59YP4wj0kua10/edit?usp=sharing");
				
				if (DeveloperMode)
				{
					DebugMode = true;
					TextManager.Get().Set(OptionManager.Get().LangURL.Replace(".txf", ".xml"));
				}
				else
					TextManager.Get().Set(OptionManager.Get().LangURL);

				if (ls != null) ls.Text = "Check SupportVersion...";
				{ // 지원 버전
					if (!RTAPI.WebAPI.CheckInternetConnection())
					{
						UpdateAccept = false;
						return res;
					}

					string str = new System.Net.WebClient().DownloadString("https://www.dropbox.com/s/j8gy71f0qyarejy/support.txt?dl=1");

					XmlDocument xml = new XmlDocument();
					xml.LoadXml(str);

					XmlNode versions = xml.SelectNodes("versions")[0];

					foreach (XmlNode it in versions.SelectNodes("version"))
					{
						int code = Convert.ToInt32(it.Attributes["code"].Value);
						bool update = Convert.ToBoolean(it.Attributes["update"].Value);

						if (code == VersionInt)
						{
							UpdateAccept = update;
							break;
						}
					}
				}
				return res;
			}
			catch (Exception e)
			{
				ReportError(e, AccessManager.AccessKey);
				return CommandLineResult.NONE;
			}
		}

		public static void ReportError(Exception ex, string password = "")
		{
			if (password != AccessManager.AccessKey)
			{
				if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.Environment_ReportError))
					throw new UnabletoAccessPermission();
			}

			if (RTAPI.WebAPI.CheckInternetConnection())
			{
				System.Collections.Specialized.NameValueCollection data = new System.Collections.Specialized.NameValueCollection();
				data.Add("entry.1674123617", ex.ToString());
				data.Add("entry.713681991", Version);
				data.Add("entry.521569291", "false");
				System.Net.WebClient wc = new System.Net.WebClient();
				wc.UploadValuesAsync(new Uri("https://docs.google.com/forms/d/1K2hLlZmlCjur28khh8HYSCjPpl4kLz6nifWEVXKE1sE/formResponse"), "POST", data, Guid.NewGuid().ToString());
			}
			LogManager.ExceptMessage(ex);
			frmError err = new frmError(ex.ToString());
			err.ShowDialog();
		}

		internal static int CalcPage(int AllItemCount, int PageItemCount)
		{
			if (AllItemCount == 0)
			{
				return 1;
			}
			else
			{
				if (PageItemCount <= 0) throw new ArgumentException("PageItemCount 는 0 보다 커야 합니다.");

				int ret = 0;

				ret = (int)Math.Ceiling(Convert.ToDouble(AllItemCount) / Convert.ToDouble(PageItemCount));

				return ret;
			}
		}

		internal static RectangleF CalcRectangle(Point p, Size size)
		{
			return new RectangleF(new PointF((p.X - (size.Width / 2)), (p.Y - (size.Height / 2))), size);
		}

		internal static Size CalcStringSize(string text, Font font)
		{
			Label lb = new Label();
			lb.AutoSize = true;
			lb.Text = text;
			lb.Font = font;

			return lb.PreferredSize;
		}
	}
}
