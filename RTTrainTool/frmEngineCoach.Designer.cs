namespace RTTrainTool
{
	partial class frmEngineCoach
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCarriage = new System.Windows.Forms.Button();
			this.btnLocomotiveSetting = new System.Windows.Forms.Button();
			this.lbTitle = new System.Windows.Forms.Label();
			this.btnReset = new System.Windows.Forms.Button();
			this.lbNullImage = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.txtURL = new System.Windows.Forms.TextBox();
			this.lbURL = new System.Windows.Forms.Label();
			this.lbCarry = new System.Windows.Forms.Label();
			this.lbRank = new System.Windows.Forms.Label();
			this.lbRTW02 = new System.Windows.Forms.Label();
			this.lbRTW01 = new System.Windows.Forms.Label();
			this.nuPrice = new System.Windows.Forms.NumericUpDown();
			this.lbPrice = new System.Windows.Forms.Label();
			this.nuMaintenance = new System.Windows.Forms.NumericUpDown();
			this.lbMaintenance = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lbName = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.nuPrice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuMaintenance)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCarriage
			// 
			this.btnCarriage.Font = new System.Drawing.Font("맑은 고딕", 12F);
			this.btnCarriage.Location = new System.Drawing.Point(173, 292);
			this.btnCarriage.Name = "btnCarriage";
			this.btnCarriage.Size = new System.Drawing.Size(437, 40);
			this.btnCarriage.TabIndex = 120;
			this.btnCarriage.Text = "설정";
			this.btnCarriage.UseVisualStyleBackColor = true;
			this.btnCarriage.Click += new System.EventHandler(this.btnCarriage_Click);
			// 
			// btnLocomotiveSetting
			// 
			this.btnLocomotiveSetting.Font = new System.Drawing.Font("맑은 고딕", 12F);
			this.btnLocomotiveSetting.Location = new System.Drawing.Point(199, 244);
			this.btnLocomotiveSetting.Name = "btnLocomotiveSetting";
			this.btnLocomotiveSetting.Size = new System.Drawing.Size(411, 40);
			this.btnLocomotiveSetting.TabIndex = 119;
			this.btnLocomotiveSetting.Text = "설정";
			this.btnLocomotiveSetting.UseVisualStyleBackColor = true;
			this.btnLocomotiveSetting.Click += new System.EventHandler(this.btnLocomotiveSetting_Click);
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbTitle.ForeColor = System.Drawing.SystemColors.Highlight;
			this.lbTitle.Location = new System.Drawing.Point(226, 40);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(188, 37);
			this.lbTitle.TabIndex = 118;
			this.lbTitle.Text = "기관객차 제작";
			// 
			// btnReset
			// 
			this.btnReset.Font = new System.Drawing.Font("맑은 고딕", 12F);
			this.btnReset.Location = new System.Drawing.Point(551, 338);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(59, 45);
			this.btnReset.TabIndex = 117;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// lbNullImage
			// 
			this.lbNullImage.AutoSize = true;
			this.lbNullImage.Location = new System.Drawing.Point(198, 388);
			this.lbNullImage.Name = "lbNullImage";
			this.lbNullImage.Size = new System.Drawing.Size(298, 15);
			this.lbNullImage.TabIndex = 116;
			this.lbNullImage.Text = "이미지를 선택하지 않으면 기본 이미지를 사용 합니다.";
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 12F);
			this.btnSave.Location = new System.Drawing.Point(34, 410);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(580, 31);
			this.btnSave.TabIndex = 115;
			this.btnSave.Text = "저장";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnBrowse
			// 
			this.btnBrowse.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.btnBrowse.Location = new System.Drawing.Point(502, 338);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(43, 45);
			this.btnBrowse.TabIndex = 114;
			this.btnBrowse.Text = "...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// txtURL
			// 
			this.txtURL.BackColor = System.Drawing.Color.White;
			this.txtURL.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.txtURL.Location = new System.Drawing.Point(199, 339);
			this.txtURL.MaxLength = 20;
			this.txtURL.Name = "txtURL";
			this.txtURL.ReadOnly = true;
			this.txtURL.Size = new System.Drawing.Size(297, 43);
			this.txtURL.TabIndex = 113;
			// 
			// lbURL
			// 
			this.lbURL.AutoSize = true;
			this.lbURL.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbURL.Location = new System.Drawing.Point(27, 339);
			this.lbURL.Name = "lbURL";
			this.lbURL.Size = new System.Drawing.Size(167, 37);
			this.lbURL.TabIndex = 112;
			this.lbURL.Text = "이미지 경로:";
			// 
			// lbCarry
			// 
			this.lbCarry.AutoSize = true;
			this.lbCarry.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbCarry.Location = new System.Drawing.Point(27, 290);
			this.lbCarry.Name = "lbCarry";
			this.lbCarry.Size = new System.Drawing.Size(140, 37);
			this.lbCarry.TabIndex = 111;
			this.lbCarry.Text = "객차 정보:";
			// 
			// lbRank
			// 
			this.lbRank.AutoSize = true;
			this.lbRank.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbRank.Location = new System.Drawing.Point(27, 242);
			this.lbRank.Name = "lbRank";
			this.lbRank.Size = new System.Drawing.Size(167, 37);
			this.lbRank.TabIndex = 110;
			this.lbRank.Text = "기관차 정보:";
			// 
			// lbRTW02
			// 
			this.lbRTW02.AutoSize = true;
			this.lbRTW02.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbRTW02.Location = new System.Drawing.Point(528, 192);
			this.lbRTW02.Name = "lbRTW02";
			this.lbRTW02.Size = new System.Drawing.Size(73, 37);
			this.lbRTW02.TabIndex = 109;
			this.lbRTW02.Text = "RTW";
			// 
			// lbRTW01
			// 
			this.lbRTW01.AutoSize = true;
			this.lbRTW01.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbRTW01.Location = new System.Drawing.Point(528, 143);
			this.lbRTW01.Name = "lbRTW01";
			this.lbRTW01.Size = new System.Drawing.Size(73, 37);
			this.lbRTW01.TabIndex = 108;
			this.lbRTW01.Text = "RTW";
			// 
			// nuPrice
			// 
			this.nuPrice.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.nuPrice.Location = new System.Drawing.Point(137, 192);
			this.nuPrice.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
			this.nuPrice.Name = "nuPrice";
			this.nuPrice.Size = new System.Drawing.Size(385, 43);
			this.nuPrice.TabIndex = 107;
			// 
			// lbPrice
			// 
			this.lbPrice.AutoSize = true;
			this.lbPrice.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbPrice.Location = new System.Drawing.Point(27, 193);
			this.lbPrice.Name = "lbPrice";
			this.lbPrice.Size = new System.Drawing.Size(104, 37);
			this.lbPrice.TabIndex = 106;
			this.lbPrice.Text = "구입비:";
			// 
			// nuMaintenance
			// 
			this.nuMaintenance.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.nuMaintenance.Location = new System.Drawing.Point(138, 141);
			this.nuMaintenance.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
			this.nuMaintenance.Name = "nuMaintenance";
			this.nuMaintenance.Size = new System.Drawing.Size(384, 43);
			this.nuMaintenance.TabIndex = 105;
			// 
			// lbMaintenance
			// 
			this.lbMaintenance.AutoSize = true;
			this.lbMaintenance.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbMaintenance.Location = new System.Drawing.Point(27, 141);
			this.lbMaintenance.Name = "lbMaintenance";
			this.lbMaintenance.Size = new System.Drawing.Size(113, 37);
			this.lbMaintenance.TabIndex = 104;
			this.lbMaintenance.Text = "유지비: ";
			// 
			// txtName
			// 
			this.txtName.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.txtName.Location = new System.Drawing.Point(113, 90);
			this.txtName.MaxLength = 20;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(497, 43);
			this.txtName.TabIndex = 103;
			// 
			// lbName
			// 
			this.lbName.AutoSize = true;
			this.lbName.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbName.Location = new System.Drawing.Point(27, 89);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(86, 37);
			this.lbName.TabIndex = 102;
			this.lbName.Text = "이름: ";
			// 
			// frmInstitutionsCarriage
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(640, 480);
			this.Controls.Add(this.btnCarriage);
			this.Controls.Add(this.btnLocomotiveSetting);
			this.Controls.Add(this.lbTitle);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.lbNullImage);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.txtURL);
			this.Controls.Add(this.lbURL);
			this.Controls.Add(this.lbCarry);
			this.Controls.Add(this.lbRank);
			this.Controls.Add(this.lbRTW02);
			this.Controls.Add(this.lbRTW01);
			this.Controls.Add(this.nuPrice);
			this.Controls.Add(this.lbPrice);
			this.Controls.Add(this.nuMaintenance);
			this.Controls.Add(this.lbMaintenance);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.lbName);
			this.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.Name = "frmInstitutionsCarriage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "기관객차 제작";
			((System.ComponentModel.ISupportInitialize)(this.nuPrice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuMaintenance)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCarriage;
		private System.Windows.Forms.Button btnLocomotiveSetting;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Label lbNullImage;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.TextBox txtURL;
		private System.Windows.Forms.Label lbURL;
		private System.Windows.Forms.Label lbCarry;
		private System.Windows.Forms.Label lbRank;
		private System.Windows.Forms.Label lbRTW02;
		private System.Windows.Forms.Label lbRTW01;
		private System.Windows.Forms.NumericUpDown nuPrice;
		private System.Windows.Forms.Label lbPrice;
		private System.Windows.Forms.NumericUpDown nuMaintenance;
		private System.Windows.Forms.Label lbMaintenance;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lbName;
	}
}