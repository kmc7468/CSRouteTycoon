namespace RouteTycoon.RTUI
{
	partial class CompanyListPage
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
			this.panListBack = new System.Windows.Forms.Panel();
			this.panList = new System.Windows.Forms.Panel();
			this.panListBack.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Font = new System.Drawing.Font("굴림", 30F);
			this.lbTitle.Location = new System.Drawing.Point(27, 62);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(271, 40);
			this.lbTitle.TabIndex = 7;
			this.lbTitle.Text = "(companylist)";
			// 
			// panListBack
			// 
			this.panListBack.AutoScroll = true;
			this.panListBack.Controls.Add(this.panList);
			this.panListBack.Location = new System.Drawing.Point(35, 144);
			this.panListBack.Name = "panListBack";
			this.panListBack.Size = new System.Drawing.Size(750, 400);
			this.panListBack.TabIndex = 11;
			// 
			// panList
			// 
			this.panList.Location = new System.Drawing.Point(0, 0);
			this.panList.Name = "panList";
			this.panList.Size = new System.Drawing.Size(730, 0);
			this.panList.TabIndex = 3;
			// 
			// CompanyListPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.lbTitle);
			this.Controls.Add(this.panListBack);
			this.DoubleBuffered = true;
			this.Name = "CompanyListPage";
			this.Size = new System.Drawing.Size(800, 600);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.CompanyListPage_Paint);
			this.panListBack.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel panListBack;
		private System.Windows.Forms.Panel panList;
	}
}
