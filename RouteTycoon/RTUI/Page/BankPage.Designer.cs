namespace RouteTycoon.RTUI
{
	partial class BankPage
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
			this.panSide = new System.Windows.Forms.Panel();
			this.lbBankBook = new System.Windows.Forms.Label();
			this.lbLoan = new System.Windows.Forms.Label();
			this.panLoan = new System.Windows.Forms.Panel();
			this.panClearLoan = new System.Windows.Forms.Panel();
			this.lbLoanMoney = new System.Windows.Forms.Label();
			this.lbGoClearLoan = new RouteTycoon.RTCore.TextButton();
			this.cbClearLoan = new System.Windows.Forms.ComboBox();
			this.lbClearLoan = new System.Windows.Forms.Label();
			this.panLoanGive = new System.Windows.Forms.Panel();
			this.lbGoLoan = new RouteTycoon.RTCore.TextButton();
			this.cbLoan = new System.Windows.Forms.ComboBox();
			this.lbLoanGive = new System.Windows.Forms.Label();
			this.lbLoanTitle = new System.Windows.Forms.Label();
			this.panBankBook = new System.Windows.Forms.Panel();
			this.panBankbookMoney = new System.Windows.Forms.Panel();
			this.lbBankbookMoney = new System.Windows.Forms.Label();
			this.panWithdraw = new System.Windows.Forms.Panel();
			this.nuWithdraw = new System.Windows.Forms.NumericUpDown();
			this.lbGoWithdraw = new RouteTycoon.RTCore.TextButton();
			this.lbWithdraw = new System.Windows.Forms.Label();
			this.panDeposit = new System.Windows.Forms.Panel();
			this.nuDeposit = new System.Windows.Forms.NumericUpDown();
			this.lbGoDeposit = new RouteTycoon.RTCore.TextButton();
			this.lbDeposit = new System.Windows.Forms.Label();
			this.lbBankBookTitle = new System.Windows.Forms.Label();
			this.panSide.SuspendLayout();
			this.panLoan.SuspendLayout();
			this.panClearLoan.SuspendLayout();
			this.panLoanGive.SuspendLayout();
			this.panBankBook.SuspendLayout();
			this.panBankbookMoney.SuspendLayout();
			this.panWithdraw.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nuWithdraw)).BeginInit();
			this.panDeposit.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nuDeposit)).BeginInit();
			this.SuspendLayout();
			// 
			// panSide
			// 
			this.panSide.Controls.Add(this.lbBankBook);
			this.panSide.Controls.Add(this.lbLoan);
			this.panSide.Location = new System.Drawing.Point(0, 40);
			this.panSide.Name = "panSide";
			this.panSide.Size = new System.Drawing.Size(142, 560);
			this.panSide.TabIndex = 0;
			// 
			// lbBankBook
			// 
			this.lbBankBook.AutoSize = true;
			this.lbBankBook.Font = new System.Drawing.Font("굴림", 22F);
			this.lbBankBook.Location = new System.Drawing.Point(16, 101);
			this.lbBankBook.Name = "lbBankBook";
			this.lbBankBook.Size = new System.Drawing.Size(171, 30);
			this.lbBankBook.TabIndex = 1;
			this.lbBankBook.Text = "(bankbook)";
			// 
			// lbLoan
			// 
			this.lbLoan.AutoSize = true;
			this.lbLoan.Font = new System.Drawing.Font("굴림", 22F);
			this.lbLoan.Location = new System.Drawing.Point(30, 51);
			this.lbLoan.Name = "lbLoan";
			this.lbLoan.Size = new System.Drawing.Size(94, 30);
			this.lbLoan.TabIndex = 0;
			this.lbLoan.Text = "(loan)";
			// 
			// panLoan
			// 
			this.panLoan.Controls.Add(this.panClearLoan);
			this.panLoan.Controls.Add(this.panLoanGive);
			this.panLoan.Controls.Add(this.lbLoanTitle);
			this.panLoan.Location = new System.Drawing.Point(141, 40);
			this.panLoan.Name = "panLoan";
			this.panLoan.Size = new System.Drawing.Size(659, 560);
			this.panLoan.TabIndex = 1;
			// 
			// panClearLoan
			// 
			this.panClearLoan.Controls.Add(this.lbLoanMoney);
			this.panClearLoan.Controls.Add(this.lbGoClearLoan);
			this.panClearLoan.Controls.Add(this.cbClearLoan);
			this.panClearLoan.Controls.Add(this.lbClearLoan);
			this.panClearLoan.Location = new System.Drawing.Point(31, 310);
			this.panClearLoan.Name = "panClearLoan";
			this.panClearLoan.Size = new System.Drawing.Size(596, 192);
			this.panClearLoan.TabIndex = 2;
			// 
			// lbLoanMoney
			// 
			this.lbLoanMoney.AutoSize = true;
			this.lbLoanMoney.Font = new System.Drawing.Font("굴림", 12F);
			this.lbLoanMoney.Location = new System.Drawing.Point(13, 166);
			this.lbLoanMoney.Name = "lbLoanMoney";
			this.lbLoanMoney.Size = new System.Drawing.Size(49, 16);
			this.lbLoanMoney.TabIndex = 5;
			this.lbLoanMoney.Text = "label1";
			// 
			// lbGoClearLoan
			// 
			this.lbGoClearLoan.AutoSize = true;
			this.lbGoClearLoan.Font = new System.Drawing.Font("굴림", 20F);
			this.lbGoClearLoan.Location = new System.Drawing.Point(427, 111);
			this.lbGoClearLoan.Name = "lbGoClearLoan";
			this.lbGoClearLoan.SelColor = System.Drawing.Color.Gray;
			this.lbGoClearLoan.Size = new System.Drawing.Size(145, 27);
			this.lbGoClearLoan.TabIndex = 4;
			this.lbGoClearLoan.Text = "(clearloan)";
			// 
			// cbClearLoan
			// 
			this.cbClearLoan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbClearLoan.Font = new System.Drawing.Font("굴림", 20F);
			this.cbClearLoan.FormattingEnabled = true;
			this.cbClearLoan.Location = new System.Drawing.Point(25, 61);
			this.cbClearLoan.Name = "cbClearLoan";
			this.cbClearLoan.Size = new System.Drawing.Size(542, 35);
			this.cbClearLoan.TabIndex = 3;
			// 
			// lbClearLoan
			// 
			this.lbClearLoan.AutoSize = true;
			this.lbClearLoan.Font = new System.Drawing.Font("굴림", 20F);
			this.lbClearLoan.Location = new System.Drawing.Point(20, 15);
			this.lbClearLoan.Name = "lbClearLoan";
			this.lbClearLoan.Size = new System.Drawing.Size(145, 27);
			this.lbClearLoan.TabIndex = 2;
			this.lbClearLoan.Text = "(clearloan)";
			// 
			// panLoanGive
			// 
			this.panLoanGive.Controls.Add(this.lbGoLoan);
			this.panLoanGive.Controls.Add(this.cbLoan);
			this.panLoanGive.Controls.Add(this.lbLoanGive);
			this.panLoanGive.Location = new System.Drawing.Point(31, 91);
			this.panLoanGive.Name = "panLoanGive";
			this.panLoanGive.Size = new System.Drawing.Size(596, 195);
			this.panLoanGive.TabIndex = 1;
			// 
			// lbGoLoan
			// 
			this.lbGoLoan.AutoSize = true;
			this.lbGoLoan.Font = new System.Drawing.Font("굴림", 20F);
			this.lbGoLoan.Location = new System.Drawing.Point(443, 111);
			this.lbGoLoan.Name = "lbGoLoan";
			this.lbGoLoan.SelColor = System.Drawing.Color.Gray;
			this.lbGoLoan.Size = new System.Drawing.Size(122, 27);
			this.lbGoLoan.TabIndex = 4;
			this.lbGoLoan.Text = "(loangiv)";
			// 
			// cbLoan
			// 
			this.cbLoan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLoan.Font = new System.Drawing.Font("굴림", 20F);
			this.cbLoan.FormattingEnabled = true;
			this.cbLoan.Items.AddRange(new object[] {
            "1,000,000RTW",
            "5,000,000RTW",
            "10,000,000RTW",
            "50,000,000RTW",
            "100,000,000RTW",
            "500,000,000RTW",
            "1,000,000,000RTW",
            "5,000,000,000RTW"});
			this.cbLoan.Location = new System.Drawing.Point(25, 61);
			this.cbLoan.Name = "cbLoan";
			this.cbLoan.Size = new System.Drawing.Size(542, 35);
			this.cbLoan.TabIndex = 3;
			// 
			// lbLoanGive
			// 
			this.lbLoanGive.AutoSize = true;
			this.lbLoanGive.Font = new System.Drawing.Font("굴림", 20F);
			this.lbLoanGive.Location = new System.Drawing.Point(20, 15);
			this.lbLoanGive.Name = "lbLoanGive";
			this.lbLoanGive.Size = new System.Drawing.Size(122, 27);
			this.lbLoanGive.TabIndex = 2;
			this.lbLoanGive.Text = "(loangiv)";
			// 
			// lbLoanTitle
			// 
			this.lbLoanTitle.AutoSize = true;
			this.lbLoanTitle.Font = new System.Drawing.Font("굴림", 30F);
			this.lbLoanTitle.Location = new System.Drawing.Point(24, 26);
			this.lbLoanTitle.Name = "lbLoanTitle";
			this.lbLoanTitle.Size = new System.Drawing.Size(126, 40);
			this.lbLoanTitle.TabIndex = 0;
			this.lbLoanTitle.Text = "(loan)";
			// 
			// panBankBook
			// 
			this.panBankBook.Controls.Add(this.panBankbookMoney);
			this.panBankBook.Controls.Add(this.panWithdraw);
			this.panBankBook.Controls.Add(this.panDeposit);
			this.panBankBook.Controls.Add(this.lbBankBookTitle);
			this.panBankBook.Location = new System.Drawing.Point(141, 40);
			this.panBankBook.Name = "panBankBook";
			this.panBankBook.Size = new System.Drawing.Size(659, 560);
			this.panBankBook.TabIndex = 2;
			// 
			// panBankbookMoney
			// 
			this.panBankbookMoney.Controls.Add(this.lbBankbookMoney);
			this.panBankbookMoney.Location = new System.Drawing.Point(31, 91);
			this.panBankbookMoney.Name = "panBankbookMoney";
			this.panBankbookMoney.Size = new System.Drawing.Size(596, 70);
			this.panBankbookMoney.TabIndex = 3;
			// 
			// lbBankbookMoney
			// 
			this.lbBankbookMoney.AutoSize = true;
			this.lbBankbookMoney.Font = new System.Drawing.Font("굴림", 20F);
			this.lbBankbookMoney.Location = new System.Drawing.Point(12, 16);
			this.lbBankbookMoney.Name = "lbBankbookMoney";
			this.lbBankbookMoney.Size = new System.Drawing.Size(239, 27);
			this.lbBankbookMoney.TabIndex = 1;
			this.lbBankbookMoney.Text = "(bankbookmoney)";
			// 
			// panWithdraw
			// 
			this.panWithdraw.Controls.Add(this.nuWithdraw);
			this.panWithdraw.Controls.Add(this.lbGoWithdraw);
			this.panWithdraw.Controls.Add(this.lbWithdraw);
			this.panWithdraw.Location = new System.Drawing.Point(31, 376);
			this.panWithdraw.Name = "panWithdraw";
			this.panWithdraw.Size = new System.Drawing.Size(596, 163);
			this.panWithdraw.TabIndex = 2;
			// 
			// nuWithdraw
			// 
			this.nuWithdraw.Font = new System.Drawing.Font("굴림", 20F);
			this.nuWithdraw.Increment = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.nuWithdraw.Location = new System.Drawing.Point(25, 61);
			this.nuWithdraw.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.nuWithdraw.Name = "nuWithdraw";
			this.nuWithdraw.Size = new System.Drawing.Size(542, 38);
			this.nuWithdraw.TabIndex = 6;
			// 
			// lbGoWithdraw
			// 
			this.lbGoWithdraw.AutoSize = true;
			this.lbGoWithdraw.Font = new System.Drawing.Font("굴림", 20F);
			this.lbGoWithdraw.Location = new System.Drawing.Point(427, 111);
			this.lbGoWithdraw.Name = "lbGoWithdraw";
			this.lbGoWithdraw.SelColor = System.Drawing.Color.Gray;
			this.lbGoWithdraw.Size = new System.Drawing.Size(142, 27);
			this.lbGoWithdraw.TabIndex = 4;
			this.lbGoWithdraw.Text = "(withdraw)";
			// 
			// lbWithdraw
			// 
			this.lbWithdraw.AutoSize = true;
			this.lbWithdraw.Font = new System.Drawing.Font("굴림", 20F);
			this.lbWithdraw.Location = new System.Drawing.Point(20, 15);
			this.lbWithdraw.Name = "lbWithdraw";
			this.lbWithdraw.Size = new System.Drawing.Size(142, 27);
			this.lbWithdraw.TabIndex = 2;
			this.lbWithdraw.Text = "(withdraw)";
			// 
			// panDeposit
			// 
			this.panDeposit.Controls.Add(this.nuDeposit);
			this.panDeposit.Controls.Add(this.lbGoDeposit);
			this.panDeposit.Controls.Add(this.lbDeposit);
			this.panDeposit.Location = new System.Drawing.Point(31, 187);
			this.panDeposit.Name = "panDeposit";
			this.panDeposit.Size = new System.Drawing.Size(596, 163);
			this.panDeposit.TabIndex = 1;
			// 
			// nuDeposit
			// 
			this.nuDeposit.Font = new System.Drawing.Font("굴림", 20F);
			this.nuDeposit.Increment = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.nuDeposit.Location = new System.Drawing.Point(25, 61);
			this.nuDeposit.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.nuDeposit.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.nuDeposit.Name = "nuDeposit";
			this.nuDeposit.Size = new System.Drawing.Size(542, 38);
			this.nuDeposit.TabIndex = 5;
			this.nuDeposit.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			// 
			// lbGoDeposit
			// 
			this.lbGoDeposit.AutoSize = true;
			this.lbGoDeposit.Font = new System.Drawing.Font("굴림", 20F);
			this.lbGoDeposit.Location = new System.Drawing.Point(443, 111);
			this.lbGoDeposit.Name = "lbGoDeposit";
			this.lbGoDeposit.SelColor = System.Drawing.Color.Gray;
			this.lbGoDeposit.Size = new System.Drawing.Size(124, 27);
			this.lbGoDeposit.TabIndex = 4;
			this.lbGoDeposit.Text = "(deposit)";
			// 
			// lbDeposit
			// 
			this.lbDeposit.AutoSize = true;
			this.lbDeposit.Font = new System.Drawing.Font("굴림", 20F);
			this.lbDeposit.Location = new System.Drawing.Point(20, 15);
			this.lbDeposit.Name = "lbDeposit";
			this.lbDeposit.Size = new System.Drawing.Size(124, 27);
			this.lbDeposit.TabIndex = 2;
			this.lbDeposit.Text = "(deposit)";
			// 
			// lbBankBookTitle
			// 
			this.lbBankBookTitle.AutoSize = true;
			this.lbBankBookTitle.Font = new System.Drawing.Font("굴림", 30F);
			this.lbBankBookTitle.Location = new System.Drawing.Point(24, 26);
			this.lbBankBookTitle.Name = "lbBankBookTitle";
			this.lbBankBookTitle.Size = new System.Drawing.Size(229, 40);
			this.lbBankBookTitle.TabIndex = 0;
			this.lbBankBookTitle.Text = "(bankbook)";
			// 
			// BankPage
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.panBankBook);
			this.Controls.Add(this.panLoan);
			this.Controls.Add(this.panSide);
			this.DoubleBuffered = true;
			this.Name = "BankPage";
			this.Size = new System.Drawing.Size(800, 600);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.BankPage_Paint);
			this.panSide.ResumeLayout(false);
			this.panSide.PerformLayout();
			this.panLoan.ResumeLayout(false);
			this.panLoan.PerformLayout();
			this.panClearLoan.ResumeLayout(false);
			this.panClearLoan.PerformLayout();
			this.panLoanGive.ResumeLayout(false);
			this.panLoanGive.PerformLayout();
			this.panBankBook.ResumeLayout(false);
			this.panBankBook.PerformLayout();
			this.panBankbookMoney.ResumeLayout(false);
			this.panBankbookMoney.PerformLayout();
			this.panWithdraw.ResumeLayout(false);
			this.panWithdraw.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nuWithdraw)).EndInit();
			this.panDeposit.ResumeLayout(false);
			this.panDeposit.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nuDeposit)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panSide;
		private System.Windows.Forms.Label lbBankBook;
		private System.Windows.Forms.Label lbLoan;
		private System.Windows.Forms.Panel panLoan;
		private System.Windows.Forms.Label lbLoanTitle;
		private System.Windows.Forms.Panel panLoanGive;
		private System.Windows.Forms.Label lbLoanGive;
		private RTCore.TextButton lbGoLoan;
		private System.Windows.Forms.ComboBox cbLoan;
		private System.Windows.Forms.Panel panClearLoan;
		private RTCore.TextButton lbGoClearLoan;
		private System.Windows.Forms.ComboBox cbClearLoan;
		private System.Windows.Forms.Label lbClearLoan;
		private System.Windows.Forms.Label lbLoanMoney;
		private System.Windows.Forms.Panel panBankBook;
		private System.Windows.Forms.Panel panWithdraw;
		private RTCore.TextButton lbGoWithdraw;
		private System.Windows.Forms.Label lbWithdraw;
		private System.Windows.Forms.Panel panDeposit;
		private RTCore.TextButton lbGoDeposit;
		private System.Windows.Forms.Label lbDeposit;
		private System.Windows.Forms.Label lbBankBookTitle;
		private System.Windows.Forms.Panel panBankbookMoney;
		private System.Windows.Forms.NumericUpDown nuDeposit;
		private System.Windows.Forms.Label lbBankbookMoney;
		private System.Windows.Forms.NumericUpDown nuWithdraw;
	}
}
