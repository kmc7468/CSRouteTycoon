namespace RTTrainTool
{
	partial class frmLocomotive
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
			this.btnReset = new System.Windows.Forms.Button();
			this.lbNullImage = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.txtURL = new System.Windows.Forms.TextBox();
			this.lbURL = new System.Windows.Forms.Label();
			this.nuCarry = new System.Windows.Forms.NumericUpDown();
			this.lbCarry = new System.Windows.Forms.Label();
			this.lbTitle = new System.Windows.Forms.Label();
			this.cbRank = new System.Windows.Forms.ComboBox();
			this.lbRank = new System.Windows.Forms.Label();
			this.lbRTW02 = new System.Windows.Forms.Label();
			this.lbRTW01 = new System.Windows.Forms.Label();
			this.nuPrice = new System.Windows.Forms.NumericUpDown();
			this.lbPrice = new System.Windows.Forms.Label();
			this.lbKmSpeed = new System.Windows.Forms.Label();
			this.nuSpeed = new System.Windows.Forms.NumericUpDown();
			this.lbSpeed = new System.Windows.Forms.Label();
			this.nuMaintenance = new System.Windows.Forms.NumericUpDown();
			this.lbMaintenance = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lbName = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.nuCarry)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuPrice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuMaintenance)).BeginInit();
			this.SuspendLayout();
			// 
			// btnReset
			// 
			this.btnReset.Font = new System.Drawing.Font("맑은 고딕", 12F);
			this.btnReset.Location = new System.Drawing.Point(551, 372);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(59, 45);
			this.btnReset.TabIndex = 56;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// lbNullImage
			// 
			this.lbNullImage.AutoSize = true;
			this.lbNullImage.Location = new System.Drawing.Point(198, 421);
			this.lbNullImage.Name = "lbNullImage";
			this.lbNullImage.Size = new System.Drawing.Size(298, 15);
			this.lbNullImage.TabIndex = 55;
			this.lbNullImage.Text = "이미지를 선택하지 않으면 기본 이미지를 사용 합니다.";
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 12F);
			this.btnSave.Location = new System.Drawing.Point(34, 442);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(580, 31);
			this.btnSave.TabIndex = 54;
			this.btnSave.Text = "저장";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnBrowse
			// 
			this.btnBrowse.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.btnBrowse.Location = new System.Drawing.Point(502, 371);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(43, 45);
			this.btnBrowse.TabIndex = 53;
			this.btnBrowse.Text = "...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// txtURL
			// 
			this.txtURL.BackColor = System.Drawing.Color.White;
			this.txtURL.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.txtURL.Location = new System.Drawing.Point(199, 373);
			this.txtURL.MaxLength = 20;
			this.txtURL.Name = "txtURL";
			this.txtURL.ReadOnly = true;
			this.txtURL.Size = new System.Drawing.Size(297, 43);
			this.txtURL.TabIndex = 52;
			// 
			// lbURL
			// 
			this.lbURL.AutoSize = true;
			this.lbURL.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbURL.Location = new System.Drawing.Point(27, 372);
			this.lbURL.Name = "lbURL";
			this.lbURL.Size = new System.Drawing.Size(167, 37);
			this.lbURL.TabIndex = 51;
			this.lbURL.Text = "이미지 경로:";
			// 
			// nuCarry
			// 
			this.nuCarry.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.nuCarry.Location = new System.Drawing.Point(272, 322);
			this.nuCarry.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.nuCarry.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.nuCarry.Name = "nuCarry";
			this.nuCarry.Size = new System.Drawing.Size(338, 43);
			this.nuCarry.TabIndex = 50;
			this.nuCarry.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// lbCarry
			// 
			this.lbCarry.AutoSize = true;
			this.lbCarry.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbCarry.Location = new System.Drawing.Point(27, 323);
			this.lbCarry.Name = "lbCarry";
			this.lbCarry.Size = new System.Drawing.Size(239, 37);
			this.lbCarry.TabIndex = 49;
			this.lbCarry.Text = "연결 가능 객차 수:";
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbTitle.ForeColor = System.Drawing.SystemColors.Highlight;
			this.lbTitle.Location = new System.Drawing.Point(247, 7);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(161, 37);
			this.lbTitle.TabIndex = 48;
			this.lbTitle.Text = "기관차 제작";
			// 
			// cbRank
			// 
			this.cbRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRank.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.cbRank.FormattingEnabled = true;
			this.cbRank.Items.AddRange(new object[] {
            "고속 기관차",
            "일반 기관차"});
			this.cbRank.Location = new System.Drawing.Point(110, 266);
			this.cbRank.Name = "cbRank";
			this.cbRank.Size = new System.Drawing.Size(500, 45);
			this.cbRank.TabIndex = 47;
			// 
			// lbRank
			// 
			this.lbRank.AutoSize = true;
			this.lbRank.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbRank.Location = new System.Drawing.Point(27, 267);
			this.lbRank.Name = "lbRank";
			this.lbRank.Size = new System.Drawing.Size(77, 37);
			this.lbRank.TabIndex = 46;
			this.lbRank.Text = "등급:";
			// 
			// lbRTW02
			// 
			this.lbRTW02.AutoSize = true;
			this.lbRTW02.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbRTW02.Location = new System.Drawing.Point(528, 215);
			this.lbRTW02.Name = "lbRTW02";
			this.lbRTW02.Size = new System.Drawing.Size(73, 37);
			this.lbRTW02.TabIndex = 45;
			this.lbRTW02.Text = "RTW";
			// 
			// lbRTW01
			// 
			this.lbRTW01.AutoSize = true;
			this.lbRTW01.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbRTW01.Location = new System.Drawing.Point(528, 110);
			this.lbRTW01.Name = "lbRTW01";
			this.lbRTW01.Size = new System.Drawing.Size(73, 37);
			this.lbRTW01.TabIndex = 44;
			this.lbRTW01.Text = "RTW";
			// 
			// nuPrice
			// 
			this.nuPrice.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.nuPrice.Location = new System.Drawing.Point(137, 215);
			this.nuPrice.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
			this.nuPrice.Name = "nuPrice";
			this.nuPrice.Size = new System.Drawing.Size(385, 43);
			this.nuPrice.TabIndex = 43;
			// 
			// lbPrice
			// 
			this.lbPrice.AutoSize = true;
			this.lbPrice.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbPrice.Location = new System.Drawing.Point(27, 216);
			this.lbPrice.Name = "lbPrice";
			this.lbPrice.Size = new System.Drawing.Size(104, 37);
			this.lbPrice.TabIndex = 42;
			this.lbPrice.Text = "구입비:";
			// 
			// lbKmSpeed
			// 
			this.lbKmSpeed.AutoSize = true;
			this.lbKmSpeed.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbKmSpeed.Location = new System.Drawing.Point(528, 163);
			this.lbKmSpeed.Name = "lbKmSpeed";
			this.lbKmSpeed.Size = new System.Drawing.Size(82, 37);
			this.lbKmSpeed.TabIndex = 41;
			this.lbKmSpeed.Text = "km/h";
			// 
			// nuSpeed
			// 
			this.nuSpeed.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.nuSpeed.Location = new System.Drawing.Point(113, 163);
			this.nuSpeed.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.nuSpeed.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.nuSpeed.Name = "nuSpeed";
			this.nuSpeed.Size = new System.Drawing.Size(409, 43);
			this.nuSpeed.TabIndex = 40;
			this.nuSpeed.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
			// 
			// lbSpeed
			// 
			this.lbSpeed.AutoSize = true;
			this.lbSpeed.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbSpeed.Location = new System.Drawing.Point(27, 163);
			this.lbSpeed.Name = "lbSpeed";
			this.lbSpeed.Size = new System.Drawing.Size(86, 37);
			this.lbSpeed.TabIndex = 39;
			this.lbSpeed.Text = "속도: ";
			// 
			// nuMaintenance
			// 
			this.nuMaintenance.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.nuMaintenance.Location = new System.Drawing.Point(138, 108);
			this.nuMaintenance.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
			this.nuMaintenance.Name = "nuMaintenance";
			this.nuMaintenance.Size = new System.Drawing.Size(384, 43);
			this.nuMaintenance.TabIndex = 38;
			// 
			// lbMaintenance
			// 
			this.lbMaintenance.AutoSize = true;
			this.lbMaintenance.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbMaintenance.Location = new System.Drawing.Point(27, 108);
			this.lbMaintenance.Name = "lbMaintenance";
			this.lbMaintenance.Size = new System.Drawing.Size(113, 37);
			this.lbMaintenance.TabIndex = 37;
			this.lbMaintenance.Text = "유지비: ";
			// 
			// txtName
			// 
			this.txtName.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.txtName.Location = new System.Drawing.Point(113, 57);
			this.txtName.MaxLength = 20;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(497, 43);
			this.txtName.TabIndex = 36;
			// 
			// lbName
			// 
			this.lbName.AutoSize = true;
			this.lbName.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.lbName.Location = new System.Drawing.Point(27, 56);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(86, 37);
			this.lbName.TabIndex = 35;
			this.lbName.Text = "이름: ";
			// 
			// frmLocomotive
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(640, 480);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.lbNullImage);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.txtURL);
			this.Controls.Add(this.lbURL);
			this.Controls.Add(this.nuCarry);
			this.Controls.Add(this.lbCarry);
			this.Controls.Add(this.lbTitle);
			this.Controls.Add(this.cbRank);
			this.Controls.Add(this.lbRank);
			this.Controls.Add(this.lbRTW02);
			this.Controls.Add(this.lbRTW01);
			this.Controls.Add(this.nuPrice);
			this.Controls.Add(this.lbPrice);
			this.Controls.Add(this.lbKmSpeed);
			this.Controls.Add(this.nuSpeed);
			this.Controls.Add(this.lbSpeed);
			this.Controls.Add(this.nuMaintenance);
			this.Controls.Add(this.lbMaintenance);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.lbName);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmLocomotive";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "기관차 제작";
			((System.ComponentModel.ISupportInitialize)(this.nuCarry)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuPrice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuMaintenance)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Label lbNullImage;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.TextBox txtURL;
		private System.Windows.Forms.Label lbURL;
		private System.Windows.Forms.NumericUpDown nuCarry;
		private System.Windows.Forms.Label lbCarry;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.ComboBox cbRank;
		private System.Windows.Forms.Label lbRank;
		private System.Windows.Forms.Label lbRTW02;
		private System.Windows.Forms.Label lbRTW01;
		private System.Windows.Forms.NumericUpDown nuPrice;
		private System.Windows.Forms.Label lbPrice;
		private System.Windows.Forms.Label lbKmSpeed;
		private System.Windows.Forms.NumericUpDown nuSpeed;
		private System.Windows.Forms.Label lbSpeed;
		private System.Windows.Forms.NumericUpDown nuMaintenance;
		private System.Windows.Forms.Label lbMaintenance;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lbName;
	}
}