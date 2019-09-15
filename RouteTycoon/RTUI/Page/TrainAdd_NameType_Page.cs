using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RouteTycoon.RTCore;
using System.Collections.Generic;

namespace RouteTycoon.RTUI
{
	internal partial class TrainAdd_NameType_Page : Page
	{
		private Graphics g;
		private Page OldPage;
		private Train t;

		private TextBox txtName = new TextBox();
		private ComboBox cbType = new ComboBox();
		private PictureBox pbDataAdd = new PictureBox();

		private Image imgAdd, imgAddSel;
		private ToolTip tt = new ToolTip();

		public TrainAdd_NameType_Page(Page old, Train _t = null)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				OldPage = old;
				t = _t;

				Title = TextManager.Get().Text("addtrain");
				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_timetable.png", 5, 7, 1, 6));
				imgAdd = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_add.png", 5, 7, 1, 6));
				imgAddSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_add_sel.png", 5, 7, 1, 6));

				lbBack.ForeColor = ResourceManager.Get("trainadd.back.unsel");
				lbBack.SelColor = ResourceManager.Get("trainadd.back.sel");
				lbBack.Font = new Font(RTCore.Environment.Font, 20);
				lbBack.Text = TextManager.Get().Text("back");
				lbBack.Location = new Point(25, 553);

				lbAdd.ForeColor = ResourceManager.Get("trainadd.add.unsel");
				lbAdd.SelColor = ResourceManager.Get("trainadd.add.sel");
				lbAdd.Font = new Font(RTCore.Environment.Font, 20);
				lbAdd.Text = TextManager.Get().Text("buy");
				lbAdd.Location = new Point(Width - 25 - lbAdd.Width, 553);

				txtName.Text = "txtName";

				cbType.SelectedIndexChanged += delegate
				{
					txtName.Text = TrainManager.SetTrainNameAuto(TrainManager.TrainDatas[cbType.SelectedIndex]);
					GameManager.LastSelectTrainData = cbType.SelectedIndex;
				};
				cbType.Name = "cbType";
				cbType.Font = new Font(RTCore.Environment.Font, 20);
				cbType.Size = new Size(455, cbType.Height);
				ReAddItem();
				cbType.DropDownStyle = ComboBoxStyle.DropDownList;
				cbType.Location = new Point((Width / 2) - 250, (Height / 2) - 75);
				Controls.Add(cbType);

				txtName.Font = new Font(RTCore.Environment.Font, 20);
				txtName.Size = new Size(500, txtName.Height);
				txtName.Location = new Point(cbType.Location.X, cbType.Location.Y + cbType.Height + 80);
				txtName.MaxLength = 40;
				Controls.Add(txtName);

				pbDataAdd.Name = "pbDataAdd";
				pbDataAdd.Location = new Point(cbType.Location.X + cbType.Width + 10, cbType.Location.Y);
				pbDataAdd.Size = new Size(cbType.Height, cbType.Height);
				pbDataAdd.SizeMode = PictureBoxSizeMode.StretchImage;
				pbDataAdd.Image = imgAdd;
				pbDataAdd.MouseEnter += delegate
				{
					pbDataAdd.Image = imgAddSel;
				};
				pbDataAdd.MouseLeave += delegate
				{
					pbDataAdd.Image = imgAdd;
				};
				pbDataAdd.Click += delegate
				{
					PageManager.SetPage(new TrainDataAdd_Name_Page(this), AccessManager.AccessKey);
				};
				Controls.Add(pbDataAdd);

				lbInfo.Font = new Font(RTCore.Environment.Font, 12);
				lbInfo.Location = new Point(txtName.Location.X, txtName.Location.Y + txtName.Height + 7);
				SetTextInfo();
				cbType.SelectedIndexChanged += delegate
				{
					SetTextInfo();
				};

