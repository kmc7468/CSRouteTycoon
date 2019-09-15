namespace RouteTycoon.RTUI
{
	partial class OddEvenPage
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
			this.lbScore = new System.Windows.Forms.Label();
			this.picBlock = new System.Windows.Forms.PictureBox();
			this.lbEven = new RouteTycoon.RTCore.TextButton();
			this.lbOdd = new RouteTycoon.RTCore.TextButton();
			this.lbNewGame = new RouteTycoon.RTCore.TextButton();
			((System.ComponentModel.ISupportInitialize)(this.picBlock)).BeginInit();
			this.SuspendLayout();
			// 
			// lbScore
			// 
			this.lbScore.AutoSize = true;
			this.lbScore.Font = new System.Drawing.Font("굴림", 20F);
			this.lbScore.Location = new System.Drawing.Point(16, 49);
			this.lbScore.Name = "lbScore";
			this.lbScore.Size = new System.Drawing.Size(145, 27);
			this.lbScore.TabIndex = 0;
			this.lbScore.Text = "O: 0   X: 0";
			// 
			// picBlock
			// 
			this.picBlock.Location = new System.Drawing.Point(298, 175);
			this.picBlock.Name = "picBlock";
			this.picBlock.Size = new System.Drawing.Size(205, 205);
			this.picBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBlock.TabIndex = 2;
			this.picBlock.TabStop = false;
			// 
			// lbEven
			// 
			this.lbEven.AutoSize = true;
			this.lbEven.Font = new System.Drawing.Font("굴림", 30F);
			this.lbEven.Location = new System.Drawing.Point(414, 414);
			this.lbEven.Name = "lbEven";
			this.lbEven.SelColor = System.Drawing.Color.Gray;
			this.lbEven.Size = new System.Drawing.Size(57, 40);
			this.lbEven.TabIndex = 6;
			this.lbEven.Text = "짝";
			this.lbEven.Click += new System.EventHandler(this.lbEven_Click);
			// 
			// lbOdd
			// 
			this.lbOdd.AutoSize = true;
			this.lbOdd.Font = new System.Drawing.Font("굴림", 30F);
			this.lbOdd.Location = new System.Drawing.Point(329, 414);
			this.lbOdd.Name = "lbOdd";
			this.lbOdd.SelColor = System.Drawing.Color.Gray;
			this.lbOdd.Size = new System.Drawing.Size(57, 40);
			this.lbOdd.TabIndex = 5;
			this.lbOdd.Text = "홀";
			this.lbOdd.Click += new System.EventHandler(this.lbOdd_Click);
			// 
			// lbNewGame
			// 
			this.lbNewGame.AutoSize = true;
			this.lbNewGame.Font = new System.Drawing.Font("굴림", 30F);
			this.lbNewGame.Location = new System.Drawing.Point(305, 412);
			this.lbNewGame.Name = "lbNewGame";
			this.lbNewGame.SelColor = System.Drawing.Color.Gray;
			this.lbNewGame.Size = new System.Drawing.Size(190, 40);
			this.lbNewGame.TabIndex = 8;
			this.lbNewGame.Text = "다시 하기";
			this.lbNewGame.Visible = false;
			this.lbNewGame.Click += new System.EventHandler(this.lbNewGame_Click);
			// 
			// OddEvenPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.lbNewGame);
			this.Controls.Add(this.lbEven);
			this.Controls.Add(this.lbOdd);
			this.Controls.Add(this.picBlock);
			this.Controls.Add(this.lbScore);
			this.DoubleBuffered = true;
			this.Name = "OddEvenPage";
			this.Size = new System.Drawing.Size(800, 600);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.OddEvenPage_Paint);
			((System.ComponentModel.ISupportInitialize)(this.picBlock)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbScore;
		private System.Windows.Forms.PictureBox picBlock;
		private RTCore.TextButton lbEven;
		private RTCore.TextButton lbOdd;
		private RTCore.TextButton lbNewGame;
	}
}
