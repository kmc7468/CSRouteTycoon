using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class AchievementListPage : Page
	{
		private ToolTip tt = new ToolTip();

		public AchievementListPage()
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				Title = TextManager.Get().Text("achievementlist");
				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_book.png", 5, 7, 1, 6));

				lbTitle.Text = TextManager.Get().Text("achievementlist");
				lbTitle.Font = new Font(RTCore.Environment.Font, 30);
				lbTitle.ForeColor = ResourceManager.Get("achievementlist.title");

				panListBack.BackColor = ResourceManager.Get("achievementlist.list");

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
				panList.Controls.Clear();

				int y = 0;
				foreach (var it in AchievementManager.Achievements)
				{
					string isclear = "";
					switch (it.Clear)
					{
						case true: isclear = TextManager.Get().Text("iscleartrue"); break;
						case false: isclear = TextManager.Get().Text("isclearfalse"); break;
					}

					AchievementList01 lst = new AchievementList01(it, isclear);
					lst.Location = new Point(0, y);
					panList.Controls.Add(lst);
					y += lst.Height;
					panList.Size = new Size(730, y);

					tt.SetToolTip(lst, $"{it.Name} ({isclear})\n{it.Description}");
				}

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

		private void AchievementListPage_Paint(object sender, PaintEventArgs e)
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
