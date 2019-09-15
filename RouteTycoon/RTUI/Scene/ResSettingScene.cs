using System;
using System.Drawing;
using RouteTycoon.RTCore;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace RouteTycoon.RTUI
{
	internal partial class ResSettingScene : Scene
	{
		private ListBox lstRes = new ListBox();
		private Label lbInfo = new Label();
		private TextButton lbFolder = new TextButton();

		public ResSettingScene()
		{
			try
			{
				InitializeComponent();

				BackgroundImage = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "main_background.png", 5, 7, 1, 6));

				lbTitle.Text = TextManager.Get().Text("resource");
				lbTitle.Font = new Font(RTCore.Environment.Font, 30);
				lbTitle.ForeColor = ResourceManager.Get("setting.res.title");

				lbAccept.Text = TextManager.Get().Text("accept");
				lbAccept.Font = new Font(RTCore.Environment.Font, 30);
				lbAccept.ForeColor = ResourceManager.Get("setting.res.accept.unsel");
				lbAccept.SelColor = ResourceManager.Get("setting.res.accept.sel");

				lstRes.Name = "lstRes";
				lstRes.Font = new Font(RTCore.Environment.Font, 20);
				lstRes.Location = new Point(150, 243);
				lstRes.Size = new Size(300, Height - 300);
				lstRes.SelectedIndexChanged += delegate
				{
					string template = TextManager.Get().Text("resinfo");
					string[] info = System.IO.File.ReadAllLines($".\\data\\res\\{fn[lstRes.SelectedIndex]}\\data_res.dat", System.Text.Encoding.Default);

					template = template.Replace("%VER%", info[0]);
					template = template.Replace("%DEV%", info[1]);
					template = template.Replace("%INFO%", info[2]);
					template = template.Replace(@"\n", "\n");

					lbInfo.Text = template;
				};

				lbInfo.Name = "lbInfo";
				lbInfo.Font = new Font(RTCore.Environment.Font, 18);
				lbInfo.ForeColor = ResourceManager.Get("setting.res.info");
				lbInfo.Location = new Point(lstRes.Location.X + lstRes.Width + 20, lstRes.Location.Y);
				lbInfo.Text = "";
				lbInfo.AutoSize = true;
				lbInfo.BackColor = Color.Transparent;
				Controls.Add(lbInfo);

				lbFolder.Name = "lbFolder";
				lbFolder.Font = new Font(RTCore.Environment.Font, 18);
				lbFolder.ForeColor = ResourceManager.Get("setting.res.folder.unsel");
				lbFolder.SelColor = ResourceManager.Get("setting.res.folder.sel");
				lbFolder.Text = TextManager.Get().Text("folderopen");
				lbFolder.BackColor = Color.Transparent;
				lbFolder.Location = new Point(lstRes.Location.X, lstRes.Location.Y + lstRes.Height + 20);
				lbFolder.AutoSize = true;
				lbFolder.Click += delegate
				{
					Process.Start(".\\data\\res");
				};
				Controls.Add(lbFolder);

				foreach (var res in System.IO.Directory.GetDirectories(".\\data\\res"))
				{
					lstRes.Items.Add($"{res.Replace(".\\data\\res\\", "")}");
					fn.Add(res.Replace(".\\data\\res\\", ""));
				}

				Controls.Add(lstRes);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private List<string> fn = new List<string>();

		private void LangSettingScene_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				e.Graphics.FillRectangle(new SolidBrush(ResourceManager.Get("main.rectangle")), new Rectangle(50, 100, Width - 100, Height - 150));
				lbInfo.Location = new Point(lstRes.Location.X + lstRes.Width + 20, lstRes.Location.Y);
				lbFolder.Location = new Point(lstRes.Location.X, lstRes.Location.Y + lstRes.Height + 20);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void LangSettingScene_Resize(object sender, EventArgs e)
		{
			try
			{
				lbAccept.Location = new Point(Width - 80 - lbAccept.Width, Height - 70 - lbAccept.Height);
				lbInfo.Location = new Point(lstRes.Location.X + lstRes.Width + 20, lstRes.Location.Y);
				lbFolder.Location = new Point(lstRes.Location.X, lstRes.Location.Y + lstRes.Height + 20);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbAccept_Click(object sender, EventArgs e)
		{
			try
			{
				if (lstRes.SelectedItems.Count == 1)
				{
					OptionManager.Get().Save("res", fn[lstRes.SelectedIndex], AccessManager.AccessKey);
					OptionManager.Get().Load(AccessManager.AccessKey);
				}

				SettingScene ss = new SettingScene();

				SceneManager.SetScene(ss, AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
