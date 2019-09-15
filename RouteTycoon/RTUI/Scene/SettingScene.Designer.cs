namespace RouteTycoon.RTUI
{
	partial class SettingScene
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
			this.lbSound = new RouteTycoon.RTCore.TextButton();
			this.lbRes = new RouteTycoon.RTCore.TextButton();
			this.lbBack = new RouteTycoon.RTCore.TextButton();
			this.lbLang = new RouteTycoon.RTCore.TextButton();
			this.lbTitle = new System.Windows.Forms.Label();
			this.lbUpdate = new RouteTycoon.RTCore.TextButton();
			this.lbGame = new RouteTycoon.RTCore.TextButton();
			this.SuspendLayout();
			// 
			// lbSound
			// 
			this.lbSound.AutoSize = true;
			this.lbSound.BackColor = System.Drawing.Color.Transparent;
			this.lbSound.Font = new System.Drawing.Font("굴림", 30F);
			this.lbSound.ForeColor = System.Drawing.Color.White;
			this.lbSound.Location = new System.Drawing.Point(168, 308);
			this.lbSound.Name = "lbSound";
			this.lbSound.SelColor = System.Drawing.Color.Gray;
			this.lbSound.Size = new System.Drawing.Size(162, 40);
			this.lbSound.TabIndex = 5;
			this.lbSound.Text = "(sound)";
			this.lbSound.Click += new System.EventHandler(this.lbSound_Click);
			// 
			// lbRes
			// 
			this.lbRes.AutoSize = true;
			this.lbRes.BackColor = System.Drawing.Color.Transparent;
			this.lbRes.Font = new System.Drawing.Font("굴림", 30F);
			this.lbRes.ForeColor = System.Drawing.Color.White;
			this.lbRes.Location = new System.Drawing.Point(168, 258);
			this.lbRes.Name = "lbRes";
			this.lbRes.SelColor = System.Drawing.Color.Gray;
			this.lbRes.Size = new System.Drawing.Size(210, 40);
			this.lbRes.TabIndex = 4;
			this.lbRes.Text = "(resource)";
			this.lbRes.Click += new System.EventHandler(this.lbRes_Click);
			// 
			// lbBack
			// 
			this.lbBack.AutoSize = true;
			this.lbBack.BackColor = System.Drawing.Color.Transparent;
			this.lbBack.Font = new System.Drawing.Font("굴림", 30F);
			this.lbBack.ForeColor = System.Drawing.Color.White;
			this.lbBack.Location = new System.Drawing.Point(826, 494);
			this.lbBack.Name = "lbBack";
			this.lbBack.SelColor = System.Drawing.Color.Gray;
			this.lbBack.Size = new System.Drawing.Size(137, 40);
			this.lbBack.TabIndex = 3;
			this.lbBack.Text = "(back)";
			this.lbBack.Click += new System.EventHandler(this.lbBack_Click);
			// 
			// lbLang
			// 
			this.lbLang.AutoSize = true;
			this.lbLang.BackColor = System.Drawing.Color.Transparent;
			this.lbLang.Font = new System.Drawing.Font("굴림", 30F);
			this.lbLang.ForeColor = System.Drawing.Color.White;
			this.lbLang.Location = new System.Drawing.Point(168, 208);
			this.lbLang.Name = "lbLang";
			this.lbLang.SelColor = System.Drawing.Color.Gray;
			this.lbLang.Size = new System.Drawing.Size(126, 40);
			this.lbLang.TabIndex = 2;
			this.lbLang.Text = "(lang)";
			this.lbLang.Click += new System.EventHandler(this.lbLang_Click);
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.BackColor = System.Drawing.Color.Transparent;
			this.lbTitle.Font = new System.Drawing.Font("굴림", 30F);
			this.lbTitle.ForeColor = System.Drawing.Color.White;
			this.lbTitle.Location = new System.Drawing.Point(100, 132);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(174, 40);
			this.lbTitle.TabIndex = 6;
			this.lbTitle.Text = "(setting)";
			// 
			// lbUpdate
			// 
			this.lbUpdate.AutoSize = true;
			this.lbUpdate.BackColor = System.Drawing.Color.Transparent;
			this.lbUpdate.Font = new System.Drawing.Font("굴림", 30F);
			this.lbUpdate.ForeColor = System.Drawing.Color.White;
			this.lbUpdate.Location = new System.Drawing.Point(168, 359);
			this.lbUpdate.Name = "lbUpdate";
			this.lbUpdate.SelColor = System.Drawing.Color.Gray;
			this.lbUpdate.Size = new System.Drawing.Size(177, 40);
			this.lbUpdate.TabIndex = 7;
			this.lbUpdate.Text = "(update)";
			this.lbUpdate.Click += new System.EventHandler(this.lbUpdate_Click);
			// 
			// lbGame
			// 
			this.lbGame.AutoSize = true;
			this.lbGame.BackColor = System.Drawing.Color.Transparent;
			this.lbGame.Font = new System.Drawing.Font("굴림", 30F);
			this.lbGame.ForeColor = System.Drawing.Color.White;
			this.lbGame.Location = new System.Drawing.Point(168, 410);
			this.lbGame.Name = "lbGame";
			this.lbGame.SelColor = System.Drawing.Color.Gray;
			this.lbGame.Size = new System.Drawing.Size(151, 40);
			this.lbGame.TabIndex = 8;
			this.lbGame.Text = "(game)";
			this.lbGame.Click += new System.EventHandler(this.lbGame_Click);
			// 
			// SettingScene
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Controls.Add(this.lbGame);
			this.Controls.Add(this.lbUpdate);
			this.Controls.Add(this.lbTitle);
			this.Controls.Add(this.lbSound);
			this.Controls.Add(this.lbRes);
			this.Controls.Add(this.lbBack);
			this.Controls.Add(this.lbLang);
			this.DoubleBuffered = true;
			this.Name = "SettingScene";
			this.Size = new System.Drawing.Size(940, 565);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.SettingScene_Paint);
			this.Resize += new System.EventHandler(this.SettingScene_Resize);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private RTCore.TextButton lbLang;
		private RTCore.TextButton lbBack;
		private RTCore.TextButton lbRes;
		private RTCore.TextButton lbSound;
		private System.Windows.Forms.Label lbTitle;
		private RTCore.TextButton lbUpdate;
		private RTCore.TextButton lbGame;
	}
}
