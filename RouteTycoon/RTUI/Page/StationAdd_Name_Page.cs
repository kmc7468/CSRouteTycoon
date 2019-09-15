using System;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class StationAdd_Name_Page : Page
	{
		private Graphics g;
		private Page OldPage = null;
		private TextBox txtInput = new TextBox();
		private Station s;

		public StationAdd_Name_Page(Page p, Station _s = null)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				OldPage = p;
				s = _s;

				Title = TextManager.Get().Text("addstn");
				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_timetable.png", 5, 7, 1, 6));

				txtInput.Name = "txtInput";
				txtInput.Font = new Font(RTCore.Environment.Font, 20);
				txtInput.Size = new Size(500, txtInput.Height);
				txtInput.MaxLength = 25;
				txtInput.TextAlign = HorizontalAlignment.Center;
				txtInput.Location = new Point((Width / 2) - 250, (Height / 2) + 10);
				if (s != null) txtInput.Text = s.Name;
				Controls.Add(txtInput);

				lbNext.Font = new Font(RTCore.Environment.Font, 20);
				lbNext.Text = TextManager.Get().Text("next");
				lbNext.ForeColor = ResourceManager.Get("stationadd.next.unsel");
				lbNext.SelColor = ResourceManager.Get("stationadd.next.sel");
				lbNext.Location = new Point(Width - 25 - lbNext.Width, 553);

				lbBack.Font = new Font(RTCore.Environment.Font, 20);
				lbBack.Text = TextManager.Get().Text("back");
				lbBack.ForeColor = ResourceManager.Get("stationadd.back.unsel");
				lbBack.SelColor = ResourceManager.Get("stationadd.back.sel");
				lbBack.Location = new Point(25, 553);
				if (OldPage == null) lbBack.Visible = false;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void StationAddPage_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Draw(e);

				g = e.Graphics;

				g.DrawString(TextManager.Get().Text("staname"), new Font(RTCore.Environment.Font, 40), new SolidBrush(ResourceManager.Get("stationadd.title")), RTCore.Environment.CalcRectangle(new Point(Width / 2, (Height / 2) - 40), RTCore.Environment.CalcStringSize(TextManager.Get().Text("staname"), new Font(RTCore.Environment.Font, 40))));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbBack_Click(object sender, EventArgs e)
		{
			try
			{
				if (OldPage is RouteAdd_Stations_List_Page)
					(OldPage as RouteAdd_Stations_List_Page).ListDraw();
				PageManager.SetPage(OldPage, AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbNext_Click(object sender, EventArgs e)
		{
			try
			{
				if (s == null) s = new Station();
				s.Name = txtInput.Text.Trim();
				s.Visitor = 0;
				PageManager.SetPage(new StationAdd_Region_Page(s, OldPage), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void StationAdd_Name_Page_Load(object sender, EventArgs e)
		{

		}
	}
}
