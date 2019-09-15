namespace RTLangTool
{
	partial class frmMain
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

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.파일FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.새로운파일NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.불러오기LToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.저장SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.다른이름으로저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.끝내기QToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.txtName = new System.Windows.Forms.ToolStripTextBox();
			this.txtRegion = new System.Windows.Forms.ToolStripTextBox();
			this.txtCode = new System.Windows.Forms.ToolStripTextBox();
			this.btnDel = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.lbValue = new System.Windows.Forms.Label();
			this.txtValue = new System.Windows.Forms.TextBox();
			this.lbKey = new System.Windows.Forms.Label();
			this.txtKey = new System.Windows.Forms.TextBox();
			this.lstLang = new System.Windows.Forms.ListBox();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일FToolStripMenuItem,
            this.txtName,
            this.txtRegion,
            this.txtCode});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(447, 27);
			this.menuStrip.TabIndex = 2;
			this.menuStrip.Text = "menuStrip1";
			// 
			// 파일FToolStripMenuItem
			// 
			this.파일FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.새로운파일NToolStripMenuItem,
            this.불러오기LToolStripMenuItem,
            this.toolStripSeparator3,
            this.저장SToolStripMenuItem,
            this.다른이름으로저장ToolStripMenuItem,
            this.toolStripSeparator2,
            this.끝내기QToolStripMenuItem});
			this.파일FToolStripMenuItem.Name = "파일FToolStripMenuItem";
			this.파일FToolStripMenuItem.Size = new System.Drawing.Size(61, 23);
			this.파일FToolStripMenuItem.Text = "파일 (&F)";
			// 
			// 새로운파일NToolStripMenuItem
			// 
			this.새로운파일NToolStripMenuItem.Name = "새로운파일NToolStripMenuItem";
			this.새로운파일NToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.새로운파일NToolStripMenuItem.Text = "새로운 파일 (&N)";
			this.새로운파일NToolStripMenuItem.Click += new System.EventHandler(this.새로운파일NToolStripMenuItem_Click);
			// 
			// 불러오기LToolStripMenuItem
			// 
			this.불러오기LToolStripMenuItem.Name = "불러오기LToolStripMenuItem";
			this.불러오기LToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.불러오기LToolStripMenuItem.Text = "불러오기 (&L)";
			this.불러오기LToolStripMenuItem.Click += new System.EventHandler(this.불러오기LToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(175, 6);
			// 
			// 저장SToolStripMenuItem
			// 
			this.저장SToolStripMenuItem.Name = "저장SToolStripMenuItem";
			this.저장SToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.저장SToolStripMenuItem.Text = "저장 (&S)";
			this.저장SToolStripMenuItem.Click += new System.EventHandler(this.저장SToolStripMenuItem_Click);
			// 
			// 다른이름으로저장ToolStripMenuItem
			// 
			this.다른이름으로저장ToolStripMenuItem.Name = "다른이름으로저장ToolStripMenuItem";
			this.다른이름으로저장ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.다른이름으로저장ToolStripMenuItem.Text = "다른 이름으로 저장";
			this.다른이름으로저장ToolStripMenuItem.Click += new System.EventHandler(this.다른이름으로저장ToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
			// 
			// 끝내기QToolStripMenuItem
			// 
			this.끝내기QToolStripMenuItem.Name = "끝내기QToolStripMenuItem";
			this.끝내기QToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.끝내기QToolStripMenuItem.Text = "끝내기 (&Q)";
			this.끝내기QToolStripMenuItem.Click += new System.EventHandler(this.끝내기QToolStripMenuItem_Click);
			// 
			// txtName
			// 
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(100, 23);
			this.txtName.Text = "한국어";
			// 
			// txtRegion
			// 
			this.txtRegion.Name = "txtRegion";
			this.txtRegion.Size = new System.Drawing.Size(100, 23);
			this.txtRegion.Text = "한국";
			// 
			// txtCode
			// 
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(100, 23);
			this.txtCode.Text = "ko-kr";
			// 
			// btnDel
			// 
			this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDel.Location = new System.Drawing.Point(297, 232);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(72, 25);
			this.btnDel.TabIndex = 17;
			this.btnDel.Text = "제거";
			this.btnDel.UseVisualStyleBackColor = true;
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Location = new System.Drawing.Point(375, 232);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(72, 25);
			this.btnEdit.TabIndex = 16;
			this.btnEdit.Text = "수정";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(219, 232);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(72, 25);
			this.btnAdd.TabIndex = 15;
			this.btnAdd.Text = "추가";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// lbValue
			// 
			this.lbValue.AutoSize = true;
			this.lbValue.Location = new System.Drawing.Point(166, 92);
			this.lbValue.Name = "lbValue";
			this.lbValue.Size = new System.Drawing.Size(37, 12);
			this.lbValue.TabIndex = 14;
			this.lbValue.Text = "Value";
			// 
			// txtValue
			// 
			this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtValue.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtValue.Location = new System.Drawing.Point(167, 108);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(279, 21);
			this.txtValue.TabIndex = 13;
			// 
			// lbKey
			// 
			this.lbKey.AutoSize = true;
			this.lbKey.Location = new System.Drawing.Point(166, 41);
			this.lbKey.Name = "lbKey";
			this.lbKey.Size = new System.Drawing.Size(27, 12);
			this.lbKey.TabIndex = 12;
			this.lbKey.Text = "Key";
			// 
			// txtKey
			// 
			this.txtKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtKey.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtKey.Location = new System.Drawing.Point(167, 57);
			this.txtKey.Name = "txtKey";
			this.txtKey.Size = new System.Drawing.Size(279, 21);
			this.txtKey.TabIndex = 11;
			// 
			// lstLang
			// 
			this.lstLang.Dock = System.Windows.Forms.DockStyle.Left;
			this.lstLang.FormattingEnabled = true;
			this.lstLang.ItemHeight = 12;
			this.lstLang.Location = new System.Drawing.Point(0, 27);
			this.lstLang.Name = "lstLang";
			this.lstLang.Size = new System.Drawing.Size(160, 230);
			this.lstLang.TabIndex = 10;
			this.lstLang.SelectedIndexChanged += new System.EventHandler(this.lstLang_SelectedIndexChanged);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(447, 257);
			this.Controls.Add(this.btnDel);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lbValue);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this.lbKey);
			this.Controls.Add(this.txtKey);
			this.Controls.Add(this.lstLang);
			this.Controls.Add(this.menuStrip);
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RTLangTool 1.0.0.6";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem 파일FToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 새로운파일NToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 불러오기LToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem 저장SToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 다른이름으로저장ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem 끝내기QToolStripMenuItem;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Label lbValue;
		private System.Windows.Forms.TextBox txtValue;
		private System.Windows.Forms.Label lbKey;
		private System.Windows.Forms.TextBox txtKey;
		private System.Windows.Forms.ListBox lstLang;
		private System.Windows.Forms.ToolStripTextBox txtName;
		private System.Windows.Forms.ToolStripTextBox txtRegion;
		private System.Windows.Forms.ToolStripTextBox txtCode;
	}
}

