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
	internal partial class RegionInfoPage : Page
	{
		private Graphics g;
		private RTCore.Region reg;
		private City city;

		private ComboBox cbCitys = new ComboBox();
		private ToolTip tt = new ToolTip();

		public RegionInfoPage(RTCore.Region r, City c = null)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				reg = r;
				city = c;

				Dictionary<string, string> data = new Dictionary<string, string>();
				data.Add("%NAME%", reg.Name);

				Title = TextManager.Get().Text("regioninfo", true, data);
				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_timetable.png", 5, 7, 1, 6));

				lbTitle.Text = reg.Name;
				lbTitle.Font = new Font(RTCore.Environment.Font, 30);
				lbTitle.ForeColor = ResourceManager.Get("regioninfo.title");

				ResetRegInfo();
				lbRegInfo.Font = new Font(RTCore.Environment.Font, 13);
				lbRegInfo.Location = new Point(lbTitle.Location.X, lbTitle.Location.Y + lbTitle.Height + 2);
				lbRegInfo.ForeColor = ResourceManager.Get("regioninfo.reginfo");

				cbCitys.Name = "cbCitys";
				cbCitys.Font = new Font(RTCore.Environment.Font, 20);
				cbCitys.DropDownStyle = ComboBoxStyle.DropDownList;
				cbCitys.Location = new Point(lbRegInfo.Location.X, lbRegInfo.Location.Y + lbRegInfo.Height + 6);
				foreach (var it in reg.Childs)
					cbCitys.Items.Add(it.Name);
				cbCitys.SelectedIndex = 0;
				cbCitys.Size = new Size(Width - (cbCitys.Location.X * 2), cbCitys.Height);
				cbCitys.SelectedIndexChanged += delegate
				{
					ResetCityInfo();
				};
				if (c != null)
					cbCitys.SelectedIndex = reg.Childs.IndexOf(c);
				Controls.Add(cbCitys);

				ResetCityInfo();
                lbCityInfo.Font = new Font(RTCore.Environment.Font, 12);
				lbCityInfo.Location = new Point(cbCitys.Location.X, cbCitys.Location.Y + cbCitys.Height + 10);
            }
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void ResetRegInfo()
		{
			try
			{
				Dictionary<string, string> data = new Dictionary<string, string>();

				long price = 0;
				int pre = 0;
				long sta_count = 0;
				int city_count = reg.Childs.Count;

				foreach (var it in reg.Childs)
				{
					price += it.Price;
					pre += it.Preference[0];
					sta_count += it.Childs.Count;
				}

				price /= city_count;
				pre /= city_count;

				data.Add("%PRICE%", string.Format("{0:n0}", price));
				data.Add("%PRE%", pre.ToString());
				data.Add("%CITY%", string.Format("{0:n0}", city_count));
				data.Add("%STATION%", string.Format("{0:n0}", sta_count));

				lbRegInfo.Text = TextManager.Get().Text("reginfotemp", true, data);
				tt.SetToolTip(lbRegInfo, lbRegInfo.Text);
			}catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void ResetCityInfo()
		{
			try
			{
				City c = reg.Childs[cbCitys.SelectedIndex];

				Dictionary<string, string> data = new Dictionary<string, string>();

				data.Add("%PRICE%", string.Format("{0:n0}", c.Price));
				data.Add("%PRE%", c.Preference[0].ToString());
				data.Add("%STATION%", string.Format("{0:n0}", c.Childs.Count));
				data.Add("%INCOME%", string.Format("{0:n0}", c.GetIncome(GameManager.Company)));
				data.Add("%CITY_DESCRIPTION%", c.Description);

				lbCityInfo.Text = TextManager.Get().Text("cityinfotemp", true, data);
				tt.SetToolTip(lbCityInfo, lbCityInfo.Text);
			}catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void RegionInfoPage_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Draw(e);

				g = e.Graphics;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
