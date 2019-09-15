namespace RouteTycoon.RTUI
{
	partial class StationList01
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
			this.picDown = new System.Windows.Forms.PictureBox();
			this.picUp = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picUp)).BeginInit();
			this.SuspendLayout();
			// 
			// picDown
			// 
			this.picDown.Location = new System.Drawing.Point(694, 5);
			this.picDown.Name = "picDown";
			this.picDown.Size = new System.Drawing.Size(30, 30);
			this.picDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picDown.TabIndex = 0;
			this.picDown.TabStop = false;
			this.picDown.Click += new System.EventHandler(this.picDown_Click);
			this.picDown.MouseEnter += new System.EventHandler(this.picDown_MouseEnter);
			this.picDown.MouseLeave += new System.EventHandler(this.picDown_MouseLeave);
			// 
			// picUp
			// 
			this.picUp.Location = new System.Drawing.Point(658, 5);
			this.picUp.Name = "picUp";
			this.picUp.Size = new System.Drawing.Size(30, 30);
			this.picUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picUp.TabIndex = 1;
			this.picUp.TabStop = false;
			this.picUp.Click += new System.EventHandler(this.picUp_Click);
			this.picUp.MouseEnter += new System.EventHandler(this.picUp_MouseEnter);
			this.picUp.MouseLeave += new System.EventHandler(this.picUp_MouseLeave);
			// 
			// StationList01
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.picUp);
			this.Controls.Add(this.picDown);
			this.DoubleBuffered = true;
			this.Name = "StationList01";
			this.Size = new System.Drawing.Size(730, 40);
			this.Click += new System.EventHandler(this.StationList01_Click);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.StationList_Paint);
			this.MouseEnter += new System.EventHandler(this.StationList_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.StationList_MouseLeave);
			((System.ComponentModel.ISupportInitialize)(this.picDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picUp)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox picDown;
		private System.Windows.Forms.PictureBox picUp;
	}
}
