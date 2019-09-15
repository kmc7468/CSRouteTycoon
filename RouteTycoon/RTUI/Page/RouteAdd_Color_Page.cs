using System;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class RouteAdd_Color_Page : Page
	{
		private Graphics g;
		private Route r;

		private Image imgShadow;

		public RouteAdd_Color_Page(Route _r)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				r = _r;

				if(r.RouteColor == Color.Transparent)
				{
					Random rd = new Random();
					int R = rd.Next(0, 256);
					int G = rd.Next(0, 256);
					int B = rd.Next(0, 256);

					r.RouteColor = Color.FromArgb(R, G, B);
				}

				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_ways.png", 5, 7, 1, 6));
				Title = TextManager.Get().Text("addroute");

				lbNext.Font = new Font(RTCore.Environment.Font, 20);
				lbNext.Text = TextManager.Get().Text("next");
				lbNext.ForeColor = ResourceManager.Get("routeadd.next.unsel");
				lbNext.SelColor = ResourceManager.Get("routeadd.next.sel");
				lbNext.Location = new Point(Width - 25 - lbNext.Width, 553);

				lbBack.Font = new Font(RTCore.Environment.Font, 20);
				lbBack.Text = TextManager.Get().Text("back");
				lbBack.ForeColor = ResourceManager.Get("routeadd.back.unsel");
				lbBack.SelColor = ResourceManager.Get("routeadd.back.sel");
				lbBack.Location = new Point(25, 553);

				imgShadow = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "routeadd_shadow.png", 5, 7, 1, 6));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void RouteAdd_Color_Page_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				e.Graphics.Clear(Color.White);

				g = e.Graphics;

				g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

				g.DrawImage(imgShadow, 0, 0, 800, 600);

				Draw(e);

				g.DrawString(TextManager.Get().Text("linecolor"), new Font(RTCore.Environment.Font, 40), new SolidBrush(ResourceManager.Get("routeadd.title")), RTCore.Environment.CalcRectangle(new Point(Width / 2, (Height / 2) - 100), RTCore.Environment.CalcStringSize(TextManager.Get().Text("linecolor"), new Font(RTCore.Environment.Font, 40))));
				g.FillEllipse(new SolidBrush(r.RouteColor), new Rectangle(((Width / 2) - (150 / 2)) - 1, ((Height / 2) - 50) - 1, 151, 151));

				string hex = r.RouteColor.R.ToString("X2") + r.RouteColor.G.ToString("X2") + r.RouteColor.B.ToString("X2");
				g.DrawString("#" + hex, new Font(RTCore.Environment.Font, 20), new SolidBrush(r.RouteColor), RTCore.Environment.CalcRectangle(new Point(Width / 2, (Height / 2) + 130), RTCore.Environment.CalcStringSize(hex, new Font(RTCore.Environment.Font, 20))));
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
				PageManager.SetPage(new RouteAdd_Type_Page(r), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbNext_Click(object sender, EventArgs e)
		{
			try
			{
				PageManager.SetPage(new RouteAdd_Stations_Page(r), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void RouteAdd_Color_Page_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				Rectangle m = new Rectangle(e.X, e.Y, 1, 1);
				Rectangle c = new Rectangle((Width / 2) - (150 / 2), (Height / 2) - 50, 150, 150);
				if (m.IntersectsWith(c))
				{
					ColorDialog cd = new ColorDialog();
					cd.AllowFullOpen = true;
					cd.FullOpen = true;
					if (cd.ShowDialog() == DialogResult.OK)
					{
						r.RouteColor = cd.Color;

						Refresh();
					}
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
