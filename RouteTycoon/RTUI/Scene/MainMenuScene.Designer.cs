namespace RouteTycoon.RTUI
{
	partial class MainMenuScene
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

		#region 구성 요소 디자이너에서 생성한 코드

		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.lbExit = new RouteTycoon.RTCore.TextButton();
			this.lbDeveloper = new RouteTycoon.RTCore.TextButton();
			this.lbSetting = new RouteTycoon.RTCore.TextButton();
			this.lbGameStart = new RouteTycoon.RTCore.TextButton();
			this.picAtus = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picAtus)).BeginInit();
			this.SuspendLayout();
			// 
			// lbExit
			// 
			this.lbExit.AutoSize = true;
			this.lbExit.BackColor = System.Drawing.Color.Transparent;
			this.lbExit.Font = new System.Drawing.Font("굴림", 30F);
			this.lbExit.Location = new System.Drawing.Point(21, 403);
			this.lbExit.Name = "lbExit";
			this.lbExit.SelColor = System.Drawing.Color.Gray;
			this.lbExit.Size = new System.Drawing.Size(113, 40);
			this.lbExit.TabIndex = 7;
			this.lbExit.Text = "(exit)";
			this.lbExit.Click += new System.EventHandler(this.lbExit_Click);
			// 
			// lbDeveloper
			// 
			this.lbDeveloper.AutoSize = true;
			this.lbDeveloper.BackColor = System.Drawing.Color.Transparent;
			this.lbDeveloper.Font = new System.Drawing.Font("굴림", 30F);
			this.lbDeveloper.Location = new System.Drawing.Point(21, 350);
			this.lbDeveloper.Name = "lbDeveloper";
			this.lbDeveloper.SelColor = System.Drawing.Color.Gray;
			this.lbDeveloper.Size = new System.Drawing.Size(230, 40);
			this.lbDeveloper.TabIndex = 6;
			this.lbDeveloper.Text = "(developer)";
			this.lbDeveloper.Click += new System.EventHandler(this.lbDeveloper_Click);
			// 
			// lbSetting
			// 
			this.lbSetting.AutoSize = true;
			this.lbSetting.BackColor = System.Drawing.Color.Transparent;
			this.lbSetting.Font = new System.Drawing.Font("굴림", 30F);
			this.lbSetting.Location = new System.Drawing.Point(21, 295);
			this.lbSetting.Name = "lbSetting";
			this.lbSetting.SelColor = System.Drawing.Color.Gray;
			this.lbSetting.Size = new System.Drawing.Size(174, 40);
			this.lbSetting.TabIndex = 5;
			this.lbSetting.Text = "(setting)";
			this.lbSetting.Click += new System.EventHandler(this.lbSetting_Click);
			// 
			// lbGameStart
			// 
			this.lbGameStart.AutoSize = true;
			this.lbGameStart.BackColor = System.Drawing.Color.Transparent;
			this.lbGameStart.Font = new System.Drawing.Font("굴림", 30F);
			this.lbGameStart.Location = new System.Drawing.Point(21, 240);
			this.lbGameStart.Name = "lbGameStart";
			this.lbGameStart.SelColor = System.Drawing.Color.Gray;
			this.lbGameStart.Size = new System.Drawing.Size(234, 40);
			this.lbGameStart.TabIndex = 4;
			this.lbGameStart.Text = "(gamestart)";
			this.lbGameStart.Click += new System.EventHandler(this.lbGameStart_Click);
			// 
			// picAtus
			// 
			this.picAtus.Location = new System.Drawing.Point(868, 631);
			this.picAtus.Name = "picAtus";
			this.picAtus.Size = new System.Drawing.Size(96, 36);
			this.picAtus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picAtus.TabIndex = 8;
			this.picAtus.TabStop = false;
			// 
			// MainMenuScene
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Controls.Add(this.picAtus);
			this.Controls.Add(this.lbExit);
			this.Controls.Add(this.lbDeveloper);
			this.Controls.Add(this.lbSetting);
			this.Controls.Add(this.lbGameStart);
			this.DoubleBuffered = true;
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "MainMenuScene";
			this.Size = new System.Drawing.Size(980, 680);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainMenuScene_Paint);
			((System.ComponentModel.ISupportInitialize)(this.picAtus)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RTCore.TextButton lbExit;
		private RTCore.TextButton lbDeveloper;
		private RTCore.TextButton lbSetting;
		private RTCore.TextButton lbGameStart;
		private System.Windows.Forms.PictureBox picAtus;
	}
}
