using System;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;
using System.Collections.Generic;

namespace RouteTycoon.RTUI
{
	internal partial class TrainDataAdd_Name_Page : Page
	{
		private Graphics g;
		private Page OldPage;

		private TextBox txtName = new TextBox();

		private string name = string.Empty;
		private List<TrainParant> args = null;
		private Image image = null;

		private void lbBack_Click(object sender, EventArgs e)
		{
			try
			{
				if (OldPage is TrainAdd_NameType_Page)
				{
					(OldPage as TrainAdd_NameType_Page).ReAddItem();
					PageManager.SetPage(OldPage, AccessManager.AccessKey);
				}
				else
					PageManager.SetPage(OldPage, AccessManager.AccessKey);
			}catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public TrainDataAdd_Name_Page(Page _p = null, string _name = "", List<TrainParant> _args = null, Image _image = null)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				OldPage = _p;
				name = _name;
				args = _args;
				image = _image;

				Title = TextManager.Get().Text("addtrainarg");
				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_train.png", 5, 7, 1, 6));

				if (OldPage == null) lbBack.Visible = false;

				txtName.Name = "txtName";
				txtName.Text = name;
				txtName.Font = new Font(RTCore.Environment.Font, 20);
				txtName.Size = new Size(500, txtName.Height);
				txtName.MaxLength = 25;
				txtName.TextAlign = HorizontalAlignment.Center;
				txtName.Location = new Point((Width / 2) - 250, (Height / 2) + 10);
				Controls.Add(txtName);

				lbBack.ForeColor = ResourceManager.Get("traindataadd.back.unsel");
				lbBack.SelColor = ResourceManager.Get("traindataadd.back.sel");
				lbBack.Location = new Point(25, 553);
				lbBack.Text = TextManager.Get().Text("back");
				lbBack.Font = new Font(RTCore.Environment.Font, 20);

				lbNext.Font = new Font(RTCore.Environment.Font, 20);
				lbNext.Text = TextManager.Get().Text("next");
				lbNext.ForeColor = ResourceManager.Get("traindataadd.next.unsel");
				lbNext.SelColor = ResourceManager.Get("traindataadd.next.sel");
				lbNext.Location = new Point(Width - 25 - lbNext.Width, 553);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void TrainDataAdd_Name_Page_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Draw(e);

				g = e.Graphics;

				g.DrawString(TextManager.Get().Text("traindataname"), new Font(RTCore.Environment.Font, 40), new SolidBrush(ResourceManager.Get("traindataadd.title")), RTCore.Environment.CalcRectangle(new Point(Width / 2, (Height / 2) - 40), RTCore.Environment.CalcStringSize(TextManager.Get().Text("traindataname"), new Font(RTCore.Environment.Font, 40))));
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
				if (txtName.Text.Trim() == string.Empty) return;

				foreach(var it in TrainManager.TrainDatas)
				{
					if(it.Name == txtName.Text.Trim())
					{
						MessageBox.Show(TextManager.Get().Text("trueargname"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						return;
					}
				}

				name = txtName.Text.Trim();

				PageManager.SetPage(new TrainDataAdd_Args_Page(OldPage, name, args, image), AccessManager.AccessKey);
			}catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
