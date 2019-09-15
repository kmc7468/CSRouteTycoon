using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class GameLoadScene : Scene
	{
		private ListBox lstSave = new ListBox();
		private Label lbInfo = new Label();
		private Label lbStart = new Label();

		public GameLoadScene()
		{
			try
			{
				InitializeComponent();

				BackgroundImage = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "main_background.png", 5, 7, 1, 6));

				lbTitle.Text = TextManager.Get().Text("gameload");
				lbTitle.Font = new Font(RTCore.Environment.Font, 40);
				lbTitle.ForeColor = ResourceManager.Get("gameload.title");
				lbBack.Text = TextManager.Get().Text("back");
				lbBack.Font = new Font(RTCore.Environment.Font, 30);
				lbBack.ForeColor = ResourceManager.Get("gameload.back.unsel");
				lbBack.SelColor = ResourceManager.Get("gameload.back.sel");

				LoadSaves();

				lstSave.Name = "lstSave";
				lstSave.Font = new Font(RTCore.Environment.Font, 20);
				lstSave.Location = new Point(150, 243);
				lstSave.Size = new Size(300, Height - 300);
				lstSave.SelectedIndexChanged += LstSave_SelectedIndexChanged;
				lstSave.ContextMenuStrip = menuFiles;
				lstSave.DoubleClick += LstSave_DoubleClick;
				Controls.Add(lstSave);
				lstSave.Visible = true;

				lbInfo.Name = "lbInfo";
				lbInfo.AutoSize = true;
				lbInfo.Font = new Font(RTCore.Environment.Font, 18);
				lbInfo.Location = new Point(lstSave.Location.X + lstSave.Width + 10, lstSave.Location.Y);
				lbInfo.Text = "";
				lbInfo.ForeColor = ResourceManager.Get("gameload.info");
				lbInfo.BackColor = Color.Transparent;
				lbInfo.Parent = this;
				Controls.Add(lbInfo);
				lbInfo.Visible = true;

				lbStart.Name = "lbStart";
				lbStart.AutoSize = true;
				lbStart.Font = new Font(RTCore.Environment.Font, 18);
				lbStart.Location = new Point(lstSave.Location.X, lstSave.Location.Y + lstSave.Height + 10);
				lbStart.Text = TextManager.Get().Text("doubleload");
				lbStart.ForeColor = ResourceManager.Get("gameload.start");
				lbStart.BackColor = Color.Transparent;
				Controls.Add(lbStart);
				lbStart.Visible = true;

				itemDelete.Text = TextManager.Get().Text("delete");
				itemAllDelete.Text = TextManager.Get().Text("alldelete");
				itemBuild.Text = TextManager.Get().Text("build");
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public void LoadSaves()
		{
			try
			{
				lstSave.Items.Clear();

				foreach (var sav in System.IO.Directory.GetFiles(".\\data\\saves"))
				{
					if (System.IO.Path.GetExtension(sav) == ".sav")
					{
						string cn = sav.Replace(".\\data\\saves\\", "");
						cn = cn.Replace(".sav", "");
						lstSave.Items.Add($"{cn}");
					}
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void LstSave_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				if (lstSave.SelectedItems.Count == 1)
				{
					if (lbInfo.Text == TextManager.Get().Text("notsavefile") || lbInfo.Text == TextManager.Get().Text("savevernot") || lbInfo.Text == TextManager.Get().Text("oldmap") || lbInfo.Text == TextManager.Get().Text("notmap") || lbInfo.Text == TextManager.Get().Text("nomap") || lbInfo.Text == TextManager.Get().Text("readerr")) return;

					GameManager.Load(lstSave.SelectedItems[0].ToString());

					MainPlayScene mps = new MainPlayScene();

					SceneManager.SetScene(mps, AccessManager.AccessKey);
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void LstSave_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (lstSave.SelectedItems.Count == 1)
				{
					string text = TextManager.Get().Text("saveinfo");
					GameManager.Load(lstSave.SelectedItems[0].ToString(), lbInfo);
					if (lbInfo.Text == TextManager.Get().Text("notsavefile") || lbInfo.Text == TextManager.Get().Text("savevernot") || lbInfo.Text == TextManager.Get().Text("oldmap") || lbInfo.Text == TextManager.Get().Text("notmap") || lbInfo.Text == TextManager.Get().Text("nomap") || lbInfo.Text == TextManager.Get().Text("readerr")) return;
					text = text.Replace("%COMPANY%", GameManager.Company.Name);
					text = text.Replace("%PRESIDENT%", GameManager.Company.PresidentName);
					text = text.Replace("%MONEY%", string.Format("{0:n}", GameManager.Company.Money));
					text = text.Replace("%SANDBOX%", GameManager.Sandbox.ToString());
					text = text.Replace("%MAP%", GameManager.Map.Name);
					text = text.Replace(@"\n", "\n");
					lbInfo.Text = text;
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void GameLoadScene_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				e.Graphics.FillRectangle(new SolidBrush(ResourceManager.Get("main.rectangle")), new Rectangle(50, 100, Width - 100, Height - 150));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void GameLoadScene_Resize(object sender, EventArgs e)
		{
			try
			{
				lbBack.Location = new Point(Width - 100 - lbBack.Width, Height - 70 - lbBack.Height);
				lbInfo.Location = new Point(lstSave.Location.X + lstSave.Width + 10, lstSave.Location.Y);
				lbStart.Location = new Point(lstSave.Location.X, lstSave.Location.Y + lstSave.Height + 10);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbBack_Click(object sender, EventArgs e)
		{
			try
			{
				GameStartScene gss = new GameStartScene();

				SceneManager.SetScene(gss, AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void itemDelete_Click(object sender, EventArgs e)
		{
			try
			{
				if (lstSave.SelectedItems.Count == 1)
				{
					Dictionary<string, string> data = new Dictionary<string, string>();
					data.Add("%NAME%", lstSave.SelectedItem.ToString());
					if (MessageBox.Show(TextManager.Get().Text("realdelete", true, data), "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						System.IO.File.Delete(".\\data\\saves\\" + lstSave.SelectedItem.ToString() + ".sav");
						if (System.IO.File.Exists(".\\data\\saves\\" + lstSave.SelectedItem.ToString() + ".png"))
							System.IO.File.Delete(".\\data\\saves\\" + lstSave.SelectedItem.ToString() + ".png");
						lstSave.Items.Remove(lstSave.SelectedItem);
						lbInfo.Text = "";
					}
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void itemAllDelete_Click(object sender, EventArgs e)
		{
			try
			{
				Dictionary<string, string> data = new Dictionary<string, string>();
				data.Add("%COUNT%", lstSave.Items.Count.ToString());
				if (MessageBox.Show(TextManager.Get().Text("realalldelete", true, data), "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					foreach (string it in lstSave.Items)
					{
						System.IO.File.Delete(".\\data\\saves\\" + it + ".sav");
						if (System.IO.File.Exists(".\\data\\saves\\" + it + ".png"))
							System.IO.File.Delete(".\\data\\saves\\" + it + ".png");
					}

					lstSave.Items.Clear();
					lbInfo.Text = "";
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void itemBuild_Click(object sender, EventArgs e)
		{
			try
			{
				if (lstSave.SelectedItems.Count == 1)
				{
					if (lbInfo.Text == TextManager.Get().Text("notsavefile") || lbInfo.Text == TextManager.Get().Text("savevernot") || lbInfo.Text == TextManager.Get().Text("oldmap") || lbInfo.Text == TextManager.Get().Text("notmap") || lbInfo.Text == TextManager.Get().Text("nomap") || lbInfo.Text == TextManager.Get().Text("readerr"))
					{
						Dictionary<string, string> d = new Dictionary<string, string>();
						d.Add("%MESSAGE%", lbInfo.Text);
						MessageBox.Show(TextManager.Get().Text("cannotbuild", true, d), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					if (MessageBox.Show(TextManager.Get().Text("buildsav"), "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						SaveFileDialog sfd = new SaveFileDialog();
						sfd.Title = TextManager.Get().Text("selectsavepath");
						sfd.Filter = "sav 파일|*.sav";
						if (sfd.ShowDialog() == DialogResult.OK)
						{
							try
							{
								GameManager.Load(lstSave.SelectedItems[0].ToString());
								string dev = "";
								while (true)
								{
									dev = Microsoft.VisualBasic.Interaction.InputBox(TextManager.Get().Text("inputdeveloper"), "RouteTycoon");
									if (dev.Trim() == string.Empty)
									{
										if (MessageBox.Show(TextManager.Get().Text("cannotempty"), "RouteTycoon", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop) == DialogResult.Cancel)
										{
											return;
										}
									}
									else
									{
										dev = dev.Trim();
										break;
									}
								}
								GameManager.SaveInfo = $"Developer: {dev}\nisSandbox: {GameManager.Sandbox.ToString().ToLower()}\nisUseCheat: {GameManager.UseCheat.ToString().ToLower()}\nPlayer Income: {string.Format("{0:n0}", GameManager.Company.Income)}RTW\nCreate Date: {GameManager.CreateTime.Year}-{GameManager.CreateTime.Month}-{GameManager.CreateTime.Day} {GameManager.CreateTime.Hour}:{GameManager.CreateTime.Minute}:{GameManager.CreateTime.Second}";
								GameManager.Sandbox = false;
								GameManager.isBuild = true;
								GameManager.Company.Money = 0;
								GameManager.SaveExtraPath(sfd.FileName.Substring(0, sfd.FileName.Length - 4));
								LoadSaves();
								MessageBox.Show(TextManager.Get().Text("buildcomplete"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
