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
using RouteTycoon.RTAPI;

namespace RouteTycoon.RTUI
{
	internal partial class NewsPage : Page
	{
		private Image imgRefresh, imgRefreshSel;

		private ToolTip tt = new ToolTip();

		public NewsPage()
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				Title = TextManager.Get().Text("news");
				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_news.png", 5, 7, 1, 6));

				imgRefresh = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_refresh.png", 5, 7, 1, 6));
				imgRefreshSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_refresh_sel.png", 5, 7, 1, 6));

				lbTitle.Text = TextManager.Get().Text("news");
				lbTitle.ForeColor = ResourceManager.Get("news.title");
				lbTitle.Font = new Font(RTCore.Environment.Font, 30);

				lbShowTooltip.Font = new Font(RTCore.Environment.Font, 12);
				lbShowTooltip.Text = TextManager.Get().Text("mouseonshow");
				lbShowTooltip.ForeColor = ResourceManager.Get("news.showtooltip");

				panListBack.BackColor = ResourceManager.Get("news.list");

				picRefresh.Image = imgRefresh;
				picRefresh.MouseEnter += delegate { picRefresh.Image = imgRefreshSel; };
				picRefresh.MouseLeave += delegate { picRefresh.Image = imgRefresh; };
				picRefresh.Click += delegate { ListDraw(); };

				ListDraw();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void ListDraw()
		{
			try
			{
				tt.RemoveAll();
				panList.Size = new Size(730, 0);
				panList.Location = new Point(0, 0);
				foreach (Control it in panList.Controls)
					it.Dispose();
				panList.Controls.Clear();

				GameManager.News.Reverse();

				int y = 0;
				foreach (var it in GameManager.News)
				{
					NewsList01 lst = new NewsList01(it);
					lst.Location = new Point(0, y);
					panList.Controls.Add(lst);
					y += lst.Height;
					panList.Size = new Size(730, y);
					tt.SetToolTip(lst, $"{it.Message}\n{it.Time.Year}.{it.Time.Month}.{it.Time.Day}");

					panList.Controls.Add(lst);
				}

				GameManager.News.Reverse();

				if (panList.Controls.Count <= 4)
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

		private void NewsPage_Paint(object sender, PaintEventArgs e)
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
