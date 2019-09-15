using System;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class OddEvenPage : Page
	{
		private int num = 0;
		private int success = 0, fail = 0;

		private void OddEvenPage_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Draw(e);

				Font f = new Font(RTCore.Environment.Font, 40);
				SizeF s = RTCore.Environment.CalcStringSize(num.ToString(), f);

				e.Graphics.DrawString(num.ToString(), f, Brushes.Black, new PointF(ClientRectangle.Width / 2 - s.Width / 2, 300));
			}catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public OddEvenPage()
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				picBlock.Image = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "rt_icon_img.png", 5, 7, 1, 6));
				Font f = new Font(RTCore.Environment.Font, 30);
				lbEven.Font = f;
				lbOdd.Font = f;
				lbNewGame.Font = f;
				lbScore.Font = new Font(RTCore.Environment.Font, 20);

				NewGame();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbNewGame_Click(object sender, EventArgs e)
		{
			try
			{
				lbNewGame.Visible = false;
				lbOdd.Visible = lbEven.Visible = true;

				NewGame();
				picBlock.Visible = true;
			}catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbOdd_Click(object sender, EventArgs e)
		{
			try
			{
				picBlock.Visible = false;

				if (num % 2 != 0)
				{
					success++;
					MessageBox.Show("정답!", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}else
				{
					fail++;
					MessageBox.Show("오답!", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				lbScore.Text = $"O: {success}   X: {fail}";

				lbOdd.Visible = lbEven.Visible = false;
				lbNewGame.Visible = true;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbEven_Click(object sender, EventArgs e)
		{
			try
			{
				picBlock.Visible = false;

				if (num % 2 == 0)
				{
					success++;
					MessageBox.Show("정답!", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					fail++;
					MessageBox.Show("오답!", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				lbScore.Text = $"O: {success}   X: {fail}";

				lbOdd.Visible = lbEven.Visible = false;
				lbNewGame.Visible = true;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void NewGame()
		{
			try
			{
				Random rd = new Random(DateTime.Now.Millisecond);

				int old = num;

				do
				{
					old = num;
					num = rd.Next(0, 150);
				} while (num == old);
			}catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
