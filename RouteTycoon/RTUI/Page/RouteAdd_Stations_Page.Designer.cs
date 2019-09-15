namespace RouteTycoon.RTUI
{
	partial class RouteAdd_Stations_Page
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
			this.lbTitle = new System.Windows.Forms.Label();
			this.panListBack = new System.Windows.Forms.Panel();
			this.panList = new System.Windows.Forms.Panel();
			this.lbEnd = new RouteTycoon.RTCore.TextButton();
			this.cbLoop = new System.Windows.Forms.CheckBox();
			this.lbReverse = new RouteTycoon.RTCore.TextButton();
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
			this.picRemove.TabIndex = 10;
			this.picRemove.TabStop = false;
			this.picRemove.Click += new System.EventHandler(this.picRemove_Click);
			this.picRemove.MouseEnter += new System.EventHandler(this.picRemove_MouseEnter);
			this.picRemove.MouseLeave += new System.EventHandler(this.picRemove_MouseLeave);
			// 
			// picAdd
			// 
			this.picAdd.Location = new System.Drawing.Point(35, 554);
			this.picAdd.Name = "picAdd";
			this.picAdd.Size = new System.Drawing.Size(35, 35);
			this.picAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picAdd.TabIndex = 9;
			this.picAdd.TabStop = false;
			this.picAdd.Click += new System.EventHandler(this.picAdd_Click);
			this.picAdd.MouseEnter += new System.EventHandler(this.picAdd_MouseEnter);
			this.picAdd.MouseLeave += new System.EventHandler(this.picAdd_MouseLeave);
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Font = new System.Drawing.Font("굴림", 30F);
			this.lbTitle.Location = new System.Drawing.Point(27, 62);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(120, 40);
			this.lbTitle.TabIndex = 7;
			this.lbTitle.Text = "(way)";
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
			this.panList.Location = new System.Drawing.Point(9, 9);
			this.panList.Name = "panList";
			this.panList.Size = new System.Drawing.Size(730, 0);
			this.panList.TabIndex = 3;
			// 
			// lbEnd
			// 
			this.lbEnd.AutoSize = true;
			this.lbEnd.Font = new System.Drawing.Font("굴림", 20F);
			this.lbEnd.Location = new System.Drawing.Point(693, 556);
			this.lbEnd.Name = "lbEnd";
			this.lbEnd.SelColor = System.Drawing.Color.Gray;
			this.lbEnd.Size = new System.Drawing.Size(79, 27);
			this.lbEnd.TabIndex = 12;
			this.lbEnd.Text = "(add)";
			this.lbEnd.Click += new System.EventHandler(this.lbEnd_Click);
			// 
			// cbLoop
			// 
			this.cbLoop.AutoSize = true;
			this.cbLoop.Font = new System.Drawing.Font("굴림", 12F);
			this.cbLoop.Location = new System.Drawing.Point(36, 117);
			this.cbLoop.Name = "cbLoop";
			this.cbLoop.Size = new System.Drawing.Size(71, 20);
			this.cbLoop.TabIndex = 15;
			this.cbLoop.Text = "(loop)";
			this.cbLoop.UseVisualStyleBackColor = true;
			// 
			// lbReverse
			// 
			this.lbReverse.AutoSize = true;
			this.lbReverse.Font = new System.Drawing.Font("굴림", 12F);
			this.lbReverse.Location = new System.Drawing.Point(664, 117);
			this.lbReverse.Name = "lbReverse";
			this.lbReverse.SelColor = System.Drawing.Color.Gray;
			this.lbReverse.Size = new System.Drawing.Size(101, 16);
			this.lbReverse.TabIndex = 16;
			this.lbReverse.Text = "(wayreverse)";
			// 
			// RouteAdd_Stations_Page
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.lbEnd);
			this.Controls.Add(this.picRemove);
			this.Controls.Add(this.picAdd);
			this.Controls.Add(this.panListBack);
			this.Controls.Add(this.cbLoop);
			this.Controls.Add(this.lbTitle);
			this.Controls.Add(this.lbReverse);
			this.DoubleBuffered = true;
			this.Name = "RouteAdd_Stations_Page";
			this.Size = new System.Drawing.Size(800, 600);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.RouteAdd_Stations_Page_Paint);
			((System.ComponentModel.ISupportInitialize)(this.picRemove)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picAdd)).EndInit();
			this.panListBack.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox picRemove;
		private System.Windows.Forms.PictureBox picAdd;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel panListBack;
		private System.Windows.Forms.Panel panList;
		private RTCore.TextButton lbEnd;
		private System.Windows.Forms.CheckBox cbLoop;
		private RTCore.TextButton lbReverse;
	}
}
