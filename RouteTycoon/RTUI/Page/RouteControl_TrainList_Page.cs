using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class RouteControl_TrainList_Page : Page
	{
		private Graphics g;
		private Route r;
		
		private ToolTip tt = new ToolTip();

		private Image imgAdd, imgAddSel, imgRemove, imgRemoveSel;

		public RouteControl_TrainList_Page(Route _r)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_ways.png", 5, 7, 1, 6));
				Title = TextManager.Get().Text("routecontrol");
				r = _r;
				
				imgAdd = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_add.png", 5, 7, 1, 6));
				imgAddSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_add_sel.png", 5, 7, 1, 6));
				imgRemove = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_remove.png", 5, 7, 1, 6));
				imgRemoveSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_remove_sel.png", 5, 7, 1, 6));

				lbTitle.Font = new Font(RTCore.Environment.Font, 30);
				lbTitle.Text = TextManager.Get().Text("train");
				lbTitle.ForeColor = ResourceManager.Get("routecontrol.train.title");

				lbAccept.Font = new Font(RTCore.Environment.Font, 20);
				lbAccept.Text = TextManager.Get().Text("accept");
				lbAccept.ForeColor = ResourceManager.Get("routecontrol.train.accept.unsel");
				lbAccept.SelColor = ResourceManager.Get("routecontrol.train.accept.sel");
				lbAccept.Location = new Point(Width - 25 - lbAccept.Width, 553);

				panListBack.BackColor = ResourceManager.Get("routecontrol.train.list.background");
				
				picAdd.Image = imgAdd;
				picAdd.MouseEnter += delegate
				{
					picAdd.Image = imgAddSel;
				};
				picAdd.MouseLeave += delegate
				{
					picAdd.Image = imgAdd;
				};
				picRemove.Image = imgRemove;
				picRemove.MouseEnter += delegate
				{
					picRemove.Image = imgRemoveSel;
				};
				picRemove.MouseLeave += delegate
				{
					picRemove.Image = imgRemove;
				};

				ListDraw();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
		
		internal void ListDraw()
		{
			try
			{
				tt.RemoveAll();
				foreach (Control it in panList.Controls)
					it.Dispose();
				panList.Controls.Clear();

				panList.Size = new Size(730, 0);
				panList.Location = new Point(0, 0);
				int y = 0;
				foreach (var it in r.Trains)
				{
					string type_string = "";
					switch (it.Data.Rank)
					{
						case TrainData.TrainRank.HIGH: type_string = TextManager.Get().Text("hightrain"); break;
						case TrainData.TrainRank.DEFAULT: type_string = TextManager.Get().Text("defaulttrain"); break;
					}

					TrainList01 sl = new TrainList01(it, true, type_string, false, r.Name);
					sl.Location = new Point(0, y);
					panList.Controls.Add(sl);
					y += sl.Height;
					panList.Size = new Size(730, y);
					tt.SetToolTip(sl, $"{it.Name} ({it.Data.Name}, {type_string})");
				}

				if (panList.Controls.Count <= 10)
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

		private void picAdd_Click(object sender, EventArgs e)
		{
			try
			{
				if (GameManager.isBuild)
				{
					MessageBox.Show(TextManager.Get().Text("builded"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return;
				}

				PageManager.SetPage(new TrainList_OKAdd_Page(null, r), AccessManager.AccessKey);
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

				List<TrainList01> ctrls = new List<TrainList01>();
				foreach (Control it in panList.Controls)
				{
					if (it is TrainList01 && (it as TrainList01).isSelect) ctrls.Add((TrainList01)it);
				}

				if (ctrls.Count == 0) return;

				Dictionary<string, string> data = new Dictionary<string, string>();
				data.Add("%COUNT%", ctrls.Count.ToString());
				data.Add("%ROUTENAME%", r.Name);

				if (MessageBox.Show(TextManager.Get().Text("realoutputtrain", true, data), "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
				{

					foreach (TrainList01 it in ctrls)
					{
						it.t.Progress = 0.0;
						it.t.NowStation = null;
						it.t.Route = null;
						PluginManager.OutputedTrain(it.t, r);
					}

					ListDraw();
				}
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
				#region 적용
				List<Train> trains = new List<Train>();

				foreach (Control c in panList.Controls)
					trains.Add((c as TrainList01).t);

				r.Trains.Clear();
				foreach (var it in trains)
					r.Trains.Add(it);
				#endregion

				PageManager.SetPage(new RouteControl_Main_Page(r), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void RouteControl_TrainList_Page_Paint(object sender, PaintEventArgs e)
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
