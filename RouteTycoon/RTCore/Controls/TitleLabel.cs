using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RouteTycoon.RTCore
{
	public class TitleLabel : Label
	{
		private Bitmap _haloBmp = null;

		public TitleLabel() : base()
		{
		}

		public string HaloTextStr
		{
			set
			{
				Text = value;

				_haloBmp = HaloText();
			}
			get
			{
				return Text;
			}
		}

		private Bitmap HaloText()
		{
			try
			{
				Graphics G = CreateGraphics();
				SizeF size = G.MeasureString(Text, Font, ClientSize);
				RectangleF rect = new RectangleF(0, 0, size.Width, size.Height);
				G.Dispose();

				Bitmap haloBmp = new Bitmap((int)size.Width / 5, (int)size.Height / 5);
				G = Graphics.FromImage(haloBmp);
				G.SmoothingMode = SmoothingMode.AntiAlias;

				Matrix mx = new Matrix(1f / 5, 0, 0, 1f / 5, -(1f / 5), -(1f / 5));
				G.Transform = mx;

				GraphicsPath path = new GraphicsPath();
				path.AddString(Text, Font.FontFamily, (int)Font.Style, Font.Size, rect, StringFormat.GenericTypographic);

				G.DrawPath(Pens.Silver, path);
				G.FillPath(Brushes.Silver, path);
				G.Dispose();

				Bitmap bmp = new Bitmap((int)rect.Width, (int)rect.Height);
				G = Graphics.FromImage(bmp);
				G.SmoothingMode = SmoothingMode.AntiAlias;
				G.InterpolationMode = InterpolationMode.HighQualityBicubic;
				rect.Offset(1, 1);
				G.DrawImage(haloBmp, rect);
				G.FillPath(new SolidBrush(ForeColor), path);
				G.Dispose();

				path.Dispose();

				return bmp;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
				return null;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			try
			{
				if (_haloBmp != null)
				{
					e.Graphics.SmoothingMode =
					   System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

					e.Graphics.DrawImageUnscaled(_haloBmp, 0, 0);
				}
				else
				{
					base.OnPaint(e);
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}