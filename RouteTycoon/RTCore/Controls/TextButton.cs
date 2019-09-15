using System;
using System.Drawing;
using System.Windows.Forms;

namespace RouteTycoon.RTCore
{
	public class TextButton : Label
	{
		private Color orginal;

		public Color SelColor
		{
			get;
			set;
		} = Color.Gray;
			
		public TextButton() : base()
		{
			try
			{
				MouseEnter += TextButton_MouseEnter;
				MouseLeave += TextButton_MouseLeave;
			}
			catch(Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
			}
		}

		private void TextButton_MouseLeave(object sender, EventArgs e)
		{
			try
			{
				ForeColor = orginal;
			}
			catch(Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
			
		}

		private void TextButton_MouseEnter(object sender, EventArgs e)
		{
			try
			{
				orginal = ForeColor;
				ForeColor = SelColor;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