				picDataIcon.Location = new Point(Width - (Width - (txtName.Width + txtName.Location.X)) - 100, txtName.Location.Y + txtName.Height + 5);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void SetTextInfo()
		{
			try
			{
				Dictionary<string, string> data = new Dictionary<string, string>();
				data.Add("%PRICE%", string.Format("{0:n0}", TrainManager.TrainDatas[cbType.SelectedIndex].Price));
				data.Add("%CARRY%", string.Format("{0:n0}", TrainManager.TrainDatas[cbType.SelectedIndex].Carrying));
				data.Add("%USE%", string.Format("{0:n0}", TrainManager.TrainDatas[cbType.SelectedIndex].Maintenance));

				lbInfo.Text = TextManager.Get().Text("trainbuyinfo", true, data);

				tt.SetToolTip(lbInfo, lbInfo.Text);

				picDataIcon.Image = TrainManager.TrainDatas[cbType.SelectedIndex].Image;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		internal void ReAddItem()
		{
			cbType.Items.Clear();

			foreach (var it in TrainManager.TrainDatas)
			{
				string type = "";
				switch (it.Rank)
				{
					case TrainData.TrainRank.HIGH: type = TextManager.Get().Text("hightrain"); break;
					case TrainData.TrainRank.DEFAULT: type = TextManager.Get().Text("defaulttrain"); break;
				}
				cbType.Items.Add(it.Name + $" ({type})");
			}
			if (t != null) { cbType.SelectedIndex = TrainManager.TrainDatas.IndexOf(t.Data); txtName.Text = t.Name; }
			else if (GameManager.LastSelectTrainData != -1) { cbType.SelectedIndex = GameManager.LastSelectTrainData; }
			else { cbType.SelectedIndex = 0; }
		}

		private void lbAdd_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtName.Text.Trim() == string.Empty) return;
				foreach (var it in TrainManager.Trains)
				{
					if (it.Name == txtName.Text.Trim())
					{
						MessageBox.Show(TextManager.Get().Text("truetrain"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						return;
					}
				}

				if (GameManager.Company.Money - TrainManager.TrainDatas[cbType.SelectedIndex].Price <= 0)
				{
					MessageBox.Show(TextManager.Get().Text("nomoney"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return;
				}

				if (t == null) t = new Train(TrainManager.TrainDatas[cbType.SelectedIndex].Name);
				if (t.Data != TrainManager.TrainDatas[cbType.SelectedIndex]) t = new Train(TrainManager.TrainDatas[cbType.SelectedIndex].Name);

				t.Name = txtName.Text.Trim();
				t.Route = null;
				t.NowStation = null;
				int i = new Random().Next(0, 2);
				if (i == 0) { t.RunMode = true; }
				else if (i == 1) { t.RunMode = false; }

				t.Progress = 0.0;
				t.Owner = GameManager.Company;

				TrainManager.Trains.Add(t);

				if (OldPage == null) PageManager.Close(false, AccessManager.AccessKey);
				else
				{
					if (OldPage is RouteControl_TrainList_Page)
						(OldPage as RouteControl_TrainList_Page).ListDraw();
					else if (OldPage is TrainList_OKAdd_Page)
						(OldPage as TrainList_OKAdd_Page).ListDraw();
					else if (OldPage is TrainListPage)
						(OldPage as TrainListPage).ListDraw();

					PageManager.SetPage(OldPage, AccessManager.AccessKey, true);
				}
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
				if (OldPage == null) PageManager.Close(false, AccessManager.AccessKey);
				else
				{
					if (OldPage is RouteControl_TrainList_Page)
						(OldPage as RouteControl_TrainList_Page).ListDraw();
					if (OldPage is TrainList_OKAdd_Page)
						(OldPage as TrainList_OKAdd_Page).ListDraw();
					PageManager.SetPage(OldPage, AccessManager.AccessKey);
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void TrainAdd_Type_Page_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Draw(e);
				g = e.Graphics;

				g.DrawString(TextManager.Get().Text("traintype"), new Font(RTCore.Environment.Font, 40), new SolidBrush(ResourceManager.Get("trainadd.title")), RTCore.Environment.CalcRectangle(new Point(Width / 2, (Height / 2) - 115), RTCore.Environment.CalcStringSize(TextManager.Get().Text("traintype"), new Font(RTCore.Environment.Font, 40))));
				g.DrawString(TextManager.Get().Text("trainname"), new Font(RTCore.Environment.Font, 40), new SolidBrush(ResourceManager.Get("trainadd.title")), RTCore.Environment.CalcRectangle(new Point(Width / 2, (Height / 2) + 15), RTCore.Environment.CalcStringSize(TextManager.Get().Text("trainname"), new Font(RTCore.Environment.Font, 40))));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void picDataIcon_Click(object sender, EventArgs e)
		{
			try
			{
				frmImage logo = new frmImage(picDataIcon.Image);

				logo.ShowDialog();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public override void OnLoad()
		{
			try
			{
				ReAddItem();
				txtName.Text = TrainManager.SetTrainNameAuto(TrainManager.TrainDatas[cbType.SelectedIndex]);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
