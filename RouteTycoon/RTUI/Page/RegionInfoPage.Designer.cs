namespace RouteTycoon.RTUI
{
	partial class RegionInfoPage
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
			this.lbTitle = new System.Windows.Forms.Label();
			this.lbRegInfo = new System.Windows.Forms.Label();
			this.lbCityInfo = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Font = new System.Drawing.Font("굴림", 30F);
			this.lbTitle.Location = new System.Drawing.Point(27, 62);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(302, 40);
			this.lbTitle.TabIndex = 1;
			this.lbTitle.Text = "%REG_NAME%";
			// 
			// lbRegInfo
			// 
			this.lbRegInfo.AutoSize = true;
			this.lbRegInfo.Font = new System.Drawing.Font("굴림", 17F);
			this.lbRegInfo.Location = new System.Drawing.Point(34, 119);
			this.lbRegInfo.Name = "lbRegInfo";
			this.lbRegInfo.Size = new System.Drawing.Size(130, 23);
			this.lbRegInfo.TabIndex = 2;
			this.lbRegInfo.Text = "(reginfotemp)";
			// 
			// lbCityInfo
			// 
			this.lbCityInfo.AutoSize = true;
			this.lbCityInfo.Font = new System.Drawing.Font("굴림", 12F);
			this.lbCityInfo.Location = new System.Drawing.Point(35, 290);
			this.lbCityInfo.Name = "lbCityInfo";
			this.lbCityInfo.Size = new System.Drawing.Size(108, 16);
			this.lbCityInfo.TabIndex = 3;
			this.lbCityInfo.Text = "(cityinfotemp)";
			// 
			// RegionInfoPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.lbCityInfo);
			this.Controls.Add(this.lbRegInfo);
			this.Controls.Add(this.lbTitle);
			this.DoubleBuffered = true;
			this.Name = "RegionInfoPage";
			this.Size = new System.Drawing.Size(800, 600);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.RegionInfoPage_Paint);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Label lbRegInfo;
		private System.Windows.Forms.Label lbCityInfo;
	}
}
