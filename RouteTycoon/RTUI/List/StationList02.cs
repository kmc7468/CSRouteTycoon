using System;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class StationList02 : UserControl
	{
		private Graphics g;
		public Station s;
		public bool isSelect = false;

		public StationList02(Station _s)
		{
			try
			{
				InitializeComponent();

				s = _s;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void StationList02_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				g = e.Graphics;

				g.DrawString($"{s.Name} ({s.Parent.Parent.Name} {s.Parent.Name})", new Font(RTCore.Environment.Font, 15), new SolidBrush(ResourceManager.Get("list.stationlist02.name")), new RectangleF(8, 7, 644, Height - 7));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void StationList02_MouseEnter(object sender, EventArgs e)
		{
			try
			{
				if (isSelect) return;
				BackColor = ResourceManager.Get("list.stationlist02.background.sel");
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void StationList02_MouseLeave(object sender, EventArgs e)
		{
			try
			{
				if (isSelect) return;
				BackColor = Color.Transparent;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void StationList02_Click(object sender, EventArgs e)
		{
			try
			{
				if (isSelect)
				{
					BackColor = Color.Transparent;
					isSelect = false;
				}
				else
				{
					BackColor = ResourceManager.Get("list.stationlist02.background.select");
					isSelect = true;
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void StationList02_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				PageManager.SetPage(new StationInfoPage(s, PageManager.GetNowPage(AccessManager.AccessKey)), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
