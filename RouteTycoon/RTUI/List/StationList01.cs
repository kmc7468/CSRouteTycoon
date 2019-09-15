using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class StationList01 : UserControl
	{
		public Station sta;
		private RouteAdd_Stations_Page page;
		private Graphics g;

		public bool isSelect = false;

		private Image imgUp, imgUpSel, imgDown, imgDownSel;

		private void picUp_MouseEnter(object sender, EventArgs e)
		{
			try
			{
				picUp.Image = imgUpSel;
				if (isSelect) return;
				BackColor = ResourceManager.Get("list.stationlist01.background.sel");
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void picUp_MouseLeave(object sender, EventArgs e)
		{
			try
			{
				picUp.Image = imgUp;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void picDown_MouseEnter(object sender, EventArgs e)
		{
			try
			{
				picDown.Image = imgDownSel;
				if (isSelect) return;
				BackColor = ResourceManager.Get("list.stationlist01.background.sel");
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void picDown_MouseLeave(object sender, EventArgs e)
		{
			try
			{
				picDown.Image = imgDown;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void StationList_MouseEnter(object sender, EventArgs e)
		{
			try
			{
				if (isSelect) return;

				BackColor = ResourceManager.Get("list.stationlist01.background.sel");
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void StationList_MouseLeave(object sender, EventArgs e)
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

		private void picUp_Click(object sender, EventArgs e)
		{
			try
			{
				if (GameManager.isBuild)
				{
					MessageBox.Show(TextManager.Get().Text("builded"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return;
				}
				page.ChangeOrder(this, page.GetStationList(this, RouteAdd_Stations_Page.GetType.Up));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void picDown_Click(object sender, EventArgs e)
		{
			try
			{
				if (GameManager.isBuild)
				{
					MessageBox.Show(TextManager.Get().Text("builded"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return;
				}
				page.ChangeOrder(this, page.GetStationList(this, RouteAdd_Stations_Page.GetType.Down));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void StationList01_Click(object sender, EventArgs e)
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
					BackColor = ResourceManager.Get("list.stationlist01.background.select");
					isSelect = true;
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public StationList01(Station s, RouteAdd_Stations_Page p, Image _imgUp, Image _imgUpSel, Image _imgDown, Image _imgDownSel)
		{
			try
			{
				InitializeComponent();

				sta = s;
				page = p;

				imgUp = _imgUp;
				imgUpSel = _imgUpSel;
				imgDown = _imgDown;
				imgDownSel = _imgDownSel;

				picUp.Image = imgUp;
				picDown.Image = imgDown;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void StationList_Paint(object sender, PaintEventArgs e)
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

		private void Draw()
		{
			try
			{
				g.DrawString($"{sta.Name} ({sta.Parent.Parent.Name} {sta.Parent.Name})", new Font(RTCore.Environment.Font, 15), new SolidBrush(ResourceManager.Get("list.stationlist01.name")), new RectangleF(8, 7, 644, Height - 7));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
