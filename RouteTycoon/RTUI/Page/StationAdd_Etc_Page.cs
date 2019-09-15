using System;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class StationAdd_Etc_Page : Page
	{
		private Graphics g;
		private Station s;
		private Page OldPage;

		private ComboBox cbRank = new ComboBox();
		private ComboBox cbType = new ComboBox();

		public StationAdd_Etc_Page(Station _s, Page _p)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				Title = TextManager.Get().Text("addstn");
				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_timetable.png", 5, 7, 1, 6));

				s = _s;
				OldPage = _p;

				lbAdd.Font = new Font(RTCore.Environment.Font, 20);
				lbAdd.Text = TextManager.Get().Text("add");
				lbAdd.ForeColor = ResourceManager.Get("stationadd.add.unsel");
				lbAdd.SelColor = ResourceManager.Get("stationadd.add.sel");
				lbAdd.Location = new Point(Width - 25 - lbAdd.Width, 553);

				lbBack.Font = new Font(RTCore.Environment.Font, 20);
				lbBack.Text = TextManager.Get().Text("back");
				lbBack.ForeColor = ResourceManager.Get("stationadd.back.unsel");
				lbBack.SelColor = ResourceManager.Get("stationadd.back.sel");
				lbBack.Location = new Point(25, 553);
				
				cbRank.Name = "cbRank";
				cbRank.Font = new Font(RTCore.Environment.Font, 20);
				cbRank.Size = new Size(500, cbRank.Height);
				cbRank.Items.Add(TextManager.Get().Text("rank1"));
				cbRank.Items.Add(TextManager.Get().Text("rank2"));
				cbRank.Items.Add(TextManager.Get().Text("rank3"));
				cbRank.Items.Add(TextManager.Get().Text("rank4"));
				cbRank.Items.Add(TextManager.Get().Text("rank5"));
				cbRank.SelectedIndex = (int)s.Rank;
				cbRank.DropDownStyle = ComboBoxStyle.DropDownList;
				cbRank.Location = new Point((Width / 2) - 250, (Height / 2) - 50);
				Controls.Add(cbRank);

				cbType.Name = "cbType";
				cbType.Font = new Font(RTCore.Environment.Font, 20);
				cbType.Size = new Size(500, cbRank.Height);
				cbType.Items.Clear();
				cbType.Items.Add(TextManager.Get().Text("passengeronly"));
				cbType.Items.Add(TextManager.Get().Text("freightonly"));
				cbType.Items.Add(TextManager.Get().Text("twoonly"));
				cbType.SelectedIndex = (int)s.Type;
				cbType.DropDownStyle = ComboBoxStyle.DropDownList;
				cbType.Location = new Point(cbRank.Location.X, cbRank.Location.Y + cbRank.Height + 80);
				Controls.Add(cbType);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void StationAdd_Etc_Page_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Draw(e);

				g = e.Graphics;

				g.DrawString(TextManager.Get().Text("stationrank"), new Font(RTCore.Environment.Font, 40), new SolidBrush(ResourceManager.Get("stationadd.title")), RTCore.Environment.CalcRectangle(new Point(Width / 2, (Height / 2) - 90), RTCore.Environment.CalcStringSize(TextManager.Get().Text("stationrank"), new Font(RTCore.Environment.Font, 40))));
				g.DrawString(TextManager.Get().Text("stationtype"), new Font(RTCore.Environment.Font, 40), new SolidBrush(ResourceManager.Get("stationadd.title")), RTCore.Environment.CalcRectangle(new Point(Width / 2, (Height / 2) + 40), RTCore.Environment.CalcStringSize(TextManager.Get().Text("stationtype"), new Font(RTCore.Environment.Font, 40))));
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
				PageManager.SetPage(new StationAdd_Region_Page(s, OldPage), AccessManager.AccessKey);
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
				long price = GameManager.GameRule.CalcStationPrice(s.Parent, 500000);
				decimal money = GameManager.Company.Money - price;
				if(money <= 0)
				{
					MessageBox.Show(TextManager.Get().Text("nomoney"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return;
				}

				s.Rank = (Station.StationRank)cbRank.SelectedIndex;
				s.Type = (Station.StationType)cbType.SelectedIndex;
				s.Open = GameManager.Time;
				s.Parent.Childs.Add(s);

				int pluspre = 0;
				switch(s.Rank)
				{
					case Station.StationRank.RANK1: pluspre += 5; break;
					case Station.StationRank.RANK2: pluspre += 4; break;
					case Station.StationRank.RANK3: pluspre += 3; break;
					case Station.StationRank.RANK4: pluspre += 2; break;
					case Station.StationRank.RANK5: pluspre += 1; break;
				}

				switch(s.Type)
				{
					case Station.StationType.PASSENGER: pluspre += 1; break;
					case Station.StationType.FREIGHT: pluspre += 0; break;
					case Station.StationType.DOUBLE: pluspre += 2; break;
				}

				s.Parent.Preference[0] += pluspre;
				if (s.Parent.Preference[0] >= 100) s.Parent.Preference[0] = 100;

				GameManager.Company.Money -= price;

				PluginManager.AddedStation(s);
				if (OldPage != null)
				{
					if(OldPage is RouteAdd_Stations_List_Page)
						(OldPage as RouteAdd_Stations_List_Page).ListDraw();

					PageManager.SetPage(OldPage, AccessManager.AccessKey);
				}
				else PageManager.Close(false, AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
