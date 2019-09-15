namespace RTMapTool
{
	partial class frmMain
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.UIRegion1 = new System.Windows.Forms.Panel();
			this.lbUIReigon1 = new System.Windows.Forms.Label();
			this.UIRegion2 = new System.Windows.Forms.Panel();
			this.timer = new System.Windows.Forms.Timer(this.components);
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
			this.UIRegion1.TabIndex = 3;
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
			this.UIRegion2.TabIndex = 4;
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Interval = 1;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(980, 680);
			this.Controls.Add(this.UIRegion1);
			this.Controls.Add(this.UIRegion2);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RTMapTool 1.0.0.8";
			this.Activated += new System.EventHandler(this.frmMain_Activated);
			this.Deactivate += new System.EventHandler(this.frmMain_Deactivate);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.LocationChanged += new System.EventHandler(this.frmMain_LocationChanged);
			this.UIRegion1.ResumeLayout(false);
			this.UIRegion1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Panel UIRegion1;
		private System.Windows.Forms.Label lbUIReigon1;
		private System.Windows.Forms.Panel UIRegion2;
		private System.Windows.Forms.Timer timer;
	}
}

