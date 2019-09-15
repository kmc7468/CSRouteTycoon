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
using RouteTycoon.RTAPI;

namespace RouteTycoon.RTUI
{
	internal partial class AchievementList01 : UserControl
	{
		public Achievement a;
		private string isclear = "";
		public AchievementList01(Achievement _a, string _isclear)
		{
			try
			{
				InitializeComponent();

				a = _a;
				isclear = _isclear;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void AchievementList01_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				string txt = $"{a.Name} ({isclear})\n{a.Description}";

				Size t_size = RTCore.Environment.CalcStringSize(txt, new Font(RTCore.Environment.Font, 12));
				Point t_loc = RTCore.Environment.CalcRectangle(new Point(8 + (t_size.Width / 2), Height / 2), t_size).Location.ToPoint();

				e.Graphics.DrawString(txt, new Font(RTCore.Environment.Font, 12), new SolidBrush(ResourceManager.Get("list.achievementlist01.texts")), new RectangleF(t_loc.X, t_loc.Y, 644, (Height - t_loc.Y)));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void AchievementList01_MouseEnter(object sender, EventArgs e)
		{
			try
			{
				BackColor = ResourceManager.Get("list.achievementlist01.background.sel");
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void AchievementList01_MouseLeave(object sender, EventArgs e)
		{
			try
			{
				BackColor = Color.Transparent;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
