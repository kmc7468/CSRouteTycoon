namespace RTMapTool
{
	partial class frmCityLocation
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
			this.UIRegion1 = new System.Windows.Forms.Panel();
			this.lbUIReigon1 = new System.Windows.Forms.Label();
			this.UIRegion2 = new System.Windows.Forms.Panel();
			this.UIRegion1.SuspendLayout();
			this.SuspendLayout();
			// 
			// UIRegion1
			// 
			this.UIRegion1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.UIRegion1.Controls.Add(this.lbUIReigon1);
			this.UIRegion1.Dock = System.Windows.Forms.DockStyle.Top;
			this.UIRegion1.Location = new System.Drawing.Point(0, 0);
			this.UIRegion1.Name = "UIRegion1";
			this.UIRegion1.Size = new System.Drawing.Size(980, 40);
			this.UIRegion1.TabIndex = 5;
			// 
			// lbUIReigon1
			// 
			this.lbUIReigon1.AutoSize = true;
			this.lbUIReigon1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lbUIReigon1.ForeColor = System.Drawing.Color.White;
			this.lbUIReigon1.Location = new System.Drawing.Point(421, 10);
			this.lbUIReigon1.Name = "lbUIReigon1";
			this.lbUIReigon1.Size = new System.Drawing.Size(139, 19);
			this.lbUIReigon1.TabIndex = 0;
			this.lbUIReigon1.Text = "UI 영역입니다.";
			// 
			// UIRegion2
			// 
			this.UIRegion2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.UIRegion2.Location = new System.Drawing.Point(0, 39);
			this.UIRegion2.Name = "UIRegion2";
			this.UIRegion2.Size = new System.Drawing.Size(100, 641);
			this.UIRegion2.TabIndex = 6;
			// 
			// frmCityLocation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(980, 680);
			this.Controls.Add(this.UIRegion1);
			this.Controls.Add(this.UIRegion2);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCityLocation";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "원하는 위치를 마우스로 누르십시오.";
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmCityLocation_MouseClick);
			this.UIRegion1.ResumeLayout(false);
			this.UIRegion1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel UIRegion1;
		private System.Windows.Forms.Label lbUIReigon1;
		private System.Windows.Forms.Panel UIRegion2;
	}
}