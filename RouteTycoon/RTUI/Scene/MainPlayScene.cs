using System;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class MainPlayScene : PlayScene
	{
		private Graphics g;
		private BankPage bp = null;

		private Image reg_mark;

		public MainPlayScene()
		{
			try
			{
				InitializeComponent();

				Command.main = this;

				BackgroundImage = GameManager.Map.BackImg;

				panTopbar.BackgroundImage = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "play_topbar.png", 5, 7, 1, 6));

				reg_mark = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_region.png", 5, 7, 1, 6));

				picRoute.Image = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "play_btn_ways.png", 5, 7, 1, 6));
				picTrain.Image = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "play_btn_train.png", 5, 7, 1, 6));
				picBank.Image = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "play_btn_bank.png", 5, 7, 1, 6));
				picNews.Image = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "play_btn_news.png", 5, 7, 1, 6));
				picCompany.Image = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "play_btn_company.png", 5, 7, 1, 6));
				picOp.Image = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "play_btn_timetable.png", 5, 7, 1, 6));
				picBook.Image = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "play_btn_book.png", 5, 7, 1, 6));

				picLogo.Image = GameManager.Company.Logo;
				picPresident.Image = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "play_ico_president.png", 5, 7, 1, 6));
				picMoney.Image = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "play_ico_coin.png", 5, 7, 1, 6));
				picIncome.Image = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "play_ico_income.png", 5, 7, 1, 6));
				picDate.Image = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "play_ico_date.png", 5, 7, 1, 6));

				lbCN.Font = new Font(RTCore.Environment.Font, 14);
				lbPN.Font = new Font(RTCore.Environment.Font, 14);
				lbMoney.Font = new Font(RTCore.Environment.Font, 14);
				lbIncome.Font = new Font(RTCore.Environment.Font, 14);
				lbDate.Font = new Font(RTCore.Environment.Font, 14);

				lbCN.ForeColor = ResourceManager.Get("play.text.company");
				lbPN.ForeColor = ResourceManager.Get("play.text.president");
				lbMoney.ForeColor = ResourceManager.Get("play.text.money");
				lbIncome.ForeColor = ResourceManager.Get("play.text.income.zero");
				lbDate.ForeColor = ResourceManager.Get("play.text.date");

				lbCN.Text = GameManager.Company.Name;
				lbPN.Text = GameManager.Company.PresidentName;
				lbMoney.Text = string.Format("{0:n0}", GameManager.Company.Money);
				lbIncome.Text = string.Format("{0:n0}", GameManager.Company.Income);
				if (GameManager.Company.Income < 0) lbIncome.ForeColor = ResourceManager.Get("play.text.income.minus");
				else if (GameManager.Company.Income > 0) lbIncome.ForeColor = ResourceManager.Get("play.text.income.plus");
				lbDate.Text = $"{GameManager.Time.Year}.{GameManager.Time.Month}.{GameManager.Time.Day}";

				panBankruptcy.BackColor = ResourceManager.Get("play.bankruptcy");
				panBankruptcy.Location = new Point(0, 0);

				lbBankruptcyTitle.ForeColor = ResourceManager.Get("play.bankruptcy.title");
				lbBankruptcyTitle.Text = TextManager.Get().Text("bankruptcy");
				Size b_size = RTCore.Environment.CalcStringSize(TextManager.Get().Text("bankruptcy"), new Font(RTCore.Environment.Font, 72));
				PointF b_loc_f = RTCore.Environment.CalcRectangle(new Point(Width / 2, (Height / 2) - (b_size.Height / 2 + 40)), b_size).Location;
				lbBankruptcyTitle.Location = new Point((int)b_loc_f.X, (int)b_loc_f.Y);
				lbBankruptcyTitle.Font = new Font(RTCore.Environment.Font, 72);
				lbBankruptcyTitle.BackColor = Color.Transparent;

				lbBank.ForeColor = ResourceManager.Get("play.bankruptcy.bank.unsel");
				lbBank.SelColor = ResourceManager.Get("play.bankruptcy.bank.sel");
				lbBank.Font = new Font(RTCore.Environment.Font, 30);
				lbBank.Text = TextManager.Get().Text("bank");
				Size l_size = RTCore.Environment.CalcStringSize(TextManager.Get().Text("bank"), new Font(RTCore.Environment.Font, 30));
				PointF l_loc_f = RTCore.Environment.CalcRectangle(new Point(Width / 2, lbBankruptcyTitle.Location.Y + lbBankruptcyTitle.Height + 25), l_size).Location;
				lbBank.Location = new Point((int)l_loc_f.X, (int)l_loc_f.Y);
				lbBank.BackColor = Color.Transparent;

				lbDelete.ForeColor = ResourceManager.Get("play.bankruptcy.delete.unsel");
				lbDelete.SelColor = ResourceManager.Get("play.bankruptcy.delete.sel");
				lbDelete.Font = new Font(RTCore.Environment.Font, 30);
				lbDelete.Text = TextManager.Get().Text("deletesav");
				Size d_size = RTCore.Environment.CalcStringSize(TextManager.Get().Text("deletesav"), new Font(RTCore.Environment.Font, 30));
				PointF d_loc_f = RTCore.Environment.CalcRectangle(new Point(Width / 2, lbBank.Location.Y + lbBank.Height + 23), d_size).Location;
				lbDelete.Location = new Point((int)d_loc_f.X, (int)d_loc_f.Y);
				lbDelete.BackColor = Color.Transparent;

				lbBuild.ForeColor = ResourceManager.Get("play.bankruptcy.build.unsel");
				lbBuild.SelColor = ResourceManager.Get("play.bankruptcy.build.sel");
				lbBuild.Font = new Font(RTCore.Environment.Font, 30);
				lbBuild.Text = TextManager.Get().Text("build");
				Size bu_size = RTCore.Environment.CalcStringSize(TextManager.Get().Text("build"), new Font(RTCore.Environment.Font, 30));
				PointF bu_loc_f = RTCore.Environment.CalcRectangle(new Point(Width / 2, lbDelete.Location.Y + lbDelete.Height + 23), bu_size).Location;
				lbBuild.Location = new Point((int)bu_loc_f.X, (int)bu_loc_f.Y);
				lbBuild.BackColor = Color.Transparent;

				tmSave.Tick += delegate
				{
					GameManager.Save(GameManager.Filename);
				};

				if (!GameManager.isBuild)
				{
					tmDate.Start();
					tmUpdate.Start();

					if (OptionManager.Get().AutoSave)
					{
						tmSave.Interval = OptionManager.Get().AutoSaveSecond * 1000;
						tmSave.Start();
					}
				}
				else
				{
					KeyPress -= MainPlayScene_KeyPress;
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void RenderRoute(Graphics g)
		{
			try
			{
				foreach (Route route in GameManager.RouteMgr.Routes)
				{
					if (route.Owner != GameManager.Company) continue;
					if (!route.MainDraw) continue;

					Station prev_sta = null;
					foreach (Station sta in route.Stations)
					{
						if (prev_sta != null)
						{
							Pen p = new Pen(route.RouteColor, 3);

							Point now = prev_sta.Parent.Location;
							Point next = sta.Parent.Location;

							if (prev_sta.Parent.Location.X == prev_sta.Parent.Parent.Location.X && prev_sta.Parent.Location.Y == prev_sta.Parent.Parent.Location.Y)
								now = new Point(prev_sta.Parent.Location.X + 15, prev_sta.Parent.Location.Y + 15);

							if (sta.Parent.Location.X == sta.Parent.Parent.Location.X && sta.Parent.Location.Y == sta.Parent.Parent.Location.Y)
								next = new Point(sta.Parent.Location.X + 15, sta.Parent.Location.Y + 15);

							g.DrawLine(p, now, next);
						}
						prev_sta = sta;
					}
				}

				foreach (RTCore.Region reg in GameManager.Map.Regions)
				{
					foreach (var it in reg.Childs)
					{
						if (it.Location.X == reg.Location.X && it.Location.Y == reg.Location.Y)
							g.FillEllipse(new SolidBrush(ResourceManager.Get("play.city")), new Rectangle(it.Location.X + 15, it.Location.Y + 15, 3, 3));
						else
							g.FillEllipse(new SolidBrush(ResourceManager.Get("play.city")), new Rectangle(it.Location.X, it.Location.Y, 3, 3));
					}
					g.DrawImage(reg_mark, new Rectangle(reg.Location, new Size(30, 30)));
				}

				if (GameManager.isBuild)
				{
					Point point = Point.Empty;
					Size size = Size.Empty;
					string text = GameManager.SaveInfo;
					Font font = new Font(RTCore.Environment.Font, 12);

					size = RTCore.Environment.CalcStringSize(text, font);
					point = new Point(Width - size.Width - 5, Height - size.Height - 5);

					g.FillRectangle(new SolidBrush(Color.FromArgb(180, Color.DeepSkyBlue)), new RectangleF(Width - size.Width - 9, Height - size.Height - 9, size.Width + 4, size.Height + 4));
					g.DrawString(text, font, Brushes.White, point);
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void Draw(MouseEventArgs e)
		{
			try
			{
				if (e != null)
				{
					foreach (RTCore.Region re in GameManager.Map.Regions)
					{
						Rectangle reg_rect = new Rectangle(re.Location, new Size(30, 30));

						if (e.X >= reg_rect.Left && e.X <= reg_rect.Right && e.Y <= reg_rect.Bottom && e.Y >= reg_rect.Top)
						{
							using (BufferedGraphics bG = BufferedGraphicsManager.Current.Allocate(g, ClientRectangle))
							{
								bG.Graphics.Clear(Color.Transparent);
								bG.Graphics.DrawImage(GameManager.Map.BackImg, ClientRectangle);
								bG.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
								bG.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
								bG.Graphics.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);

								bG.Graphics.DrawLine(Pens.White, 100, 40, 100, Height);

								RenderRoute(bG.Graphics);

								string info_str = TextManager.Get().Text("clickcheckinfo");

								long total = 0;
								if (re.Childs.Count != 0)
								{
									foreach (City city in re.Childs) total += city.Price;

									total = total / re.Childs.Count;
								}

								int preference = 0;
								if (re.Childs.Count != 0)
								{
									foreach (City city in re.Childs) preference += city.Preference[0];
									preference = preference / re.Childs.Count;
								}

								string str = TextManager.Get().Text("average") + " " + TextManager.Get().Text("cityprice") + ": ";

								Font font = new Font(RTCore.Environment.Font, 10);

								SizeF nameSize = bG.Graphics.MeasureString(str + string.Format("{0:n0}", total) + "RTW", font);
								SizeF priceSize = bG.Graphics.MeasureString(str + string.Format("{0:n0}", total) + "RTW", font);
								SizeF preSize = bG.Graphics.MeasureString(re.Name, font);
								SizeF infoSize = bG.Graphics.MeasureString(info_str, new Font(font.FontFamily, 8));

								SizeF size = new SizeF(0, 0);

								float w = 0f;
								float h = 0f;

								if (nameSize.Width >= priceSize.Width && nameSize.Width >= preSize.Width && nameSize.Width >= infoSize.Width)
									w = nameSize.Width;
								else if (priceSize.Width >= nameSize.Width && priceSize.Width >= preSize.Width && priceSize.Width >= infoSize.Width)
									w = priceSize.Width;
								else if (preSize.Width >= nameSize.Width && preSize.Width > priceSize.Width && preSize.Width >= infoSize.Width)
									w = preSize.Width;
								else if (infoSize.Width >= nameSize.Width && infoSize.Width > priceSize.Width && infoSize.Width >= preSize.Width)
									w = infoSize.Width;

								h = nameSize.Height;

								size = new SizeF(w, h);

								bG.Graphics.DrawRectangle(Pens.Blue, e.X, e.Y - 30, size.Width + 10, size.Height * 4 + 10);
								bG.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(180, Color.DeepSkyBlue)), new RectangleF(new PointF(e.X, e.Y - 30), new SizeF(size.Width + 10, size.Height * 4 + 10)));
								bG.Graphics.DrawString(re.Name, font, Brushes.White, new PointF(e.X + 5, e.Y + 4 - 30));

								bG.Graphics.DrawString(str + string.Format("{0:n0}", total) + "RTW", font, Brushes.White, new PointF(e.X + 5, e.Y + 4 - 10));

								string tmpstring = TextManager.Get().Text("average") + " " + TextManager.Get().Text("preference") + ": ";
								bG.Graphics.DrawString(tmpstring + preference.ToString(), font, Brushes.White, new PointF(e.X + 5, e.Y + 4 + 10));

								bG.Graphics.DrawString(info_str, new Font(font.FontFamily, 8), Brushes.White, new PointF(e.X + 5, e.Y + 4 + 13 + preSize.Height));

								bG.Render(g);
							}
							return;
						}

						foreach (var city in re.Childs)
						{
							Rectangle city_rect = new Rectangle(new Point(city.Location.X - 2, city.Location.Y - 2), new Size(9, 9));

							if (e.X >= city_rect.Left && e.X <= city_rect.Right && e.Y <= city_rect.Bottom && e.Y >= city_rect.Top)
							{
								using (BufferedGraphics bG = BufferedGraphicsManager.Current.Allocate(g, ClientRectangle))
								{
									bG.Graphics.Clear(Color.Transparent);
									bG.Graphics.DrawImage(GameManager.Map.BackImg, ClientRectangle);
									bG.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
									bG.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
									bG.Graphics.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);

									bG.Graphics.DrawLine(Pens.White, 100, 40, 100, Height);

									RenderRoute(bG.Graphics);

									Font font = new Font(RTCore.Environment.Font, 10);
									SizeF size = SizeF.Empty;
									float w = 0f;
									float h = 0f;

									string city_price = TextManager.Get().Text("cityprice") + " : " + string.Format("{0:n0}", city.Price) + "RTW";
									string pop = TextManager.Get().Text("population") + " : " + string.Format("{0:n0}", city.Population);
									string pre = TextManager.Get().Text("preference") + " : " + city.Preference[0];
									string info_str = TextManager.Get().Text("clickcheckinfo");

									SizeF title_size = bG.Graphics.MeasureString($"{re.Name}.{city.Name}", font);
									SizeF cityprice_size = bG.Graphics.MeasureString(city_price, font);
									SizeF pop_size = bG.Graphics.MeasureString(pop, font);
									SizeF pre_size = bG.Graphics.MeasureString(pre, font);
									SizeF infostr_size = bG.Graphics.MeasureString(info_str, font);

									if (title_size.Width >= cityprice_size.Width && title_size.Width >= pop_size.Width && title_size.Width >= pre_size.Width && title_size.Width >= infostr_size.Width)
										w = title_size.Width;
									else if (cityprice_size.Width >= title_size.Width && cityprice_size.Width >= pop_size.Width && cityprice_size.Width >= pre_size.Width && cityprice_size.Width >= infostr_size.Width)
										w = cityprice_size.Width;
									else if (pop_size.Width >= cityprice_size.Width && pop_size.Width >= title_size.Width && pop_size.Width >= pre_size.Width && pop_size.Width >= infostr_size.Width)
										w = pop_size.Width;
									else if (pre_size.Width >= cityprice_size.Width && pre_size.Width >= pop_size.Width && pre_size.Width >= title_size.Width && pre_size.Width >= infostr_size.Width)
										w = pre_size.Width;
									else if (infostr_size.Width >= cityprice_size.Width && infostr_size.Width >= pop_size.Width && infostr_size.Width >= pre_size.Width && infostr_size.Width >= title_size.Width)
										w = infostr_size.Width;

									h = title_size.Height;

									size = new SizeF(w, h);

									bG.Graphics.DrawRectangle(Pens.Blue, e.X, e.Y - 30, size.Width + 10, size.Height * 5 + 10);
									bG.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(180, Color.DeepSkyBlue)), new RectangleF(new PointF(e.X, e.Y - 30), new SizeF(size.Width + 10, size.Height * 5 + 10)));
									bG.Graphics.DrawString($"{re.Name}.{city.Name}", font, Brushes.White, new PointF(e.X + 5, e.Y + 4 - 30));
									bG.Graphics.DrawString(city_price, font, Brushes.White, new PointF(e.X + 5, e.Y + 4 - 30 + title_size.Height + 0.8f));
									bG.Graphics.DrawString(pop, font, Brushes.White, new PointF(e.X + 5, e.Y + 4 - 30 + title_size.Height + 1 + cityprice_size.Height + 0.8f));
									bG.Graphics.DrawString(pre, font, Brushes.White, new PointF(e.X + 5, e.Y + 4 - 30 + title_size.Height + 0.8f + cityprice_size.Height + 0.8f + pop_size.Height + 0.8f));
									bG.Graphics.DrawString(info_str, new Font(font.FontFamily, 8), Brushes.White, new PointF(e.X + 5, e.Y + 4 - 30 + title_size.Height + 0.8f + cityprice_size.Height + 0.8f + pop_size.Height + 0.8f + pre_size.Height + 1.05f));

									bG.Render(g);
								}
								return;
							}
						}
					}
				}

				using (BufferedGraphics bG = BufferedGraphicsManager.Current.Allocate(g, ClientRectangle))
				{
					bG.Graphics.Clear(Color.Transparent);

					bG.Graphics.DrawImage(GameManager.Map.BackImg, ClientRectangle);
					bG.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
					bG.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
					bG.Graphics.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);

					bG.Graphics.DrawLine(Pens.White, 100, 40, 100, Height);

					RenderRoute(bG.Graphics);

					bG.Render(g);
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public enum DateType
		{
			Year,
			Month,
			Day
		}

		private bool NewsNotice = false;
		private Timer NewsNoticeTimer = null;

		private bool BookNotice = false;
		private Timer BookNoticeTimer = null;

		public void AddDate(DateType type)
		{
			try
			{
				if (type == DateType.Year) GameManager.Time = GameManager.Time.AddYears(1);
				else if (type == DateType.Month) GameManager.Time = GameManager.Time.AddMonths(1);
				else if (type == DateType.Day) GameManager.Time = GameManager.Time.AddDays(1);

				if (GameManager.Time.Day == 1)
				{
					GameManager.Company.Loan += GameManager.LoanRate;
					if (bp != null) { bp.ClearLoan(); bp.BankBookUpdate(); bp.UpdateBankBook(); }
					if (GameManager.Company.Income != 0)
					{
						if (GameManager.Company.Income > 0)
							GameManager.Company.Money += GameManager.Company.Income;
						else if (GameManager.Company.Income < 0)
						{
							string tmp = GameManager.Company.Income.ToString();
							tmp = tmp.Replace("-", "");
							GameManager.Company.Money -= Convert.ToDecimal(tmp);
						}
					}
				}

				foreach (var r in GameManager.Map.Regions)
				{
					foreach (var c in r.Childs)
					{
						foreach (var s in c.Childs)
						{
							s.Visitor = GameManager.GameRule.CalcVisitor(c.Population, c.Preference[0], c.Childs.Count);
							if (s.Type != Station.StationType.DOUBLE)
								s.Visitor = s.Visitor / 2;
						}
					}
				}

				foreach (var it in GameManager.RouteMgr.Routes)
				{
					foreach (var s in it.Stations)
					{
						s.Visitor -= GameManager.GameRule.CalcMinusStationVistor(s.Parent.Population, s.Visitor, it.UseMoney);
					}
				}

				if (NewsManager.Update())
				{
					Timer tm = new Timer();
					tm.Interval = 300;
					int i = 0;
					tm.Tick += delegate
					{
						if (i == 0 || i == 2 || i == 4)
						{
							tm.Interval = 300;
							panNews.BackColor = ResourceManager.Get("play.news.sel");
						}
						else if (i == 1 || i == 3 || i == 5)
						{
							tm.Interval = 800;
							panNews.BackColor = Color.Transparent;
						}

						if (i == 5)
						{
							tm.Stop();
							NewsNotice = false;
							NewsNoticeTimer = null;
							tm.Dispose();
							return;
						}

						i++;
					};
					if (!NewsNotice) { tm.Start(); NewsNotice = true; NewsNoticeTimer = tm; }
				}

				if (AchievementManager.Update())
				{
					Timer tm = new Timer();
					tm.Interval = 300;
					int i = 0;
					tm.Tick += delegate
					{
						if (i == 0 || i == 2 || i == 4)
						{
							tm.Interval = 300;
							panBook.BackColor = ResourceManager.Get("play.book.sel");
						}
						else if (i == 1 || i == 3 || i == 5)
						{
							tm.Interval = 800;
							panBook.BackColor = Color.Transparent;
						}

						if (i == 5)
						{
							tm.Stop();
							BookNotice = false;
							BookNoticeTimer = null;
							tm.Dispose();
							return;
						}

						i++;
					};
					if (!BookNotice) { tm.Start(); BookNotice = true; BookNoticeTimer = tm; }
				}

				GameManager.UpdateMap();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void MainPlayScene_MouseMove(object sender, MouseEventArgs e)
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

		bool p = true;

		private void MainPlayScene_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				if (!p) return;

				g = CreateGraphics();

				g.Clear(Color.Transparent);

				g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

				Draw(null);

				p = false;

				Refresh();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void panRoute_MouseEnter(object sender, EventArgs e)
		{
			panRoute.BackColor = ResourceManager.Get("play.route.sel");
		}

		private void panRoute_MouseLeave(object sender, EventArgs e)
		{
			panRoute.BackColor = Color.Transparent;
		}

		private void panTrain_MouseEnter(object sender, EventArgs e)
		{
			panTrain.BackColor = ResourceManager.Get("play.train.sel");
		}

		private void panTrain_MouseLeave(object sender, EventArgs e)
		{
			panTrain.BackColor = Color.Transparent;
		}

		private void panBank_MouseEnter(object sender, EventArgs e)
		{
			panBank.BackColor = ResourceManager.Get("play.bank.sel");
		}

		private void panBank_MouseLeave(object sender, EventArgs e)
		{
			panBank.BackColor = Color.Transparent;
		}

		private void panNews_MouseEnter(object sender, EventArgs e)
		{
			if (NewsNotice)
			{
				NewsNoticeTimer.Stop();
				NewsNoticeTimer.Dispose();
				NewsNoticeTimer = null;
				NewsNotice = false;
			}

			panNews.BackColor = ResourceManager.Get("play.news.sel");
		}

		private void panNews_MouseLeave(object sender, EventArgs e)
		{
			panNews.BackColor = Color.Transparent;
		}

		private void panCompany_MouseEnter(object sender, EventArgs e)
		{
			panCompany.BackColor = ResourceManager.Get("play.company.sel");
		}

		private void panCompany_MouseLeave(object sender, EventArgs e)
		{
			panCompany.BackColor = Color.Transparent;
		}

		private void panOp_MouseEnter(object sender, EventArgs e)
		{
			panOp.BackColor = ResourceManager.Get("play.timetable.sel");
		}

		private void panOp_MouseLeave(object sender, EventArgs e)
		{
			panOp.BackColor = Color.Transparent;
		}

		private void picLogo_Click(object sender, EventArgs e)
		{
			try
			{
				new frmImage(GameManager.Company.Logo).ShowDialog();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void tmUpdate_Tick(object sender, EventArgs e)
		{
			try
			{
				GameManager.Update();

				lbMoney.Text = string.Format("{0:n0}", GameManager.Company.Money);
				if (GameManager.Company.Money >= decimal.MaxValue - int.MaxValue) lbMoney.ForeColor = ResourceManager.Get("play.text.money.many");
				else if (GameManager.Company.Money <= decimal.MinValue + int.MaxValue) lbMoney.ForeColor = ResourceManager.Get("play.text.money.little");
				lbIncome.Text = string.Format("{0:n0}", GameManager.Company.Income);
				if (GameManager.Company.Income < 0) lbIncome.ForeColor = ResourceManager.Get("play.text.income.minus");
				else if (GameManager.Company.Income > 0) lbIncome.ForeColor = ResourceManager.Get("play.text.income.plus");
				else lbIncome.ForeColor = ResourceManager.Get("play.text.income.zero");

				lbDate.Text = $"{GameManager.Time.Year}.{GameManager.Time.Month}.{GameManager.Time.Day}";

				toolTip.SetToolTip(lbMoney, TextManager.Get().Text("money") + " : " + string.Format("{0:n0}", GameManager.Company.Money));
				toolTip.SetToolTip(picMoney, TextManager.Get().Text("money") + " : " + string.Format("{0:n0}", GameManager.Company.Money));

				toolTip.SetToolTip(lbIncome, TextManager.Get().Text("income") + " : " + string.Format("{0:n0}", GameManager.Company.Income));
				toolTip.SetToolTip(picIncome, TextManager.Get().Text("income") + " : " + string.Format("{0:n0}", GameManager.Company.Income));

				toolTip.SetToolTip(lbDate, TextManager.Get().Text("date") + " : " + $"{GameManager.Time.Year}.{GameManager.Time.Month}.{GameManager.Time.Day}");
				toolTip.SetToolTip(picDate, TextManager.Get().Text("date") + " : " + $"{GameManager.Time.Year}.{GameManager.Time.Month}.{GameManager.Time.Day}");

				toolTip.SetToolTip(lbPN, TextManager.Get().Text("presidentname") + " : " + GameManager.Company.PresidentName);
				toolTip.SetToolTip(picPresident, TextManager.Get().Text("presidentname") + " : " + GameManager.Company.PresidentName);

				toolTip.SetToolTip(lbCN, TextManager.Get().Text("companyname") + " : " + GameManager.Company.Name);
				toolTip.SetToolTip(picLogo, TextManager.Get().Text("companylogo"));

				if (GameManager.Company.Money <= 0 && !GameManager.Sandbox)
				{
					tmUpdate.Stop();
					tmDate.Stop();

					KeyPress -= MainPlayScene_KeyPress;

					panBankruptcy.Visible = true;
				}
			}
			catch (Exception ex)
			{
				tmUpdate.Stop();
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void panRoute_Click(object sender, EventArgs e)
		{
			try
			{
				RouteListPage rlp = new RouteListPage();

				PageManager.SetPage(rlp, AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void tmDate_Tick(object sender, EventArgs e)
		{
			try
			{
				AddDate(DateType.Day);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public void MainPlayScene_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar.ToString() == "\r" || e.KeyChar.ToString() == "\n")
				{
					// Chat
					return;
				}

				Command.AddChar(e.KeyChar);
				e.Handled = true;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void panBook_MouseEnter(object sender, EventArgs e)
		{
			try
			{
				if (BookNotice)
				{
					BookNoticeTimer.Stop();
					BookNoticeTimer.Dispose();
					BookNoticeTimer = null;
					BookNotice = false;
				}

				panBook.BackColor = ResourceManager.Get("play.book.sel");
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void panBook_MouseLeave(object sender, EventArgs e)
		{
			try
			{
				panBook.BackColor = Color.Transparent;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void panBook_Click(object sender, EventArgs e)
		{
			try
			{
				PageManager.SetPage(new AchievementListPage(), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public override void OnClosed()
		{
			try
			{
				Command.main = null;

				reg_mark.Dispose();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void MainPlayScene_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				foreach (var it in GameManager.Map.Regions)
				{
					Rectangle reg = new Rectangle(it.Location, new Size(30, 30));

					if (e.X >= reg.Left && e.X <= reg.Right && e.Y <= reg.Bottom && e.Y >= reg.Top)
					{
						if (it.Childs.Count == 0)
						{
							MessageBox.Show(TextManager.Get().Text("nocity"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}

						PageManager.SetPage(new RegionInfoPage(it), AccessManager.AccessKey);
						return;
					}

					foreach (var c in it.Childs)
					{
						Rectangle city = new Rectangle(new Point(c.Location.X - 2, c.Location.Y - 2), new Size(9, 9));

						if (e.X >= city.Left && e.X <= city.Right && e.Y <= city.Bottom && e.Y >= city.Top)
						{
							PageManager.SetPage(new RegionInfoPage(it, c), AccessManager.AccessKey);
							return;
						}
					}
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void panNews_Click(object sender, EventArgs e)
		{
			try
			{
				PageManager.SetPage(new NewsPage(), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void panTrain_Click(object sender, EventArgs e)
		{
			try
			{
				PageManager.SetPage(new TrainListPage(), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbDelete_Click(object sender, EventArgs e)
		{
			try
			{
				if (MessageBox.Show(TextManager.Get().Text("realdelete").Replace("%NAME%\n", ""), "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					SceneManager.SetScene(new MainMenuScene(), AccessManager.AccessKey);
					GameManager.Save(GameManager.Filename);
					System.IO.File.Delete($".\\data\\saves\\{GameManager.Filename}.sav");
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbBuild_Click(object sender, EventArgs e)
		{
			try
			{
				if (MessageBox.Show(TextManager.Get().Text("buildsav"), "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					SaveFileDialog sfd = new SaveFileDialog();
					sfd.Title = TextManager.Get().Text("selectsavepath");
					sfd.Filter = "sav 파일|*.sav";
					if (sfd.ShowDialog() == DialogResult.OK)
					{
						try
						{
							GameManager.Sandbox = false;
							GameManager.isBuild = true;
							GameManager.Company.Money = 0;
							GameManager.SaveExtraPath(sfd.FileName.Substring(0, sfd.FileName.Length - 4));
							MessageBox.Show(TextManager.Get().Text("buildcomplete"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
							SceneManager.SetScene(new MainPlayScene(), AccessManager.AccessKey);
							return;
						}
						catch (Exception ex)
						{
							LogManager.Add(new Log() { evt = Log.Event.MESSAGE, type = Log.Type.ERROR, Message = $@"GameManager - 빌드 도중 오류 발생\n에러 메세지: {ex.ToString()}" });
							MessageBox.Show(TextManager.Get().Text("builderr"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
					}
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbLoan_Click(object sender, EventArgs e)
		{
			try
			{
				PageManager.SetPage(new BankPage(this), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void panBank_Click(object sender, EventArgs e)
		{
			try
			{
				bp = new BankPage();
				PageManager.SetPage(bp, AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void panCompany_Click(object sender, EventArgs e)
		{
			try
			{
				PageManager.SetPage(new CompanyListPage(), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void panOp_Click(object sender, EventArgs e)
		{
			try
			{
				{
					MessageBox.Show(TextManager.Get().Text("nowdevelop"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return;
				}

				PageManager.SetPage(new Operation_Main_Page(), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
