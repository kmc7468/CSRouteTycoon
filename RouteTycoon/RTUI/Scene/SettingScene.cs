using System;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class SettingScene : Scene
	{
		public SettingScene()
		{
			try
			{
				InitializeComponent();

				BackgroundImage = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "main_background.png", 5, 7, 1, 6));

				lbTitle.Text = TextManager.Get().Text("setting");
				lbTitle.Font = new Font(RTCore.Environment.Font, 30);
				lbTitle.ForeColor = ResourceManager.Get("setting.main.title");

				lbBack.Text = TextManager.Get().Text("back");
				lbBack.Font = new Font(RTCore.Environment.Font, 30);
				lbBack.ForeColor = ResourceManager.Get("setting.main.back.unsel");
				lbBack.SelColor = ResourceManager.Get("setting.main.back.sel");

				lbLang.Text = TextManager.Get().Text("lang");
				lbLang.Font = new Font(RTCore.Environment.Font, 30);
				lbLang.ForeColor = ResourceManager.Get("setting.main.lang.unsel");
				lbLang.SelColor = ResourceManager.Get("setting.main.lang.sel");

				lbRes.Text = TextManager.Get().Text("resource");
				lbRes.Font = new Font(RTCore.Environment.Font, 30);
				lbRes.ForeColor = ResourceManager.Get("setting.main.res.unsel");
				lbRes.SelColor = ResourceManager.Get("setting.main.res.sel");

				lbSound.Text = TextManager.Get().Text("sound");
				lbSound.Font = new Font(RTCore.Environment.Font, 30);
				lbSound.ForeColor = ResourceManager.Get("setting.main.sound.unsel");
				lbSound.SelColor = ResourceManager.Get("setting.main.sound.sel");

				lbUpdate.Text = TextManager.Get().Text("update");
				lbUpdate.Font = new Font(RTCore.Environment.Font, 30);
				lbUpdate.ForeColor = ResourceManager.Get("setting.main.update.unsel");
				lbUpdate.SelColor = ResourceManager.Get("setting.main.update.sel");

				lbGame.Text = TextManager.Get().Text("game");
				lbGame.Font = new Font(RTCore.Environment.Font, 30);
				lbGame.ForeColor = ResourceManager.Get("setting.main.game.unsel");
				lbGame.SelColor = ResourceManager.Get("setting.main.game.sel");
			}
			catch (Exception e)
			{
				RTCore.Environment.ReportError(e, AccessManager.AccessKey);
			}
		}

		private void SettingScene_Paint(object sender, PaintEventArgs e)
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

		private void SettingScene_Resize(object sender, EventArgs e)
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

		private void lbBack_Click(object sender, EventArgs e)
		{
			try
			{
				MainMenuScene mms = new MainMenuScene();

				SceneManager.SetScene(mms, AccessManager.AccessKey);
			}
			catch (Exception EX)
			{
				RTCore.Environment.ReportError(EX, AccessManager.AccessKey);
			}
		}

		private void lbLang_Click(object sender, EventArgs e)
		{
			try
			{
				LangSettingScene lss = new LangSettingScene();

				SceneManager.SetScene(lss, AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbRes_Click(object sender, EventArgs e)
		{
			try
			{
				ResSettingScene rss = new ResSettingScene();

				SceneManager.SetScene(rss, AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbSound_Click(object sender, EventArgs e)
		{
			try
			{
				SoundSettingScene sss = new SoundSettingScene();

				SceneManager.SetScene(sss, AccessManager.AccessKey);
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
				if (!RTAPI.WebAPI.CheckInternetConnection())
				{
					MessageBox.Show(TextManager.Get().Text("networknotconnection"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				if (!RTCore.Environment.UpdateAccept)
				{
					MessageBox.Show(TextManager.Get().Text("notsupportupdate"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				UpdateSettingScene uss = new UpdateSettingScene();

				SceneManager.SetScene(uss, AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbGame_Click(object sender, EventArgs e)
		{
			try
			{
				GameSettingScene gss = new GameSettingScene();

				SceneManager.SetScene(gss, AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
