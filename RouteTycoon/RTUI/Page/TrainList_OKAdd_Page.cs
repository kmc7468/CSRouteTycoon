using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class TrainList_OKAdd_Page : Page
	{
		private Graphics g;
		private Page OldPage;
		internal Route route;

		private ToolTip tt = new ToolTip();

		private Image imgAdd, imgAddSel, imgRemove, imgRemoveSel;

		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter)
				{
					ListDraw(txtSearch.Text);
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public TrainList_OKAdd_Page(Page _Oldpage = null, Route r = null)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				OldPage = _Oldpage;
				route = r;

				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_train.png", 5, 7, 1, 6));
				Title = TextManager.Get().Text("addtr");

				imgAdd = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_add.png", 5, 7, 1, 6));
				imgAddSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_add_sel.png", 5, 7, 1, 6));
				imgRemove = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_remove.png", 5, 7, 1, 6));
				imgRemoveSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_remove_sel.png", 5, 7, 1, 6));

				panListBack.BackColor = ResourceManager.Get("okaddtrain.list");

				lbTitle.ForeColor = ResourceManager.Get("okaddtrain.title");
				lbTitle.Font = new Font(RTCore.Environment.Font, 30);
				lbTitle.Text = TextManager.Get().Text("okaddtrain");

				lbEnd.ForeColor = ResourceManager.Get("okaddtrain.add.unsel");
				lbEnd.SelColor = ResourceManager.Get("okaddtrain.add.sel");
				lbEnd.Font = new Font(RTCore.Environment.Font, 20);
				lbEnd.Text = TextManager.Get().Text("addroutetrain");
				lbEnd.Location = new Point(Width - 25 - lbEnd.Width, 553);
				lbEnd.Click += delegate
				{
					List<TrainList01> trains = new List<TrainList01>();
					foreach (Control it in panList.Controls)
						if (it is TrainList01)
							if ((it as TrainList01).isSelect)
								trains.Add((TrainList01)it);

					foreach (var it in trains)
					{
						if (route.Type == Route.RouteType.HIGH && it.t.Data.Rank == TrainData.TrainRank.DEFAULT)
						{
							MessageBox.Show(TextManager.Get().Text("highnotenterdef"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
					}

					foreach (var it in trains)
					{
						it.t.Route = r;

						if (!it.t.RunMode) // 상행
							it.t.NowStation = it.t.Route.Stations.Last();
						else // 하행
							it.t.NowStation = it.t.Route.Stations.First();

						PluginManager.InputedTrain(it.t, route);
					}

					if (OldPage == null)
						PageManager.SetPage(new RouteControl_TrainList_Page(route), AccessManager.AccessKey);
				};

				lbSearch.Font = new Font(RTCore.Environment.Font, 18);
				lbSearch.Text = TextManager.Get().Text("search");
				lbSearch.ForeColor = ResourceManager.Get("okaddtrain.search.unsel");
				lbSearch.SelColor = ResourceManager.Get("okaddtrain.search.sel");
				lbSearch.Location = new Point(Width - 36 - lbSearch.Width, 146);
				lbSearch.Click += delegate
				{
					ListDraw(txtSearch.Text);
				};

				txtSearch.Font = new Font(RTCore.Environment.Font, 12);
				txtSearch.Location = new Point(txtSearch.Location.X, 148);
				txtSearch.Size = new Size(730 - 3 - lbSearch.Width, txtSearch.Height);

				picAdd.Image = imgAdd;
				picAdd.MouseEnter += delegate
				{
					picAdd.Image = imgAddSel;
				};
				picAdd.MouseLeave += delegate
				{
					picAdd.Image = imgAdd;
				};
				picAdd.Click += delegate
				{
					PageManager.SetPage(new TrainAdd_NameType_Page(this), AccessManager.AccessKey);
				};

				if (!GameManager.Sandbox && GameManager.Company.Money <= 0) picRemove.Enabled = false;
				picRemove.Image = imgRemove;
				picRemove.MouseEnter += delegate
				{
					picRemove.Image = imgRemoveSel;
				};
				picRemove.MouseLeave += delegate
				{
					picRemove.Image = imgRemove;
				};
				picRemove.Click += delegate
				{
					List<TrainList01> trains = new List<TrainList01>();
					foreach (Control it in panList.Controls)
						if (it is TrainList01)
							if ((it as TrainList01).isSelect)
								trains.Add((TrainList01)it);

					if (trains.Count == 0) return;

					long res = 0;
					foreach (var it in trains)
						res += Convert.ToInt64(it.t.Data.Price * 0.8);

					Dictionary<string, string> data = new Dictionary<string, string>();
					data.Add("%COUNT%", string.Format("{0:n0}", trains.Count));
					data.Add("%RESULT%", string.Format("{0:n0}", res));

					if (MessageBox.Show(TextManager.Get().Text("trainsell", true, data), "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
					{
						foreach (var it in trains)
						{
							TrainManager.Trains.Remove(it.t);
							PluginManager.SoldTrain(it.t);
						}

						GameManager.Company.Money += res;
						ListDraw();
					}
				};

				ListDraw();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		internal void ListDraw(string search = "")
		{
			List<Train> Selects = new List<Train>();
			foreach (Control it in panList.Controls)
			{
				if (it is TrainList01)
				{
					TrainList01 lst = it as TrainList01;

					if (lst.isSelect)
						Selects.Add(lst.t);
				}
			}

			tt.RemoveAll();
			foreach (Control it in panList.Controls)
				it.Dispose();
			panList.Controls.Clear();

			panList.Size = new Size(730, 0);
			panList.Location = new Point(0, 0);

			if (search == string.Empty)
			{
				int y = 0;
				foreach (var it in TrainManager.Trains)
				{
					if (it.Route != null) continue;
					if (it.Owner != GameManager.Company) continue;

					string type_string = "";
					switch (it.Data.Rank)
					{
						case TrainData.TrainRank.HIGH: type_string = TextManager.Get().Text("hightrain"); break;
						case TrainData.TrainRank.DEFAULT: type_string = TextManager.Get().Text("defaulttrain"); break;
					}

					TrainList01 sl = new TrainList01(it, true, type_string);
					sl.Location = new Point(0, y);
					panList.Controls.Add(sl);
					y += sl.Height;
					panList.Size = new Size(730, y);

					tt.SetToolTip(sl, $"{it.Name} ({it.Data.Name}, {type_string})");

					if (Selects.Contains(it))
					{
						sl.isSelect = true;
						BackColor = ResourceManager.Get("list.trainlist01.background.sel");
					}
				}
			}
			else
			{
				List<string> all_item = new List<string>();
				foreach (var it in TrainManager.Trains)
				{
					if (it.Route != null) continue;
					if (it.Owner != GameManager.Company) continue;

					all_item.Add(it.Name);
				}

				List<string> result = RTAPI.StringAPI.Search(all_item, search);

				int y = 0;
				foreach (var it in TrainManager.Trains)
				{
					if (it.Route != null) continue;
					if (it.Owner != GameManager.Company) continue;
					if (!result.Contains(it.Name)) continue;

					string type_string = "";
					switch (it.Data.Rank)
					{
						case TrainData.TrainRank.HIGH: type_string = TextManager.Get().Text("hightrain"); break;
						case TrainData.TrainRank.DEFAULT: type_string = TextManager.Get().Text("defaulttrain"); break;
					}

					TrainList01 sl = new TrainList01(it, true, type_string);
					sl.Location = new Point(0, y);
					panList.Controls.Add(sl);
					y += sl.Height;
					panList.Size = new Size(730, y);

					tt.SetToolTip(sl, $"{it.Name} ({it.Data.Name}, {type_string})");

					if (Selects.Contains(it))
					{
						sl.isSelect = true;
						BackColor = ResourceManager.Get("list.trainlist01.background.sel");
					}
				}
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

		private void TrainList_OKAdd_Page_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Draw(e);
				g = e.Graphics;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
