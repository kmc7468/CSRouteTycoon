using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	partial class NewGameScene
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
			this.picAtus = new System.Windows.Forms.PictureBox();
			this.lbBack = new RouteTycoon.RTCore.TextButton();
			this.lbSandbox = new RouteTycoon.RTCore.TextButton();
			this.lbDefault = new RouteTycoon.RTCore.TextButton();
			this.lbCareer = new RouteTycoon.RTCore.TextButton();
			this.lbTitle = new RouteTycoon.RTCore.TitleLabel();
			((System.ComponentModel.ISupportInitialize)(this.picAtus)).BeginInit();
			this.SuspendLayout();
			// 
			// picAtus
			// 
			this.picAtus.BackColor = System.Drawing.Color.Transparent;
			this.picAtus.Location = new System.Drawing.Point(868, 631);
			this.picAtus.Name = "picAtus";
			this.picAtus.Size = new System.Drawing.Size(96, 36);
			this.picAtus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picAtus.TabIndex = 12;
			this.picAtus.TabStop = false;
			// 
			// lbBack
			// 
			this.lbBack.AutoSize = true;
			this.lbBack.BackColor = System.Drawing.Color.Transparent;
			this.lbBack.Font = new System.Drawing.Font("굴림", 30F);
			this.lbBack.Location = new System.Drawing.Point(21, 403);
			this.lbBack.Name = "lbBack";
			this.lbBack.SelColor = System.Drawing.Color.Gray;
			this.lbBack.Size = new System.Drawing.Size(137, 40);
			this.lbBack.TabIndex = 11;
			this.lbBack.Text = "(back)";
			this.lbBack.Click += new System.EventHandler(this.lbBack_Click);
			// 
			// lbSandbox
			// 
			this.lbSandbox.AutoSize = true;
			this.lbSandbox.BackColor = System.Drawing.Color.Transparent;
			this.lbSandbox.Font = new System.Drawing.Font("굴림", 30F);
			this.lbSandbox.Location = new System.Drawing.Point(21, 350);
			this.lbSandbox.Name = "lbSandbox";
			this.lbSandbox.SelColor = System.Drawing.Color.Gray;
			this.lbSandbox.Size = new System.Drawing.Size(311, 40);
			this.lbSandbox.TabIndex = 10;
			this.lbSandbox.Text = "(sandboxmode)";
			this.lbSandbox.Click += new System.EventHandler(this.lbSandbox_Click);
			// 
			// lbDefault
			// 
			this.lbDefault.AutoSize = true;
			this.lbDefault.BackColor = System.Drawing.Color.Transparent;
			this.lbDefault.Font = new System.Drawing.Font("굴림", 30F);
			this.lbDefault.Location = new System.Drawing.Point(21, 295);
			this.lbDefault.Name = "lbDefault";
			this.lbDefault.SelColor = System.Drawing.Color.Gray;
			this.lbDefault.Size = new System.Drawing.Size(281, 40);
			this.lbDefault.TabIndex = 9;
			this.lbDefault.Text = "(defaultmode)";
			this.lbDefault.Click += new System.EventHandler(this.lbDefault_Click);
			// 
			// lbCareer
			// 
			this.lbCareer.AutoSize = true;
			this.lbCareer.BackColor = System.Drawing.Color.Transparent;
			this.lbCareer.Font = new System.Drawing.Font("굴림", 30F);
			this.lbCareer.Location = new System.Drawing.Point(21, 240);
			this.lbCareer.Name = "lbCareer";
			this.lbCareer.SelColor = System.Drawing.Color.Gray;
			this.lbCareer.Size = new System.Drawing.Size(270, 40);
			this.lbCareer.TabIndex = 8;
			this.lbCareer.Text = "(careermode)";
			this.lbCareer.Click += new System.EventHandler(this.lbCareer_Click);
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.BackColor = System.Drawing.Color.Transparent;
			this.lbTitle.HaloTextStr = "(newgame)";
			this.lbTitle.Location = new System.Drawing.Point(32, 53);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(71, 12);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "(newgame)";
			// 
			// NewGameScene
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Controls.Add(this.picAtus);
			this.Controls.Add(this.lbBack);
			this.Controls.Add(this.lbSandbox);
			this.Controls.Add(this.lbDefault);
			this.Controls.Add(this.lbCareer);
			this.Controls.Add(this.lbTitle);
			this.DoubleBuffered = true;
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "NewGameScene";
			this.Size = new System.Drawing.Size(980, 680);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.NewGameScene_Paint);
			((System.ComponentModel.ISupportInitialize)(this.picAtus)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private TitleLabel lbTitle;
		private TextButton lbBack;
		private TextButton lbSandbox;
		private TextButton lbDefault;
		private TextButton lbCareer;
		private System.Windows.Forms.PictureBox picAtus;
	}
}
