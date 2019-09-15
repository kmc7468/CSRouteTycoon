namespace RouteTycoon.RTUI
{
	partial class UpdateSettingScene
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
			this.lbBack = new RouteTycoon.RTCore.TextButton();
			this.lbTitle = new System.Windows.Forms.Label();
			this.lbInfo = new System.Windows.Forms.Label();
			this.lbUpdate = new RouteTycoon.RTCore.TextButton();
			this.SuspendLayout();
			// 
			// lbBack
			// 
			this.lbBack.AutoSize = true;
			this.lbBack.BackColor = System.Drawing.Color.Transparent;
			this.lbBack.Font = new System.Drawing.Font("굴림", 30F);
			this.lbBack.ForeColor = System.Drawing.Color.White;
			this.lbBack.Location = new System.Drawing.Point(781, 494);
			this.lbBack.Name = "lbBack";
			this.lbBack.SelColor = System.Drawing.Color.Gray;
			this.lbBack.Size = new System.Drawing.Size(137, 40);
			this.lbBack.TabIndex = 4;
			this.lbBack.Text = "(back)";
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.BackColor = System.Drawing.Color.Transparent;
			this.lbTitle.Font = new System.Drawing.Font("굴림", 30F);
			this.lbTitle.ForeColor = System.Drawing.Color.White;
			this.lbTitle.Location = new System.Drawing.Point(100, 132);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(177, 40);
			this.lbTitle.TabIndex = 3;
			this.lbTitle.Text = "(update)";
			// 
			// lbInfo
			// 
			this.lbInfo.AutoSize = true;
			this.lbInfo.BackColor = System.Drawing.Color.Transparent;
			this.lbInfo.Font = new System.Drawing.Font("굴림", 20F);
			this.lbInfo.ForeColor = System.Drawing.Color.White;
			this.lbInfo.Location = new System.Drawing.Point(176, 203);
			this.lbInfo.Name = "lbInfo";
			this.lbInfo.Size = new System.Drawing.Size(165, 27);
			this.lbInfo.TabIndex = 5;
			this.lbInfo.Text = "(updateinfo)";
			// 
			// lbUpdate
			// 
			this.lbUpdate.AutoSize = true;
			this.lbUpdate.BackColor = System.Drawing.Color.Transparent;
			this.lbUpdate.Font = new System.Drawing.Font("굴림", 20F);
			this.lbUpdate.ForeColor = System.Drawing.Color.White;
			this.lbUpdate.Location = new System.Drawing.Point(176, 254);
			this.lbUpdate.Name = "lbUpdate";
			this.lbUpdate.SelColor = System.Drawing.Color.Gray;
			this.lbUpdate.Size = new System.Drawing.Size(117, 27);
			this.lbUpdate.TabIndex = 6;
			this.lbUpdate.Text = "(update)";
			this.lbUpdate.Click += new System.EventHandler(this.lbUpdate_Click);
			// 
			// UpdateSettingScene
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add(this.lbUpdate);
			this.Controls.Add(this.lbInfo);
			this.Controls.Add(this.lbBack);
			this.Controls.Add(this.lbTitle);
			this.DoubleBuffered = true;
			this.Name = "UpdateSettingScene";
			this.Size = new System.Drawing.Size(940, 565);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdateSettingScene_Paint);
			this.Resize += new System.EventHandler(this.UpdateSettingScene_Resize);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RTCore.TextButton lbBack;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Label lbInfo;
		private RTCore.TextButton lbUpdate;
	}
}
