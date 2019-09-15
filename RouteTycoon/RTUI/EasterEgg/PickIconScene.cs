// by SteveOS (SteveOS Developer is kmc7468@naver.com, this game developer is kmc7468@naver.com)
// ⓒ 2015-2016. kmc7468 All rights reserved.
// Steve is Smart

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

namespace RouteTycoon.RTUI
{
	internal partial class PickIconScene : Scene
	{
		#region data
		decimal score = 0;

		decimal retime = 500;
		decimal time = 1000;

		decimal a = 100;
		decimal b = 50;

		string soundurl = string.Empty;
		string unit = "점";

		System.Media.SoundPlayer p = new System.Media.SoundPlayer();

		bool changescore = false;
		Image img = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "rt_icon_img.png", 5, 7, 1, 6));

		int piccount = 1;
		int icocount = 1;

		int i = 0;
		#endregion

		public PickIconScene()
		{
			try
			{
				InitializeComponent();

				lbScore.Font = new Font(RTCore.Environment.Font, 18);
				btnStart.Font = new Font(RTCore.Environment.Font, 11);
				btnPause.Font = new Font(RTCore.Environment.Font, 11);
				btnCommand.Font = new Font(RTCore.Environment.Font, 11);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void btnCommand_Click(object sender, EventArgs e)
		{
			try
			{
				string entercommand = string.Empty;
				if (InputBox("RouteTycoon", "명령어를 입력하세요. (명령어 목록을 보려면 help 입력)", ref entercommand) == DialogResult.OK)
				{
					if (entercommand != string.Empty)
					{
						char enter = ' ';
						string[] cmdargs = entercommand.Split(enter);
						#region score
						if (cmdargs[0] == "score")
						{
							#region add
							if (cmdargs[1] == "add")
							{
								try
								{
									score += int.Parse(cmdargs[2]);
									lbScore.Text = score.ToString() + unit;
									changescore = true;
								}
								catch (OverflowException)
								{
									MessageBox.Show("숫자가 너무 큽니다.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
								catch (Exception)
								{
									MessageBox.Show("알 수 없는 오류가 발생하였습니다.\n다시 시도하십시오.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
							}
							#endregion
							#region set
							else if (cmdargs[1] == "set")
							{
								try
								{
									score = int.Parse(cmdargs[2]);
									lbScore.Text = score.ToString() + unit;
									changescore = true;
								}
								catch (OverflowException)
								{
									MessageBox.Show("숫자가 너무 큽니다.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
								catch (Exception)
								{
									MessageBox.Show("알 수 없는 오류가 발생하였습니다.\n다시 시도하십시오.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
							}
							#endregion
							#region remove
							else if (cmdargs[1] == "remove")
							{
								try
								{
									score -= int.Parse(cmdargs[2]);
									lbScore.Text = score.ToString() + unit;
									changescore = true;
								}
								catch (OverflowException)
								{
									MessageBox.Show("숫자가 너무 큽니다.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
								catch (Exception)
								{
									MessageBox.Show("알 수 없는 오류가 발생하였습니다.\n다시 시도하십시오.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
							}
							#endregion
							#region reset
							else if (cmdargs[1] == "reset")
							{
								try
								{
									score = 0;
									lbScore.Text = score.ToString() + unit;
									changescore = true;
								}
								catch (OverflowException)
								{
									MessageBox.Show("숫자가 너무 큽니다.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
								catch (Exception)
								{
									MessageBox.Show("알 수 없는 오류가 발생하였습니다.\n다시 시도하십시오.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
							}
							#endregion
							#region a
							else if (cmdargs[1] == "a")
							{
								try
								{
									a = int.Parse(cmdargs[2]);
									changescore = true;
								}
								catch (OverflowException)
								{
									MessageBox.Show("숫자가 너무 큽니다.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
								catch (Exception)
								{
									MessageBox.Show("알 수 없는 오류가 발생하였습니다.\n다시 시도하십시오.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
							}
							#endregion
							#region b
							else if (cmdargs[1] == "b")
							{
								try
								{
									b = int.Parse(cmdargs[2]);
									changescore = true;
								}
								catch (OverflowException)
								{
									MessageBox.Show("숫자가 너무 큽니다.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
								catch (Exception)
								{
									MessageBox.Show("알 수 없는 오류가 발생하였습니다.\n다시 시도하십시오.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
							}
							#endregion
						}
						#endregion
						#region spawn
						else if (cmdargs[0] == "spawn")
						{
							#region set
							if (cmdargs[1] == "set")
							{
								try
								{
									retime = int.Parse(cmdargs[2]);
								}
								catch (OverflowException)
								{
									MessageBox.Show("숫자가 너무 큽니다.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
								catch (Exception)
								{
									MessageBox.Show("알 수 없는 오류가 발생하였습니다.\n다시 시도하십시오.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
							}
							#endregion
							#region count
							else if (cmdargs[1] == "count")
							{
								piccount = int.Parse(cmdargs[2]);
							}
							#endregion
						}
						#endregion
						#region time
						else if (cmdargs[0] == "time")
						{
							#region set
							if (cmdargs[1] == "set")
							{
								try
								{
									time = int.Parse(cmdargs[2]);
								}
								catch (OverflowException)
								{
									MessageBox.Show("숫자가 너무 큽니다.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
								catch (Exception)
								{
									MessageBox.Show("알 수 없는 오류가 발생하였습니다.\n다시 시도하십시오.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
							}
							#endregion
						}
						#endregion
						#region image
						else if (cmdargs[0] == "image")
						{
							#region set
							if (cmdargs[1] == "set")
							{
								try
								{
									OpenFileDialog od = new OpenFileDialog();
									od.Filter = "이미지|*.png;*.jpg;*.jpge;*.bmp;*.gif";
									od.Title = "RouteTycoon";
									if (od.ShowDialog() == DialogResult.OK)
									{
										img = Image.FromFile(od.FileName);
									}
								}
								catch (OverflowException)
								{
									MessageBox.Show("숫자가 너무 큽니다.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
								catch (Exception)
								{
									MessageBox.Show("알 수 없는 오류가 발생하였습니다.\n다시 시도하십시오.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
							}
							#endregion
							#region reset
							else if (cmdargs[1] == "reset")
							{
								try
								{
									img = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "rt_icon_img.png", 5, 7, 1, 6));
								}
								catch (OverflowException)
								{
									MessageBox.Show("숫자가 너무 큽니다.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
								catch (Exception)
								{
									MessageBox.Show("알 수 없는 오류가 발생하였습니다.\n다시 시도하십시오.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
							}
							#endregion
						}
						#endregion
						#region sound
						else if (cmdargs[0] == "sound")
						{
							#region set
							if (cmdargs[1] == "set")
							{
								try
								{
									OpenFileDialog od = new OpenFileDialog();
									od.Title = "RouteTycoon";
									od.Filter = "wav 파일|*.wav";
									if (od.ShowDialog() == DialogResult.OK)
									{
										soundurl = od.FileName;
										p = new System.Media.SoundPlayer(soundurl);
									}
								}
								catch (OverflowException)
								{
									MessageBox.Show("숫자가 너무 큽니다.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
								catch (Exception)
								{
									MessageBox.Show("알 수 없는 오류가 발생하였습니다.\n다시 시도하십시오.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
							}
							#endregion
							#region start
							try
							{
								p.PlayLooping();
							}
							catch (OverflowException)
							{
								MessageBox.Show("숫자가 너무 큽니다.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}
							catch (Exception)
							{
								MessageBox.Show("알 수 없는 오류가 발생하였습니다.\n다시 시도하십시오.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}
							#endregion
							#region stop
							try
							{
								p.Stop();
							}
							catch (OverflowException)
							{
								MessageBox.Show("숫자가 너무 큽니다.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}
							catch (Exception)
							{
								MessageBox.Show("알 수 없는 오류가 발생하였습니다.\n다시 시도하십시오.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}
							#endregion
						}
						#endregion
						#region unit
						else if (cmdargs[0] == "unit")
						{
							#region set
							if (cmdargs[1] == "set")
							{
								try
								{
									unit = cmdargs[2];
									lbScore.Text = score.ToString() + unit;
								}
								catch (OverflowException)
								{
									MessageBox.Show("숫자가 너무 큽니다.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
								catch (Exception)
								{
									MessageBox.Show("알 수 없는 오류가 발생하였습니다.\n다시 시도하십시오.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
							}
							#endregion
						}
						#endregion
						#region background
						else if (cmdargs[0] == "background")
						{
							#region color
							if (cmdargs[1] == "color")
							{
								#region set
								if (cmdargs[2] == "set")
								{
									try
									{
										ColorDialog cd = new ColorDialog();
										cd.FullOpen = true;
										if (cd.ShowDialog() == DialogResult.OK)
										{
											this.BackColor = cd.Color;
											panGamezone.BackColor = cd.Color;
										}
									}
									catch (OverflowException)
									{
										MessageBox.Show("숫자가 너무 큽니다.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
										return;
									}
									catch (Exception)
									{
										MessageBox.Show("알 수 없는 오류가 발생하였습니다.\n다시 시도하십시오.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
										return;
									}
								}
								#endregion
							}
							#endregion
							#region reset
							else if (cmdargs[1] == "reset")
							{
								try
								{
									this.BackColor = Color.White;
									this.BackgroundImage.Dispose();
								}
								catch (OverflowException)
								{
									MessageBox.Show("숫자가 너무 큽니다.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
								catch (Exception)
								{
									MessageBox.Show("알 수 없는 오류가 발생하였습니다.\n다시 시도하십시오.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
							}
							#endregion
							#region image
							else if (cmdargs[1] == "image")
							{
								#region set
								if (cmdargs[2] == "set")
								{
									try
									{
										OpenFileDialog od = new OpenFileDialog();
										od.Title = "RouteTycoon";
										od.Filter = "이미지|*.png;*.jpg;*.jpge;*.bmp;*.gif";
										if (od.ShowDialog() == DialogResult.OK)
										{
											this.BackgroundImage = Image.FromFile(od.FileName);
											panGamezone.BackColor = Color.Transparent;
										}
									}
									catch (OverflowException)
									{
										MessageBox.Show("숫자가 너무 큽니다.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
										return;
									}
									catch (Exception)
									{
										MessageBox.Show("알 수 없는 오류가 발생하였습니다.\n다시 시도하십시오.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
										return;
									}
								}
								#endregion
							}
							#endregion
						}
						#endregion
						#region help
						else if (cmdargs[0] == "help")
						{
							#region cmd
							string score, spawn, time, image, sound, unit, background, help;
							string first = "<value> 에는 <,> 를 제외하고 원하는 숫자를 넣습니다.";
							score = "\nscore add <value> - 점수에 value 만큼을 더합니다.\nscore set <value> - 점수를 value 로 설정합니다.\nscore remove <value> - 점수를 value 만큼 뺍니다.\nscore reset - 점수를 0으로 만듭니다.\nscore a <value> - 지급 점수가 줄어들기 전에 얻는 점수를 value 로 설정합니다.\nscore b <value> - 지급 점수가 줄어든 후에 얻는 점수를 value 로 설정합니다.";
							spawn = "\nspawn set <value> - 아이콘이 생기는 주기를 value 로 설정합니다. (1초 = 1000)\nspawn count <value> - 한번에 아이콘이 생기는 갯수를 value 로 설정합니다.";
							time = "\ntime set <value> - 지급 점수가 줄어드는 단위를 value 로 설정합니다. (1초 = 1000)";
							image = "\nimage set - RouteTycoon 아이콘을 대체할 이미지를 선택하는 창을 엽니다.\nimage reset - 변경된 아이콘을 RouteTycoon 아이콘으로 되돌립니다.";
							sound = "\nsound set - 배경음악을 설정하는 창을 엽니다. wav 확장자만 지원합니다.\nsound play - 설정한 배경음악을 반복합니다. 음악이 끝나면 계속 반복됩니다.\nsound stop - 재생중인 배경음악을 정지 합니다.";
							unit = "\nunit set <value> - 점수 뒤에 붙을 글자를 설정합니다. 이 명령어에서의 <value> 에는 아무 글자나 상관 없이 입력할 수 있습니다.";
							background = "\nbackground color set - 배경화면의 색을 선택하는 창을 엽니다.\nbackground image set - 배경화면의 이미지를 선택하는 창을 엽니다. (권장 사이즈 : 980x680)\nbackground reset - 배경화면을 초기 설정으로 되돌립니다.";
							help = "\nhelp - 명령어의 목록 및 설명을 봅니다.";
							#endregion
							MessageBox.Show(first + score + spawn + time + image + sound + unit + background + help, "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						#endregion
					}
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void btnPause_Click(object sender, EventArgs e)
		{
			try
			{
				if (btnPause.Text == "일시정지")
				{
					btnPause.Text = "재시작";
					timIcon.Stop();
					panGamezone.Visible = false;
					btnCommand.Visible = true;
				}
				else
				{
					btnPause.Text = "일시정지";
					timIcon.Start();
					panGamezone.Visible = true;
					btnCommand.Visible = false;
					btnPause.Visible = false;
					timPause.Start();
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void timPause_Tick(object sender, EventArgs e)
		{
			try
			{
				btnPause.Visible = true;
				timPause.Stop();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			try
			{
				if (btnStart.Text == "아이콘 줍기 시작")
				{
					MessageBox.Show("행운을 빕니다! 확인 버튼을 누르면 시작 합니다.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
					btnStart.Text = "아이콘 줍기 종료";
					btnPause.Visible = true;
					btnCommand.Visible = false;
					timIcon.Start();
				}
				else
				{
					timIcon.Stop();
					try
					{
						p.Stop();
					}
					catch (Exception)
					{

					}
					string add1;
					if (changescore == true)
					{
						add1 = "(점수 수정 여부 : Yes)";
					}
					else
					{
						add1 = "(점수 수정 여부 : No)";
					}
					MessageBox.Show("당신의 최종 점수 : " + score.ToString() + "\n" + add1, "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Application.Exit();
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public static DialogResult InputBox(string title, string promptText, ref string value)
		{
			try
			{
				Form form = new Form();
				Label label = new Label();
				TextBox textBox = new TextBox();
				Button buttonOk = new Button();
				Button buttonCancel = new Button();

				form.Text = title;
				label.Text = promptText;
				textBox.Text = value;

				buttonOk.Text = "확인";
				buttonCancel.Text = "취소";
				buttonOk.DialogResult = DialogResult.OK;
				buttonCancel.DialogResult = DialogResult.Cancel;

				label.SetBounds(9, 20, 372, 13);
				textBox.SetBounds(12, 36, 372, 20);
				buttonOk.SetBounds(228, 72, 75, 23);
				buttonCancel.SetBounds(309, 72, 75, 23);

				label.AutoSize = true;
				textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
				buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
				buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

				form.ClientSize = new Size(396, 107);
				form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
				form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
				form.FormBorderStyle = FormBorderStyle.FixedDialog;
				form.StartPosition = FormStartPosition.CenterScreen;
				form.MinimizeBox = false;
				form.MaximizeBox = false;
				form.AcceptButton = buttonOk;
				form.CancelButton = buttonCancel;

				textBox.BringToFront();

				DialogResult dialogResult = form.ShowDialog();
				value = textBox.Text;
				return dialogResult;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
				return 0;
			}
		}

		private void clickevent(PictureBox pic)
		{
			if (i == 1)
			{
				try
				{
					panGamezone.Controls.Remove(pic);
					score += int.Parse(a.ToString());
					lbScore.Text = score.ToString() + unit;
					icocount -= 1;
					if (icocount == 0)
					{
						i = 0;
					}
				}
				catch (OverflowException)
				{
					string add1;
					if (changescore == true)
					{
						add1 = "(점수 수정 여부 : Yes)";
					}
					else
					{
						add1 = "(점수 수정 여부 : No)";
					}
					MessageBox.Show("처리 가능한 최고 점수 도달!\n당신의 최종 점수 : " + score.ToString() + "\n" + add1, "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Application.Exit();
				}
			}
			else if (i == 2)
			{
				try
				{
					panGamezone.Controls.Remove(pic);
					score += int.Parse(b.ToString());
					lbScore.Text = score.ToString() + unit;
					icocount -= 1;
					if (icocount == 0)
					{
						i = 0;
					}
				}
				catch (OverflowException)
				{
					string add1;
					if (changescore == true)
					{
						add1 = "(점수 수정 여부 : Yes)";
					}
					else
					{
						add1 = "(점수 수정 여부 : No)";
					}
					MessageBox.Show("처리 가능한 최고 점수 도달!\n당신의 최종 점수 : " + score.ToString() + "\n" + add1, "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Application.Exit();
				}
			}
		}

		private void timIcon_Tick(object sender, EventArgs e)
		{
			try
			{
				if (i == 0)
				{
					timIcon.Stop();
					icocount = 1;
					for (icocount = 0; icocount < piccount; icocount++)
					{
						Point pt = new Point();
						bool isvalid = false;

						do
						{
							isvalid = true;

							Random rd = new Random();
							pt.X = rd.Next(0, 920);
							pt.Y = rd.Next(0, 541);

							foreach (Control ctl in panGamezone.Controls)
							{
								if ((new Rectangle(ctl.Location, ctl.Size)).IntersectsWith(new Rectangle(pt, new Size(60, 60))))
									isvalid = false;
							}
						} while (isvalid != true);



						PictureBox pic = new PictureBox();
						pic.Location = pt;
						pic.Image = img;
						pic.BackColor = Color.Transparent;
						pic.SizeMode = PictureBoxSizeMode.StretchImage;
						pic.Size = new Size(60, 60);
						pic.Click += (object senders, EventArgs es) => { clickevent(pic); };
						panGamezone.Controls.Add(pic);
					}
					i += 1;
					timIcon.Start();
				}
				else if (i == 1)
				{
					i += 1;
				}
				else if (i == 2)
				{
					i += 1;
				}
				else if (i == 3)
				{
					timIcon.Stop();
					string add1;
					if (changescore == true)
					{
						add1 = "(점수 수정 여부 : Yes)";
					}
					else
					{
						add1 = "(점수 수정 여부 : No)";
					}
					MessageBox.Show("게임 오버!\n당신의 최종 점수 : " + score.ToString() + "\n" + add1, "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Application.Exit();
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex);
			}
		}
	}
}