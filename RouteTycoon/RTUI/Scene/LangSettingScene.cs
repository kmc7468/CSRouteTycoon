using System;
using System.Drawing;
using RouteTycoon.RTCore;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace RouteTycoon.RTUI
{
	internal partial class LangSettingScene : Scene
	{
		private ListBox lstLang = new ListBox();
		private TextButton lbFolder = new TextButton();

		public LangSettingScene()
		{
			try
			{
				InitializeComponent();

				BackgroundImage = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "main_background.png", 5, 7, 1, 6));

				lbTitle.Text = TextManager.Get().Text("lang");
				lbTitle.Font = new Font(RTCore.Environment.Font, 30);
				lbTitle.ForeColor = ResourceManager.Get("setting.lang.title");

				lbAccept.Text = TextManager.Get().Text("accept");
				lbAccept.Font = new Font(RTCore.Environment.Font, 30);
				lbAccept.ForeColor = ResourceManager.Get("setting.lang.accept.unsel");
				lbAccept.SelColor = ResourceManager.Get("setting.lang.accept.sel");

				lstLang.Name = "lstLang";
				lstLang.Font = new Font(RTCore.Environment.Font, 20);
				lstLang.Location = new Point(150, 243);
				lstLang.Size = new Size(300, Height - 300);

				foreach(var lang in System.IO.Directory.GetFiles(".\\data\\langs"))
				{
					if(System.IO.Path.GetExtension(lang) == ".txf")
					{
						TextManager tms = new TextManager();
						tms.Set(System.IO.Path.GetFileName(lang), true);

						lstLang.Items.Add($"{tms.Name}({tms.Region},{tms.Code})");
						tm.Add(tms);
					}
				}

				Controls.Add(lstLang);

				lbFolder.Name = "lbFolder";
				lbFolder.Font = new Font(RTCore.Environment.Font, 18);
				lbFolder.ForeColor = ResourceManager.Get("setting.lang.folder.unsel");
				lbFolder.SelColor = ResourceManager.Get("setting.lang.folder.sel");
				lbFolder.Text = TextManager.Get().Text("folderopen");
				lbFolder.BackColor = Color.Transparent;
				lbFolder.Location = new Point(lstLang.Location.X, lstLang.Location.Y + lstLang.Height + 20);
				lbFolder.AutoSize = true;
				lbFolder.Click += delegate
				{
					Process.Start(".\\data\\langs");
				};
				Controls.Add(lbFolder);
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private List<TextManager> tm = new List<TextManager>();

		private void LangSettingScene_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				e.Graphics.FillRectangle(new SolidBrush(ResourceManager.Get("main.rectangle")), new Rectangle(50, 100, Width - 100, Height - 150));
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void LangSettingScene_Resize(object sender, EventArgs e)
		{
			try
			{
				lbAccept.Location = new Point(Width - 80 - lbAccept.Width, Height - 70 - lbAccept.Height);
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
				if(lstLang.SelectedItems.Count == 1)
				{
					OptionManager.Get().Save("lang", tm[lstLang.SelectedIndex].FileName, AccessManager.AccessKey);
					OptionManager.Get().Load(AccessManager.AccessKey);
					TextManager.Get().Set(OptionManager.Get().LangURL);
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
