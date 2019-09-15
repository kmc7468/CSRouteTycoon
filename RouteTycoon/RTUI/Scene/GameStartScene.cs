using RouteTycoon.RTCore;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RouteTycoon.RTUI
{
	internal partial class GameStartScene : Scene
	{
		private Image imgAtus;

		public GameStartScene()
		{
			try
			{
				InitializeComponent();

				imgAtus = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "atus_white.png", 5, 7, 1, 6));
				picAtus.Image = imgAtus;

				lbNewGame.Text = TextManager.Get().Text("newgame");
				lbNewGame.Font = new Font(RTCore.Environment.Font, 30);
				lbNewGame.ForeColor = ResourceManager.Get("gamestart.newgame.unsel");
				lbNewGame.SelColor = ResourceManager.Get("gamestart.newgame.sel");

				lbGameLoad.Text = TextManager.Get().Text("gameload");
				lbGameLoad.Font = new Font(RTCore.Environment.Font, 30);
				lbGameLoad.ForeColor = ResourceManager.Get("gamestart.gameload.unsel");
				lbGameLoad.SelColor = ResourceManager.Get("gamestart.gameload.sel");

				lbMutiPlay.Text = TextManager.Get().Text("multimode");
				lbMutiPlay.Font = new Font(RTCore.Environment.Font, 30);
				lbMutiPlay.ForeColor = ResourceManager.Get("gamestart.multi.unsel");
				lbMutiPlay.SelColor = ResourceManager.Get("gamestart.multi.sel");

				lbBack.Text = TextManager.Get().Text("back");
				lbBack.Font = new Font(RTCore.Environment.Font, 30);
				lbBack.ForeColor = ResourceManager.Get("gamestart.back.unsel");
				lbBack.SelColor = ResourceManager.Get("gamestart.back.sel");

				lbTitle.Font = new Font(RTCore.Environment.Font, 40);
				lbTitle.HaloTextStr = TextManager.Get().Text("gamestart");
				lbTitle.ForeColor = ResourceManager.Get("gamestart.title");

				BackgroundImage = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "main_background.png", 5, 7, 1, 6));
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void GameStartScene_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				e.Graphics.FillRectangle(new SolidBrush(ResourceManager.Get("main.sidebar")), new Rectangle(0, 0, 300, Height));
			}
			catch(Exception ex)
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
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public override void OnClosed()
		{
			try
			{
				imgAtus.Dispose();
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbNewGame_Click(object sender, EventArgs e)
		{
			try
			{
				NewGameScene ngs = new NewGameScene();

				SceneManager.SetScene(ngs, AccessManager.AccessKey);
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbMutiPlay_Click(object sender, EventArgs e)
		{
			try
			{
				MessageBox.Show(TextManager.Get().Text("nowdevelop"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbGameLoad_Click(object sender, EventArgs e)
		{
			try
			{
				GameLoadScene gls = new GameLoadScene();

				SceneManager.SetScene(gls, AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
