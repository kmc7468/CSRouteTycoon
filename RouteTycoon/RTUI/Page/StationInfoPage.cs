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

namespace RouteTycoon.RTUI
{
	internal partial class StationInfoPage : Page
	{
		private Station s;
		private Page OldPage;

		public StationInfoPage(Station _s, Page _old)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				Title = TextManager.Get().Text("stainfo");
				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_timetable.png", 5, 7, 1, 6));

				s = _s;
				OldPage = _old;

				lbBack.Font = new Font(RTCore.Environment.Font, 20);
				lbBack.Text = TextManager.Get().Text("back");
				lbBack.ForeColor = ResourceManager.Get("stationinfo.back.unsel");
				lbBack.SelColor = ResourceManager.Get("stationinfo.back.sel");
				lbBack.Location = new Point(Width - 25 - lbBack.Width, 553);
				lbBack.Click += delegate
				{
					if (OldPage is RouteAdd_Stations_List_Page)
						(OldPage as RouteAdd_Stations_List_Page).ListDraw();
					PageManager.SetPage(OldPage, AccessManager.AccessKey);
				};
				if (OldPage == null) lbBack.Visible = false;

				lbTitle.Text = s.Name;
				lbTitle.Font = new Font(RTCore.Environment.Font, 30);
				lbTitle.ForeColor = ResourceManager.Get("stationinfo.title");

				lbStationInfo.Font = new Font(RTCore.Environment.Font, 20);
				lbStationInfo.ForeColor = ResourceManager.Get("stationinfo.info");
				lbStationInfo.Location = new Point(lbTitle.Location.X, lbTitle.Location.Y + lbTitle.Height + 2);
				Dictionary<string, string> data = new Dictionary<string, string>();
				data.Add("%OPEN%", $"{s.Open.Year}.{s.Open.Month}.{s.Open.Day}");
				data.Add("%VISTIOR%", string.Format("{0:n0}", s.Visitor));
				string rank = "";
				switch(s.Rank)
				{
					case Station.StationRank.RANK1: rank = TextManager.Get().Text("rank1"); break;
					case Station.StationRank.RANK2: rank = TextManager.Get().Text("rank2"); break;
					case Station.StationRank.RANK3: rank = TextManager.Get().Text("rank3"); break;
					case Station.StationRank.RANK4: rank = TextManager.Get().Text("rank4"); break;
					case Station.StationRank.RANK5: rank = TextManager.Get().Text("rank5"); break;
				}
				data.Add("%RANK%", rank);
				string type = "";
				switch(s.Type)
				{
					case Station.StationType.DOUBLE: type = TextManager.Get().Text("twoonly"); break;
					case Station.StationType.PASSENGER: type = TextManager.Get().Text("passengeronly"); break;
					case Station.StationType.FREIGHT: type = TextManager.Get().Text("freightonly"); break;
				}
				data.Add("%TYPE%", type);

				lbStationInfo.Text = TextManager.Get().Text("stationinfotemp", true, data);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void StationInfoPage_Paint(object sender, PaintEventArgs e)
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
