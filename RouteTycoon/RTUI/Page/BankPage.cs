using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RouteTycoon.RTCore;
using RouteTycoon.RTAPI;

namespace RouteTycoon.RTUI
{
	internal partial class BankPage : Page
	{
		private bool loan = true;
		private ToolTip tt = new ToolTip();

		private MainPlayScene Scene = null;

		public BankPage(MainPlayScene mps = null)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				Title = TextManager.Get().Text("bank");
				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_bank.png", 5, 7, 1, 6));
				Scene = mps;

				panBankBook.Visible = false;

				panSide.BackColor = ResourceManager.Get("bank.sidebar");

				lbLoan.Text = TextManager.Get().Text("loan");
				lbLoan.Font = new Font(RTCore.Environment.Font, 22);
				Size l_size = RTCore.Environment.CalcStringSize(lbLoan.Text, lbBankBook.Font);
				PointF l_point_f = RTCore.Environment.CalcRectangle(new Point(panSide.Width / 2, lbLoan.Location.Y + (lbLoan.Height / 2)), l_size).Location;
				lbLoan.Location = l_point_f.ToPoint();
				lbLoan.ForeColor = ResourceManager.Get("bank.sidebar.item.select");
				lbLoan.MouseEnter += delegate { if (loan) return; lbLoan.ForeColor = ResourceManager.Get("bank.sidebar.item.sel"); };
				lbLoan.MouseLeave += delegate { if (loan) return; lbLoan.ForeColor = ResourceManager.Get("bank.sidebar.item.unsel"); };
				lbLoan.Click += delegate
				{
					if (!loan)
					{
						loan = true;
						lbBankBook.ForeColor = ResourceManager.Get("bank.sidebar.item.unsel");
						lbLoan.ForeColor = ResourceManager.Get("bank.sidebar.item.select");
						panBankBook.Visible = false;
					}
				};
				tt.SetToolTip(lbLoan, TextManager.Get().Text("loan"));

				lbBankBook.Text = TextManager.Get().Text("bankbook");
				lbBankBook.Font = new Font(RTCore.Environment.Font, 22);
				Size b_size = RTCore.Environment.CalcStringSize(lbBankBook.Text, lbBankBook.Font);
				PointF b_point_f = RTCore.Environment.CalcRectangle(new Point(panSide.Width / 2, lbBankBook.Location.Y + (lbBankBook.Height / 2)), b_size).Location;
				lbBankBook.Location = b_point_f.ToPoint();
				lbBankBook.ForeColor = ResourceManager.Get("bank.sidebar.item.unsel");
				lbBankBook.MouseEnter += delegate { if (!loan) return; lbBankBook.ForeColor = ResourceManager.Get("bank.sidebar.item.sel"); };
				lbBankBook.MouseLeave += delegate { if (!loan) return; lbBankBook.ForeColor = ResourceManager.Get("bank.sidebar.item.unsel"); };
				lbBankBook.Click += delegate
				{
					if (loan)
					{
						loan = false;
						lbBankBook.ForeColor = ResourceManager.Get("bank.sidebar.item.select");
						lbLoan.ForeColor = ResourceManager.Get("bank.sidebar.item.unsel");
						panBankBook.Visible = true;
					}
				};
				tt.SetToolTip(lbBankBook, TextManager.Get().Text("bankbook"));

				panLoanGive.BackColor = ResourceManager.Get("bank.rect");
				panClearLoan.BackColor = ResourceManager.Get("bank.rect");

				lbLoanTitle.Font = new Font(RTCore.Environment.Font, 30);
				lbLoanTitle.Text = TextManager.Get().Text("loan");
				lbLoanTitle.ForeColor = ResourceManager.Get("bank.title");

				lbLoanGive.ForeColor = ResourceManager.Get("bank.subtitle");
				lbLoanGive.Text = TextManager.Get().Text("loangiv");
				lbLoanGive.Font = new Font(RTCore.Environment.Font, 20);

				cbLoan.SelectedIndex = 0;
				cbLoan.Font = new Font(RTCore.Environment.Font, 20);

