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
	internal partial class CompanyList01 : UserControl
	{
		public Company comp = null;
		private Graphics g;

		public CompanyList01(Company _comp)
		{
			try
			{
				InitializeComponent();

				comp = _comp;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void CompanyList01_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				g = e.Graphics;

				g.DrawString($"{comp.Name} - {comp.PresidentName}", new Font(RTCore.Environment.Font, 15), new SolidBrush(ResourceManager.Get("list.companylist01.text")), new RectangleF(8, 7, 644, Height - 7));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void CompanyList01_MouseEnter(object sender, EventArgs e)
		{
			try
			{
				BackColor = ResourceManager.Get("list.companylist01.background.sel");
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void CompanyList01_MouseLeave(object sender, EventArgs e)
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
