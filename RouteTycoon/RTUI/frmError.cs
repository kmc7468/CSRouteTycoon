using RouteTycoon.RTCore;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RouteTycoon.RTUI
{
	internal partial class frmError : Form
	{
		public frmError(string text)
		{

			InitializeComponent();

			Icon = SceneManager.MainForm.Icon;

			Random rd = new Random();
			int result = rd.Next(0, 4); // 0~3 중 랜덤 수 생성

			if (result == 0)
				BackgroundImage = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "msg_err_01.png", 5, 7, 1, 6));
			else if (result == 1)
				BackgroundImage = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "msg_err_02.png", 5, 7, 1, 6));
			else
				BackgroundImage = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "msg_err_03.png", 5, 7, 1, 6));

			lbText.Text = text;
			lbText.Font = new Font(RTCore.Environment.Font, 12, FontStyle.Regular);

			btnClose.Font = new Font(RTCore.Environment.Font, 9);

			bool reet = true;
			if (reet)
			{
				// love
			}
		}

		private Point point;
		private int X, Y;

		private void frmError_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				X = MousePosition.X - Location.X;
				Y = MousePosition.Y - Location.Y;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			try
			{
				LogManager.Save("log.rte");
				SceneManager.MainForm.ExitGame();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void frmError_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				LogManager.Save("log.rte");
				SceneManager.MainForm.ExitGame();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void frmError_MouseMove(object sender, MouseEventArgs e)
		{
			try
			{
				if (e.Button == MouseButtons.Left)
				{
					point = MousePosition;
					point.X -= X;
					point.Y -= Y;
					Location = point;
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
