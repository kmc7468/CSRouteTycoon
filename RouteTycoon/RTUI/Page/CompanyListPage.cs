using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class CompanyListPage : Page
	{
		private ToolTip tt = new ToolTip();
		
		public CompanyListPage()
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				Title = TextManager.Get().Text("companylist");
				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_company.png", 5, 7, 1, 6));
				
				lbTitle.Text = TextManager.Get().Text("companylist");
				lbTitle.Font = new Font(RTCore.Environment.Font, 30);
				lbTitle.ForeColor = ResourceManager.Get("companylist.title");
				
				panListBack.BackColor = ResourceManager.Get("companylist.list");
				
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
				foreach (var it in GameManager.Companies)
				{
					CompanyList01 lst = new CompanyList01(it);
					lst.Location = new Point(0, y);
					panList.Controls.Add(lst);
					y += lst.Height;
					panList.Size = new Size(730, y);
					tt.SetToolTip(lst, $"{it.Name} - {it.PresidentName}");
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
			catch (Exception e)
			{
				RTCore.Environment.ReportError(e, AccessManager.AccessKey);
			}
		}
		
		private void CompanyListPage_Paint(object sender, PaintEventArgs e)
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
