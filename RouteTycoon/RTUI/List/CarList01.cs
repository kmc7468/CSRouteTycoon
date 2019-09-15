using System;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class CarList01 : UserControl
	{
		public TrainParant tp;
		private Graphics g;
		private TrainDataAdd_Args_Page page;

		private Image imgUp, imgUpSel, imgDown, imgDownSel;

		public bool isSelect = false;

		public CarList01(TrainParant _tp, TrainDataAdd_Args_Page _page)
		{
			try
			{
				InitializeComponent();

				tp = _tp;
				page = _page;

				imgUp = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_up.png", 5, 7, 1, 6));
				imgUpSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_up_sel.png", 5, 7, 1, 6));
				imgDown = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_down.png", 5, 7, 1, 6));
				imgDownSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_down_sel.png", 5, 7, 1, 6));

				picUp.Image = imgUp;
				picDown.Image = imgDown;
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void CarList01_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				g = e.Graphics;

				string type = "";

				if (tp is Locomotive) type = TextManager.Get().Text("locomotive");
				else if (tp is Coach) type = TextManager.Get().Text("coach");
				else if (tp is EngineCoach) type = TextManager.Get().Text("enginecoach");

				g.DrawString($"{tp.Name} ({type})", new Font(RTCore.Environment.Font, 15), new SolidBrush(ResourceManager.Get("list.carlist01.name")), new RectangleF(8, 7, 444, Height - 7));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
		private void picUp_MouseEnter(object sender, EventArgs e)
		{
			try
			{
				picUp.Image = imgUpSel;
				if (isSelect) return;
				BackColor = ResourceManager.Get("list.carlist01.background.sel");
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void CarList01_MouseEnter(object sender, EventArgs e)
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

		private void CarList01_MouseLeave(object sender, EventArgs e)
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

		private void CarList01_Click(object sender, EventArgs e)
		{
			try
			{
				if (isSelect)
				{
					isSelect = false;
					BackColor = Color.Transparent;
				}
				else
				{
					isSelect = true;
					BackColor = ResourceManager.Get("list.carlist01.background.select");
				}
			}catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void picUp_Click(object sender, EventArgs e)
		{
			try
			{
				page.ChangeOrder(this, page.GetCarList(this, TrainDataAdd_Args_Page.GetType.Up));
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
				page.ChangeOrder(this, page.GetCarList(this, TrainDataAdd_Args_Page.GetType.Down));
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
				BackColor = ResourceManager.Get("list.carlist01.background.sel");
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
	}
}