				lbGoLoan.Text = TextManager.Get().Text("loangiv");
				lbGoLoan.ForeColor = ResourceManager.Get("bank.btn.unsel");
				lbGoLoan.SelColor = ResourceManager.Get("bank.btn.sel");
				lbGoLoan.Font = new Font(RTCore.Environment.Font, 20);
				lbGoLoan.Location = new Point(panLoanGive.Width - 25 - lbGoLoan.Width, 111);
				lbGoLoan.Click += delegate
				{
					if (GameManager.Company.Loan != 0)
					{
						MessageBox.Show(TextManager.Get().Text("isloan"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					}
					else
					{
						if(GameManager.isBuild)
						{
							MessageBox.Show(TextManager.Get().Text("builded"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
							return;
						}

						long l = 0;
						string tmp = cbLoan.Items[cbLoan.SelectedIndex].ToString();
						tmp = tmp.Replace(",", "");
						tmp = tmp.Replace("RTW", "");
						l = Convert.ToInt64(tmp);
						GameManager.Company.Loan += Convert.ToInt64((l) + (l * 0.05));
						GameManager.Company.Money += l;

						Dictionary<string, string> data = new Dictionary<string, string>();
						data.Add("%LOAN%", string.Format("{0:n0}", l));

						PluginManager.Loaned(l);

						ClearLoan();

						if (Scene == null)
						{
							if(GameManager.isBuild)
							{
								MessageBox.Show(TextManager.Get().Text("builded"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
								return;
							}
							MessageBox.Show(TextManager.Get().Text("okloan", true, data), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							if (GameManager.Company.Money <= 0) { MessageBox.Show(TextManager.Get().Text("okloan", true, data), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

							Scene.tmUpdate.Start();
							Scene.tmDate.Start();
							Scene.panBankruptcy.Visible = false;
							Scene.KeyPress += Scene.MainPlayScene_KeyPress;
							PageManager.Close(false, AccessManager.AccessKey);
							MessageBox.Show(TextManager.Get().Text("okloan", true, data), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
				};

				lbClearLoan.Font = new Font(RTCore.Environment.Font, 20);
				lbClearLoan.Text = TextManager.Get().Text("clearloan");
				lbClearLoan.ForeColor = ResourceManager.Get("bank.subtitle");

				ClearLoan();
				cbClearLoan.Font = new Font(RTCore.Environment.Font, 20);

				lbGoClearLoan.Text = TextManager.Get().Text("clearloan");
				lbGoClearLoan.ForeColor = ResourceManager.Get("bank.btn.unsel");
				lbGoClearLoan.SelColor = ResourceManager.Get("bank.btn.sel");
				lbGoClearLoan.Font = new Font(RTCore.Environment.Font, 20);
				lbGoClearLoan.Location = new Point(panClearLoan.Width - 25 - lbGoClearLoan.Width, 111);
				lbGoClearLoan.Click += delegate
				{
					if (GameManager.Company.Loan == 0)
					{
						MessageBox.Show(TextManager.Get().Text("noloan"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					}
					else
					{
						if (GameManager.isBuild)
						{
							MessageBox.Show(TextManager.Get().Text("builded"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
							return;
						}

						long l = 0;
						string tmp = cbClearLoan.Items[cbClearLoan.SelectedIndex].ToString();
						tmp = tmp.Replace(",", "");
						tmp = tmp.Replace("RTW", "");
						l = Convert.ToInt64(tmp);

						if (GameManager.Company.Money - l <= 0)
						{
							MessageBox.Show(TextManager.Get().Text("nomoney"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
							return;
						}

						GameManager.Company.Loan -= l;
						GameManager.Company.Money -= l;

						Dictionary<string, string> data = new Dictionary<string, string>();
						data.Add("%CLEAR%", string.Format("{0:n0}", l));

						PluginManager.ClearedLoan(l);

						ClearLoan();

						MessageBox.Show(TextManager.Get().Text("okclearloan", true, data), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				};

				lbLoanMoney.Font = new Font(RTCore.Environment.Font, 12);

				lbBankBookTitle.Text = TextManager.Get().Text("bankbook");
				lbBankBookTitle.ForeColor = ResourceManager.Get("bank.title");
				lbBankBookTitle.Font = new Font(RTCore.Environment.Font, 30);

				panBankbookMoney.BackColor = ResourceManager.Get("bank.rect");

				lbBankbookMoney.ForeColor = ResourceManager.Get("bank.subtitle");
				lbBankbookMoney.Font = new Font(RTCore.Environment.Font, 20);
				BankBookUpdate();

				panDeposit.BackColor = ResourceManager.Get("bank.rect");

				lbDeposit.Font = new Font(RTCore.Environment.Font, 20);
				lbDeposit.Text = TextManager.Get().Text("deposit");
				lbDeposit.ForeColor = ResourceManager.Get("bank.subtitle");

				nuDeposit.Font = new Font(RTCore.Environment.Font, 20);
				nuDeposit.Maximum = GameManager.Company.Money * 0.8m;

				lbGoDeposit.Font = new Font(RTCore.Environment.Font, 20);
				lbGoDeposit.Text = TextManager.Get().Text("deposit");
				lbGoDeposit.Location = new Point(panDeposit.Width - 25 - lbGoDeposit.Width, 111);
				lbGoDeposit.Click += delegate
				{
					if (GameManager.isBuild)
					{
						MessageBox.Show(TextManager.Get().Text("builded"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						return;
					}

					if (nuDeposit.Value > 0)
					{
						GameManager.Company.Money -= nuDeposit.Value;
						GameManager.Company.Bankbooks[0] += nuDeposit.Value;
						Dictionary<string, string> d = new Dictionary<string, string>();
						d.Add("%MONEY%", string.Format("{0:n0}", nuDeposit.Value));
						PluginManager.DepositedBankBook(nuDeposit.Value);
						UpdateBankBook();
						MessageBox.Show(TextManager.Get().Text("depositok", true, d), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				};

				panWithdraw.BackColor = ResourceManager.Get("bank.rect");

				lbWithdraw.Font = new Font(RTCore.Environment.Font, 20);
				lbWithdraw.Text = TextManager.Get().Text("withdraw");
				lbWithdraw.ForeColor = ResourceManager.Get("bank.subtitle");

				nuWithdraw.Font = new Font(RTCore.Environment.Font, 20);
				nuWithdraw.Maximum = GameManager.Company.Bankbooks[0];

				lbGoWithdraw.Font = new Font(RTCore.Environment.Font, 20);
				lbGoWithdraw.Text = TextManager.Get().Text("withdraw");
				lbGoWithdraw.Location = new Point(panWithdraw.Width - 25 - lbGoWithdraw.Width, 111);
				lbGoWithdraw.Click += delegate
				{
					if (GameManager.isBuild)
					{
						MessageBox.Show(TextManager.Get().Text("builded"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						return;
					}

					if (nuWithdraw.Value > 0)
					{
						GameManager.Company.Money += nuWithdraw.Value;
						GameManager.Company.Bankbooks[0] -= nuWithdraw.Value;
						Dictionary<string, string> d = new Dictionary<string, string>();
						d.Add("%MONEY%", string.Format("{0:n0}", nuWithdraw.Value));
						PluginManager.WithdrawedBankBook(nuWithdraw.Value);
						UpdateBankBook();
						MessageBox.Show(TextManager.Get().Text("withdrawok", true, d), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				};
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public void ClearLoan()
		{
			try
			{
				cbClearLoan.Items.Clear();

				List<decimal> lst = new List<decimal>();

				lst.Add(1000000);
				lst.Add(5000000);
				lst.Add(10000000);
				lst.Add(50000000);
				lst.Add(100000000);
				lst.Add(500000000);
				lst.Add(1000000000);
				lst.Add(5000000000);
				lst.Add(GameManager.Company.Loan);

				for (int i = 0; i < 9; i++)
				{
					if (lst[i] <= GameManager.Company.Loan)
						cbClearLoan.Items.Add(string.Format("{0:n0}RTW", lst[i]));
					else
					{
						if (i != 0 && lst[i - 1] == lst[8]) break;
						cbClearLoan.Items.Add(string.Format("{0:n0}RTW", lst[8]));
						break;
					}
				}
				cbClearLoan.SelectedIndex = 0;

				Dictionary<string, string> d = new Dictionary<string, string>();
				d.Add("%LOAN%", string.Format("{0:n0}", GameManager.Company.Loan));

				lbLoanMoney.Text = TextManager.Get().Text("loans", true, d);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public void BankBookUpdate()
		{
			try
			{
				Dictionary<string, string> d = new Dictionary<string, string>();
				d.Add("%BANKBOOK%", string.Format("{0:n0}", GameManager.Company.Bankbooks[0]));

				lbBankbookMoney.Text = TextManager.Get().Text("bankbookmoney", true, d);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public void UpdateBankBook()
		{
			try
			{
				nuWithdraw.Maximum = GameManager.Company.Bankbooks[0];
				nuDeposit.Maximum = GameManager.Company.Money * 0.8m;
				if (GameManager.Company.Money <= 2000000)
					nuDeposit.Maximum = 0;
				BankBookUpdate();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void BankPage_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Draw(e);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
