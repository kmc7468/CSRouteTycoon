using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class EngineCoachList01 : UserControl
	{
		public bool isSelect = false;
		public EngineCoach car = null;
		private TrainList_OKAdd_EngineCoach_Page page = null;

		public EngineCoachList01(EngineCoach _car, TrainList_OKAdd_EngineCoach_Page _page)
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

		private void EngineCoachList01_MouseEnter(object sender, EventArgs e)
		{
			try
			{
				if (isSelect) return;

				BackColor = ResourceManager.Get("list.enginecoachlist01.background.sel");
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void EngineCoachList01_MouseLeave(object sender, EventArgs e)
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

		private void EngineCoachList01_Click(object sender, EventArgs e)
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
					BackColor = ResourceManager.Get("list.enginecoachlist01.background.select");
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void EngineCoachList01_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				e.Graphics.DrawImage(car.Image, new Rectangle(20, 20, 160, 160));

				e.Graphics.DrawString(car.Name, new Font(RTCore.Environment.Font, 20), new SolidBrush(ResourceManager.Get("list.enginecoachlist01.texts")), new Rectangle(200, 20, Width - 220, 60));

				Dictionary<string, string> data = new Dictionary<string, string>();
				data.Add("%LOC_CARRY%", string.Format("{0:n0}", car.Locomotive.Carrying));
				string loc_rank = "";
				switch(car.Locomotive.Rank)
				{
					case EngineCoach.LocomotiveData.LocomotiveRank.HIGH: loc_rank = TextManager.Get().Text("highloc"); break;
					case EngineCoach.LocomotiveData.LocomotiveRank.DEFAULT: loc_rank = TextManager.Get().Text("defloc"); break;
				}
				data.Add("%LOC_RANK%", loc_rank);
				data.Add("%LOC_SPEED%", string.Format("{0:n0}", car.Locomotive.Speed));
				string car_rank = "";
				switch(car.Coach.Rank)
				{
					case EngineCoach.CoachData.CoachRank.FREIGHT: car_rank = TextManager.Get().Text("freightcar"); break;
					case EngineCoach.CoachData.CoachRank.ECONOMY: car_rank = TextManager.Get().Text("economycar"); break;
					case EngineCoach.CoachData.CoachRank.FIRST: car_rank = TextManager.Get().Text("firstcar"); break;
				}
				data.Add("%CAR_RANK%", string.Format("{0:n0}", car_rank));
				data.Add("%CAR_CARRY%", string.Format("{0:n0}", car.Coach.Carrying));

				string infotext = TextManager.Get().Text("enginecoachinfotemp", true, data);

				e.Graphics.DrawString(infotext, new Font(RTCore.Environment.Font, 12), new SolidBrush(ResourceManager.Get("list.enginecoachlist01.texts")), new Rectangle(220, 65, Width - 240, Height - 80));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}