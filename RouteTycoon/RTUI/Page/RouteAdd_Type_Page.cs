using System;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class RouteAdd_Type_Page : Page
	{
		private Graphics g;
		private Route r;

		private ComboBox cbType = new ComboBox();

		public RouteAdd_Type_Page(Route _r)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				r = _r;

				Title = TextManager.Get().Text("addroute");
				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_ways.png", 5, 7, 1, 6));

				cbType.Font = new Font(RTCore.Environment.Font, 20);
				cbType.Size = new Size(500, cbType.Height);
				cbType.Items.Add(TextManager.Get().Text("highspeedrail"));
				cbType.Items.Add(TextManager.Get().Text("defaultrail"));
				if (r.Type == Route.RouteType.DEFAULT)
					cbType.SelectedIndex = 1;
				else
					cbType.SelectedIndex = 0;
				cbType.DropDownStyle = ComboBoxStyle.DropDownList;
				cbType.Location = new Point((Width / 2) - 250, (Height / 2) + 10);
				cbType.Name = "cbType";
				Controls.Add(cbType);

				lbNext.Font = new Font(RTCore.Environment.Font, 20);
				lbNext.Text = TextManager.Get().Text("next");
				lbNext.ForeColor = ResourceManager.Get("routeadd.next.unsel");
				lbNext.SelColor = ResourceManager.Get("routeadd.next.sel");
				lbNext.Location = new Point(Width - 25 - lbNext.Width, 553);

				lbBack.Font = new Font(RTCore.Environment.Font, 20);
				lbBack.Text = TextManager.Get().Text("back");
				lbBack.ForeColor = ResourceManager.Get("routeadd.back.unsel");
				lbBack.SelColor = ResourceManager.Get("routeadd.back.sel");
				lbBack.Location = new Point(25, 553);
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void RouteAdd_Type_Page_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Draw(e);

				g = e.Graphics;

				g.DrawString(TextManager.Get().Text("routetype"), new Font(RTCore.Environment.Font, 40), new SolidBrush(ResourceManager.Get("routeadd.title")), RTCore.Environment.CalcRectangle(new Point(Width / 2, (Height / 2) - 40), RTCore.Environment.CalcStringSize(TextManager.Get().Text("routetype"), new Font(RTCore.Environment.Font, 40))));
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbBack_Click(object sender, EventArgs e)
		{
			try
			{
				PageManager.SetPage(new RouteAdd_Name_Page(r.Name), AccessManager.AccessKey);
			}catch(Exception EX)
			{
				RTCore.Environment.ReportError(EX, AccessManager.AccessKey);
			}
		}

		private void lbNext_Click(object sender, EventArgs e)
		{
			try
			{
				if (cbType.SelectedIndex == 0)
					r.Type = Route.RouteType.HIGH;
				else
					r.Type = Route.RouteType.DEFAULT;
				PageManager.SetPage(new RouteAdd_Color_Page(r), AccessManager.AccessKey);
			}
			catch (Exception EX)
			{
				RTCore.Environment.ReportError(EX, AccessManager.AccessKey);
			}
		}
	}
}
