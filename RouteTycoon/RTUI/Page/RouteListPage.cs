using System;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;
using System.Collections.Generic;

namespace RouteTycoon.RTUI
{
	internal partial class RouteListPage : Page
	{
		private ToolTip tt = new ToolTip();

		private void lbAdd_Click(object sender, EventArgs e)
		{
			try
			{
				if (GameManager.isBuild)
				{
					MessageBox.Show(TextManager.Get().Text("builded"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return;
				}

				PageManager.SetPage(new RouteAdd_Name_Page(), AccessManager.AccessKey);
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
				{
					ListDraw(txtSearch.Text);
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public RouteListPage()
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				{
					IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_ways.png", 5, 7, 1, 6));
					Title = TextManager.Get().Text("route");
					
					lbTitle.Font = new Font(RTCore.Environment.Font, 30);
					lbTitle.ForeColor = ResourceManager.Get("routelist.title");
					lbTitle.Text = TextManager.Get().Text("routelist");
					
					panListBack.BackColor = ResourceManager.Get("routelist.list");
					
					lbAdd.Font = new Font(RTCore.Environment.Font, 20);
					lbAdd.Text = TextManager.Get().Text("addroute");
					lbAdd.ForeColor = ResourceManager.Get("routelist.addroute.unsel");
					lbAdd.SelColor = ResourceManager.Get("routelist.addroute.sel");
					lbAdd.Location = new Point(Width - 25 - lbAdd.Width, 553);

					lbDoubleControl.Text = TextManager.Get().Text("doublecontrol");
					lbDoubleControl.Font = new Font(RTCore.Environment.Font, 12);

					lbSearch.Font = new Font(RTCore.Environment.Font, 18);
					lbSearch.Text = TextManager.Get().Text("search");
					lbSearch.ForeColor = ResourceManager.Get("routelist.search.unsel");
					lbSearch.SelColor = ResourceManager.Get("routelist.search.sel");
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
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void ListDraw(string s = "")
		{
			try
			{
				tt.RemoveAll();
				panList.Size = new Size(730, 0);
				panList.Location = new Point(0, 0);
				
				panList.Controls.Clear();

				int y = 0;
				if (s == "")
				{
					foreach (var it in GameManager.RouteMgr.Routes)
					{
						RouteList01 rl = new RouteList01(it);
						rl.Location = new Point(0, y);
						panList.Controls.Add(rl);
						y += rl.Height;
						panList.Size = new Size(730, y);
						tt.SetToolTip(rl, it.Name);
						rl.DoubleClick += delegate
						{
							PageManager.SetPage(new RouteControl_Main_Page(it), AccessManager.AccessKey);
						};
					}
				}
				else
				{
					List<string> names = new List<string>();
					foreach (var it in GameManager.RouteMgr.Routes)
					{
						names.Add(it.Name);
					}

					List<string> result = RTAPI.StringAPI.Search(names, s);

					foreach (var it in GameManager.RouteMgr.Routes)
					{
						if (result.Contains(it.Name))
						{
							RouteList01 rl = new RouteList01(it);
							rl.Location = new Point(0, y);
							panList.Controls.Add(rl);
							y += rl.Height;
							panList.Size = new Size(730, y);
							tt.SetToolTip(rl, it.Name);
							rl.DoubleClick += delegate
							{
								PageManager.SetPage(new RouteControl_Main_Page(it), AccessManager.AccessKey);
							};
						}
					}
				}

				{
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
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void RouteListPage_Paint(object sender, PaintEventArgs e)
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
