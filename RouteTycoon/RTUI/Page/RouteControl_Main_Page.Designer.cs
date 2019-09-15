namespace RouteTycoon.RTUI
{
	partial class RouteControl_Main_Page
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
			this.lbCreate = new System.Windows.Forms.Label();
			this.lbTitle = new System.Windows.Forms.Label();
			this.lbBack = new RouteTycoon.RTCore.TextButton();
			this.panTrain = new System.Windows.Forms.Panel();
			this.picTrain = new System.Windows.Forms.PictureBox();
			this.panWay = new System.Windows.Forms.Panel();
			this.picWay = new System.Windows.Forms.PictureBox();
			this.lbDelete = new RouteTycoon.RTCore.TextButton();
			this.lbMoreInfo = new RouteTycoon.RTCore.TextButton();
			this.cbDraw = new System.Windows.Forms.CheckBox();
			this.panTrain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picTrain)).BeginInit();
			this.panWay.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picWay)).BeginInit();
			this.SuspendLayout();
			// 
			// lbCreate
			// 
			this.lbCreate.AutoSize = true;
			this.lbCreate.Font = new System.Drawing.Font("굴림", 12F);
			this.lbCreate.Location = new System.Drawing.Point(340, 83);
			this.lbCreate.Name = "lbCreate";
			this.lbCreate.Size = new System.Drawing.Size(89, 16);
			this.lbCreate.TabIndex = 5;
			this.lbCreate.Text = "(opendate)";
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Font = new System.Drawing.Font("굴림", 30F);
			this.lbTitle.Location = new System.Drawing.Point(27, 62);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(305, 40);
			this.lbTitle.TabIndex = 4;
			this.lbTitle.Text = "%RouteName%";
			// 
			// lbBack
			// 
			this.lbBack.AutoSize = true;
			this.lbBack.Font = new System.Drawing.Font("굴림", 20F);
			this.lbBack.Location = new System.Drawing.Point(685, 559);
			this.lbBack.Name = "lbBack";
			this.lbBack.SelColor = System.Drawing.Color.Gray;
			this.lbBack.Size = new System.Drawing.Size(92, 27);
			this.lbBack.TabIndex = 10;
			this.lbBack.Text = "(back)";
			this.lbBack.Click += new System.EventHandler(this.lbAccept_Click);
			// 
			// panTrain
			// 
			this.panTrain.Controls.Add(this.picTrain);
			this.panTrain.Location = new System.Drawing.Point(650, 196);
			this.panTrain.Name = "panTrain";
			this.panTrain.Size = new System.Drawing.Size(85, 85);
			this.panTrain.TabIndex = 11;
			this.panTrain.Click += new System.EventHandler(this.picTrain_Click);
			// 
			// picTrain
			// 
			this.picTrain.BackColor = System.Drawing.Color.Transparent;
			this.picTrain.Location = new System.Drawing.Point(11, 11);
			this.picTrain.Name = "picTrain";
			this.picTrain.Size = new System.Drawing.Size(63, 63);
			this.picTrain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picTrain.TabIndex = 16;
			this.picTrain.TabStop = false;
			this.picTrain.Click += new System.EventHandler(this.picTrain_Click);
			// 
			// panWay
			// 
			this.panWay.Controls.Add(this.picWay);
			this.panWay.Location = new System.Drawing.Point(650, 326);
			this.panWay.Name = "panWay";
			this.panWay.Size = new System.Drawing.Size(85, 85);
			this.panWay.TabIndex = 12;
			this.panWay.Click += new System.EventHandler(this.picWay_Click);
			// 
			// picWay
			// 
			this.picWay.BackColor = System.Drawing.Color.Transparent;
			this.picWay.Location = new System.Drawing.Point(11, 11);
			this.picWay.Name = "picWay";
			this.picWay.Size = new System.Drawing.Size(63, 63);
			this.picWay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picWay.TabIndex = 16;
			this.picWay.TabStop = false;
			this.picWay.Click += new System.EventHandler(this.picWay_Click);
			// 
			// lbDelete
			// 
			this.lbDelete.AutoSize = true;
			this.lbDelete.Font = new System.Drawing.Font("굴림", 25F);
			this.lbDelete.Location = new System.Drawing.Point(28, 490);
			this.lbDelete.Name = "lbDelete";
			this.lbDelete.SelColor = System.Drawing.Color.Gray;
			this.lbDelete.Size = new System.Drawing.Size(219, 34);
			this.lbDelete.TabIndex = 13;
			this.lbDelete.Text = "(deleteroute)";
			this.lbDelete.Click += new System.EventHandler(this.lbDelete_Click);
			// 
			// lbMoreInfo
			// 
			this.lbMoreInfo.AutoSize = true;
			this.lbMoreInfo.Font = new System.Drawing.Font("굴림", 25F);
			this.lbMoreInfo.Location = new System.Drawing.Point(28, 446);
			this.lbMoreInfo.Name = "lbMoreInfo";
			this.lbMoreInfo.SelColor = System.Drawing.Color.Gray;
			this.lbMoreInfo.Size = new System.Drawing.Size(182, 34);
			this.lbMoreInfo.TabIndex = 14;
			this.lbMoreInfo.Text = "(moreinfo)";
			// 
			// cbDraw
			// 
			this.cbDraw.AutoSize = true;
			this.cbDraw.Font = new System.Drawing.Font("굴림", 12F);
			this.cbDraw.Location = new System.Drawing.Point(34, 563);
			this.cbDraw.Name = "cbDraw";
			this.cbDraw.Size = new System.Drawing.Size(106, 20);
			this.cbDraw.TabIndex = 15;
			this.cbDraw.Text = "(maindraw)";
			this.cbDraw.UseVisualStyleBackColor = true;
			// 
			// RouteControl_Main_Page
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.cbDraw);
			this.Controls.Add(this.lbMoreInfo);
			this.Controls.Add(this.lbDelete);
			this.Controls.Add(this.panWay);
			this.Controls.Add(this.panTrain);
			this.Controls.Add(this.lbBack);
			this.Controls.Add(this.lbCreate);
			this.Controls.Add(this.lbTitle);
			this.DoubleBuffered = true;
			this.Name = "RouteControl_Main_Page";
			this.Size = new System.Drawing.Size(800, 600);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.RouteControl_Main_Page_Paint);
			this.panTrain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picTrain)).EndInit();
			this.panWay.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picWay)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbCreate;
		private System.Windows.Forms.Label lbTitle;
		private RTCore.TextButton lbBack;
		private System.Windows.Forms.Panel panTrain;
		private System.Windows.Forms.Panel panWay;
		private RTCore.TextButton lbDelete;
		private System.Windows.Forms.PictureBox picTrain;
		private System.Windows.Forms.PictureBox picWay;
		private RTCore.TextButton lbMoreInfo;
		private System.Windows.Forms.CheckBox cbDraw;
	}
}
