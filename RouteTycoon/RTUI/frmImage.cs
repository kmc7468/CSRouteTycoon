using RouteTycoon.RTCore;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RouteTycoon.RTUI
{
	partial class frmImage : Form
	{
		private Image Image;
		public frmImage(Image img)
		{
			try
			{
				InitializeComponent();

				Image = img;
				MinimumSize = img.Size;

				Icon = SceneManager.MainForm.Icon;
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void frmLogo_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				e.Graphics.Clear(Color.White);

				e.Graphics.DrawImage(Image, 0, 0, Width - 16, Height - 39);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
