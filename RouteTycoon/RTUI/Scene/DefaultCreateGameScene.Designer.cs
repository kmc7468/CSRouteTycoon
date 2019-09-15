namespace RouteTycoon.RTUI
{
	partial class DefaultCreateGameScene
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
			this.lbTitle = new System.Windows.Forms.Label();
			this.lbMessage = new RouteTycoon.RTCore.TitleLabel();
			this.lbNext = new RouteTycoon.RTCore.TextButton();
			this.lbBack = new RouteTycoon.RTCore.TextButton();
			this.lbLogo = new System.Windows.Forms.Label();
			this.tbLogoPath = new System.Windows.Forms.TextBox();
			this.lbBrowse = new RouteTycoon.RTCore.TextButton();
			this.cbDefaultLogo = new System.Windows.Forms.CheckBox();
			this.lbAI = new System.Windows.Forms.Label();
			this.nudAI = new System.Windows.Forms.NumericUpDown();
			this.picLogo = new System.Windows.Forms.PictureBox();
			this.lbGoodsize = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.nudAI)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
			this.SuspendLayout();
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.BackColor = System.Drawing.Color.Transparent;
			this.lbTitle.Font = new System.Drawing.Font("굴림", 30F);
			this.lbTitle.ForeColor = System.Drawing.Color.White;
			this.lbTitle.Location = new System.Drawing.Point(100, 132);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(227, 40);
			this.lbTitle.TabIndex = 2;
			this.lbTitle.Text = "(newgame)";
			// 
			// lbMessage
			// 
			this.lbMessage.AutoSize = true;
			this.lbMessage.BackColor = System.Drawing.Color.Transparent;
			this.lbMessage.ForeColor = System.Drawing.Color.White;
			this.lbMessage.HaloTextStr = "(msg)";
			this.lbMessage.Location = new System.Drawing.Point(150, 243);
			this.lbMessage.Name = "lbMessage";
			this.lbMessage.Size = new System.Drawing.Size(40, 12);
			this.lbMessage.TabIndex = 3;
			this.lbMessage.Text = "(msg)";
			// 
			// lbNext
			// 
			this.lbNext.AutoSize = true;
			this.lbNext.BackColor = System.Drawing.Color.Transparent;
			this.lbNext.Font = new System.Drawing.Font("굴림", 30F);
			this.lbNext.ForeColor = System.Drawing.Color.White;
			this.lbNext.Location = new System.Drawing.Point(724, 427);
			this.lbNext.Name = "lbNext";
			this.lbNext.SelColor = System.Drawing.Color.Gray;
			this.lbNext.Size = new System.Drawing.Size(126, 40);
			this.lbNext.TabIndex = 4;
			this.lbNext.Text = "(next)";
			this.lbNext.Click += new System.EventHandler(this.lbNext_Click);
			// 
			// lbBack
			// 
			this.lbBack.AutoSize = true;
			this.lbBack.BackColor = System.Drawing.Color.Transparent;
			this.lbBack.Font = new System.Drawing.Font("굴림", 30F);
			this.lbBack.ForeColor = System.Drawing.Color.White;
			this.lbBack.Location = new System.Drawing.Point(590, 427);
			this.lbBack.Name = "lbBack";
			this.lbBack.SelColor = System.Drawing.Color.Gray;
			this.lbBack.Size = new System.Drawing.Size(137, 40);
			this.lbBack.TabIndex = 5;
			this.lbBack.Text = "(back)";
			this.lbBack.Click += new System.EventHandler(this.lbBack_Click);
			// 
			// lbLogo
			// 
			this.lbLogo.AutoSize = true;
			this.lbLogo.BackColor = System.Drawing.Color.Transparent;
			this.lbLogo.Font = new System.Drawing.Font("굴림", 14F);
			this.lbLogo.Location = new System.Drawing.Point(148, 276);
			this.lbLogo.Name = "lbLogo";
			this.lbLogo.Size = new System.Drawing.Size(56, 19);
			this.lbLogo.TabIndex = 6;
			this.lbLogo.Text = "(logo)";
			this.lbLogo.Visible = false;
			// 
			// tbLogoPath
			// 
			this.tbLogoPath.BackColor = System.Drawing.Color.White;
			this.tbLogoPath.Font = new System.Drawing.Font("굴림", 10F);
			this.tbLogoPath.Location = new System.Drawing.Point(217, 302);
			this.tbLogoPath.Name = "tbLogoPath";
			this.tbLogoPath.ReadOnly = true;
			this.tbLogoPath.Size = new System.Drawing.Size(363, 23);
			this.tbLogoPath.TabIndex = 7;
			this.tbLogoPath.Visible = false;
			// 
			// lbBrowse
			// 
			this.lbBrowse.AutoSize = true;
			this.lbBrowse.BackColor = System.Drawing.Color.Transparent;
			this.lbBrowse.Font = new System.Drawing.Font("굴림", 12F);
			this.lbBrowse.ForeColor = System.Drawing.Color.Black;
			this.lbBrowse.Location = new System.Drawing.Point(587, 303);
			this.lbBrowse.Name = "lbBrowse";
			this.lbBrowse.SelColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.lbBrowse.Size = new System.Drawing.Size(72, 16);
			this.lbBrowse.TabIndex = 8;
			this.lbBrowse.Text = "(browse)";
			this.lbBrowse.Visible = false;
			this.lbBrowse.Click += new System.EventHandler(this.lbBrowse_Click);
			// 
			// cbDefaultLogo
			// 
			this.cbDefaultLogo.AutoSize = true;
			this.cbDefaultLogo.BackColor = System.Drawing.Color.Transparent;
			this.cbDefaultLogo.Checked = true;
			this.cbDefaultLogo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbDefaultLogo.Font = new System.Drawing.Font("굴림", 12F);
			this.cbDefaultLogo.ForeColor = System.Drawing.Color.Black;
			this.cbDefaultLogo.Location = new System.Drawing.Point(217, 334);
			this.cbDefaultLogo.Name = "cbDefaultLogo";
			this.cbDefaultLogo.Size = new System.Drawing.Size(115, 20);
			this.cbDefaultLogo.TabIndex = 9;
			this.cbDefaultLogo.Text = "(usedefault)";
			this.cbDefaultLogo.UseVisualStyleBackColor = false;
			this.cbDefaultLogo.Visible = false;
			this.cbDefaultLogo.CheckedChanged += new System.EventHandler(this.cbDefaultLogo_CheckedChanged);
			// 
			// lbAI
			// 
			this.lbAI.AutoSize = true;
			this.lbAI.BackColor = System.Drawing.Color.Transparent;
			this.lbAI.Font = new System.Drawing.Font("굴림", 14F);
			this.lbAI.Location = new System.Drawing.Point(148, 374);
			this.lbAI.Name = "lbAI";
			this.lbAI.Size = new System.Drawing.Size(80, 19);
			this.lbAI.TabIndex = 10;
			this.lbAI.Text = "(aicount)";
			this.lbAI.Visible = false;
			// 
			// nudAI
			// 
			this.nudAI.Location = new System.Drawing.Point(152, 402);
			this.nudAI.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.nudAI.Name = "nudAI";
			this.nudAI.Size = new System.Drawing.Size(52, 21);
			this.nudAI.TabIndex = 11;
			this.nudAI.Visible = false;
			// 
			// picLogo
			// 
			this.picLogo.BackColor = System.Drawing.Color.Transparent;
			this.picLogo.Location = new System.Drawing.Point(147, 302);
			this.picLogo.Name = "picLogo";
			this.picLogo.Size = new System.Drawing.Size(63, 63);
			this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picLogo.TabIndex = 12;
			this.picLogo.TabStop = false;
			this.picLogo.Visible = false;
			// 
			// lbGoodsize
			// 
			this.lbGoodsize.AutoSize = true;
			this.lbGoodsize.BackColor = System.Drawing.Color.Transparent;
			this.lbGoodsize.Font = new System.Drawing.Font("굴림", 12F);
			this.lbGoodsize.ForeColor = System.Drawing.Color.Black;
			this.lbGoodsize.Location = new System.Drawing.Point(587, 327);
			this.lbGoodsize.Name = "lbGoodsize";
			this.lbGoodsize.Size = new System.Drawing.Size(162, 16);
			this.lbGoodsize.TabIndex = 13;
			this.lbGoodsize.Text = "(goodsize) : 400x400";
			this.lbGoodsize.Visible = false;
			// 
			// DefaultCreateGameScene
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Controls.Add(this.lbGoodsize);
			this.Controls.Add(this.picLogo);
			this.Controls.Add(this.nudAI);
			this.Controls.Add(this.lbAI);
			this.Controls.Add(this.cbDefaultLogo);
			this.Controls.Add(this.lbBrowse);
			this.Controls.Add(this.tbLogoPath);
			this.Controls.Add(this.lbLogo);
			this.Controls.Add(this.lbBack);
			this.Controls.Add(this.lbNext);
			this.Controls.Add(this.lbMessage);
			this.Controls.Add(this.lbTitle);
			this.DoubleBuffered = true;
			this.Name = "DefaultCreateGameScene";
			this.Size = new System.Drawing.Size(879, 546);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.DefaultCreateGameScene_Paint);
			this.Resize += new System.EventHandler(this.DefaultCreateGameScene_Resize);
			((System.ComponentModel.ISupportInitialize)(this.nudAI)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbTitle;
		private RTCore.TitleLabel lbMessage;
		private RTCore.TextButton lbNext;
		private RTCore.TextButton lbBack;
		private System.Windows.Forms.Label lbLogo;
		private System.Windows.Forms.TextBox tbLogoPath;
		private RTCore.TextButton lbBrowse;
		private System.Windows.Forms.CheckBox cbDefaultLogo;
		private System.Windows.Forms.Label lbAI;
		private System.Windows.Forms.NumericUpDown nudAI;
		private System.Windows.Forms.PictureBox picLogo;
		private System.Windows.Forms.Label lbGoodsize;
	}
}
