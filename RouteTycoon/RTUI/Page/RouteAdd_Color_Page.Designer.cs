namespace RouteTycoon.RTUI
{
	partial class RouteAdd_Color_Page
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
			this.lbNext = new RouteTycoon.RTCore.TextButton();
			this.SuspendLayout();
			// 
			// lbBack
			// 
			this.lbBack.AutoSize = true;
			this.lbBack.Font = new System.Drawing.Font("굴림", 20F);
			this.lbBack.Location = new System.Drawing.Point(24, 559);
			this.lbBack.Name = "lbBack";
			this.lbBack.SelColor = System.Drawing.Color.Gray;
			this.lbBack.Size = new System.Drawing.Size(92, 27);
			this.lbBack.TabIndex = 4;
			this.lbBack.Text = "(back)";
			this.lbBack.Click += new System.EventHandler(this.lbBack_Click);
			// 
			// lbNext
			// 
			this.lbNext.AutoSize = true;
			this.lbNext.Font = new System.Drawing.Font("굴림", 20F);
			this.lbNext.Location = new System.Drawing.Point(685, 559);
			this.lbNext.Name = "lbNext";
			this.lbNext.SelColor = System.Drawing.Color.Gray;
			this.lbNext.Size = new System.Drawing.Size(85, 27);
			this.lbNext.TabIndex = 3;
			this.lbNext.Text = "(next)";
			this.lbNext.Click += new System.EventHandler(this.lbNext_Click);
			// 
			// RouteAdd_Color_Page
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.lbBack);
			this.Controls.Add(this.lbNext);
			this.DoubleBuffered = true;
			this.Name = "RouteAdd_Color_Page";
			this.Size = new System.Drawing.Size(800, 600);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.RouteAdd_Color_Page_Paint);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RouteAdd_Color_Page_MouseDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RTCore.TextButton lbBack;
		private RTCore.TextButton lbNext;
	}
}
