namespace RouteTycoon.RTUI
{
	partial class UpdateingScene
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateingScene));
			this.pbProgress = new RouteTycoon.RTCore.CircularProgressBar();
			this.lbProgress = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// pbProgress
			// 
			this.pbProgress.AnimatorDuration = 300;
			this.pbProgress.AnimatorFunction = ((WinFormAnimation.Functions.Function)(resources.GetObject("pbProgress.AnimatorFunction")));
			this.pbProgress.BackColor = System.Drawing.Color.Transparent;
			this.pbProgress.Caption = "0%";
			this.pbProgress.CaptionMargin = 3;
			this.pbProgress.Font = new System.Drawing.Font("굴림", 30F);
			this.pbProgress.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.pbProgress.InnerCircleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.pbProgress.InnerCircleMargin = 4;
			this.pbProgress.InnerCircleWidth = 3;
			this.pbProgress.Location = new System.Drawing.Point(385, 206);
			this.pbProgress.MaxValue = 100F;
			this.pbProgress.MinValue = 0F;
			this.pbProgress.Name = "pbProgress";
			this.pbProgress.OuterCircleColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(57)))), ((int)(((byte)(3)))));
			this.pbProgress.OuterCircleMargin = 0;
			this.pbProgress.OuterCircleWidth = 0;
			this.pbProgress.ProgressCircleColor = System.Drawing.SystemColors.Highlight;
			this.pbProgress.ProgressCircleStartAngle = 270;
			this.pbProgress.ProgressCircleWidth = 2;
			this.pbProgress.Size = new System.Drawing.Size(210, 210);
			this.pbProgress.SubText = null;
			this.pbProgress.SubTextColor = System.Drawing.Color.Gray;
			this.pbProgress.SupSubFont = new System.Drawing.Font("굴림", 4.5F);
			this.pbProgress.SupText = null;
			this.pbProgress.SupTextColor = System.Drawing.Color.Gray;
			this.pbProgress.TabIndex = 4;
			this.pbProgress.Value = 0F;
			// 
			// lbProgress
			// 
			this.lbProgress.AutoSize = true;
			this.lbProgress.BackColor = System.Drawing.Color.Transparent;
			this.lbProgress.Font = new System.Drawing.Font("굴림", 20F);
			this.lbProgress.ForeColor = System.Drawing.Color.White;
			this.lbProgress.Location = new System.Drawing.Point(411, 447);
			this.lbProgress.Name = "lbProgress";
			this.lbProgress.Size = new System.Drawing.Size(158, 27);
			this.lbProgress.TabIndex = 6;
			this.lbProgress.Text = "(updatepro)";
			// 
			// UpdateingScene
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add(this.lbProgress);
			this.Controls.Add(this.pbProgress);
			this.DoubleBuffered = true;
			this.Name = "UpdateingScene";
			this.Size = new System.Drawing.Size(980, 680);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdateingScene_Paint);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private RTCore.CircularProgressBar pbProgress;
		private System.Windows.Forms.Label lbProgress;
	}
}
