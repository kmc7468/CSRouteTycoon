using RouteTycoon.RTCore;
using System;
using System.Windows.Forms;

namespace RouteTycoon.RTUI
{
	internal partial class frmMain : Form
	{
		public frmMain()
		{
			try
			{
				InitializeComponent();

				if (new Random().Next(0, 100) == 13)
					Text = "RouteTycoon " + RTCore.Environment.Version.Replace("Beta", "BetaGo");
				else
					Text = "RouteTycoon " + RTCore.Environment.Version;

				SceneManager.MainForm = this;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public void ExitGame()
		{
			try
			{
				FormClosing -= frmMain_FormClosing;
				Application.Exit();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (Controls[0] is PlayScene)
				{
					GameManager.Save(GameManager.Filename);
					SceneManager.SetScene(new MainMenuScene(), AccessManager.AccessKey);
					e.Cancel = true;
					return;
				}
				else if (Controls[0] is UpdateingScene)
				{
					MessageBox.Show(TextManager.Get().Text("notupdateclose"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					e.Cancel = true;
					return;
				}
				else if (Controls[0] is DeveloperScene)
				{
					SceneManager.SetScene(new MainMenuScene(), AccessManager.AccessKey);
					e.Cancel = true;
					return;
				}

				Controls.Clear();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			try
			{
				LogoScene logo = new LogoScene();

				SceneManager.SetScene(logo, AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
