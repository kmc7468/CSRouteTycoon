using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class LocomotiveList01 : UserControl
	{
		public bool isSelect = false;
		public Locomotive car = null;
		private TrainList_OKAdd_Locomotive_Page page;

		public LocomotiveList01(Locomotive _car, TrainList_OKAdd_Locomotive_Page _page)
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

				BackColor = ResourceManager.Get("list.locomotivelist01.background.sel");
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
					BackColor = ResourceManager.Get("list.locomotivelist01.background.select");
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

				e.Graphics.DrawString(car.Name, new Font(RTCore.Environment.Font, 20), new SolidBrush(ResourceManager.Get("list.locomotivelist01.texts")), new Rectangle(200, 20, Width - 220, 60));

				Dictionary<string, string> data = new Dictionary<string, string>();
				data.Add("%CARRY%", string.Format("{0:n0}", car.Carrying));
				string rank = "";
				switch(car.Rank)
				{
					case Locomotive.LocomotiveRank.HIGH: rank = TextManager.Get().Text("highloc"); break;
					case Locomotive.LocomotiveRank.DEFAULT: rank = TextManager.Get().Text("defloc"); break;
				}
				data.Add("%RANK%", rank);
				data.Add("%SPEED%", string.Format("{0:n0}", car.Speed));

				string infotext = TextManager.Get().Text("locinfotemp", true, data);

				e.Graphics.DrawString(infotext, new Font(RTCore.Environment.Font, 12), new SolidBrush(ResourceManager.Get("list.locomotivelist01.texts")), new Rectangle(220, 65, Width - 240, Height - 80));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}