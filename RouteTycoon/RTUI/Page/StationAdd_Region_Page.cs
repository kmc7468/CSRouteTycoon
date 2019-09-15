using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class StationAdd_Region_Page : Page
	{
		private Graphics g;
		private Station s;
		private Page OldPage;

		private ComboBox cbRegion = new ComboBox();
		private ComboBox cbCity = new ComboBox();
		private Label lbSub = new Label() { AutoSize = true, Font = new Font(RTCore.Environment.Font, 14), Text = "" };

		public StationAdd_Region_Page(Station _s, Page p)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				Title = TextManager.Get().Text("addstn");
				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_timetable.png", 5, 7, 1, 6));

				s = _s;
				OldPage = p;

				cbRegion.Name = "cbRegion";
				cbRegion.Font = new Font(RTCore.Environment.Font, 20);
				cbRegion.Size = new Size(500, cbRegion.Height);
				foreach (var it in GameManager.Map.Regions)
				{
					if (it.Childs.Count == 0) continue;
					cbRegion.Items.Add(it.Name);
				}
				if (s.Parent != null) cbRegion.SelectedIndex = GameManager.Map.Regions.IndexOf(s.Parent.Parent);
				else if (GameManager.LastSelectRegion != -1) cbRegion.SelectedIndex = GameManager.LastSelectRegion;
				else cbRegion.SelectedIndex = 0;
				cbRegion.DropDownStyle = ComboBoxStyle.DropDownList;
				cbRegion.Location = new Point((Width / 2) - 250, (Height / 2) - 15);
				Controls.Add(cbRegion);

				cbCity.Name = "cbCity";
				cbCity.Font = new Font(RTCore.Environment.Font, 20);
				cbCity.Size = new Size(500, cbRegion.Height);
				cbCity.Items.Clear();
				foreach (var it in GameManager.Map.Regions[cbRegion.SelectedIndex].Childs)
					cbCity.Items.Add(it.Name);
				if (s.Parent != null) cbCity.SelectedIndex = GameManager.Map.Regions[cbRegion.SelectedIndex].Childs.IndexOf(s.Parent);
				else if (GameManager.LastSelectCity != -1) cbCity.SelectedIndex = GameManager.LastSelectCity;
				else cbCity.SelectedIndex = 0;
				cbCity.DropDownStyle = ComboBoxStyle.DropDownList;
				cbCity.Location = new Point(cbRegion.Location.X, cbRegion.Location.Y + 10 + cbRegion.Height);
				Controls.Add(cbCity);

				Dictionary<string, string> data = new Dictionary<string, string>();
				data.Add("%CITYPRICE_TEXT%", TextManager.Get().Text("cityprice"));
				data.Add("%BUILDPRICE_TEXT%", TextManager.Get().Text("buildprice"));
				data.Add("%CITYPRICE%", string.Format("{0:n0}", GameManager.Map.Regions[cbRegion.SelectedIndex].Childs[cbCity.SelectedIndex].Price));
				data.Add("%BUILDPRICE%", string.Format("{0:n0}", GameManager.GameRule.CalcStationPrice(GameManager.Map.Regions[cbRegion.SelectedIndex].Childs[cbCity.SelectedIndex], 500000)));
				lbSub.Text = TextManager.Get().Text("buildpricetemp", true, data);

				s.Parent = GameManager.Map.Regions[cbRegion.SelectedIndex].Childs[cbCity.SelectedIndex];

				cbRegion.SelectedIndexChanged += delegate
				{
					cbCity.Items.Clear();
					foreach (var it in GameManager.Map.Regions[cbRegion.SelectedIndex].Childs)
						cbCity.Items.Add(it.Name);
					cbCity.SelectedIndex = 0;
					GameManager.LastSelectRegion = cbRegion.SelectedIndex;
				};

				cbCity.SelectedIndexChanged += delegate
				{
					Dictionary<string, string> datas = new Dictionary<string, string>();
					datas.Add("%CITYPRICE_TEXT%", TextManager.Get().Text("cityprice"));
					datas.Add("%BUILDPRICE_TEXT%", TextManager.Get().Text("buildprice"));
					datas.Add("%CITYPRICE%", string.Format("{0:n0}", GameManager.Map.Regions[cbRegion.SelectedIndex].Childs[cbCity.SelectedIndex].Price));
					datas.Add("%BUILDPRICE%", string.Format("{0:n0}", GameManager.GameRule.CalcStationPrice(GameManager.Map.Regions[cbRegion.SelectedIndex].Childs[cbCity.SelectedIndex], 500000)));
					lbSub.Text = TextManager.Get().Text("buildpricetemp", true, datas);

					s.Parent = GameManager.Map.Regions[cbRegion.SelectedIndex].Childs[cbCity.SelectedIndex];

					GameManager.LastSelectCity = cbCity.SelectedIndex;
				};

				lbSub.Location = new Point(cbCity.Location.X, cbCity.Location.Y + cbCity.Height + 10);
				Controls.Add(lbSub);

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
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void StationAdd_Region_Page_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Draw(e);

				g = e.Graphics;

				g.DrawString(TextManager.Get().Text("location"), new Font(RTCore.Environment.Font, 40), new SolidBrush(ResourceManager.Get("stationadd.title")), RTCore.Environment.CalcRectangle(new Point(Width / 2, (Height / 2) - 65), RTCore.Environment.CalcStringSize(TextManager.Get().Text("location"), new Font(RTCore.Environment.Font, 40))));
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
				PageManager.SetPage(new StationAdd_Name_Page(OldPage, s), AccessManager.AccessKey);
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
				if (s.Name.Trim() == string.Empty) return;
				foreach (var it in GameManager.GetAllStations())
				{
					if (it.Name == s.Name.Trim() && it.Parent == s.Parent)
					{
						string txt = TextManager.Get().Text("truestnname");
						MessageBox.Show(txt, "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						return;
					}
				}

				PageManager.SetPage(new StationAdd_Etc_Page(s, OldPage), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
