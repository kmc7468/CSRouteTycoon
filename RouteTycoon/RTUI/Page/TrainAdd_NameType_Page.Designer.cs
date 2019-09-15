namespace RouteTycoon.RTUI
{
	partial class TrainAdd_NameType_Page
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
			this.lbAdd = new RouteTycoon.RTCore.TextButton();
			this.lbInfo = new System.Windows.Forms.Label();
			this.picDataIcon = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picDataIcon)).BeginInit();
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
			this.lbBack.TabIndex = 8;
			this.lbBack.Text = "(back)";
			this.lbBack.Click += new System.EventHandler(this.lbBack_Click);
			// 
			// lbAdd
			// 
			this.lbAdd.AutoSize = true;
			this.lbAdd.Font = new System.Drawing.Font("굴림", 20F);
			this.lbAdd.Location = new System.Drawing.Point(685, 559);
			this.lbAdd.Name = "lbAdd";
			this.lbAdd.SelColor = System.Drawing.Color.Gray;
			this.lbAdd.Size = new System.Drawing.Size(77, 27);
			this.lbAdd.TabIndex = 7;
			this.lbAdd.Text = "(buy)";
			this.lbAdd.Click += new System.EventHandler(this.lbAdd_Click);
			// 
			// lbInfo
			// 
			this.lbInfo.AutoSize = true;
			this.lbInfo.Location = new System.Drawing.Point(296, 354);
			this.lbInfo.Name = "lbInfo";
			this.lbInfo.Size = new System.Drawing.Size(35, 12);
			this.lbInfo.TabIndex = 9;
			this.lbInfo.Text = "lbInfo";
			// 
			// picDataIcon
			// 
			this.picDataIcon.Location = new System.Drawing.Point(500, 354);
			this.picDataIcon.Name = "picDataIcon";
			this.picDataIcon.Size = new System.Drawing.Size(100, 100);
			this.picDataIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picDataIcon.TabIndex = 10;
			this.picDataIcon.TabStop = false;
			this.picDataIcon.Click += new System.EventHandler(this.picDataIcon_Click);
			// 
			// TrainAdd_NameType_Page
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.picDataIcon);
			this.Controls.Add(this.lbInfo);
			this.Controls.Add(this.lbBack);
			this.Controls.Add(this.lbAdd);
			this.DoubleBuffered = true;
			this.Name = "TrainAdd_NameType_Page";
			this.Size = new System.Drawing.Size(800, 600);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.TrainAdd_Type_Page_Paint);
			((System.ComponentModel.ISupportInitialize)(this.picDataIcon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RTCore.TextButton lbBack;
		private RTCore.TextButton lbAdd;
		private System.Windows.Forms.Label lbInfo;
		private System.Windows.Forms.PictureBox picDataIcon;
	}
}
