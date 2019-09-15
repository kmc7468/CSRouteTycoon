namespace RouteTycoon.RTUI
{
	partial class DeveloperScene
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeveloperScene));
			this.panDevelopers = new System.Windows.Forms.Panel();
			this.lbtmp = new System.Windows.Forms.Label();
			this.panDevelopers.SuspendLayout();
			this.SuspendLayout();
			// 
			// panDevelopers
			// 
			this.panDevelopers.Controls.Add(this.lbtmp);
			this.panDevelopers.Location = new System.Drawing.Point(0, 679);
			this.panDevelopers.Name = "panDevelopers";
			this.panDevelopers.Size = new System.Drawing.Size(980, 680);
			this.panDevelopers.TabIndex = 0;
			// 
			// lbtmp
			// 
			this.lbtmp.AutoSize = true;
			this.lbtmp.Location = new System.Drawing.Point(659, 55);
			this.lbtmp.Name = "lbtmp";
			this.lbtmp.Size = new System.Drawing.Size(38, 12);
			this.lbtmp.TabIndex = 0;
			this.lbtmp.Text = "label1";
			this.lbtmp.Visible = false;
			// 
			// DeveloperScene
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Controls.Add(this.panDevelopers);
			this.DoubleBuffered = true;
			this.Name = "DeveloperScene";
			this.Size = new System.Drawing.Size(980, 680);
			this.panDevelopers.ResumeLayout(false);
			this.panDevelopers.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panDevelopers;
		private System.Windows.Forms.Label lbtmp;
	}
}
