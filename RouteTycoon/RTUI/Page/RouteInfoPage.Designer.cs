namespace RouteTycoon.RTUI
{
	partial class RouteInfoPage
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
			this.lbRouteInfo = new System.Windows.Forms.Label();
			this.lbTitle = new System.Windows.Forms.Label();
			this.lbUseMoney = new System.Windows.Forms.Label();
			this.nuUseMoney = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.nuUseMoney)).BeginInit();
			this.SuspendLayout();
			// 
			// lbBack
			// 
			this.lbBack.AutoSize = true;
			this.lbBack.Font = new System.Drawing.Font("굴림", 20F);
			this.lbBack.Location = new System.Drawing.Point(685, 559);
			this.lbBack.Name = "lbBack";
			this.lbBack.SelColor = System.Drawing.Color.Gray;
			this.lbBack.Size = new System.Drawing.Size(92, 27);
			this.lbBack.TabIndex = 11;
			this.lbBack.Text = "(back)";
			// 
			// lbRouteInfo
			// 
			this.lbRouteInfo.AutoSize = true;
			this.lbRouteInfo.Font = new System.Drawing.Font("굴림", 20F);
			this.lbRouteInfo.Location = new System.Drawing.Point(34, 119);
			this.lbRouteInfo.Name = "lbRouteInfo";
			this.lbRouteInfo.Size = new System.Drawing.Size(205, 27);
			this.lbRouteInfo.TabIndex = 13;
			this.lbRouteInfo.Text = "(routeinfotemp)";
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Font = new System.Drawing.Font("굴림", 30F);
			this.lbTitle.Location = new System.Drawing.Point(27, 62);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(353, 40);
			this.lbTitle.TabIndex = 12;
			this.lbTitle.Text = "%ROUTE_NAME%";
			// 
			// lbUseMoney
			// 
			this.lbUseMoney.AutoSize = true;
			this.lbUseMoney.Font = new System.Drawing.Font("굴림", 20F);
			this.lbUseMoney.Location = new System.Drawing.Point(34, 161);
			this.lbUseMoney.Name = "lbUseMoney";
			this.lbUseMoney.Size = new System.Drawing.Size(178, 27);
			this.lbUseMoney.TabIndex = 14;
			this.lbUseMoney.Text = "(usemoney) :";
			// 
			// nuUseMoney
			// 
			this.nuUseMoney.Font = new System.Drawing.Font("굴림", 13F);
			this.nuUseMoney.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.nuUseMoney.Location = new System.Drawing.Point(216, 162);
			this.nuUseMoney.Name = "nuUseMoney";
			this.nuUseMoney.Size = new System.Drawing.Size(120, 27);
			this.nuUseMoney.TabIndex = 15;
			// 
			// RouteInfoPage
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.nuUseMoney);
			this.Controls.Add(this.lbUseMoney);
			this.Controls.Add(this.lbRouteInfo);
			this.Controls.Add(this.lbTitle);
			this.Controls.Add(this.lbBack);
			this.DoubleBuffered = true;
			this.Name = "RouteInfoPage";
			this.Size = new System.Drawing.Size(800, 600);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.RouteInfoPage_Paint);
			((System.ComponentModel.ISupportInitialize)(this.nuUseMoney)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RTCore.TextButton lbBack;
		private System.Windows.Forms.Label lbRouteInfo;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Label lbUseMoney;
		private System.Windows.Forms.NumericUpDown nuUseMoney;
	}
}
