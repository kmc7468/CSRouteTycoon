using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class RouteInfoPage : Page
	{
		private Route r;
		private Page OldPage;

		private ToolTip tt = new ToolTip();

		public RouteInfoPage(Route _r, Page _old)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				Title = TextManager.Get().Text("routeinfo");
				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_timetable.png", 5, 7, 1, 6));

				r = _r;
				OldPage = _old;

				lbBack.Font = new Font(RTCore.Environment.Font, 20);
				lbBack.Text = TextManager.Get().Text("back");
				lbBack.ForeColor = ResourceManager.Get("routeinfo.back.unsel");
				lbBack.SelColor = ResourceManager.Get("routeinfo.back.sel");
				lbBack.Location = new Point(Width - 25 - lbBack.Width, 553);
				lbBack.Click += delegate
				{
					PageManager.SetPage(OldPage, AccessManager.AccessKey);
				};
				if (OldPage == null) lbBack.Visible = false;

				lbTitle.Text = _r.Name;
				lbTitle.Font = new Font(RTCore.Environment.Font, 30);
				lbTitle.ForeColor = ResourceManager.Get("routeinfo.title");

				lbRouteInfo.Font = new Font(RTCore.Environment.Font, 20);
				lbRouteInfo.ForeColor = ResourceManager.Get("routeinfo.info");
				lbRouteInfo.Location = new Point(lbTitle.Location.X, lbTitle.Location.Y + lbTitle.Height + 2);

				Dictionary<string, string> d = new Dictionary<string, string>();
				d.Add("%ALL_VISITOR%", string.Format("{0:n0}", _r.Visitor));
				decimal income = 0;
				{
					long pass_carry = 0;
					long freight_carry = 0;

					foreach (var t in r.Trains)
					{
						foreach (TrainParant a in t.Data.Args)
						{
							if (a is Locomotive) continue;

							Coach c = (Coach)a;

							if (c.Rank == Coach.CarriageRank.FREIGHT)
								freight_carry += c.Carrying;
							else
								pass_carry += c.Carrying;
						}
					}

					int use = r.UseMoney;
					if (r.Type == Route.RouteType.HIGH) use = use + Convert.ToInt32(use * 0.3);

					long pass_visit = 0;
					long freight_visit = 0;
					long double_visit = 0;

					foreach (var s in r.Stations)
					{
						if (s.Type == Station.StationType.DOUBLE)
							double_visit += s.Visitor;
						else if (s.Type == Station.StationType.PASSENGER)
							pass_visit += s.Visitor;
						else if (s.Type == Station.StationType.FREIGHT)
							freight_visit += s.Visitor;
					}

					long v = 0;

					if (pass_visit + (double_visit / 2) <= pass_carry) v += pass_visit;
					else v += pass_carry;

					if (freight_visit + (double_visit / 2) <= freight_carry) v += freight_visit;
					else v += freight_carry;

					income += GameManager.GameRule.CalcRouteIncome(pass_visit + (double_visit / 2), pass_carry, use);
					income += GameManager.GameRule.CalcRouteIncome(freight_visit + (double_visit / 2), freight_carry, use);

					d.Add("%VISITOR%", string.Format("{0:n0}", v));
				}
				d.Add("%INCOME%", string.Format("{0:n0}", income));
				d.Add("%OPEN%", $"{r.Open.Year}.{r.Open.Month}.{r.Open.Day}");
				if(r.Type == Route.RouteType.HIGH)
					d.Add("%TYPE%", TextManager.Get().Text("highspeedrail"));
				else
					d.Add("%TYPE%", TextManager.Get().Text("defaultrail"));

				lbRouteInfo.Text = TextManager.Get().Text("routeinfotemp", true, d);
				tt.SetToolTip(lbRouteInfo, lbRouteInfo.Text);

				lbUseMoney.Text = TextManager.Get().Text("usemoney") + " : ";
				lbUseMoney.ForeColor = ResourceManager.Get("routeinfo.usemoney");
				lbUseMoney.Location = new Point(lbTitle.Location.X, lbUseMoney.Location.Y + lbUseMoney.Height + 5);
				lbUseMoney.Font = new Font(RTCore.Environment.Font, 20);

				nuUseMoney.Font = new Font(RTCore.Environment.Font, 13);
				nuUseMoney.Maximum = GameManager.GameRule.MaxRouteMoney;
				nuUseMoney.Value = r.UseMoney;
				nuUseMoney.Location = new Point(lbUseMoney.Location.X + lbUseMoney.Width, lbUseMoney.Location.Y + 3);
				nuUseMoney.ValueChanged += delegate
				{
					r.UseMoney = (int)nuUseMoney.Value;
					if (nuUseMoney.Value > GameManager.GameRule.MaxRouteMoneyUser)
						nuUseMoney.ForeColor = ResourceManager.Get("routeinfo.usernotpre");
					else
						nuUseMoney.ForeColor = Color.Black;
				};
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void RouteInfoPage_Paint(object sender, PaintEventArgs e)
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
