namespace RouteTycoon.RTUI
{
	partial class frmError
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel = new System.Windows.Forms.Panel();
			this.lbText = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel
			// 
			this.panel.AutoScroll = true;
			this.panel.BackColor = System.Drawing.Color.Transparent;
			this.panel.Controls.Add(this.lbText);
			this.panel.Location = new System.Drawing.Point(23, 134);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(594, 250);
			this.panel.TabIndex = 0;
			// 
			// lbText
			// 
			this.lbText.AutoSize = true;
			this.lbText.Font = new System.Drawing.Font("굴림", 12F);
			this.lbText.Location = new System.Drawing.Point(9, 10);
			this.lbText.Name = "lbText";
			this.lbText.Size = new System.Drawing.Size(40, 16);
			this.lbText.TabIndex = 0;
			this.lbText.Text = "Text";
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(504, 390);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(113, 34);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "확인";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// frmError
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(640, 480);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.panel);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmError";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmError_FormClosed);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmError_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmError_MouseMove);
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Label lbText;
		private System.Windows.Forms.Button btnClose;
	}
}