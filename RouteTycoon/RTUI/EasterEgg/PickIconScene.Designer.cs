namespace RouteTycoon.RTUI
{
	partial class PickIconScene
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
			this.btnCommand = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnPause = new System.Windows.Forms.Button();
			this.lbScore = new System.Windows.Forms.Label();
			this.panGamezone = new System.Windows.Forms.Panel();
			this.timIcon = new System.Windows.Forms.Timer(this.components);
			this.timPause = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// btnCommand
			// 
			this.btnCommand.Font = new System.Drawing.Font("굴림", 11F);
			this.btnCommand.Location = new System.Drawing.Point(0, 641);
			this.btnCommand.Name = "btnCommand";
			this.btnCommand.Size = new System.Drawing.Size(141, 39);
			this.btnCommand.TabIndex = 12;
			this.btnCommand.Text = "명령어 입력";
			this.btnCommand.UseVisualStyleBackColor = true;
			this.btnCommand.Click += new System.EventHandler(this.btnCommand_Click);
			// 
			// btnStart
			// 
			this.btnStart.Font = new System.Drawing.Font("굴림", 11F);
			this.btnStart.Location = new System.Drawing.Point(147, 641);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(686, 39);
			this.btnStart.TabIndex = 11;
			this.btnStart.Text = "아이콘 줍기 시작";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnPause
			// 
			this.btnPause.Font = new System.Drawing.Font("굴림", 11F);
			this.btnPause.Location = new System.Drawing.Point(839, 641);
			this.btnPause.Name = "btnPause";
			this.btnPause.Size = new System.Drawing.Size(141, 39);
			this.btnPause.TabIndex = 10;
			this.btnPause.Text = "일시정지";
			this.btnPause.UseVisualStyleBackColor = true;
			this.btnPause.Visible = false;
			this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
			// 
			// lbScore
			// 
			this.lbScore.AutoSize = true;
			this.lbScore.BackColor = System.Drawing.Color.Transparent;
			this.lbScore.Font = new System.Drawing.Font("굴림", 18F);
			this.lbScore.Location = new System.Drawing.Point(6, 7);
			this.lbScore.Name = "lbScore";
			this.lbScore.Size = new System.Drawing.Size(47, 24);
			this.lbScore.TabIndex = 9;
			this.lbScore.Text = "0점";
			// 
			// panGamezone
			// 
			this.panGamezone.BackColor = System.Drawing.Color.Transparent;
			this.panGamezone.Location = new System.Drawing.Point(0, 40);
			this.panGamezone.Name = "panGamezone";
			this.panGamezone.Size = new System.Drawing.Size(980, 601);
			this.panGamezone.TabIndex = 8;
			// 
			// timIcon
			// 
			this.timIcon.Interval = 1000;
			this.timIcon.Tick += new System.EventHandler(this.timIcon_Tick);
			// 
			// timPause
			// 
			this.timPause.Interval = 10000;
			this.timPause.Tick += new System.EventHandler(this.timPause_Tick);
			// 
			// PickIconScene
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.btnCommand);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.btnPause);
			this.Controls.Add(this.lbScore);
			this.Controls.Add(this.panGamezone);
			this.DoubleBuffered = true;
			this.Name = "PickIconScene";
			this.Size = new System.Drawing.Size(980, 680);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCommand;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnPause;
		private System.Windows.Forms.Label lbScore;
		private System.Windows.Forms.Panel panGamezone;
		private System.Windows.Forms.Timer timIcon;
		private System.Windows.Forms.Timer timPause;
	}
}
