using System;
using System.Drawing;
using System.Windows.Forms;

namespace RouteTycoon.RTUI
{
	internal partial class NewsList01 : UserControl
	{
		private Image img;
		private DateTime time;
		private string msg;

		public NewsList01(RTCore.NEWS_SAV n)
		{
			try
			{
				InitializeComponent();

				msg = n.Message;
				time = n.Time;
				img = n.Data.Image;

				MouseEnter += delegate
				{
					BackColor = RTCore.ResourceManager.Get("list.newslist01.background.sel");
				};

				MouseLeave += delegate
				{
					BackColor = Color.Transparent;
				};
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, RTCore.AccessManager.AccessKey);
			}
		}

		private void NewsList01_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				e.Graphics.DrawImage(img, new Rectangle(10, 10, 80, 80));
				e.Graphics.DrawString(msg, new Font(RTCore.Environment.Font, 20), new SolidBrush(RTCore.ResourceManager.Get("list.newslist01.msg")), new Rectangle(110, 15, Width - 120, Height - 20));
				Size date_size = RTCore.Environment.CalcStringSize($"{time.Year.ToString()}.{time.Month.ToString()}.{time.Day.ToString()}", new Font(RTCore.Environment.Font, 12));
				e.Graphics.DrawString($"{time.Year.ToString()}.{time.Month.ToString()}.{time.Day.ToString()}", new Font(RTCore.Environment.Font, 12), new SolidBrush(RTCore.ResourceManager.Get("list.newslist01.date")), new Rectangle(Width - date_size.Width - 5, 5, date_size.Width, date_size.Height));
			} catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, RTCore.AccessManager.AccessKey);
			}
		}

		private void NewsList01_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				Rectangle m = new Rectangle(e.X, e.Y, 1, 1);

				if(m.IntersectsWith(new Rectangle(10, 10, 80, 80)))
				{
					new frmImage(img).ShowDialog();
				}
			}catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, RTCore.AccessManager.AccessKey);
			}
		}
	}
}
