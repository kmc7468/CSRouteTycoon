namespace RouteTycoon.RTUI
{
	partial class LogoScene
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogoScene));
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.picAtus = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picAtus)).BeginInit();
			this.SuspendLayout();
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Interval = 3000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// picAtus
			// 
			this.picAtus.Image = ((System.Drawing.Image)(resources.GetObject("picAtus.Image")));
			this.picAtus.Location = new System.Drawing.Point(353, 290);
			this.picAtus.Name = "picAtus";
			this.picAtus.Size = new System.Drawing.Size(275, 100);
			this.picAtus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picAtus.TabIndex = 1;
			this.picAtus.TabStop = false;
			// 
			// LogoScene
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.picAtus);
			this.DoubleBuffered = true;
			this.Name = "LogoScene";
			this.Size = new System.Drawing.Size(980, 680);
			((System.ComponentModel.ISupportInitialize)(this.picAtus)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.PictureBox picAtus;
	}
}
