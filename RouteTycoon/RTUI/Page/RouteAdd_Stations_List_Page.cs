using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class RouteAdd_Stations_List_Page : Page
	{
		private List<Station> stas;
		private RouteAdd_Stations_Page page;
		private Image imgAdd, imgAddSel, imgRemove, imgRemoveSel;
		private int np = 1, mp = 1;
		private ToolTip tt = new ToolTip();
		
		private void picStnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				PageManager.SetPage(new StationAdd_Name_Page(this), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbEnd_Click(object sender, EventArgs e)
		{
			try
			{
				foreach (var it in panList.Controls)
				{
					if ((it as StationList02).isSelect)
						stas.Add((it as StationList02).s);
				}

				page.stas = stas;

				PageManager.SetPage(page, AccessManager.AccessKey);
				page.ListDraw();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void picStnRemove_Click(object sender, EventArgs e)
		{
			try
			{
				List<Station> selects = new List<Station>();

				foreach (Control it in panList.Controls)
				{
					if ((it as StationList02).isSelect)
						selects.Add((it as StationList02).s);
				}

				if (selects.Count == 0) return;

				foreach (var it in selects)
				{
					List<Route> getroute_all = it.GetRoutes();
					List<Route> getroute_player = it.GetRoutes(true);

					if (getroute_all.Count != 0)
					{
						Dictionary<string, string> d = new Dictionary<string, string>();
						d.Add("%STA_NAME%", it.Name);
						d.Add("%USER_COUNT%", string.Format("{0:n0}", getroute_player.Count));
						d.Add("%OTHER_COUNT%", string.Format("{0:n0}", getroute_all.Count - getroute_player.Count));
						string r = "";
						foreach (var s in getroute_all)
						{
							r += s.Name + ", ";
						}

						d.Add("%ROUTES%", r.Substring(0, r.Length - 2));

						MessageBox.Show(TextManager.Get().Text("useroutes", true, d), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						return;
					}
				}

				Dictionary<string, string> data = new Dictionary<string, string>();
				data.Add("%STA_COUNT%", string.Format("{0:n0}", selects.Count));
				decimal p = 0;
				foreach (var it in selects)
				{
					p += it.Parent.Price + 500000;
				}
				data.Add("%PRICE%", string.Format("{0:n0}", p));

				if (MessageBox.Show(TextManager.Get().Text("realdeletesta", true, data), "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					foreach (var it in selects)
					{
						it.Parent.Preference[0] -= 10;
						if (it.Parent.Preference[0] < 0) it.Parent.Preference[0] = 0;

						stas.Remove(it);
						it.Parent.Childs.Remove(it);
					}

					ListDraw();
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public RouteAdd_Stations_List_Page(List<Station> _stas, RouteAdd_Stations_Page _page)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				stas = _stas;
				page = _page;
				
				imgAdd = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_add.png", 5, 7, 1, 6));
				imgAddSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_add_sel.png", 5, 7, 1, 6));
				imgRemove = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_remove.png", 5, 7, 1, 6));
				imgRemoveSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_remove_sel.png", 5, 7, 1, 6));

				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_ways.png", 5, 7, 1, 6));
				Title = TextManager.Get().Text("addroute");

				lbTitle.Font = new Font(RTCore.Environment.Font, 30);
				lbTitle.Text = TextManager.Get().Text("stas");
				lbTitle.ForeColor = ResourceManager.Get("routeadd.title");
				
				lbEnd.Font = new Font(RTCore.Environment.Font, 20);
				lbEnd.Text = TextManager.Get().Text("addlist");
				lbEnd.ForeColor = ResourceManager.Get("routeadd.sta.addlist.unsel");
				lbEnd.SelColor = ResourceManager.Get("routeadd.sta.addlist.sel");
				lbEnd.Location = new Point(Width - 25 - lbEnd.Width, 553);

				panListBack.BackColor = ResourceManager.Get("routeadd.list");

				lbDoubleInfo.Text = TextManager.Get().Text("doubleinfosta");
				lbDoubleInfo.Font = new Font(RTCore.Environment.Font, 12);
				lbDoubleInfo.ForeColor = ResourceManager.Get("routeadd.doubleinfo");

				lbSearch.Font = new Font(RTCore.Environment.Font, 18);
				lbSearch.Text = TextManager.Get().Text("search");
				lbSearch.ForeColor = ResourceManager.Get("routeadd.search.unsel");
				lbSearch.SelColor = ResourceManager.Get("routeadd.search.sel");
				lbSearch.Location = new Point(Width - 36 - lbSearch.Width, 146);
				lbSearch.Click += delegate
				{
					ListDraw(txtSearch.Text);
				};

				txtSearch.Font = new Font(RTCore.Environment.Font, 12);
				txtSearch.Location = new Point(txtSearch.Location.X, 148);
				txtSearch.Size = new Size(730 - 3 - lbSearch.Width, txtSearch.Height);

				ListDraw();
				
				picStnAdd.Image = imgAdd;
				picStnAdd.MouseEnter += delegate
				{
					picStnAdd.Image = imgAddSel;
				};
				picStnAdd.MouseLeave += delegate
				{
					picStnAdd.Image = imgAdd;
				};

				picStnRemove.Image = imgRemove;
				picStnRemove.MouseEnter += delegate
				{
					picStnRemove.Image = imgRemoveSel;
				};
				picStnRemove.MouseLeave += delegate
				{
					picStnRemove.Image = imgRemove;
				};
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter)
					ListDraw(txtSearch.Text);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		internal void ListDraw(string s = "")
		{
			try
			{
				List<Station> Stations = GameManager.GetAllStations();
				foreach (var it in stas)
				{
					Stations.Remove(it);
				}

				foreach (Control it in panList.Controls)
				{
					StationList02 sl = it as StationList02;
					if (sl.isSelect)
						Select.Add(sl.s);
				}

				panList.Size = new Size(730, 0);
				panList.Location = new Point(0, 0);
				foreach (Control it in panList.Controls)
					it.Dispose();
				panList.Controls.Clear();
				tt.RemoveAll();
				np = 1;
				mp = 1;

				_ListDraw(Stations, s);

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

		private new List<Station> Select = new List<Station>();

		private void _ListDraw(List<Station> Stations, string s)
		{
			try
			{
				#region ListDraw
				int y = 0;
				if (s == "")
				{
					foreach (var it in Stations)
					{
						StationList02 sl = new StationList02(it);
						sl.Location = new Point(0, y);
						panList.Controls.Add(sl);
						y += sl.Height;
						panList.Size = new Size(730, y);
						tt.SetToolTip(sl, $"{it.Name} ({it.Parent.Parent.Name} {it.Parent.Name})");

						if (Select.Contains(it))
						{
							sl.isSelect = true;
							sl.BackColor = ResourceManager.Get("list.stationlist02.background.select");
						}
					}

					mp = RTCore.Environment.CalcPage(Stations.Count, 9);
				}
				else
				{
					List<string> names = new List<string>();

					foreach (var it in Stations)
					{
						if (names.Contains(it.Name)) continue;
						names.Add(it.Name);
					}

					List<string> result = RTAPI.StringAPI.Search(names, s);

					foreach (var it in Stations)
					{
						if (!result.Contains(it.Name)) continue;

						StationList02 sl = new StationList02(it);
						sl.Location = new Point(0, y);
						panList.Controls.Add(sl);
						y += sl.Height;
						panList.Size = new Size(730, y);
						tt.SetToolTip(sl, $"{it.Name} ({it.Parent.Parent.Name} {it.Parent.Name})");

						if (Select.Contains(it))
						{
							sl.isSelect = true;
							sl.BackColor = ResourceManager.Get("list.stationlist02.background.select");
						}
					}

					mp = RTCore.Environment.CalcPage(result.Count, 9);
				}

				Select = new List<Station>();
				#endregion
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void RouteAdd_Stations_List_Page_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Draw(e);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
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
