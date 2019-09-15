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
	internal partial class TrainWayPage : Page
	{
		private Train t;
		private Page o;

		private ToolTip tt = new ToolTip();
		private ComboBox cbWay = new ComboBox();

		public TrainWayPage(Train _t, Page _oldpage)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				t = _t;
				o = _oldpage;

				Title = TextManager.Get().Text("settrainway");
				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_train.png", 5, 7, 1, 6));

				if (o == null)
					lbBack.Visible = false;

				lbBack.Text = TextManager.Get().Text("back");
				lbBack.ForeColor = ResourceManager.Get("settrainway.back.unsel");
				lbBack.SelColor = ResourceManager.Get("settrainway.back.sel");
				lbBack.Location = new Point(25, 553);
				lbBack.Click += delegate
				{
					PageManager.SetPage(o, AccessManager.AccessKey);
				};

				lbAccept.Text = TextManager.Get().Text("accept");
				lbAccept.ForeColor = ResourceManager.Get("settrainway.accept.unsel");
				lbAccept.SelColor = ResourceManager.Get("settrainway.accept.sel");
				lbAccept.Location = new Point(Width - 25 - lbAccept.Width, 553);
				lbAccept.Click += delegate
				{
					// TODO : Save

					if (o != null)
						PageManager.SetPage(o, AccessManager.AccessKey);
					else
						PageManager.Close();
				};

				lbTitle.Text = t.Name;
				lbTitle.ForeColor = ResourceManager.Get("settrainway.title");
				tt.SetToolTip(lbTitle, lbTitle.Text);

				cbWay.SelectedIndexChanged += delegate
				{

				};
				cbWay.Name = "cbType";
				cbWay.Font = new Font(RTCore.Environment.Font, 20);
				cbWay.Size = new Size(455, cbWay.Height);
				ReAddItem();
				cbWay.DropDownStyle = ComboBoxStyle.DropDownList;
				cbWay.Location = new Point((Width / 2) - 250, (Height / 2) - 75);
				Controls.Add(cbWay);

				foreach (Control it in Controls)
					it.Font = new Font(RTCore.Environment.Font, it.Font.Size, it.Font.Style);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void ReAddItem()
		{
			try
			{
				cbWay.Items.Clear();

				foreach (var it in t.Route.Ways)
				{
					cbWay.Items.Add(it.Key);
				}

				cbWay.SelectedIndex = t.WayIndex;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void TrainWayPage_Paint(object sender, PaintEventArgs e)
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
