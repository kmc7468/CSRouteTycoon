namespace RTResourceMaker.UI
{
    partial class main
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
			this.btnExit = new System.Windows.Forms.Button();
			this.btnLoad = new System.Windows.Forms.Button();
			this.btnMake = new System.Windows.Forms.Button();
			this.lbVersion = new System.Windows.Forms.Label();
			this.btnSetting = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lbTitle.Location = new System.Drawing.Point(60, 90);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(180, 21);
			this.lbTitle.TabIndex = 7;
			this.lbTitle.Text = "RTResourceMaker";
			// 
			// btnExit
			// 
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnExit.Location = new System.Drawing.Point(64, 320);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(180, 40);
			this.btnExit.TabIndex = 6;
			this.btnExit.Text = "종료";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnLoad
			// 
			this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnLoad.Location = new System.Drawing.Point(64, 205);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(180, 40);
			this.btnLoad.TabIndex = 5;
			this.btnLoad.Text = "프로젝트 불러 오기";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnMake
			// 
			this.btnMake.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnMake.Location = new System.Drawing.Point(64, 155);
			this.btnMake.Name = "btnMake";
			this.btnMake.Size = new System.Drawing.Size(180, 40);
			this.btnMake.TabIndex = 4;
			this.btnMake.Text = "새 프로젝트";
			this.btnMake.UseVisualStyleBackColor = true;
			this.btnMake.Click += new System.EventHandler(this.btnMake_Click);
			// 
			// lbVersion
			// 
			this.lbVersion.AutoSize = true;
			this.lbVersion.Location = new System.Drawing.Point(250, 98);
			this.lbVersion.Name = "lbVersion";
			this.lbVersion.Size = new System.Drawing.Size(41, 12);
			this.lbVersion.TabIndex = 8;
			this.lbVersion.Text = "1.0.0.0";
			// 
			// btnSetting
			// 
			this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnSetting.Location = new System.Drawing.Point(64, 255);
			this.btnSetting.Name = "btnSetting";
			this.btnSetting.Size = new System.Drawing.Size(180, 40);
			this.btnSetting.TabIndex = 9;
			this.btnSetting.Text = "설정";
			this.btnSetting.UseVisualStyleBackColor = true;
			this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
			// 
			// main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.btnSetting);
			this.Controls.Add(this.lbVersion);
			this.Controls.Add(this.lbTitle);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnLoad);
			this.Controls.Add(this.btnMake);
			this.DoubleBuffered = true;
			this.Name = "main";
			this.Size = new System.Drawing.Size(564, 401);
			this.Load += new System.EventHandler(this.main_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnMake;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Button btnSetting;
    }
}
