using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class TrainListPage : Page
	{
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

		private ToolTip tt = new ToolTip();

		public TrainListPage()
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				Title = TextManager.Get().Text("trainlist");
				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_train.png", 5, 7, 1, 6));

				imgAdd = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_add.png", 5, 7, 1, 6));
				imgAddSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_add_sel.png", 5, 7, 1, 6));
				imgRemove = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_remove.png", 5, 7, 1, 6));
				imgRemoveSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_remove_sel.png", 5, 7, 1, 6));

				lbTitle.Text = TextManager.Get().Text("trainlist");
				lbTitle.Font = new Font(RTCore.Environment.Font, 30);
				lbTitle.ForeColor = ResourceManager.Get("trainlist.title");

				panListBack.BackColor = ResourceManager.Get("trainlist.list");

				picAdd.Image = imgAdd;
				picAdd.MouseEnter += delegate { picAdd.Image = imgAddSel; };
				picAdd.MouseLeave += delegate { picAdd.Image = imgAdd; };
				picAdd.Click += delegate
				{
					if (GameManager.isBuild)
					{
						MessageBox.Show(TextManager.Get().Text("builded"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						return;
					}

					PageManager.SetPage(new TrainAdd_NameType_Page(this), AccessManager.AccessKey);
				};

				picRemove.Image = imgRemove;
				picRemove.MouseEnter += delegate { picRemove.Image = imgRemoveSel; };
				picRemove.MouseLeave += delegate { picRemove.Image = imgRemove; };
				picRemove.Click += delegate
				{
					if (GameManager.isBuild)
					{
						MessageBox.Show(TextManager.Get().Text("builded"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						return;
					}

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

				lbSearch.Font = new Font(RTCore.Environment.Font, 18);
				lbSearch.Text = TextManager.Get().Text("search");
				lbSearch.ForeColor = ResourceManager.Get("trainlist.search.unsel");
				lbSearch.SelColor = ResourceManager.Get("trainlist.search.sel");
				lbSearch.Location = new Point(Width - 36 - lbSearch.Width, 146);
				lbSearch.Click += delegate
				{
					ListDraw(txtSearch.Text);
				};

				txtSearch.Font = new Font(RTCore.Environment.Font, 12);
				txtSearch.Location = new Point(txtSearch.Location.X, 148);
				txtSearch.Size = new Size(730 - 3 - lbSearch.Width, txtSearch.Height);

				ListDraw();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		List<Train> Selects = new List<Train>();

		public void ListDraw(string s = "")
		{
			try
			{
				foreach (Control it in panList.Controls)
				{
					TrainList01 tl = it as TrainList01;

					if (tl.isSelect)
						Selects.Add(tl.t);
				}

				tt.RemoveAll();
				foreach (Control it in panList.Controls)
					it.Dispose();
				panList.Controls.Clear();

				panList.Size = new Size(730, 0);
				panList.Location = new Point(0, 0);

				int y = 0;

				if (s == string.Empty)
				{
					foreach (var it in TrainManager.Trains)
					{
						if (it.Owner != GameManager.Company) continue;

						string type = "";
						switch (it.Data.Rank)
						{
							case TrainData.TrainRank.HIGH: type = TextManager.Get().Text("hightrain"); break;
							case TrainData.TrainRank.DEFAULT: type = TextManager.Get().Text("defaulttrain"); break;
						}

						string route_name = "";
						if (it.Route == null) route_name = TextManager.Get().Text("uninputtrain");
						else route_name = TextManager.Get().Text("trainroute").Replace("%ROUTENAME%", it.Route.Name);

						TrainList01 lst = new TrainList01(it, false, type, true, route_name);
						lst.Location = new Point(0, y);
						panList.Controls.Add(lst);
						y += lst.Height;
						panList.Size = new Size(730, y);
						tt.SetToolTip(lst, $"{it.Name} ({it.Data.Name}, {type}, {route_name})");

						if (Selects.Contains(it))
						{
							lst.isSelect = true;
							lst.BackColor = ResourceManager.Get("list.trainlist01.background.select");
						}
					}

					Selects = new List<Train>();
				}
				else
				{
					List<string> names = new List<string>();
					foreach (var it in TrainManager.Trains)
					{
						if (it.Owner == GameManager.Company) names.Add(it.Name);
					}

					List<string> result = RTAPI.StringAPI.Search(names, s);

					foreach (var it in TrainManager.Trains)
					{
						if (it.Owner != GameManager.Company) continue;
						if (!result.Contains(it.Name)) continue;

						string type = "";
						switch (it.Data.Rank)
						{
							case TrainData.TrainRank.HIGH: type = TextManager.Get().Text("hightrain"); break;
							case TrainData.TrainRank.DEFAULT: type = TextManager.Get().Text("defaulttrain"); break;
						}

						string route_name = "";
						if (it.Route == null) route_name = TextManager.Get().Text("uninputtrain");
						else route_name = TextManager.Get().Text("trainroute").Replace("%ROUTENAME%", it.Route.Name);

						TrainList01 lst = new TrainList01(it, false, type, true, route_name);
						lst.Location = new Point(0, y);
						panList.Controls.Add(lst);
						y += lst.Height;
						panList.Size = new Size(730, y);
						tt.SetToolTip(lst, $"{it.Name} ({it.Data.Name}, {type}, {route_name})");

						if (Selects.Contains(it))
						{
							lst.isSelect = true;
							lst.BackColor = ResourceManager.Get("list.trainlist01.background.select");
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
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void TrainListPage_Paint(object sender, PaintEventArgs e)
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
	}
}
