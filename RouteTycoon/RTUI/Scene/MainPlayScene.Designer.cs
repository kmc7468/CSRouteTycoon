namespace RouteTycoon.RTUI
{
	partial class MainPlayScene
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
			this.components = new System.ComponentModel.Container();
			this.panTopbar = new System.Windows.Forms.Panel();
			this.lbDate = new System.Windows.Forms.Label();
			this.lbIncome = new System.Windows.Forms.Label();
			this.lbMoney = new System.Windows.Forms.Label();
			this.lbPN = new System.Windows.Forms.Label();
			this.lbCN = new System.Windows.Forms.Label();
			this.picDate = new System.Windows.Forms.PictureBox();
			this.picIncome = new System.Windows.Forms.PictureBox();
			this.picMoney = new System.Windows.Forms.PictureBox();
			this.picPresident = new System.Windows.Forms.PictureBox();
			this.picLogo = new System.Windows.Forms.PictureBox();
			this.panRoute = new System.Windows.Forms.Panel();
			this.picRoute = new System.Windows.Forms.PictureBox();
			this.panTrain = new System.Windows.Forms.Panel();
			this.picTrain = new System.Windows.Forms.PictureBox();
			this.panBank = new System.Windows.Forms.Panel();
			this.picBank = new System.Windows.Forms.PictureBox();
			this.panNews = new System.Windows.Forms.Panel();
			this.picNews = new System.Windows.Forms.PictureBox();
			this.panCompany = new System.Windows.Forms.Panel();
			this.picCompany = new System.Windows.Forms.PictureBox();
			this.panOp = new System.Windows.Forms.Panel();
			this.picOp = new System.Windows.Forms.PictureBox();
			this.tmUpdate = new System.Windows.Forms.Timer(this.components);
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.tmDate = new System.Windows.Forms.Timer(this.components);
			this.panBook = new System.Windows.Forms.Panel();
			this.picBook = new System.Windows.Forms.PictureBox();
			this.panBankruptcy = new System.Windows.Forms.Panel();
			this.lbBuild = new RouteTycoon.RTCore.TextButton();
			this.lbDelete = new RouteTycoon.RTCore.TextButton();
			this.lbBank = new RouteTycoon.RTCore.TextButton();
			this.lbBankruptcyTitle = new System.Windows.Forms.Label();
			this.tmSave = new System.Windows.Forms.Timer(this.components);
			this.panTopbar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picIncome)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picMoney)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picPresident)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
			this.panRoute.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picRoute)).BeginInit();
			this.panTrain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picTrain)).BeginInit();
			this.panBank.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picBank)).BeginInit();
			this.panNews.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picNews)).BeginInit();
			this.panCompany.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picCompany)).BeginInit();
			this.panOp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picOp)).BeginInit();
			this.panBook.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picBook)).BeginInit();
			this.panBankruptcy.SuspendLayout();
			this.SuspendLayout();
			// 
			// panTopbar
			// 
			this.panTopbar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panTopbar.Controls.Add(this.lbDate);
			this.panTopbar.Controls.Add(this.lbIncome);
			this.panTopbar.Controls.Add(this.lbMoney);
			this.panTopbar.Controls.Add(this.lbPN);
			this.panTopbar.Controls.Add(this.lbCN);
			this.panTopbar.Controls.Add(this.picDate);
			this.panTopbar.Controls.Add(this.picIncome);
			this.panTopbar.Controls.Add(this.picMoney);
			this.panTopbar.Controls.Add(this.picPresident);
			this.panTopbar.Controls.Add(this.picLogo);
			this.panTopbar.Dock = System.Windows.Forms.DockStyle.Top;
			this.panTopbar.Location = new System.Drawing.Point(0, 0);
			this.panTopbar.Name = "panTopbar";
			this.panTopbar.Size = new System.Drawing.Size(980, 40);
			this.panTopbar.TabIndex = 0;
			// 
			// lbDate
			// 
			this.lbDate.BackColor = System.Drawing.Color.Transparent;
			this.lbDate.Location = new System.Drawing.Point(826, 5);
			this.lbDate.Name = "lbDate";
			this.lbDate.Size = new System.Drawing.Size(139, 30);
			this.lbDate.TabIndex = 15;
			this.lbDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbIncome
			// 
			this.lbIncome.BackColor = System.Drawing.Color.Transparent;
			this.lbIncome.Location = new System.Drawing.Point(586, 5);
			this.lbIncome.Name = "lbIncome";
			this.lbIncome.Size = new System.Drawing.Size(198, 30);
			this.lbIncome.TabIndex = 14;
			this.lbIncome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbMoney
			// 
			this.lbMoney.BackColor = System.Drawing.Color.Transparent;
			this.lbMoney.Location = new System.Drawing.Point(346, 5);
			this.lbMoney.Name = "lbMoney";
			this.lbMoney.Size = new System.Drawing.Size(198, 30);
			this.lbMoney.TabIndex = 13;
			this.lbMoney.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbPN
			// 
			this.lbPN.BackColor = System.Drawing.Color.Transparent;
			this.lbPN.Location = new System.Drawing.Point(196, 5);
			this.lbPN.Name = "lbPN";
			this.lbPN.Size = new System.Drawing.Size(108, 30);
			this.lbPN.TabIndex = 12;
			this.lbPN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbCN
			// 
			this.lbCN.BackColor = System.Drawing.Color.Transparent;
			this.lbCN.Location = new System.Drawing.Point(46, 5);
			this.lbCN.Name = "lbCN";
			this.lbCN.Size = new System.Drawing.Size(108, 30);
			this.lbCN.TabIndex = 7;
			this.lbCN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// picDate
			// 
			this.picDate.BackColor = System.Drawing.Color.Transparent;
			this.picDate.Location = new System.Drawing.Point(790, 5);
			this.picDate.Name = "picDate";
			this.picDate.Size = new System.Drawing.Size(30, 30);
			this.picDate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picDate.TabIndex = 11;
			this.picDate.TabStop = false;
			// 
			// picIncome
			// 
			this.picIncome.BackColor = System.Drawing.Color.Transparent;
			this.picIncome.Location = new System.Drawing.Point(550, 5);
			this.picIncome.Name = "picIncome";
			this.picIncome.Size = new System.Drawing.Size(30, 30);
			this.picIncome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picIncome.TabIndex = 10;
			this.picIncome.TabStop = false;
			// 
			// picMoney
			// 
			this.picMoney.BackColor = System.Drawing.Color.Transparent;
			this.picMoney.Location = new System.Drawing.Point(310, 5);
			this.picMoney.Name = "picMoney";
			this.picMoney.Size = new System.Drawing.Size(30, 30);
			this.picMoney.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picMoney.TabIndex = 9;
			this.picMoney.TabStop = false;
			// 
			// picPresident
			// 
			this.picPresident.BackColor = System.Drawing.Color.Transparent;
			this.picPresident.Location = new System.Drawing.Point(160, 5);
			this.picPresident.Name = "picPresident";
			this.picPresident.Size = new System.Drawing.Size(30, 30);
			this.picPresident.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picPresident.TabIndex = 8;
			this.picPresident.TabStop = false;
			// 
			// picLogo
			// 
			this.picLogo.BackColor = System.Drawing.Color.Transparent;
			this.picLogo.Location = new System.Drawing.Point(10, 5);
			this.picLogo.Name = "picLogo";
			this.picLogo.Size = new System.Drawing.Size(30, 30);
			this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picLogo.TabIndex = 7;
			this.picLogo.TabStop = false;
			this.picLogo.Click += new System.EventHandler(this.picLogo_Click);
			// 
			// panRoute
			// 
			this.panRoute.BackColor = System.Drawing.Color.Transparent;
			this.panRoute.Controls.Add(this.picRoute);
			this.panRoute.ForeColor = System.Drawing.Color.Black;
			this.panRoute.Location = new System.Drawing.Point(8, 50);
			this.panRoute.Name = "panRoute";
			this.panRoute.Size = new System.Drawing.Size(84, 84);
			this.panRoute.TabIndex = 1;
			this.panRoute.Click += new System.EventHandler(this.panRoute_Click);
			this.panRoute.MouseEnter += new System.EventHandler(this.panRoute_MouseEnter);
			this.panRoute.MouseLeave += new System.EventHandler(this.panRoute_MouseLeave);
			// 
			// picRoute
			// 
			this.picRoute.BackColor = System.Drawing.Color.Transparent;
			this.picRoute.Location = new System.Drawing.Point(2, 2);
			this.picRoute.Name = "picRoute";
			this.picRoute.Size = new System.Drawing.Size(80, 80);
			this.picRoute.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picRoute.TabIndex = 8;
			this.picRoute.TabStop = false;
			this.picRoute.Click += new System.EventHandler(this.panRoute_Click);
			this.picRoute.MouseEnter += new System.EventHandler(this.panRoute_MouseEnter);
			this.picRoute.MouseLeave += new System.EventHandler(this.panRoute_MouseLeave);
			// 
			// panTrain
			// 
			this.panTrain.BackColor = System.Drawing.Color.Transparent;
			this.panTrain.Controls.Add(this.picTrain);
			this.panTrain.Location = new System.Drawing.Point(8, 138);
			this.panTrain.Name = "panTrain";
			this.panTrain.Size = new System.Drawing.Size(84, 84);
			this.panTrain.TabIndex = 2;
			this.panTrain.Click += new System.EventHandler(this.panTrain_Click);
			this.panTrain.MouseEnter += new System.EventHandler(this.panTrain_MouseEnter);
			this.panTrain.MouseLeave += new System.EventHandler(this.panTrain_MouseLeave);
			// 
			// picTrain
			// 
			this.picTrain.BackColor = System.Drawing.Color.Transparent;
			this.picTrain.Location = new System.Drawing.Point(2, 2);
			this.picTrain.Name = "picTrain";
			this.picTrain.Size = new System.Drawing.Size(80, 80);
			this.picTrain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picTrain.TabIndex = 8;
			this.picTrain.TabStop = false;
			this.picTrain.Click += new System.EventHandler(this.panTrain_Click);
			this.picTrain.MouseEnter += new System.EventHandler(this.panTrain_MouseEnter);
			this.picTrain.MouseLeave += new System.EventHandler(this.panTrain_MouseLeave);
			// 
			// panBank
			// 
			this.panBank.BackColor = System.Drawing.Color.Transparent;
			this.panBank.Controls.Add(this.picBank);
			this.panBank.Location = new System.Drawing.Point(8, 226);
			this.panBank.Name = "panBank";
			this.panBank.Size = new System.Drawing.Size(84, 84);
			this.panBank.TabIndex = 3;
			this.panBank.Click += new System.EventHandler(this.panBank_Click);
			this.panBank.MouseEnter += new System.EventHandler(this.panBank_MouseEnter);
			this.panBank.MouseLeave += new System.EventHandler(this.panBank_MouseLeave);
			// 
			// picBank
			// 
			this.picBank.BackColor = System.Drawing.Color.Transparent;
			this.picBank.Location = new System.Drawing.Point(2, 2);
			this.picBank.Name = "picBank";
			this.picBank.Size = new System.Drawing.Size(80, 80);
			this.picBank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBank.TabIndex = 8;
			this.picBank.TabStop = false;
			this.picBank.Click += new System.EventHandler(this.panBank_Click);
			this.picBank.MouseEnter += new System.EventHandler(this.panBank_MouseEnter);
			this.picBank.MouseLeave += new System.EventHandler(this.panBank_MouseLeave);
			// 
			// panNews
			// 
			this.panNews.BackColor = System.Drawing.Color.Transparent;
			this.panNews.Controls.Add(this.picNews);
			this.panNews.Location = new System.Drawing.Point(8, 314);
			this.panNews.Name = "panNews";
			this.panNews.Size = new System.Drawing.Size(84, 84);
			this.panNews.TabIndex = 4;
			this.panNews.Click += new System.EventHandler(this.panNews_Click);
			this.panNews.MouseEnter += new System.EventHandler(this.panNews_MouseEnter);
			this.panNews.MouseLeave += new System.EventHandler(this.panNews_MouseLeave);
			// 
			// picNews
			// 
			this.picNews.BackColor = System.Drawing.Color.Transparent;
			this.picNews.Location = new System.Drawing.Point(2, 2);
			this.picNews.Name = "picNews";
			this.picNews.Size = new System.Drawing.Size(80, 80);
			this.picNews.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picNews.TabIndex = 8;
			this.picNews.TabStop = false;
			this.picNews.Click += new System.EventHandler(this.panNews_Click);
			this.picNews.MouseEnter += new System.EventHandler(this.panNews_MouseEnter);
			this.picNews.MouseLeave += new System.EventHandler(this.panNews_MouseLeave);
			// 
			// panCompany
			// 
			this.panCompany.BackColor = System.Drawing.Color.Transparent;
			this.panCompany.Controls.Add(this.picCompany);
			this.panCompany.Location = new System.Drawing.Point(8, 402);
			this.panCompany.Name = "panCompany";
			this.panCompany.Size = new System.Drawing.Size(84, 84);
			this.panCompany.TabIndex = 5;
			this.panCompany.Click += new System.EventHandler(this.panCompany_Click);
			this.panCompany.MouseEnter += new System.EventHandler(this.panCompany_MouseEnter);
			this.panCompany.MouseLeave += new System.EventHandler(this.panCompany_MouseLeave);
			// 
			// picCompany
			// 
			this.picCompany.BackColor = System.Drawing.Color.Transparent;
			this.picCompany.Location = new System.Drawing.Point(2, 2);
			this.picCompany.Name = "picCompany";
			this.picCompany.Size = new System.Drawing.Size(80, 80);
			this.picCompany.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picCompany.TabIndex = 8;
			this.picCompany.TabStop = false;
			this.picCompany.Click += new System.EventHandler(this.panCompany_Click);
			this.picCompany.MouseEnter += new System.EventHandler(this.panCompany_MouseEnter);
			this.picCompany.MouseLeave += new System.EventHandler(this.panCompany_MouseLeave);
			// 
			// panOp
			// 
			this.panOp.BackColor = System.Drawing.Color.Transparent;
			this.panOp.Controls.Add(this.picOp);
			this.panOp.Location = new System.Drawing.Point(8, 490);
			this.panOp.Name = "panOp";
			this.panOp.Size = new System.Drawing.Size(84, 84);
			this.panOp.TabIndex = 6;
			this.panOp.Click += new System.EventHandler(this.panOp_Click);
			this.panOp.MouseEnter += new System.EventHandler(this.panOp_MouseEnter);
			this.panOp.MouseLeave += new System.EventHandler(this.panOp_MouseLeave);
			// 
			// picOp
			// 
			this.picOp.BackColor = System.Drawing.Color.Transparent;
			this.picOp.Location = new System.Drawing.Point(2, 2);
			this.picOp.Name = "picOp";
			this.picOp.Size = new System.Drawing.Size(80, 80);
			this.picOp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picOp.TabIndex = 8;
			this.picOp.TabStop = false;
			this.picOp.Click += new System.EventHandler(this.panOp_Click);
			this.picOp.MouseEnter += new System.EventHandler(this.panOp_MouseEnter);
			this.picOp.MouseLeave += new System.EventHandler(this.panOp_MouseLeave);
			// 
			// tmUpdate
			// 
			this.tmUpdate.Interval = 1;
			this.tmUpdate.Tick += new System.EventHandler(this.tmUpdate_Tick);
			// 
			// tmDate
			// 
			this.tmDate.Interval = 5000;
			this.tmDate.Tick += new System.EventHandler(this.tmDate_Tick);
			// 
			// panBook
			// 
			this.panBook.BackColor = System.Drawing.Color.Transparent;
			this.panBook.Controls.Add(this.picBook);
			this.panBook.Location = new System.Drawing.Point(8, 578);
			this.panBook.Name = "panBook";
			this.panBook.Size = new System.Drawing.Size(84, 84);
			this.panBook.TabIndex = 7;
			this.panBook.Click += new System.EventHandler(this.panBook_Click);
			this.panBook.MouseEnter += new System.EventHandler(this.panBook_MouseEnter);
			this.panBook.MouseLeave += new System.EventHandler(this.panBook_MouseLeave);
			// 
			// picBook
			// 
			this.picBook.BackColor = System.Drawing.Color.Transparent;
			this.picBook.Location = new System.Drawing.Point(2, 2);
			this.picBook.Name = "picBook";
			this.picBook.Size = new System.Drawing.Size(80, 80);
			this.picBook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBook.TabIndex = 8;
			this.picBook.TabStop = false;
			this.picBook.Click += new System.EventHandler(this.panBook_Click);
			this.picBook.MouseEnter += new System.EventHandler(this.panBook_MouseEnter);
			this.picBook.MouseLeave += new System.EventHandler(this.panBook_MouseLeave);
			// 
			// panBankruptcy
			// 
			this.panBankruptcy.BackColor = System.Drawing.Color.Transparent;
			this.panBankruptcy.Controls.Add(this.lbBuild);
			this.panBankruptcy.Controls.Add(this.lbDelete);
			this.panBankruptcy.Controls.Add(this.lbBank);
			this.panBankruptcy.Controls.Add(this.lbBankruptcyTitle);
			this.panBankruptcy.Location = new System.Drawing.Point(0, 980);
			this.panBankruptcy.Name = "panBankruptcy";
			this.panBankruptcy.Size = new System.Drawing.Size(980, 680);
			this.panBankruptcy.TabIndex = 8;
			this.panBankruptcy.Visible = false;
			// 
			// lbBuild
			// 
			this.lbBuild.AutoSize = true;
			this.lbBuild.Font = new System.Drawing.Font("굴림", 30F);
			this.lbBuild.Location = new System.Drawing.Point(480, 578);
			this.lbBuild.Name = "lbBuild";
			this.lbBuild.SelColor = System.Drawing.Color.Gray;
			this.lbBuild.Size = new System.Drawing.Size(137, 40);
			this.lbBuild.TabIndex = 3;
			this.lbBuild.Text = "(build)";
			this.lbBuild.Click += new System.EventHandler(this.lbBuild_Click);
			// 
			// lbDelete
			// 
			this.lbDelete.AutoSize = true;
			this.lbDelete.Font = new System.Drawing.Font("굴림", 30F);
			this.lbDelete.Location = new System.Drawing.Point(454, 446);
			this.lbDelete.Name = "lbDelete";
			this.lbDelete.SelColor = System.Drawing.Color.Gray;
			this.lbDelete.Size = new System.Drawing.Size(211, 40);
			this.lbDelete.TabIndex = 2;
			this.lbDelete.Text = "(deletesav";
			this.lbDelete.Click += new System.EventHandler(this.lbDelete_Click);
			// 
			// lbBank
			// 
			this.lbBank.AutoSize = true;
			this.lbBank.Font = new System.Drawing.Font("굴림", 30F);
			this.lbBank.Location = new System.Drawing.Point(454, 358);
			this.lbBank.Name = "lbBank";
			this.lbBank.SelColor = System.Drawing.Color.Gray;
			this.lbBank.Size = new System.Drawing.Size(126, 40);
			this.lbBank.TabIndex = 1;
			this.lbBank.Text = "(loan)";
			this.lbBank.Click += new System.EventHandler(this.lbLoan_Click);
			// 
			// lbBankruptcyTitle
			// 
			this.lbBankruptcyTitle.AutoSize = true;
			this.lbBankruptcyTitle.Font = new System.Drawing.Font("굴림", 72F);
			this.lbBankruptcyTitle.Location = new System.Drawing.Point(214, 175);
			this.lbBankruptcyTitle.Name = "lbBankruptcyTitle";
			this.lbBankruptcyTitle.Size = new System.Drawing.Size(606, 96);
			this.lbBankruptcyTitle.TabIndex = 0;
			this.lbBankruptcyTitle.Text = "(bankruptcy)";
			// 
			// MainPlayScene
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Controls.Add(this.panBankruptcy);
			this.Controls.Add(this.panBook);
			this.Controls.Add(this.panOp);
			this.Controls.Add(this.panCompany);
			this.Controls.Add(this.panNews);
			this.Controls.Add(this.panBank);
			this.Controls.Add(this.panTrain);
			this.Controls.Add(this.panRoute);
			this.Controls.Add(this.panTopbar);
			this.DoubleBuffered = true;
			this.Name = "MainPlayScene";
			this.Size = new System.Drawing.Size(980, 680);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPlayScene_Paint);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainPlayScene_KeyPress);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPlayScene_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPlayScene_MouseMove);
			this.panTopbar.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picIncome)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picMoney)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picPresident)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
			this.panRoute.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picRoute)).EndInit();
			this.panTrain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picTrain)).EndInit();
			this.panBank.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picBank)).EndInit();
			this.panNews.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picNews)).EndInit();
			this.panCompany.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picCompany)).EndInit();
			this.panOp.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picOp)).EndInit();
			this.panBook.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picBook)).EndInit();
			this.panBankruptcy.ResumeLayout(false);
			this.panBankruptcy.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panTopbar;
		private System.Windows.Forms.Panel panRoute;
		private System.Windows.Forms.Panel panTrain;
		private System.Windows.Forms.Panel panBank;
		private System.Windows.Forms.Panel panNews;
		private System.Windows.Forms.Panel panCompany;
		private System.Windows.Forms.Panel panOp;
		private System.Windows.Forms.PictureBox picRoute;
		private System.Windows.Forms.PictureBox picTrain;
		private System.Windows.Forms.PictureBox picBank;
		private System.Windows.Forms.PictureBox picNews;
		private System.Windows.Forms.PictureBox picCompany;
		private System.Windows.Forms.PictureBox picOp;
		private System.Windows.Forms.PictureBox picLogo;
		private System.Windows.Forms.PictureBox picPresident;
		private System.Windows.Forms.PictureBox picMoney;
		private System.Windows.Forms.PictureBox picIncome;
		private System.Windows.Forms.PictureBox picDate;
		private System.Windows.Forms.Label lbCN;
		private System.Windows.Forms.Label lbDate;
		private System.Windows.Forms.Label lbIncome;
		private System.Windows.Forms.Label lbMoney;
		private System.Windows.Forms.Label lbPN;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Panel panBook;
		private System.Windows.Forms.PictureBox picBook;
		private System.Windows.Forms.Label lbBankruptcyTitle;
		private RTCore.TextButton lbDelete;
		private RTCore.TextButton lbBank;
		private RTCore.TextButton lbBuild;
		internal System.Windows.Forms.Timer tmUpdate;
		internal System.Windows.Forms.Timer tmDate;
		public System.Windows.Forms.Panel panBankruptcy;
		private System.Windows.Forms.Timer tmSave;
	}
}
