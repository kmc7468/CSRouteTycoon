namespace RouteTycoon.RTUI
{
	partial class GameSettingScene
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
			this.lbAccept = new RouteTycoon.RTCore.TextButton();
			this.cbUseAutoSave = new System.Windows.Forms.CheckBox();
			this.nuAutoSaveTime = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.nuAutoSaveTime)).BeginInit();
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
			this.lbTitle.Size = new System.Drawing.Size(151, 40);
			this.lbTitle.TabIndex = 8;
			this.lbTitle.Text = "(game)";
			// 
			// lbAccept
			// 
			this.lbAccept.AutoSize = true;
			this.lbAccept.BackColor = System.Drawing.Color.Transparent;
			this.lbAccept.Font = new System.Drawing.Font("굴림", 30F);
			this.lbAccept.ForeColor = System.Drawing.Color.White;
			this.lbAccept.Location = new System.Drawing.Point(826, 494);
			this.lbAccept.Name = "lbAccept";
			this.lbAccept.SelColor = System.Drawing.Color.Gray;
			this.lbAccept.Size = new System.Drawing.Size(176, 40);
			this.lbAccept.TabIndex = 7;
			this.lbAccept.Text = "(accept)";
			this.lbAccept.Click += new System.EventHandler(this.lbAccept_Click);
			// 
			// cbUseAutoSave
			// 
			this.cbUseAutoSave.AutoSize = true;
			this.cbUseAutoSave.BackColor = System.Drawing.Color.Transparent;
			this.cbUseAutoSave.Font = new System.Drawing.Font("굴림", 20F);
			this.cbUseAutoSave.ForeColor = System.Drawing.Color.White;
			this.cbUseAutoSave.Location = new System.Drawing.Point(107, 193);
			this.cbUseAutoSave.Name = "cbUseAutoSave";
			this.cbUseAutoSave.Size = new System.Drawing.Size(163, 31);
			this.cbUseAutoSave.TabIndex = 9;
			this.cbUseAutoSave.Text = "(autosave)";
			this.cbUseAutoSave.UseVisualStyleBackColor = false;
			// 
			// nuAutoSaveTime
			// 
			this.nuAutoSaveTime.Font = new System.Drawing.Font("굴림", 12F);
			this.nuAutoSaveTime.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.nuAutoSaveTime.Location = new System.Drawing.Point(230, 243);
			this.nuAutoSaveTime.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
			this.nuAutoSaveTime.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.nuAutoSaveTime.Name = "nuAutoSaveTime";
			this.nuAutoSaveTime.Size = new System.Drawing.Size(120, 26);
			this.nuAutoSaveTime.TabIndex = 10;
			this.nuAutoSaveTime.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			// 
			// GameSettingScene
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add(this.nuAutoSaveTime);
			this.Controls.Add(this.cbUseAutoSave);
			this.Controls.Add(this.lbTitle);
			this.Controls.Add(this.lbAccept);
			this.DoubleBuffered = true;
			this.Name = "GameSettingScene";
			this.Size = new System.Drawing.Size(940, 565);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameSettingScene_Paint);
			this.Resize += new System.EventHandler(this.GameSettingScene_Resize);
			((System.ComponentModel.ISupportInitialize)(this.nuAutoSaveTime)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbTitle;
		private RTCore.TextButton lbAccept;
		private System.Windows.Forms.CheckBox cbUseAutoSave;
		private System.Windows.Forms.NumericUpDown nuAutoSaveTime;
	}
}
