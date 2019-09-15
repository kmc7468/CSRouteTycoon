using RouteTycoon.RTCore;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RouteTycoon.RTUI
{
	internal partial class NewGameScene : Scene
	{
		private Image imgAtus;

		public NewGameScene()
		{
			try
			{
				InitializeComponent();

				imgAtus = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "atus_white.png", 5, 7, 1, 6));
				picAtus.Image = imgAtus;

				lbCareer.Text = TextManager.Get().Text("careermode");
				lbCareer.Font = new Font(RTCore.Environment.Font, 30);
				lbCareer.ForeColor = ResourceManager.Get("newgame.career.unsel");
				lbCareer.SelColor = ResourceManager.Get("newgame.career.sel");

				lbDefault.Text = TextManager.Get().Text("defaultmode");
				lbDefault.Font = new Font(RTCore.Environment.Font, 30);
				lbDefault.ForeColor = ResourceManager.Get("newgame.default.unsel");
				lbDefault.SelColor = ResourceManager.Get("newgame.default.sel");

				lbSandbox.Text = TextManager.Get().Text("sandboxmode");
				lbSandbox.Font = new Font(RTCore.Environment.Font, 30);
				lbSandbox.ForeColor = ResourceManager.Get("newgame.sandbox.unsel");
				lbSandbox.SelColor = ResourceManager.Get("newgame.sandbox.sel");

				lbBack.Text = TextManager.Get().Text("back");
				lbBack.Font = new Font(RTCore.Environment.Font, 30);
				lbBack.ForeColor = ResourceManager.Get("newgame.back.unsel");
				lbBack.SelColor = ResourceManager.Get("newgame.back.sel");

				lbTitle.Font = new Font(RTCore.Environment.Font, 40);
				lbTitle.HaloTextStr = TextManager.Get().Text("newgame");
				lbTitle.ForeColor = ResourceManager.Get("newgame.title");

				BackgroundImage = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "main_background.png", 5, 7, 1, 6));
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void NewGameScene_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				e.Graphics.FillRectangle(new SolidBrush(ResourceManager.Get("main.sidebar")), new Rectangle(0, 0, 300, Height));
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
				GameStartScene gss = new GameStartScene();

				SceneManager.SetScene(gss, AccessManager.AccessKey);
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
				imgAtus.Dispose();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbDefault_Click(object sender, EventArgs e)
		{
			try
			{
				DefaultCreateGameScene dcgs = new DefaultCreateGameScene();

				SceneManager.SetScene(dcgs, AccessManager.AccessKey);
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbSandbox_Click(object sender, EventArgs e)
		{
			try
			{
				DefaultCreateGameScene dcgs = new DefaultCreateGameScene(true);

				SceneManager.SetScene(dcgs, AccessManager.AccessKey);
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbCareer_Click(object sender, EventArgs e)
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
	}
}
