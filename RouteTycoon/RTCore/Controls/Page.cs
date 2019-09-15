using System;
using System.Drawing;
using System.Windows.Forms;

namespace RouteTycoon.RTCore
{
	public class Page : UserControl
	{
		private int X, Y;
		private Point Loc;

		private Image imgClose, imgCloseSel;

		public Image IconImg
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		} = "";

		public virtual void OnLoad() { }
		public virtual void OnClose() { }

		protected void Draw(PaintEventArgs e)
		{
			DoubleBuffered = true;

			e.Graphics.DrawImage(Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "play_topbar.png", 5, 7, 1, 6)), 0, 0, Width, 40);
			if(IconImg != null) e.Graphics.DrawImage(IconImg, 760, 5, 30, 30);
			if (Title != "")
			{
				Size s = Environment.CalcStringSize(Title, new Font(Environment.Font, 14));
				e.Graphics.DrawString(Title, new Font(Environment.Font, 14), new SolidBrush(ResourceManager.Get("page.title")), new Rectangle(new Point(Width - 45 - s.Width, 6),s));
			}
        }

		protected void AddControl(Page p)
		{
			PictureBox pb = new PictureBox();
			pb.Name = "pbClose";
			pb.Size = new Size(20, 20);
			pb.Location = new Point(10, 10);
			pb.SizeMode = PictureBoxSizeMode.StretchImage;
			imgClose = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_close.png", 5, 7, 1, 6));
			imgCloseSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_close_sel.png", 5, 7, 1, 6));
			pb.MouseEnter += Pb_MouseEnter;
			pb.MouseLeave += Pb_MouseLeave;
			pb.Click += delegate
			{
				PageManager.Close(false, AccessManager.AccessKey);
			};
			pb.BackColor = Color.Transparent;
			pb.Image = imgClose;
			p.Controls.Add(pb);

			p.MouseDown += Page_MouseDown;
			p.MouseMove += Page_MouseMove;
		}

		private void Pb_MouseLeave(object sender, EventArgs e)
		{
			(sender as PictureBox).Image = imgClose;
		}

		private void Pb_MouseEnter(object sender, EventArgs e)
		{
			(sender as PictureBox).Image = imgCloseSel;
		}

		private void Page_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				Rectangle m = new Rectangle(e.X, e.Y, 1, 1);
				if (new Rectangle(0, 0, 800, 40).IntersectsWith(m))
				{
					X = MousePosition.X - PageManager.PageForm.Location.X;
					Y = MousePosition.Y - PageManager.PageForm.Location.Y;
				}
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void Page_MouseMove(object sender, MouseEventArgs e)
		{
			try
			{
				Rectangle m = new Rectangle(e.X, e.Y, 1, 1);
				if (new Rectangle(0, 0, 800, 40).IntersectsWith(m))
				{
					if (e.Button == MouseButtons.Left)
					{
						Loc = MousePosition;
						Loc.X -= X;
						Loc.Y -= Y;
						PageManager.PageForm.Location = Loc;
					}
				}
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
