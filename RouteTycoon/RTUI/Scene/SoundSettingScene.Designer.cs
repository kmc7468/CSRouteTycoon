namespace RouteTycoon.RTUI
{
	partial class SoundSettingScene
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
			this.lbAccept = new RouteTycoon.RTCore.TextButton();
			this.lbTitle = new System.Windows.Forms.Label();
			this.cbUse = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// lbAccept
			// 
			this.lbAccept.AutoSize = true;
			this.lbAccept.BackColor = System.Drawing.Color.Transparent;
			this.lbAccept.Font = new System.Drawing.Font("굴림", 30F);
			this.lbAccept.ForeColor = System.Drawing.Color.White;
			this.lbAccept.Location = new System.Drawing.Point(781, 494);
			this.lbAccept.Name = "lbAccept";
			this.lbAccept.SelColor = System.Drawing.Color.Gray;
			this.lbAccept.Size = new System.Drawing.Size(176, 40);
			this.lbAccept.TabIndex = 6;
			this.lbAccept.Text = "(accept)";
			this.lbAccept.Click += new System.EventHandler(this.lbAccept_Click);
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.BackColor = System.Drawing.Color.Transparent;
			this.lbTitle.Font = new System.Drawing.Font("굴림", 30F);
			this.lbTitle.ForeColor = System.Drawing.Color.White;
			this.lbTitle.Location = new System.Drawing.Point(100, 132);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(162, 40);
			this.lbTitle.TabIndex = 5;
			this.lbTitle.Text = "(sound)";
			// 
			// cbUse
			// 
			this.cbUse.AutoSize = true;
			this.cbUse.BackColor = System.Drawing.Color.Transparent;
			this.cbUse.Font = new System.Drawing.Font("굴림", 20F);
			this.cbUse.ForeColor = System.Drawing.Color.White;
			this.cbUse.Location = new System.Drawing.Point(107, 193);
			this.cbUse.Name = "cbUse";
			this.cbUse.Size = new System.Drawing.Size(179, 31);
			this.cbUse.TabIndex = 7;
			this.cbUse.Text = "(playsound)";
			this.cbUse.UseVisualStyleBackColor = false;
			// 
			// SoundSettingScene
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add(this.cbUse);
			this.Controls.Add(this.lbAccept);
			this.Controls.Add(this.lbTitle);
			this.DoubleBuffered = true;
			this.Name = "SoundSettingScene";
			this.Size = new System.Drawing.Size(940, 565);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.SoundSettingScene_Paint);
			this.Resize += new System.EventHandler(this.SoundSettingScene_Resize);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RTCore.TextButton lbAccept;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.CheckBox cbUse;
	}
}
