using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class RouteControl_Main_Page : Page
	{
		private Route r;
		private Graphics g;

		private ToolTip tt = new ToolTip();

		public RouteControl_Main_Page(Route _r)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_ways.png", 5, 7, 1, 6));
				Title = TextManager.Get().Text("routecontrol");

				r = _r;

				lbTitle.Font = new Font(RTCore.Environment.Font, 30);
				lbTitle.ForeColor = ResourceManager.Get("routecontrol.title");
				lbTitle.Text = r.Name;

				lbCreate.Font = new Font(RTCore.Environment.Font, 12);
				lbCreate.ForeColor = ResourceManager.Get("routecontrol.create");
				Dictionary<string, string> datas = new Dictionary<string, string>();
				datas.Add("%TIME%", $"{r.Open.Year}.{r.Open.Month}.{r.Open.Day}");
				lbCreate.Text = TextManager.Get().Text("opendate", true, datas);
				lbCreate.Location = new Point(lbTitle.Location.X + lbTitle.Width + 7, lbCreate.Location.Y);

				tt.SetToolTip(lbTitle, $"{lbTitle.Text}\n{lbCreate.Text}");
				tt.SetToolTip(lbCreate, $"{lbTitle.Text}\n{lbCreate.Text}");

				lbBack.Font = new Font(RTCore.Environment.Font, 20);
				lbBack.Text = TextManager.Get().Text("back");
				lbBack.ForeColor = ResourceManager.Get("routecontrol.back.unsel");
				lbBack.SelColor = ResourceManager.Get("routecontrol.back.sel");
				lbBack.Location = new Point(Width - 25 - lbBack.Width, 553);

				panTrain.Location = new Point(Width - lbTitle.Location.X - 102, lbTitle.Location.Y + lbTitle.Height + 27);
				panTrain.BackColor = ResourceManager.Get("routecontrol.setting.unsel");
				panTrain.MouseEnter += delegate
				{
					panTrain.BackColor = ResourceManager.Get("routecontrol.setting.sel");
				};
				panTrain.MouseLeave += delegate
				{
					panTrain.BackColor = ResourceManager.Get("routecontrol.setting.unsel");
				};

				panWay.Location = new Point(Width - lbTitle.Location.X - 102, lbTitle.Location.Y + lbTitle.Height + 135 + 27);
				panWay.BackColor = ResourceManager.Get("routecontrol.setting.unsel");
				panWay.MouseEnter += delegate
				{
					panWay.BackColor = ResourceManager.Get("routecontrol.setting.sel");
				};
				panWay.MouseLeave += delegate
				{
					panWay.BackColor = ResourceManager.Get("routecontrol.setting.unsel");
				};

				picTrain.Image = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_setting.png", 5, 7, 1, 6));
				picTrain.MouseEnter += delegate
				{
					panTrain.BackColor = ResourceManager.Get("routecontrol.setting.sel");
				};
				picTrain.MouseLeave += delegate
				{
					panTrain.BackColor = ResourceManager.Get("routecontrol.setting.unsel");
				};

				picWay.Image = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_setting.png", 5, 7, 1, 6));
				picWay.MouseEnter += delegate
				{
					panWay.BackColor = ResourceManager.Get("routecontrol.setting.sel");
				};
				picWay.MouseLeave += delegate
				{
					panWay.BackColor = ResourceManager.Get("routecontrol.setting.unsel");
				};

				lbMoreInfo.Text = TextManager.Get().Text("moreinfo");
				lbMoreInfo.Font = new Font(RTCore.Environment.Font, 25);
				lbMoreInfo.ForeColor = ResourceManager.Get("routecontrol.moreinfo.unsel");
				lbMoreInfo.SelColor = ResourceManager.Get("routecontrol.moreinfo.sel");
				lbMoreInfo.Location = new Point(lbTitle.Location.X, lbTitle.Location.Y + lbTitle.Height + 135 + 27 + 120 + 10);
				lbMoreInfo.Click += delegate
				{
					PageManager.SetPage(new RouteInfoPage(r, this), AccessManager.AccessKey);
				};

				lbDelete.Text = TextManager.Get().Text("deleteroute");
				lbDelete.Font = new Font(RTCore.Environment.Font, 25);
				lbDelete.ForeColor = ResourceManager.Get("routecontrol.delete.unsel");
				lbDelete.SelColor = ResourceManager.Get("routecontrol.delete.sel");
				lbDelete.Location = new Point(lbTitle.Location.X, lbMoreInfo.Height + lbMoreInfo.Location.Y + 5);

				cbDraw.Checked = r.MainDraw;
				cbDraw.Text = TextManager.Get().Text("maindraw");
				cbDraw.Font = new Font(RTCore.Environment.Font, 12);
				cbDraw.Location = new Point(lbTitle.Location.X, lbBack.Location.Y + (lbBack.Height / 3));
				cbDraw.ForeColor = ResourceManager.Get("routecontrol.draw");
				cbDraw.CheckedChanged += delegate
				{
					r.MainDraw = cbDraw.Checked;
				};
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void RouteControl_Main_Page_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Draw(e);

				g = e.Graphics;

				g.FillRectangle(new SolidBrush(ResourceManager.Get("routecontrol.info")), new Rectangle(lbTitle.Location.X, lbTitle.Location.Y + lbTitle.Height + 10, Width - (lbTitle.Location.X * 2), 120));
				g.FillRectangle(new SolidBrush(ResourceManager.Get("routecontrol.info")), new Rectangle(lbTitle.Location.X, lbTitle.Location.Y + lbTitle.Height + 145, Width - (lbTitle.Location.X * 2), 120));

				g.DrawString(TextManager.Get().Text("train"), new Font(RTCore.Environment.Font, 15), new SolidBrush(ResourceManager.Get("routecontrol.infotext")), new PointF(lbTitle.Location.X + 13, lbTitle.Location.Y + lbTitle.Height + 10 + 8));
				if (r.Trains.Count == 0)
				{
					g.DrawString(TextManager.Get().Text("nowaddtrain"), new Font(RTCore.Environment.Font, 26), new SolidBrush(ResourceManager.Get("routecontrol.infotext")), new PointF(lbTitle.Location.X + 13, lbTitle.Location.Y + lbTitle.Height + 6 + RTCore.Environment.CalcStringSize(TextManager.Get().Text("train"), new Font(RTCore.Environment.Font, 18)).Height));
				}
				else
				{
					g.DrawString(r.Trains.First().Name, new Font(RTCore.Environment.Font, 26), new SolidBrush(ResourceManager.Get("routecontrol.infotext")), new PointF(lbTitle.Location.X + 20, lbTitle.Location.Y + lbTitle.Height + 6 + RTCore.Environment.CalcStringSize(TextManager.Get().Text("train"), new Font(RTCore.Environment.Font, 18)).Height));
					Dictionary<string, string> dat = new Dictionary<string, string>();
					dat.Add("%COUNT%", (r.Trains.Count - 1).ToString());
					dat.Add("%ALL%", (r.Trains.Count).ToString());
					string txt = TextManager.Get().Text("traincount", true, dat);
					g.DrawString(txt, new Font(RTCore.Environment.Font, 13),
						new SolidBrush(ResourceManager.Get("routecontrol.infotext")),
						new PointF(lbTitle.Location.X + 25, lbTitle.Location.Y + lbTitle.Height + 2 +
						RTCore.Environment.CalcStringSize(TextManager.Get().Text("train"), new Font(RTCore.Environment.Font, 18)).Height +
						RTCore.Environment.CalcStringSize(r.Trains.First().Name, new Font(RTCore.Environment.Font, 26)).Height));
				}

				g.DrawString(TextManager.Get().Text("way"), new Font(RTCore.Environment.Font, 15), new SolidBrush(ResourceManager.Get("routecontrol.infotext")), new Point(lbTitle.Location.X + 13, lbTitle.Location.Y + lbTitle.Height + 145 + 8));
				string way = r.Stations.First().Name + " ~ " + r.Stations.Last().Name;
				g.DrawString(way, new Font(RTCore.Environment.Font, 26), new SolidBrush(ResourceManager.Get("routecontrol.infotext")), new PointF(lbTitle.Location.X + 13, lbTitle.Location.Y + lbTitle.Height + 135 + 6 + RTCore.Environment.CalcStringSize(TextManager.Get().Text("way"), new Font(RTCore.Environment.Font, 18)).Height));
				Dictionary<string, string> data = new Dictionary<string, string>();
				data.Add("%COUNT%", (r.Stations.Count - 2).ToString());
				data.Add("%ALL%", (r.Stations.Count).ToString());
				string text = TextManager.Get().Text("waycount", true, data);
				g.DrawString(text, new Font(RTCore.Environment.Font, 13),
						new SolidBrush(ResourceManager.Get("routecontrol.infotext")),
						new PointF(lbTitle.Location.X + 25, lbTitle.Location.Y + lbTitle.Height + 130 +
						RTCore.Environment.CalcStringSize(TextManager.Get().Text("train"), new Font(RTCore.Environment.Font, 18)).Height +
						RTCore.Environment.CalcStringSize(way, new Font(RTCore.Environment.Font, 26)).Height));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbAccept_Click(object sender, EventArgs e)
		{
			try
			{
				PageManager.SetPage(new RouteListPage(), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbDelete_Click(object sender, EventArgs e)
		{
			try
			{
				long m = 0;
				int pxm = 0;
				if (r.Type == Route.RouteType.DEFAULT) { pxm = 500; }
				else if (r.Type == Route.RouteType.HIGH) { pxm = 800; }
				for (int i = 0; i < r.Stations.Count - 1; i++)
					if (r.Stations[i].Parent.Parent == r.Stations[i + 1].Parent.Parent) m += GameManager.GameRule.CalcRailBuildPriceForSameRegion(r.Stations[i].Parent.Price);
					else m += GameManager.GameRule.CalcRailBuildPrice(r.Stations[i].Parent.Parent.Location, r.Stations[i + 1].Parent.Parent.Location, pxm);

				Dictionary<string, string> data = new Dictionary<string, string>();
				data.Add("%MONEY%", string.Format("{0:n0}", m));
				if (MessageBox.Show(TextManager.Get().Text("realdeleteroute", true, data), "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
				{
					if (GameManager.Company.Money - m <= 0)
					{
						MessageBox.Show(TextManager.Get().Text("nomoney"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						return;
					}

					GameManager.Company.Money -= m;
					GameManager.RouteMgr.Routes.Remove(r);
					List<City> citys = new List<City>();
					foreach (var it in r.Stations)
					{
						if (citys.Contains(it.Parent)) continue;
						citys.Add(it.Parent);
					}

					foreach (var it in citys)
					{
						it.Preference[0] -= 10;
						if (it.Preference[0] <= 0) it.Preference[0] = 0;
					}

					PageManager.SetPage(new RouteListPage(), AccessManager.AccessKey);
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void picTrain_Click(object sender, EventArgs e)
		{
			try
			{
				PageManager.SetPage(new RouteControl_TrainList_Page(r), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void picWay_Click(object sender, EventArgs e)
		{
			try
			{
				PageManager.SetPage(new RouteAdd_Stations_Page(r, this, true), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
