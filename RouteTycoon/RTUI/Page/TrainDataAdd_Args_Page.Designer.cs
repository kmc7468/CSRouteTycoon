namespace RouteTycoon.RTUI
{
	partial class TrainDataAdd_Args_Page
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
			this.picDown = new System.Windows.Forms.PictureBox();
			this.picUp = new System.Windows.Forms.PictureBox();
			this.lbPage = new System.Windows.Forms.Label();
			this.lbTitle = new System.Windows.Forms.Label();
			this.panListBack = new System.Windows.Forms.Panel();
			this.panList = new System.Windows.Forms.Panel();
			this.picRemove = new System.Windows.Forms.PictureBox();
			this.lbLocAdd = new RouteTycoon.RTCore.TextButton();
			this.lbCarAdd = new RouteTycoon.RTCore.TextButton();
			this.lbEngineAdd = new RouteTycoon.RTCore.TextButton();
			((System.ComponentModel.ISupportInitialize)(this.picDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picUp)).BeginInit();
			this.panListBack.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picRemove)).BeginInit();
			this.SuspendLayout();
			// 
			// lbBack
			// 
			this.lbBack.AutoSize = true;
			this.lbBack.Font = new System.Drawing.Font("굴림", 20F);
			this.lbBack.Location = new System.Drawing.Point(587, 559);
			this.lbBack.Name = "lbBack";
			this.lbBack.SelColor = System.Drawing.Color.Gray;
			this.lbBack.Size = new System.Drawing.Size(92, 27);
			this.lbBack.TabIndex = 10;
			this.lbBack.Text = "(back)";
			// 
			// lbNext
			// 
			this.lbNext.AutoSize = true;
			this.lbNext.Font = new System.Drawing.Font("굴림", 20F);
			this.lbNext.Location = new System.Drawing.Point(685, 559);
			this.lbNext.Name = "lbNext";
			this.lbNext.SelColor = System.Drawing.Color.Gray;
			this.lbNext.Size = new System.Drawing.Size(85, 27);
			this.lbNext.TabIndex = 9;
			this.lbNext.Text = "(next)";
			// 
			// picDown
			// 
			this.picDown.Location = new System.Drawing.Point(117, 554);
			this.picDown.Name = "picDown";
			this.picDown.Size = new System.Drawing.Size(35, 35);
			this.picDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picDown.TabIndex = 14;
			this.picDown.TabStop = false;
			this.picDown.Click += new System.EventHandler(this.picDown_Click);
			// 
			// picUp
			// 
			this.picUp.Location = new System.Drawing.Point(76, 554);
			this.picUp.Name = "picUp";
			this.picUp.Size = new System.Drawing.Size(35, 35);
			this.picUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picUp.TabIndex = 13;
			this.picUp.TabStop = false;
			this.picUp.Click += new System.EventHandler(this.picUp_Click);
			// 
			// lbPage
			// 
			this.lbPage.AutoSize = true;
			this.lbPage.Font = new System.Drawing.Font("굴림", 12F);
			this.lbPage.Location = new System.Drawing.Point(233, 83);
			this.lbPage.Name = "lbPage";
			this.lbPage.Size = new System.Drawing.Size(56, 16);
			this.lbPage.TabIndex = 12;
			this.lbPage.Text = "(page)";
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Font = new System.Drawing.Font("굴림", 30F);
			this.lbTitle.Location = new System.Drawing.Point(27, 62);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(212, 40);
			this.lbTitle.TabIndex = 11;
			this.lbTitle.Text = "(traindata)";
			// 
			// panListBack
			// 
			this.panListBack.Controls.Add(this.panList);
			this.panListBack.Location = new System.Drawing.Point(35, 144);
			this.panListBack.Name = "panListBack";
			this.panListBack.Size = new System.Drawing.Size(530, 400);
			this.panListBack.TabIndex = 15;
			// 
			// panList
			// 
			this.panList.Location = new System.Drawing.Point(0, 0);
			this.panList.Name = "panList";
			this.panList.Size = new System.Drawing.Size(530, 0);
			this.panList.TabIndex = 3;
			// 
			// picRemove
			// 
			this.picRemove.Location = new System.Drawing.Point(35, 554);
			this.picRemove.Name = "picRemove";
			this.picRemove.Size = new System.Drawing.Size(35, 35);
			this.picRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picRemove.TabIndex = 16;
			this.picRemove.TabStop = false;
			// 
			// lbLocAdd
			// 
			this.lbLocAdd.AutoSize = true;
			this.lbLocAdd.Font = new System.Drawing.Font("굴림", 20F);
			this.lbLocAdd.Location = new System.Drawing.Point(577, 159);
			this.lbLocAdd.Name = "lbLocAdd";
			this.lbLocAdd.SelColor = System.Drawing.Color.Gray;
			this.lbLocAdd.Size = new System.Drawing.Size(116, 27);
			this.lbLocAdd.TabIndex = 17;
			this.lbLocAdd.Text = "(addloc)";
			this.lbLocAdd.Click += new System.EventHandler(this.lbLocAdd_Click);
			// 
			// lbCarAdd
			// 
			this.lbCarAdd.AutoSize = true;
			this.lbCarAdd.Font = new System.Drawing.Font("굴림", 20F);
			this.lbCarAdd.Location = new System.Drawing.Point(577, 195);
			this.lbCarAdd.Name = "lbCarAdd";
			this.lbCarAdd.SelColor = System.Drawing.Color.Gray;
			this.lbCarAdd.Size = new System.Drawing.Size(118, 27);
			this.lbCarAdd.TabIndex = 18;
			this.lbCarAdd.Text = "(addcar)";
			this.lbCarAdd.Click += new System.EventHandler(this.lbCarAdd_Click);
			// 
			// lbEngineAdd
			// 
			this.lbEngineAdd.AutoSize = true;
			this.lbEngineAdd.Font = new System.Drawing.Font("굴림", 20F);
			this.lbEngineAdd.Location = new System.Drawing.Point(577, 230);
			this.lbEngineAdd.Name = "lbEngineAdd";
			this.lbEngineAdd.SelColor = System.Drawing.Color.Gray;
			this.lbEngineAdd.Size = new System.Drawing.Size(164, 27);
			this.lbEngineAdd.TabIndex = 19;
			this.lbEngineAdd.Text = "(addengine)";
			this.lbEngineAdd.Click += new System.EventHandler(this.lbEngineAdd_Click);
			// 
			// TrainDataAdd_Args_Page
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.lbEngineAdd);
			this.Controls.Add(this.lbCarAdd);
			this.Controls.Add(this.lbLocAdd);
			this.Controls.Add(this.picRemove);
			this.Controls.Add(this.picDown);
			this.Controls.Add(this.picUp);
			this.Controls.Add(this.lbPage);
			this.Controls.Add(this.lbTitle);
			this.Controls.Add(this.panListBack);
			this.Controls.Add(this.lbBack);
			this.Controls.Add(this.lbNext);
			this.DoubleBuffered = true;
			this.Name = "TrainDataAdd_Args_Page";
			this.Size = new System.Drawing.Size(797, 600);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.TrainDataAdd_Args_Page_Paint);
			((System.ComponentModel.ISupportInitialize)(this.picDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picUp)).EndInit();
			this.panListBack.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picRemove)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RTCore.TextButton lbBack;
		private RTCore.TextButton lbNext;
		private System.Windows.Forms.PictureBox picDown;
		private System.Windows.Forms.PictureBox picUp;
		private System.Windows.Forms.Label lbPage;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel panListBack;
		private System.Windows.Forms.Panel panList;
		private System.Windows.Forms.PictureBox picRemove;
		private RTCore.TextButton lbLocAdd;
		private RTCore.TextButton lbCarAdd;
		private RTCore.TextButton lbEngineAdd;
	}
}
