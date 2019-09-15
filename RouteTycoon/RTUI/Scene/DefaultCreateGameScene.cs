using System;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;
using System.Collections.Generic;

namespace RouteTycoon.RTUI
{
	internal partial class DefaultCreateGameScene : Scene
	{
		private bool _isSandBox;

		private int step = 0;

		private TextBox txtInput = new TextBox();
		private ListBox lstRegion = new ListBox();
		private PictureBox picMap = new PictureBox();
		private Label lbFilename = new Label();
		private TextBox txtFilename = new TextBox();
		private Label lbMapDeveloper = new Label();

		private Image imgDefault = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "defaultlogo.png", 5, 7, 1, 6));

		private new string CompanyName = string.Empty;
		private string PresidentName = string.Empty;
		private string SaveName = string.Empty;

		public DefaultCreateGameScene(bool sandbox = false)
		{
			try
			{
				InitializeComponent();

				_isSandBox = sandbox;

				_Load();

				txtInput.Name = "txtInput";
				lstRegion.Name = "lstRegion";
				picMap.Name = "picMap";
				lbFilename.Name = "lbFilename";
				txtFilename.Name = "txtFilename";
			}
			catch(Exception e)
			{
				RTCore.Environment.ReportError(e, AccessManager.AccessKey);
			}
		}

		private void SetControl()
		{
			try
			{
				if (step == 0)
				{
					lbMessage.HaloTextStr = TextManager.Get().Text("cnerror");

					txtInput.MaxLength = 30;
					txtInput.TextAlign = HorizontalAlignment.Center;
					txtInput.Text = CompanyName;

					lbFilename.Visible = true;
					lbFilename.Location = new Point(txtInput.Location.X, txtInput.Location.Y + txtInput.Height + 10);
					txtFilename.Visible = true;
					txtFilename.Text = SaveName;

					lstRegion.Visible = false;
					picMap.Visible = false;
				}
				else if (step == 1)
				{
					txtInput.Visible = true;
					lbMessage.HaloTextStr = TextManager.Get().Text("pnerror");

					txtInput.Text = PresidentName;

					lstRegion.Visible = false;
					picMap.Visible = false;
					lbFilename.Visible = false;
					txtFilename.Visible = false;
					lbMapDeveloper.Visible = false;
				}
				else if (step == 2)
				{
					txtInput.Visible = false;
					lbMessage.HaloTextStr = TextManager.Get().Text("rgerror");

					picLogo.Visible = false;
					nudAI.Visible = false;
					cbDefaultLogo.Visible = false;
					tbLogoPath.Visible = false;
					lbBrowse.Visible = false;
					lbGoodsize.Visible = false;
					lbAI.Visible = false;
					lbLogo.Visible = false;

					lbMapDeveloper.Visible = true;
					lstRegion.Visible = true;
					picMap.Visible = true;
					Controls.Add(lstRegion);
				}
				else if (step == 3)
				{
					txtInput.Visible = false;
					lbMessage.HaloTextStr = TextManager.Get().Text("etcdata");

					lstRegion.Visible = false;
					picMap.Visible = false;
					lbMapDeveloper.Visible = false;

					picLogo.Visible = true;
					nudAI.Visible = true;
					cbDefaultLogo.Visible = true;
					tbLogoPath.Visible = true;
					lbBrowse.Visible = true;
					lbGoodsize.Visible = true;
					lbAI.Visible = true;
					lbLogo.Visible = true;
				}
			}
			catch(Exception e)
			{
				RTCore.Environment.ReportError(e, AccessManager.AccessKey);
			}
		}

		private void DefaultCreateGameScene_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				e.Graphics.FillRectangle(new SolidBrush(ResourceManager.Get("main.rectangle")), new Rectangle(50, 100, Width - 100, Height - 150));
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void DefaultCreateGameScene_Resize(object sender, EventArgs e)
		{
			try
			{
				lbBack.Location = new Point(Width - 100 - lbBack.Width - lbNext.Width, Height - 70 - lbBack.Height);
				lbNext.Location = new Point(Width - 80 - lbNext.Width, Height - 70 - lbNext.Height);
				txtFilename.Location = new Point(lbFilename.Location.X + lbFilename.Width + 3, lbFilename.Location.Y);
				txtFilename.Size = new Size(txtInput.Width - lbFilename.Width - 3, txtFilename.Height);
				lbMapDeveloper.Location = new Point(picMap.Location.X, picMap.Location.Y + picMap.Height + 5);
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbBack_Click(object sender, EventArgs e)
		{
			try
			{
				if (step == 0)
				{
					NewGameScene ngs = new NewGameScene();

					SceneManager.SetScene(ngs, AccessManager.AccessKey);

					return;
				}

				step--;

				if (step == 0)
					PresidentName = txtInput.Text;

				SetControl();
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbNext_Click(object sender, EventArgs e)
		{
			try
			{
				step++;

				if (step == 1)
				{
					if (txtInput.Text.Trim() == string.Empty || txtFilename.Text.Trim() == string.Empty)
					{
						step--;
						return;
					}
					bool next = true;
					foreach (var sav in System.IO.Directory.GetFiles(".\\data\\saves"))
					{
						if (System.IO.Path.GetExtension(sav) == ".sav")
						{
							string fn = sav.Replace(".\\data\\saves\\", "");
							fn = fn.Replace(".sav", "");
							if (fn == txtFilename.Text) { next = false; break; }
						}
					}
					if (!next)
					{
						if (MessageBox.Show(TextManager.Get().Text("savewar").Replace(@"\n", "\n"), "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
						{
							CompanyName = txtInput.Text;
							SaveName = txtFilename.Text;
						}
						else
						{
							step--;
							return;
						}
					} else
					{
						CompanyName = txtInput.Text;
						SaveName = txtFilename.Text;
					}
				}
				else if (step == 2)
				{
					PresidentName = txtInput.Text;
					if (PresidentName.Trim() == string.Empty)
					{
						step--;
						return;
					}
				}
				else if (step == 3)
				{
					if (lstRegion.SelectedItems.Count == 0)
					{
						step--;
						return;
					}
				}
				else if (step == 4)
				{
					if (!cbDefaultLogo.Checked && (tbLogoPath.Text.Trim() == string.Empty || !System.IO.File.Exists(tbLogoPath.Text))) { step--; return; } //cbDefaultLogo 가 체크 안되어 있음 +  tbText.Text 가 비어있거나 존재하지 않는 파일

					GameInitParams parms = new GameInitParams();

					parms.CompanyName = CompanyName;
					parms.PresidentName = PresidentName;
					parms.Sandbox = _isSandBox;
					if (!_isSandBox)
					{
						parms.Money = 60000000; // 6천만
						int num = new Random().Next(0, 100);
						if(num == 39)
						{
							if(MessageBox.Show("스티브(RouteTycoon 프로그래머)는 천재일까요?\nSteve(RouteTycoon Programmer) is smart?", "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							{
								MessageBox.Show("고마워요 :) 맵이 열리면 돈을 확인해 보세요.\nThanks :) Game started, Check your money.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
								parms.Money = 100000000; // 1억
							}else
							{
								MessageBox.Show(":( 난 당신의 돈을 가져갈거에요!\n:( I'll steal your money!", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								parms.Money = 30000000; // 3천만
							}
						}else if(num == 75)
						{
							if (MessageBox.Show("이프리트(RouteTycoon 디자이너)는 천재일까요?\nSteve(RouteTycoon Designer) is smart?", "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							{
								MessageBox.Show("고마워요 :) 맵이 열리면 돈을 확인해 보세요.\nThanks :) Game started, Check your money.", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
								parms.Money = 100000000; // 1억
							}
							else
							{
								MessageBox.Show(":( 난 당신의 돈을 가져갈거에요!\n:( I'll steal your money!", "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								parms.Money = 30000000; // 3천만
							}
						}
					}
					else
						parms.Money = 1000000000000; // 1조
					parms.NulAI = (int)nudAI.Value;
					parms.useDefaultLogo = cbDefaultLogo.Checked;
					parms.MapName = lstRegion.SelectedItem.ToString();
					parms.Filename = SaveName;
					parms.CreateTime = DateTime.Now;
					if (!cbDefaultLogo.Checked)
						System.IO.File.Copy(tbLogoPath.Text, ".\\data\\saves\\" + CompanyName + ".png", true);

					GameManager.NewGame(parms);

					MainPlayScene mps = new MainPlayScene();

					SceneManager.SetScene(mps, AccessManager.AccessKey);
				}

				SetControl();
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void _Load()
		{
			try
			{
				BackgroundImage = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "main_background.png", 5, 7, 1, 6));

				lbTitle.Text = TextManager.Get().Text("newgame");
				lbTitle.Font = new Font(RTCore.Environment.Font, 40);
				lbTitle.ForeColor = ResourceManager.Get("creategame.default.title");

				lbBack.Text = TextManager.Get().Text("back");
				lbBack.Font = new Font(RTCore.Environment.Font, 30);
				lbBack.ForeColor = ResourceManager.Get("creategame.default.back.unsel");
				lbBack.SelColor = ResourceManager.Get("creategame.default.back.sel");

				lbNext.Text = TextManager.Get().Text("next");
				lbNext.Font = new Font(RTCore.Environment.Font, 30);
				lbNext.ForeColor = ResourceManager.Get("creategame.default.next.unsel");
				lbNext.SelColor = ResourceManager.Get("creategame.default.next.sel");

				lbMessage.Font = new Font(RTCore.Environment.Font, 20);
				lbMessage.ForeColor = ResourceManager.Get("creategame.default.message");

				txtInput.Font = new Font(RTCore.Environment.Font, 20);
				txtInput.Location = new Point((Width / 2) - 200, (Height / 2) + 40);
				txtInput.Size = new Size(500, txtInput.Height);
				txtInput.TextChanged += TxtInput_TextChanged;

				txtFilename.Font = new Font(RTCore.Environment.Font, 12);
				txtFilename.Location = new Point(lbFilename.Location.X + lbFilename.Width + 3,lbFilename.Location.Y);
				txtFilename.Size = new Size(txtInput.Width - lbFilename.Width - 3, txtFilename.Height);
				txtFilename.MaxLength = 50;
				Controls.Add(txtFilename);
				txtFilename.Visible = true;

				lstRegion.Font = new Font(RTCore.Environment.Font, 20);
				lstRegion.Location = new Point(150, 243 + lbMessage.Height);
				lstRegion.Size = new Size(300, Height - 300 - lbNext.Height);
				lstRegion.SelectedIndexChanged += LstRegion_SelectedIndexChanged;

				picMap.Size = new Size(262, 182);
				picMap.Location = new Point(lstRegion.Width + lstRegion.Location.X + 10, lstRegion.Location.Y);
				picMap.SizeMode = PictureBoxSizeMode.StretchImage;

				lbMapDeveloper.Font = new Font(RTCore.Environment.Font, 12);
				lbMapDeveloper.Location = new Point(picMap.Location.X, picMap.Location.Y + picMap.Height + 5);
				lbMapDeveloper.Visible = false;
				lbMapDeveloper.ForeColor = ResourceManager.Get("creategame.default.mapdev");
				lbMapDeveloper.BackColor = Color.Transparent;
				lbMapDeveloper.AutoSize = true;
				Controls.Add(lbMapDeveloper);

				picLogo.Image = imgDefault;
				picLogo.BackColor = Color.FromArgb(100, Color.Black);

				lbAI.Text = TextManager.Get().Text("aicount");
				lbAI.Font = new Font(RTCore.Environment.Font, 14);
				lbAI.ForeColor = ResourceManager.Get("creategame.default.ai");

				lbGoodsize.Font = new Font(RTCore.Environment.Font, 12);
				lbGoodsize.Text = TextManager.Get().Text("goodsize") + " : 400x400";
				lbGoodsize.ForeColor = ResourceManager.Get("creategame.default.goodsize");

				cbDefaultLogo.Font = new Font(RTCore.Environment.Font, 12);
				cbDefaultLogo.Text = TextManager.Get().Text("usedefault");
				cbDefaultLogo.ForeColor = ResourceManager.Get("creategame.default.defaultlogo");

				lbBrowse.Font = new Font(RTCore.Environment.Font, 12);
				lbBrowse.Text = TextManager.Get().Text("browse");
				lbBrowse.ForeColor = ResourceManager.Get("creategame.default.browse.unsel");
				lbBrowse.SelColor = ResourceManager.Get("creategame.default.browse.sel");

				nudAI.Font = new Font(RTCore.Environment.Font, 9);

				lbLogo.Text = TextManager.Get().Text("logo");
				lbLogo.Font = new Font(RTCore.Environment.Font, 14);
				lbLogo.ForeColor = ResourceManager.Get("creategame.default.logo");

				tbLogoPath.Font = new Font(RTCore.Environment.Font, 10);

				lbFilename.Font = new Font(RTCore.Environment.Font, 14);
				lbFilename.Text = TextManager.Get().Text("savename");
				lbFilename.AutoSize = true;
				lbFilename.BackColor = Color.Transparent;
				lbFilename.ForeColor = ResourceManager.Get("creategame.default.overwrite");
				Controls.Add(lbFilename);

				foreach (string str in System.IO.Directory.GetFiles(".\\data\\maps"))
				{
					if (System.IO.Path.GetExtension(str) == ".dat")
					{
						Map map = new Map();

						map.Load(str);

						lstRegion.Items.Add(map.Name);
					}
				}

				Controls.Add(txtInput);

				SetControl();
			}
			catch (Exception e)
			{
				RTCore.Environment.ReportError(e, AccessManager.AccessKey);
			}
		}

		private void TxtInput_TextChanged(object sender, EventArgs e)
		{
			if (step == 0)
			{
				string txt = txtInput.Text;
				List<string> files = new List<string>();

				foreach (var sav in System.IO.Directory.GetFiles(".\\data\\saves"))
				{
					if (System.IO.Path.GetExtension(sav) == ".sav")
					{
						string fn = sav.Replace(".\\data\\saves\\", "");
						fn = fn.Replace(".sav", "");
						files.Add(fn);
					}
				}
				
				while(true)
				{
					if (files.Contains(txt))
					{
						txt += "_";
					}
					else
						break;
				}

				txtFilename.Text = txt;
			}
		}

		private void LstRegion_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (lstRegion.SelectedItems.Count == 1)
				{
					Map m = new Map();
					m.Load(".\\data\\maps\\" + lstRegion.SelectedItem.ToString() + ".dat");

					picMap.Image = m.BackImg;

					picMap.Visible = true;
					Controls.Add(picMap);

					Dictionary<string, string> d = new Dictionary<string, string>();
					d.Add("%DEV%", m.Developer);

					lbMapDeveloper.Text = TextManager.Get().Text("mapdeveloper", true, d);
				}
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbBrowse_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog ofd = new OpenFileDialog();
				ofd.Filter = "png 파일|*.png";
				ofd.Title = "로고 찾기";

				if (ofd.ShowDialog() == DialogResult.OK)
				{
					tbLogoPath.Text = ofd.FileName;
					picLogo.Image = Image.FromFile(ofd.FileName);
					cbDefaultLogo.Checked = false;
				}
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void cbDefaultLogo_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (cbDefaultLogo.Checked)
				{
					picLogo.Image = imgDefault;
					tbLogoPath.Text = string.Empty;
				}
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public override void OnClosed()
		{
			imgDefault.Dispose();
			txtInput.Dispose();
			lstRegion.Dispose();
			picMap.Dispose();
			txtFilename.Dispose();
		}
	}
}
