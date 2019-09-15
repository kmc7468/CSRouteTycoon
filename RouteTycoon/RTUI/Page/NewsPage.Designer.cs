namespace RouteTycoon.RTUI
{
	partial class NewsPage
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
			this.lbShowTooltip = new System.Windows.Forms.Label();
			this.picRefresh = new System.Windows.Forms.PictureBox();
			this.panListBack.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picRefresh)).BeginInit();
			this.SuspendLayout();
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Font = new System.Drawing.Font("굴림", 30F);
			this.lbTitle.Location = new System.Drawing.Point(27, 62);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(144, 40);
			this.lbTitle.TabIndex = 7;
			this.lbTitle.Text = "(news)";
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
			// lbShowTooltip
			// 
			this.lbShowTooltip.AutoSize = true;
			this.lbShowTooltip.Font = new System.Drawing.Font("굴림", 12F);
			this.lbShowTooltip.Location = new System.Drawing.Point(36, 117);
			this.lbShowTooltip.Name = "lbShowTooltip";
			this.lbShowTooltip.Size = new System.Drawing.Size(127, 16);
			this.lbShowTooltip.TabIndex = 12;
			this.lbShowTooltip.Text = "(mouseonshow)";
			// 
			// picRefresh
			// 
			this.picRefresh.Location = new System.Drawing.Point(35, 554);
			this.picRefresh.Name = "picRefresh";
			this.picRefresh.Size = new System.Drawing.Size(35, 35);
			this.picRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picRefresh.TabIndex = 13;
			this.picRefresh.TabStop = false;
			// 
			// NewsPage
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.panListBack);
			this.Controls.Add(this.picRefresh);
			this.Controls.Add(this.lbShowTooltip);
			this.Controls.Add(this.lbTitle);
			this.DoubleBuffered = true;
			this.Name = "NewsPage";
			this.Size = new System.Drawing.Size(800, 600);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.NewsPage_Paint);
			this.panListBack.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picRefresh)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel panListBack;
		private System.Windows.Forms.Panel panList;
		private System.Windows.Forms.Label lbShowTooltip;
		private System.Windows.Forms.PictureBox picRefresh;
	}
}
