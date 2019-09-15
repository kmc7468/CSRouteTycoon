using RouteTycoon.RTCore;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RouteTycoon.RTUI
{
	internal partial class MainMenuScene : Scene
	{
		private Image imgLogo;
		private Image imgAtus;

		public MainMenuScene()
		{
			try
			{
				InitializeComponent();

				imgLogo = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "rt_logo.png", 5, 7, 1, 6));
				imgAtus = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "atus_white.png", 5, 7, 1, 6));

				BackgroundImage = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "main_background.png", 5, 7, 1, 6));

				lbGameStart.Text = TextManager.Get().Text("gamestart");
				lbGameStart.Font = new Font(RTCore.Environment.Font, 30);
				lbGameStart.ForeColor = ResourceManager.Get("main.menu.gamestart.unsel");
				lbGameStart.SelColor = ResourceManager.Get("main.menu.gamestart.sel");

				lbSetting.Text = TextManager.Get().Text("setting");
				lbSetting.Font = new Font(RTCore.Environment.Font, 30);
				lbSetting.ForeColor = ResourceManager.Get("main.menu.setting.unsel");
				lbSetting.SelColor = ResourceManager.Get("main.menu.setting.sel");

				lbDeveloper.Text = TextManager.Get().Text("developer");
				lbDeveloper.Font = new Font(RTCore.Environment.Font, 30);
				lbDeveloper.ForeColor = ResourceManager.Get("main.menu.developer.unsel");
				lbDeveloper.SelColor = ResourceManager.Get("main.menu.developer.sel");

				lbExit.Text = TextManager.Get().Text("exit");
				lbExit.Font = new Font(RTCore.Environment.Font, 30);
				lbExit.ForeColor = ResourceManager.Get("main.menu.exit.unsel");
				lbExit.SelColor = ResourceManager.Get("main.menu.exit.sel");

				picAtus.Image = imgAtus;
				picAtus.BackColor = Color.Transparent;
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void MainMenuScene_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				e.Graphics.FillRectangle(new SolidBrush(ResourceManager.Get("main.sidebar")), new Rectangle(0, 0, 300, Height));
				e.Graphics.DrawImage(imgLogo, new Rectangle(25, 80, 250, 60));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public override void OnClosed()
		{
			try
			{
				imgLogo.Dispose();
				imgAtus.Dispose();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbGameStart_Click(object sender, EventArgs e)
		{
			try
			{
				GameStartScene gss = new GameStartScene();

				SceneManager.SetScene(gss, AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbExit_Click(object sender, EventArgs e)
		{
			try
			{
				Application.Exit();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbDeveloper_Click(object sender, EventArgs e)
		{
			try
			{
				SceneManager.SetScene(new DeveloperScene(), AccessManager.AccessKey);
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbSetting_Click(object sender, EventArgs e)
		{
			try
			{
				SettingScene ss = new SettingScene();

				SceneManager.SetScene(ss, AccessManager.AccessKey);
			}catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
