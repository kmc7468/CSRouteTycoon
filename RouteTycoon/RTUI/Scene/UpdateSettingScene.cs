using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;
using System.Text.RegularExpressions;

namespace RouteTycoon.RTUI
{
	internal struct VersionInfoParmas
	{
		public string NowVersion { get { return RTCore.Environment.Version; } }
		public int NowVersionInt { get { return RTCore.Environment.VersionInt; } }
		public string NewVersion { get; set; }
		public int NewVersionInt { get; set; }
		public bool InstallData { get; set; }
	}

	internal partial class UpdateSettingScene : Scene
	{
		private VersionInfoParmas verinfo = new VersionInfoParmas();
		private ToolTip tt = new ToolTip();

		public UpdateSettingScene()
		{
			try
			{
				InitializeComponent();

				BackgroundImage = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "main_background.png", 5, 7, 1, 6));

				string tmp1 = new System.Net.WebClient().DownloadString("https://www.dropbox.com/s/bfm8npk7k25wxfl/ver.txt?dl=1");
				string[] tmp2 = Regex.Split(tmp1, "\r\n");

				verinfo.NewVersion = tmp2[0];
				verinfo.NewVersionInt = Convert.ToInt32(tmp2[1]);
				verinfo.InstallData = Convert.ToBoolean(tmp2[2]);

				lbTitle.Text = TextManager.Get().Text("update");
				lbTitle.Font = new Font(RTCore.Environment.Font, 30);
				lbTitle.ForeColor = ResourceManager.Get("setting.update.title");

				lbBack.Text = TextManager.Get().Text("back");
				lbBack.Font = new Font(RTCore.Environment.Font, 30);
				lbBack.ForeColor = ResourceManager.Get("setting.update.back.unsel");
				lbBack.SelColor = ResourceManager.Get("setting.update.back.sel");
				lbBack.Click += delegate
				{
					SettingScene ss = new SettingScene();

					SceneManager.SetScene(ss, AccessManager.AccessKey);
				};

				lbInfo.Font = new Font(RTCore.Environment.Font, 20);
				lbInfo.ForeColor = ResourceManager.Get("setting.update.info");

				Dictionary<string, string> d = new Dictionary<string, string>();
				d.Add("%NOWVER%", verinfo.NowVersion);
				d.Add("%NEWVER%", verinfo.NewVersion);

				lbInfo.Text = TextManager.Get().Text("updateinfo", true, d);
				tt.SetToolTip(lbInfo, lbInfo.Text);

				lbUpdate.Font = new Font(RTCore.Environment.Font, 20);
				lbUpdate.Text = TextManager.Get().Text("update");
				lbUpdate.ForeColor = ResourceManager.Get("setting.update.goupdate.unsel");
				lbUpdate.SelColor = ResourceManager.Get("setting.update.goupdate.sel");
				lbUpdate.Location = new Point(lbInfo.Location.X, lbInfo.Location.Y + lbInfo.Height + 15);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void UpdateSettingScene_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				e.Graphics.FillRectangle(new SolidBrush(ResourceManager.Get("main.rectangle")), new Rectangle(50, 100, Width - 100, Height - 150));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void UpdateSettingScene_Resize(object sender, EventArgs e)
		{
			try
			{
				lbBack.Location = new Point(Width - 80 - lbBack.Width, Height - 70 - lbBack.Height);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbUpdate_Click(object sender, EventArgs e)
		{
			try
			{
				if (verinfo.NowVersionInt == verinfo.NewVersionInt)
				{
					MessageBox.Show(TextManager.Get().Text("nownewver"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
				else if (verinfo.NowVersionInt > verinfo.NewVersionInt)
				{
					if (MessageBox.Show(TextManager.Get().Text("nownewnewver"), "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						GoUpdate();
					}
				}
				else
				{
					if (MessageBox.Show(TextManager.Get().Text("realupdate"), "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						GoUpdate();
					}
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void GoUpdate()
		{
			try
			{
				SceneManager.SetScene(new UpdateingScene(verinfo), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
