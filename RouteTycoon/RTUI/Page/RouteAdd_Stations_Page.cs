using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class RouteAdd_Stations_Page : Page
	{
		private Graphics g;
		private Route r;

		internal List<Station> stas = new List<Station>();

		private Image imgUp, imgUpSel, imgDown, imgDownSel;
		private Image imgAdd, imgAddSel, imgRemove, imgRemoveSel;
		private Page OldPage = null;
		private bool EditMode = false;

		private ToolTip tt = new ToolTip();

		public RouteAdd_Stations_Page(Route _r, Page _OldPage = null, bool _editmode = false)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				r = _r;
				OldPage = _OldPage;
				EditMode = _editmode;

				imgUp = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_up.png", 5, 7, 1, 6));
				imgUpSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_up_sel.png", 5, 7, 1, 6));
				imgDown = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_down.png", 5, 7, 1, 6));
				imgDownSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_down_sel.png", 5, 7, 1, 6));

				imgAdd = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_add.png", 5, 7, 1, 6));
				imgAddSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_add_sel.png", 5, 7, 1, 6));
				imgRemove = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_remove.png", 5, 7, 1, 6));
				imgRemoveSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_remove_sel.png", 5, 7, 1, 6));

				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_ways.png", 5, 7, 1, 6));
				Title = TextManager.Get().Text("addroute");

				lbTitle.Font = new Font(RTCore.Environment.Font, 30);
				lbTitle.ForeColor = ResourceManager.Get("routeadd.title");
				lbTitle.Text = TextManager.Get().Text("way");

				panListBack.BackColor = ResourceManager.Get("routeadd.list");

				lbEnd.Font = new Font(RTCore.Environment.Font, 20);
				lbEnd.Text = TextManager.Get().Text("add");
				lbEnd.ForeColor = ResourceManager.Get("routeadd.sta.add.unsel");
				lbEnd.SelColor = ResourceManager.Get("routeadd.sta.add.sel");
				lbEnd.Location = new Point(Width - 25 - lbEnd.Width, 553);

				cbLoop.Font = new Font(RTCore.Environment.Font, 12);
				cbLoop.Text = TextManager.Get().Text("loop");

				lbReverse.Font = new Font(RTCore.Environment.Font, 12);
				lbReverse.Text = TextManager.Get().Text("wayreverse");
				lbReverse.ForeColor = ResourceManager.Get("stationadd.back.unsel");
				lbReverse.SelColor = ResourceManager.Get("stationadd.back.sel");
				lbReverse.Location = new Point(Width - lbReverse.Width - 35, lbReverse.Location.Y);

				picAdd.Image = imgAdd;
				picRemove.Image = imgRemove;

				bool reet = _editmode;

				if (reet)
				{
					foreach (var it in r.Stations)
						stas.Add(it);
					if (r.Stations.First() == r.Stations.Last())
					{
						cbLoop.Checked = true;
						stas.RemoveAt(stas.Count - 1);
					}

					Title = TextManager.Get().Text("routecontrol");
					lbEnd.Text = TextManager.Get().Text("accept");
				}

				lbReverse.Click += delegate
				{
					stas.Reverse();
					ListDraw();
				};

				ListDraw();
			}
			catch (Exception EX)
			{
				RTCore.Environment.ReportError(EX, AccessManager.AccessKey);
			}
		}

		internal void ListDraw()
		{
			try
			{
				tt.RemoveAll();
				panList.Controls.Clear();

				panList.Size = new Size(730, 0);
				panList.Location = new Point(0, 0);

				int y = 0;
				foreach (var it in stas)
				{
					StationList01 sl = new StationList01(it, this, imgUp, imgUpSel, imgDown, imgDownSel);
					sl.Location = new Point(0, y);
					panList.Controls.Add(sl);
					y += sl.Height;
					panList.Size = new Size(730, y);
					tt.SetToolTip(sl, $"{it.Name} ({it.Parent.Parent.Name} {it.Parent.Name})");
				}

				if (panList.Controls.Count <= 9)
				{
					panListBack.AutoScroll = false;
					panListBack.Size = new Size(730, panListBack.Height);
				}
				else
				{
					panListBack.AutoScroll = true;
					panListBack.Size = new Size(750, panListBack.Height);
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void RouteAdd_Stations_Page_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Draw(e);

				g = e.Graphics;
				g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			}
			catch (Exception EX)
			{
				RTCore.Environment.ReportError(EX, AccessManager.AccessKey);
			}
		}

		private void lbEnd_Click(object sender, EventArgs e)
		{
			try
			{
				if (stas.Count < 2)
				{
					MessageBox.Show(TextManager.Get().Text("notsta"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return;
				}

				if (EditMode)
				{
					List<Station> old = r.Stations;

					if (cbLoop.Checked) stas.Add(stas.First());

					bool reet = false; // true : 변경됨 / false : 변경되지 않음

					if (old.Count == stas.Count)
					{
						int inx = 0;
						foreach (var it in stas)
						{
							if (it != old[inx]) { reet = true; break; }
							inx++;
						}
					}
					else
						reet = true;

					if (reet)
					{
						r.Stations.Clear();
						foreach (var it in stas)
							r.Stations.Add(it);

						int pxm = 0;
						decimal money = 0;
						if (r.Type == Route.RouteType.DEFAULT) { pxm = 500; }
						else if (r.Type == Route.RouteType.HIGH) { pxm = 800; }
						for (int i = 0; i < r.Stations.Count - 1; i++)
						{
							if (r.Stations[i].Parent.Parent == r.Stations[i + 1].Parent.Parent) money += GameManager.GameRule.CalcRailBuildPriceForSameRegion(r.Stations[i].Parent.Price);
							else money += GameManager.GameRule.CalcRailBuildPrice(r.Stations[i].Parent.Parent.Location, r.Stations[i + 1].Parent.Parent.Location, pxm);
						}
						decimal nowm = GameManager.Company.Money;
						if (nowm - money <= 0)
						{
							MessageBox.Show(TextManager.Get().Text("nomoney"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
							return;
						}

						GameManager.Company.Money -= money;

						List<City> citys = new List<City>();

						foreach (var it in r.Stations)
						{
							if (old.Contains(it)) continue;

							if (citys.Contains(it.Parent)) continue;
							citys.Add(it.Parent);
						}

						foreach (var it in citys)
						{
							it.Preference[0] += 5;
							if (it.Preference[0] >= 100) it.Preference[0] = 100;
						}
					}

					if (OldPage != null)
					{
						if (OldPage is RouteControl_Main_Page)
							OldPage = new RouteControl_Main_Page(r);

						PageManager.SetPage(OldPage, AccessManager.AccessKey);
					}
					else
						PageManager.Close(false, AccessManager.AccessKey);
				}
				else
				{
					foreach (var it in stas)
						r.Stations.Add(it);

					if (cbLoop.Checked) r.Stations.Add(r.Stations.First());

					int pxm = 0;
					long money = 0;
					if (r.Type == Route.RouteType.DEFAULT) { pxm = 500; r.UseMoney = 50; }
					else if (r.Type == Route.RouteType.HIGH) { pxm = 800; r.UseMoney = 100; }
					for (int i = 0; i < r.Stations.Count - 1; i++)
					{
						if (r.Stations[i].Parent.Parent == r.Stations[i + 1].Parent.Parent) money += GameManager.GameRule.CalcRailBuildPriceForSameRegion(r.Stations[i].Parent.Price);
						else money += GameManager.GameRule.CalcRailBuildPrice(r.Stations[i].Parent.Parent.Location, r.Stations[i + 1].Parent.Parent.Location, pxm);
					}
					decimal nowm = GameManager.Company.Money;
					if (nowm - money <= 0)
					{
						MessageBox.Show(TextManager.Get().Text("nomoney"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						return;
					}

					GameManager.Company.Money -= money;

					r.Open = GameManager.Time;
					List<City> citys = new List<City>();
					foreach (var it in r.Stations)
					{
						if (citys.Contains(it.Parent)) continue;
						citys.Add(it.Parent);
					}

					foreach (var it in citys)
					{
						it.Preference[0] += 5;
						if (it.Preference[0] >= 100) it.Preference[0] = 100;
					}

					GameManager.RouteMgr.Routes.Add(r);
					PluginManager.AddedRoute(r);

					PageManager.Close(false, AccessManager.AccessKey);
				}
			}
			catch (Exception Ex)
			{
				RTCore.Environment.ReportError(Ex, AccessManager.AccessKey);
			}
		}

		private void picAdd_MouseEnter(object sender, EventArgs e)
		{
			try
			{
				picAdd.Image = imgAddSel;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void picAdd_MouseLeave(object sender, EventArgs e)
		{
			try
			{
				picAdd.Image = imgAdd;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void picRemove_MouseEnter(object sender, EventArgs e)
		{
			try
			{
				picRemove.Image = imgRemoveSel;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void picRemove_MouseLeave(object sender, EventArgs e)
		{
			try
			{
				picRemove.Image = imgRemove;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void picAdd_Click(object sender, EventArgs e)
		{
			try
			{
				if (GameManager.isBuild)
				{
					MessageBox.Show(TextManager.Get().Text("builded"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return;
				}

				PageManager.SetPage(new RouteAdd_Stations_List_Page(stas, this), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void picRemove_Click(object sender, EventArgs e)
		{
			try
			{
				if (GameManager.isBuild)
				{
					MessageBox.Show(TextManager.Get().Text("builded"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return;
				}

				List<StationList01> ctrl = new List<StationList01>();
				foreach (Control it in panList.Controls)
				{
					if (it.BackColor == ResourceManager.Get("list.stationlist01.background.select"))
					{
						ctrl.Add((StationList01)it);
					}
				}

				if (ctrl.Count == 0) return;

				foreach (StationList01 it in ctrl)
				{
					stas.Remove(it.sta);
				}

				ListDraw();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		internal void ChangeOrder(StationList01 sl1, StationList01 sl2)
		{
			if (sl1 == null || sl2 == null) return;

			Point p1 = sl1.Location;
			Point p2 = sl2.Location;

			sl2.Location = p1;
			sl1.Location = p2;

			sl2.BackColor = Color.Transparent;
			sl1.BackColor = Color.Transparent;
			sl2.isSelect = false;
			sl1.isSelect = false;

			int sl1_inx = stas.IndexOf(sl1.sta);
			int sl2_inx = stas.IndexOf(sl2.sta);

			stas[sl1_inx] = sl2.sta;
			stas[sl2_inx] = sl1.sta;
		}

		internal StationList01 GetStationList(StationList01 sl, GetType t)
		{
			if (t == GetType.Up)
			{
				List<StationList01> tmp = new List<StationList01>();
				foreach (var it in panList.Controls)
					tmp.Add((StationList01)it);

				if (sl.Location.Y == 0) return null;

				Control ctrl = tmp.First(x => x.Location == new Point(0, sl.Location.Y - 40));

				return (StationList01)ctrl;
			}
			else
			{
				List<StationList01> tmp = new List<StationList01>();
				foreach (var it in panList.Controls)
					tmp.Add((StationList01)it);

				if (sl.Location.Y == panList.Height - 40) return null;

				Control ctrl = tmp.First(x => x.Location == new Point(0, sl.Location.Y + 40));

				return (StationList01)ctrl;
			}
		}

		internal new enum GetType
		{
			Up, // 위에 있는 것
			Down // 밑에 있는 것
		}

		public override void OnClose()
		{
			try
			{
				foreach (Control it in panList.Controls)
					it.Dispose();
				panList.Controls.Clear();
				panList.Size = new Size(730, 0);
				panList.Location = new Point(0, 0);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
