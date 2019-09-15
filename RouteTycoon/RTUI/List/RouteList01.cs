using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;
using System;

namespace RouteTycoon.RTUI
{
	internal partial class RouteList01 : UserControl
	{
		public Color RouteColor;
		public string RouteName;
		private Graphics g;

		public RouteList01(Route r)
		{
			try
			{ 
				InitializeComponent();

				RouteColor = r.RouteColor;
				RouteName = r.Name;
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public void Draw()
		{
			try
			{
				g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

				g.FillEllipse(new SolidBrush(RouteColor), new Rectangle(8, 7, 25, 25));
				g.DrawString(RouteName, new Font(RTCore.Environment.Font, 15), new SolidBrush(ResourceManager.Get("list.routelist01.name")), new PointF(43, 5));

			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void RouteList_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				g = e.Graphics;
				Draw();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void RouteList_MouseEnter(object sender, System.EventArgs e)
		{
			try
			{ 
				BackColor = ResourceManager.Get("list.routelist01.background.sel");
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
        }

		private void RouteList_MouseLeave(object sender, System.EventArgs e)
		{
			try
			{
				BackColor = Color.Transparent;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
