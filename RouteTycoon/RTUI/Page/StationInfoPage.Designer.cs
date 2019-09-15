namespace RouteTycoon.RTUI
{
	partial class StationInfoPage
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
			this.lbStationInfo = new System.Windows.Forms.Label();
			this.lbTitle = new System.Windows.Forms.Label();
			this.lbBack = new RouteTycoon.RTCore.TextButton();
			this.SuspendLayout();
			// 
			// lbStationInfo
			// 
			this.lbStationInfo.AutoSize = true;
			this.lbStationInfo.Font = new System.Drawing.Font("굴림", 20F);
			this.lbStationInfo.Location = new System.Drawing.Point(34, 119);
			this.lbStationInfo.Name = "lbStationInfo";
			this.lbStationInfo.Size = new System.Drawing.Size(226, 27);
			this.lbStationInfo.TabIndex = 15;
			this.lbStationInfo.Text = "(stationinfotemp)";
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Font = new System.Drawing.Font("굴림", 30F);
			this.lbTitle.Location = new System.Drawing.Point(27, 62);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(386, 40);
			this.lbTitle.TabIndex = 14;
			this.lbTitle.Text = "%STATION_NAME%";
			// 
			// lbBack
			// 
			this.lbBack.AutoSize = true;
			this.lbBack.Font = new System.Drawing.Font("굴림", 20F);
			this.lbBack.Location = new System.Drawing.Point(685, 559);
			this.lbBack.Name = "lbBack";
			this.lbBack.SelColor = System.Drawing.Color.Gray;
			this.lbBack.Size = new System.Drawing.Size(92, 27);
			this.lbBack.TabIndex = 16;
			this.lbBack.Text = "(back)";
			// 
			// StationInfoPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.lbBack);
			this.Controls.Add(this.lbStationInfo);
			this.Controls.Add(this.lbTitle);
			this.DoubleBuffered = true;
			this.Name = "StationInfoPage";
			this.Size = new System.Drawing.Size(800, 600);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.StationInfoPage_Paint);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbStationInfo;
		private System.Windows.Forms.Label lbTitle;
		private RTCore.TextButton lbBack;
	}
}
