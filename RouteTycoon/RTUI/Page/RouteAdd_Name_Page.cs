using System;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class RouteAdd_Name_Page : Page
	{
		private Graphics g;
		private TextBox txtInput = new TextBox();

		public RouteAdd_Name_Page(string RouteName = "")
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_ways.png", 5, 7, 1, 6));
				Title = TextManager.Get().Text("addroute");

				txtInput.Name = "txtInput";
				txtInput.Font = new Font(RTCore.Environment.Font, 20);
				txtInput.Size = new Size(500, txtInput.Height);
				txtInput.MaxLength = 20;
				txtInput.TextAlign = HorizontalAlignment.Center;
				txtInput.Location = new Point((Width / 2) - 250, (Height / 2) + 10);
				txtInput.Text = RouteName;
				Controls.Add(txtInput);

				lbNext.Text = TextManager.Get().Text("next");
				lbNext.ForeColor = ResourceManager.Get("routeadd.next.unsel");
				lbNext.SelColor = ResourceManager.Get("routeadd.next.sel");
				lbNext.Font = new Font(RTCore.Environment.Font, 20);
				lbNext.Location = new Point(Width - 25 - lbNext.Width, 553);
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
        }

		private void RouteAdd_Name_Page_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Draw(e);

				g = e.Graphics;

				g.DrawString(TextManager.Get().Text("routename"), new Font(RTCore.Environment.Font, 40), new SolidBrush(ResourceManager.Get("routeadd.title")), RTCore.Environment.CalcRectangle(new Point(Width / 2, (Height / 2) - 40), RTCore.Environment.CalcStringSize(TextManager.Get().Text("routename"), new Font(RTCore.Environment.Font, 40))));
			}
			catch(Exception EX)
			{
				RTCore.Environment.ReportError(EX, AccessManager.AccessKey);
			}
		}

		private void lbNext_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtInput.Text.Trim() == string.Empty) return;
				foreach (var it in GameManager.RouteMgr.Routes)
				{
					if (it.Name == txtInput.Text.Trim())
					{
						string txt = TextManager.Get().Text("trueroute");
						txt = txt.Replace(@"\n", "\n");
						txt = txt.Replace("%NAME%", it.Owner.Name);
						MessageBox.Show(txt, "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						return;
					}
				}

				RouteAdd_Type_Page ratp = new RouteAdd_Type_Page(new Route() { Name = txtInput.Text, Owner = GameManager.Company, RouteColor = Color.Transparent });

				PageManager.SetPage(ratp, AccessManager.AccessKey);
			}
			catch(Exception EX)
			{
				RTCore.Environment.ReportError(EX, AccessManager.AccessKey);
			}
		}
	}
}
