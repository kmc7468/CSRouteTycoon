using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	partial class GameStartScene
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
			this.lbMutiPlay = new RouteTycoon.RTCore.TextButton();
			this.lbGameLoad = new RouteTycoon.RTCore.TextButton();
			this.lbNewGame = new RouteTycoon.RTCore.TextButton();
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
			// lbMutiPlay
			// 
			this.lbMutiPlay.AutoSize = true;
			this.lbMutiPlay.BackColor = System.Drawing.Color.Transparent;
			this.lbMutiPlay.Font = new System.Drawing.Font("굴림", 30F);
			this.lbMutiPlay.Location = new System.Drawing.Point(21, 350);
			this.lbMutiPlay.Name = "lbMutiPlay";
			this.lbMutiPlay.SelColor = System.Drawing.Color.Gray;
			this.lbMutiPlay.Size = new System.Drawing.Size(241, 40);
			this.lbMutiPlay.TabIndex = 10;
			this.lbMutiPlay.Text = "(multimode)";
			this.lbMutiPlay.Click += new System.EventHandler(this.lbMutiPlay_Click);
			// 
			// lbGameLoad
			// 
			this.lbGameLoad.AutoSize = true;
			this.lbGameLoad.BackColor = System.Drawing.Color.Transparent;
			this.lbGameLoad.Font = new System.Drawing.Font("굴림", 30F);
			this.lbGameLoad.Location = new System.Drawing.Point(21, 295);
			this.lbGameLoad.Name = "lbGameLoad";
			this.lbGameLoad.SelColor = System.Drawing.Color.Gray;
			this.lbGameLoad.Size = new System.Drawing.Size(231, 40);
			this.lbGameLoad.TabIndex = 9;
			this.lbGameLoad.Text = "(gameload)";
			this.lbGameLoad.Click += new System.EventHandler(this.lbGameLoad_Click);
			// 
			// lbNewGame
			// 
			this.lbNewGame.AutoSize = true;
			this.lbNewGame.BackColor = System.Drawing.Color.Transparent;
			this.lbNewGame.Font = new System.Drawing.Font("굴림", 30F);
			this.lbNewGame.Location = new System.Drawing.Point(21, 240);
			this.lbNewGame.Name = "lbNewGame";
			this.lbNewGame.SelColor = System.Drawing.Color.Gray;
			this.lbNewGame.Size = new System.Drawing.Size(227, 40);
			this.lbNewGame.TabIndex = 8;
			this.lbNewGame.Text = "(newgame)";
			this.lbNewGame.Click += new System.EventHandler(this.lbNewGame_Click);
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.BackColor = System.Drawing.Color.Transparent;
			this.lbTitle.HaloTextStr = "(gamestart)";
			this.lbTitle.Location = new System.Drawing.Point(32, 53);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(71, 12);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "(gamestart)";
			// 
			// GameStartScene
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Controls.Add(this.picAtus);
			this.Controls.Add(this.lbBack);
			this.Controls.Add(this.lbMutiPlay);
			this.Controls.Add(this.lbGameLoad);
			this.Controls.Add(this.lbNewGame);
			this.Controls.Add(this.lbTitle);
			this.DoubleBuffered = true;
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "GameStartScene";
			this.Size = new System.Drawing.Size(980, 680);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameStartScene_Paint);
			((System.ComponentModel.ISupportInitialize)(this.picAtus)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private TitleLabel lbTitle;
		private TextButton lbBack;
		private TextButton lbMutiPlay;
		private TextButton lbGameLoad;
		private TextButton lbNewGame;
		private System.Windows.Forms.PictureBox picAtus;
	}
}
