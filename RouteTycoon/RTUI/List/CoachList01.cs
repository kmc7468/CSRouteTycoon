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
	internal partial class CarriageList01 : UserControl
	{
		public bool isSelect = false;
		public Coach car = null;
		private TrainList_OKAdd_Coach_Page page;

		public CarriageList01(Coach _car, TrainList_OKAdd_Coach_Page _page)
		{
			try
			{
				InitializeComponent();

				car = _car;
				page = _page;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void LocomotiveList01_MouseEnter(object sender, EventArgs e)
		{
			try
			{
				if (isSelect) return;

				BackColor = ResourceManager.Get("list.coachlist01.background.sel");
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void LocomotiveList01_MouseLeave(object sender, EventArgs e)
		{
			try
			{
				if (isSelect) return;

				BackColor = Color.Transparent;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void LocomotiveList01_Click(object sender, EventArgs e)
		{
			try
			{
				if (isSelect)
				{
					isSelect = false;
					BackColor = Color.Transparent;
				}
				else
				{
					page.SelectChange(this);
					isSelect = true;
					BackColor = ResourceManager.Get("list.coachlist01.background.select");
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void LocomotiveList01_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				e.Graphics.DrawImage(car.Image, new Rectangle(20, 20, 160, 160));

				e.Graphics.DrawString(car.Name, new Font(RTCore.Environment.Font, 20), new SolidBrush(ResourceManager.Get("list.coachlist01.texts")), new Rectangle(200, 20, Width - 220, 60));

				Dictionary<string, string> data = new Dictionary<string, string>();
				data.Add("%CARRY%", string.Format("{0:n0}", car.Carrying));
				string rank = "";
				switch(car.Rank)
				{
					case Coach.CarriageRank.FIRST: rank = TextManager.Get().Text("firstcar"); break;
					case Coach.CarriageRank.ECONOMY: rank = TextManager.Get().Text("economycar"); break;
					case Coach.CarriageRank.FREIGHT: rank = TextManager.Get().Text("freightcar"); break;
				}

				data.Add("%RANK%", rank);

				string infotext = TextManager.Get().Text("carinfotemp", true, data);

				e.Graphics.DrawString(infotext, new Font(RTCore.Environment.Font, 12), new SolidBrush(ResourceManager.Get("list.coachlist01.texts")), new Rectangle(220, 65, Width - 240, Height - 80));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}