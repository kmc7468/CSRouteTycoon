namespace RouteTycoon.RTUI
{
	partial class TrainList_OKAdd_Page
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
			this.picRemove = new System.Windows.Forms.PictureBox();
			this.picAdd = new System.Windows.Forms.PictureBox();
			this.panListBack = new System.Windows.Forms.Panel();
			this.panList = new System.Windows.Forms.Panel();
			this.lbTitle = new System.Windows.Forms.Label();
			this.lbEnd = new RouteTycoon.RTCore.TextButton();
			this.lbSearch = new RouteTycoon.RTCore.TextButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.picRemove)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picAdd)).BeginInit();
			this.panListBack.SuspendLayout();
			this.SuspendLayout();
			// 
			// picRemove
			// 
			this.picRemove.Location = new System.Drawing.Point(76, 554);
			this.picRemove.Name = "picRemove";
			this.picRemove.Size = new System.Drawing.Size(35, 35);
			this.picRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picRemove.TabIndex = 19;
			this.picRemove.TabStop = false;
			// 
			// picAdd
			// 
			this.picAdd.Location = new System.Drawing.Point(35, 554);
			this.picAdd.Name = "picAdd";
			this.picAdd.Size = new System.Drawing.Size(35, 35);
			this.picAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picAdd.TabIndex = 18;
			this.picAdd.TabStop = false;
			// 
			// panListBack
			// 
			this.panListBack.AutoScroll = true;
			this.panListBack.Controls.Add(this.panList);
			this.panListBack.Location = new System.Drawing.Point(35, 184);
			this.panListBack.Name = "panListBack";
			this.panListBack.Size = new System.Drawing.Size(750, 360);
			this.panListBack.TabIndex = 20;
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
			this.lbTitle.Size = new System.Drawing.Size(244, 40);
			this.lbTitle.TabIndex = 16;
			this.lbTitle.Text = "(okaddtrain)";
			// 
			// lbEnd
			// 
			this.lbEnd.AutoSize = true;
			this.lbEnd.Font = new System.Drawing.Font("굴림", 20F);
			this.lbEnd.Location = new System.Drawing.Point(579, 556);
			this.lbEnd.Name = "lbEnd";
			this.lbEnd.SelColor = System.Drawing.Color.Gray;
			this.lbEnd.Size = new System.Drawing.Size(197, 27);
			this.lbEnd.TabIndex = 21;
			this.lbEnd.Text = "(addroutetrain)";
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
			// TrainList_OKAdd_Page
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.lbSearch);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.panListBack);
			this.Controls.Add(this.picRemove);
			this.Controls.Add(this.picAdd);
			this.Controls.Add(this.lbTitle);
			this.Controls.Add(this.lbEnd);
			this.DoubleBuffered = true;
			this.Name = "TrainList_OKAdd_Page";
			this.Size = new System.Drawing.Size(800, 600);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.TrainList_OKAdd_Page_Paint);
			((System.ComponentModel.ISupportInitialize)(this.picRemove)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picAdd)).EndInit();
			this.panListBack.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox picRemove;
		private System.Windows.Forms.PictureBox picAdd;
		private System.Windows.Forms.Panel panListBack;
		private System.Windows.Forms.Panel panList;
		private System.Windows.Forms.Label lbTitle;
		private RTCore.TextButton lbEnd;
		private RTCore.TextButton lbSearch;
		private System.Windows.Forms.TextBox txtSearch;
	}
}
