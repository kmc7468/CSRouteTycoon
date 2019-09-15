namespace RouteTycoon.RTUI
{
	partial class RouteAdd_Stations_List_Page
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
			this.lbEnd = new RouteTycoon.RTCore.TextButton();
			this.panListBack = new System.Windows.Forms.Panel();
			this.panList = new System.Windows.Forms.Panel();
			this.lbTitle = new System.Windows.Forms.Label();
			this.picStnAdd = new System.Windows.Forms.PictureBox();
			this.lbDoubleInfo = new System.Windows.Forms.Label();
			this.lbSearch = new RouteTycoon.RTCore.TextButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.picStnRemove = new System.Windows.Forms.PictureBox();
			this.panListBack.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picStnAdd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picStnRemove)).BeginInit();
			this.SuspendLayout();
			// 
			// lbEnd
			// 
			this.lbEnd.AutoSize = true;
			this.lbEnd.Font = new System.Drawing.Font("굴림", 20F);
			this.lbEnd.Location = new System.Drawing.Point(693, 556);
			this.lbEnd.Name = "lbEnd";
			this.lbEnd.SelColor = System.Drawing.Color.Gray;
			this.lbEnd.Size = new System.Drawing.Size(79, 27);
			this.lbEnd.TabIndex = 18;
			this.lbEnd.Text = "(add)";
			this.lbEnd.Click += new System.EventHandler(this.lbEnd_Click);
			// 
			// panListBack
			// 
			this.panListBack.AutoScroll = true;
			this.panListBack.Controls.Add(this.panList);
			this.panListBack.Location = new System.Drawing.Point(35, 184);
			this.panListBack.Name = "panListBack";
			this.panListBack.Size = new System.Drawing.Size(750, 360);
			this.panListBack.TabIndex = 17;
			// 
			// panList
			// 
			this.panList.Location = new System.Drawing.Point(0, 0);
			this.panList.Name = "panList";
			this.panList.Size = new System.Drawing.Size(730, 0);
			this.panList.TabIndex = 3;
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Font = new System.Drawing.Font("굴림", 30F);
			this.lbTitle.Location = new System.Drawing.Point(27, 62);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(125, 40);
			this.lbTitle.TabIndex = 15;
			this.lbTitle.Text = "(stas)";
			// 
			// picStnAdd
			// 
			this.picStnAdd.Location = new System.Drawing.Point(35, 554);
			this.picStnAdd.Name = "picStnAdd";
			this.picStnAdd.Size = new System.Drawing.Size(35, 35);
			this.picStnAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picStnAdd.TabIndex = 21;
			this.picStnAdd.TabStop = false;
			this.picStnAdd.Click += new System.EventHandler(this.picStnAdd_Click);
			// 
			// lbDoubleInfo
			// 
			this.lbDoubleInfo.AutoSize = true;
			this.lbDoubleInfo.Font = new System.Drawing.Font("굴림", 12F);
			this.lbDoubleInfo.Location = new System.Drawing.Point(36, 117);
			this.lbDoubleInfo.Name = "lbDoubleInfo";
			this.lbDoubleInfo.Size = new System.Drawing.Size(119, 16);
			this.lbDoubleInfo.TabIndex = 22;
			this.lbDoubleInfo.Text = "(doubleinfosta)";
			// 
			// lbSearch
			// 
			this.lbSearch.AutoSize = true;
			this.lbSearch.Font = new System.Drawing.Font("굴림", 18F);
			this.lbSearch.Location = new System.Drawing.Point(671, 146);
			this.lbSearch.Name = "lbSearch";
			this.lbSearch.SelColor = System.Drawing.Color.Gray;
			this.lbSearch.Size = new System.Drawing.Size(94, 24);
			this.lbSearch.TabIndex = 25;
			this.lbSearch.Text = "(search)";
			// 
			// txtSearch
			// 
			this.txtSearch.Font = new System.Drawing.Font("굴림", 12F);
			this.txtSearch.Location = new System.Drawing.Point(35, 146);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(630, 26);
			this.txtSearch.TabIndex = 24;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// picStnRemove
			// 
			this.picStnRemove.Location = new System.Drawing.Point(76, 554);
			this.picStnRemove.Name = "picStnRemove";
			this.picStnRemove.Size = new System.Drawing.Size(35, 35);
			this.picStnRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picStnRemove.TabIndex = 26;
			this.picStnRemove.TabStop = false;
			this.picStnRemove.Click += new System.EventHandler(this.picStnRemove_Click);
			// 
			// RouteAdd_Stations_List_Page
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.picStnRemove);
			this.Controls.Add(this.panListBack);
			this.Controls.Add(this.lbSearch);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.picStnAdd);
			this.Controls.Add(this.lbEnd);
			this.Controls.Add(this.lbDoubleInfo);
			this.Controls.Add(this.lbTitle);
			this.DoubleBuffered = true;
			this.Name = "RouteAdd_Stations_List_Page";
			this.Size = new System.Drawing.Size(800, 600);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.RouteAdd_Stations_List_Page_Paint);
			this.panListBack.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picStnAdd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picStnRemove)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private RTCore.TextButton lbEnd;
		private System.Windows.Forms.Panel panListBack;
		private System.Windows.Forms.Panel panList;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.PictureBox picStnAdd;
		private System.Windows.Forms.Label lbDoubleInfo;
		private RTCore.TextButton lbSearch;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.PictureBox picStnRemove;
	}
}
