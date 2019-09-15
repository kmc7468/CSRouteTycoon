namespace RouteTycoon.RTUI
{
	partial class RouteListPage
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
			this.lbAdd = new RouteTycoon.RTCore.TextButton();
			this.lbDoubleControl = new System.Windows.Forms.Label();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.lbSearch = new RouteTycoon.RTCore.TextButton();
			this.panListBack.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Font = new System.Drawing.Font("굴림", 30F);
			this.lbTitle.Location = new System.Drawing.Point(27, 62);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(196, 40);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "(routelist)";
			// 
			// panListBack
			// 
			this.panListBack.AutoScroll = true;
			this.panListBack.Controls.Add(this.panList);
			this.panListBack.Location = new System.Drawing.Point(35, 184);
			this.panListBack.Name = "panListBack";
			this.panListBack.Size = new System.Drawing.Size(750, 360);
			this.panListBack.TabIndex = 6;
			// 
			// panList
			// 
			this.panList.Location = new System.Drawing.Point(0, 0);
			this.panList.Name = "panList";
			this.panList.Size = new System.Drawing.Size(730, 0);
			this.panList.TabIndex = 3;
			// 
			// lbAdd
			// 
			this.lbAdd.AutoSize = true;
			this.lbAdd.Font = new System.Drawing.Font("굴림", 20F);
			this.lbAdd.Location = new System.Drawing.Point(627, 556);
			this.lbAdd.Name = "lbAdd";
			this.lbAdd.SelColor = System.Drawing.Color.Gray;
			this.lbAdd.Size = new System.Drawing.Size(142, 27);
			this.lbAdd.TabIndex = 7;
			this.lbAdd.Text = "(addroute)";
			this.lbAdd.Click += new System.EventHandler(this.lbAdd_Click);
			// 
			// lbDoubleControl
			// 
			this.lbDoubleControl.AutoSize = true;
			this.lbDoubleControl.Font = new System.Drawing.Font("굴림", 12F);
			this.lbDoubleControl.Location = new System.Drawing.Point(36, 117);
			this.lbDoubleControl.Name = "lbDoubleControl";
			this.lbDoubleControl.Size = new System.Drawing.Size(120, 16);
			this.lbDoubleControl.TabIndex = 8;
			this.lbDoubleControl.Text = "(doublecontrol)";
			// 
			// txtSearch
			// 
			this.txtSearch.Font = new System.Drawing.Font("굴림", 12F);
			this.txtSearch.Location = new System.Drawing.Point(35, 146);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(630, 26);
			this.txtSearch.TabIndex = 10;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// lbSearch
			// 
			this.lbSearch.AutoSize = true;
			this.lbSearch.Font = new System.Drawing.Font("굴림", 18F);
			this.lbSearch.Location = new System.Drawing.Point(671, 146);
			this.lbSearch.Name = "lbSearch";
			this.lbSearch.SelColor = System.Drawing.Color.Gray;
			this.lbSearch.Size = new System.Drawing.Size(94, 24);
			this.lbSearch.TabIndex = 11;
			this.lbSearch.Text = "(search)";
			// 
			// RouteListPage
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.panListBack);
			this.Controls.Add(this.lbSearch);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.lbAdd);
			this.Controls.Add(this.lbDoubleControl);
			this.Controls.Add(this.lbTitle);
			this.DoubleBuffered = true;
			this.Name = "RouteListPage";
			this.Size = new System.Drawing.Size(800, 600);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.RouteListPage_Paint);
			this.panListBack.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel panListBack;
		private System.Windows.Forms.Panel panList;
		private RTCore.TextButton lbAdd;
		private System.Windows.Forms.Label lbDoubleControl;
		private System.Windows.Forms.TextBox txtSearch;
		private RTCore.TextButton lbSearch;
	}
}
