namespace RouteTycoon.RTUI
{
	partial class RouteControl_TrainList_Page
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
			this.lbAccept = new RouteTycoon.RTCore.TextButton();
			this.picRemove = new System.Windows.Forms.PictureBox();
			this.picAdd = new System.Windows.Forms.PictureBox();
			this.panListBack = new System.Windows.Forms.Panel();
			this.panList = new System.Windows.Forms.Panel();
			this.lbTitle = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.picRemove)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picAdd)).BeginInit();
			this.panListBack.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbAccept
			// 
			this.lbAccept.AutoSize = true;
			this.lbAccept.Font = new System.Drawing.Font("굴림", 20F);
			this.lbAccept.Location = new System.Drawing.Point(693, 556);
			this.lbAccept.Name = "lbAccept";
			this.lbAccept.SelColor = System.Drawing.Color.Gray;
			this.lbAccept.Size = new System.Drawing.Size(116, 27);
			this.lbAccept.TabIndex = 21;
			this.lbAccept.Text = "(accept)";
			this.lbAccept.Click += new System.EventHandler(this.lbAccept_Click);
			// 
			// picRemove
			// 
			this.picRemove.Location = new System.Drawing.Point(76, 554);
			this.picRemove.Name = "picRemove";
			this.picRemove.Size = new System.Drawing.Size(35, 35);
			this.picRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picRemove.TabIndex = 19;
			this.picRemove.TabStop = false;
			this.picRemove.Click += new System.EventHandler(this.picRemove_Click);
			// 
			// picAdd
			// 
			this.picAdd.Location = new System.Drawing.Point(35, 554);
			this.picAdd.Name = "picAdd";
			this.picAdd.Size = new System.Drawing.Size(35, 35);
			this.picAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picAdd.TabIndex = 18;
			this.picAdd.TabStop = false;
			this.picAdd.Click += new System.EventHandler(this.picAdd_Click);
			// 
			// panListBack
			// 
			this.panListBack.AutoScroll = true;
			this.panListBack.Controls.Add(this.panList);
			this.panListBack.Location = new System.Drawing.Point(35, 144);
			this.panListBack.Name = "panListBack";
			this.panListBack.Size = new System.Drawing.Size(750, 400);
			this.panListBack.TabIndex = 20;
			// 
			// panList
			// 
			this.panList.BackColor = System.Drawing.Color.Transparent;
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
			this.lbTitle.Size = new System.Drawing.Size(129, 40);
			this.lbTitle.TabIndex = 16;
			this.lbTitle.Text = "(train)";
			// 
			// RouteControl_TrainList_Page
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.lbAccept);
			this.Controls.Add(this.picRemove);
			this.Controls.Add(this.picAdd);
			this.Controls.Add(this.panListBack);
			this.Controls.Add(this.lbTitle);
			this.DoubleBuffered = true;
			this.Name = "RouteControl_TrainList_Page";
			this.Size = new System.Drawing.Size(800, 600);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.RouteControl_TrainList_Page_Paint);
			((System.ComponentModel.ISupportInitialize)(this.picRemove)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picAdd)).EndInit();
			this.panListBack.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private RTCore.TextButton lbAccept;
		private System.Windows.Forms.PictureBox picRemove;
		private System.Windows.Forms.PictureBox picAdd;
		private System.Windows.Forms.Panel panListBack;
		private System.Windows.Forms.Panel panList;
		private System.Windows.Forms.Label lbTitle;
	}
}
