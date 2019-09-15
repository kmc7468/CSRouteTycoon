using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RTTrainTool
{
	partial class frmEngineCoach : Form
	{
		public bool loc_edit = false;
		public double loc_speed = 0.0;
		public int loc_rank = -1;
		public long loc_carrying = 0;

		public bool car_edit = false;
		public int car_rank = -1;
		public long car_carrying = 0;

		public frmEngineCoach()
		{
			InitializeComponent();
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			txtURL.Text = string.Empty;
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "기관차 이미지";
			ofd.Filter = "이미지 파일|*.png;*.jpg;*.jpge;*.gif;*.bmp|모든 파일|*.*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				txtURL.Text = ofd.FileName;
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (!loc_edit)
			{
				MessageBox.Show("기관차 정보를 설정해 주세요.", "RTTrainTool", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}
			else if (!car_edit)
			{
				MessageBox.Show("객차 정보를 설정해 주세요.", "RTTrainTool", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}
			else
			{
				if (txtName.Text.Trim() == string.Empty)
				{
					MessageBox.Show("이름을 입력해 주세요.", "RTTrainTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				FolderBrowserDialog fbd = new FolderBrowserDialog();
				fbd.RootFolder = Environment.SpecialFolder.DesktopDirectory;
				fbd.ShowNewFolderButton = true;
				if (fbd.ShowDialog() == DialogResult.OK)
				{
					string path = fbd.SelectedPath + $@"\\{txtName.Text.Trim()}";
					System.IO.Directory.CreateDirectory(path);

					XmlDocument xml = new XmlDocument();

					XmlNode root = xml.CreateElement("enginecoach");

					XmlNode name = xml.CreateElement("name");
					name.InnerText = txtName.Text.Trim();
					root.AppendChild(name);

					XmlNode main = xml.CreateElement("maintenance");
					main.InnerText = nuMaintenance.Value.ToString();
					root.AppendChild(main);

					XmlNode price = xml.CreateElement("price");
					price.InnerText = nuPrice.Value.ToString();
					root.AppendChild(price);

					XmlNode img = xml.CreateElement("image");
					img.InnerText = "img.png";
					root.AppendChild(img);

					XmlNode loc = xml.CreateElement("locomotive");

					{
						XmlNode speed = xml.CreateElement("speed");
						speed.InnerText = loc_speed.ToString();
						loc.AppendChild(speed);

						XmlNode rank = xml.CreateElement("rank");
						switch (loc_rank)
						{
							case 0:
								rank.InnerText = "high";
								break;

							case 1:
								rank.InnerText = "default";
								break;

							default:
								break;
						}
						loc.AppendChild(rank);

						XmlNode carry = xml.CreateElement("carrying");
						carry.InnerText = loc_carrying.ToString();
						loc.AppendChild(carry);
					}

					root.AppendChild(loc);

					XmlNode car = xml.CreateElement("coach");

					{
						XmlNode rank = xml.CreateElement("rank");
						if (car_rank == 0)
						{
							rank.InnerText = "first";
						}
						else if (car_rank == 1)
						{
							rank.InnerText = "economy";
						}
						else if (car_rank == 2)
						{
							rank.InnerText = "freight";
						}
						car.AppendChild(rank);

						XmlNode carry = xml.CreateElement("carrying");
						carry.InnerText = car_carrying.ToString();
						car.AppendChild(carry);
					}

					root.AppendChild(car);

					xml.AppendChild(root);

					xml.Save(path + @"\data.xml");

					if (txtURL.Text.Trim() == string.Empty)
					{
						Properties.Resources.img_no.Save(path + @"\img.png");
					}
					else
					{
						Image i = Image.FromFile(txtURL.Text);
						i.Save(path + @"\img.png", System.Drawing.Imaging.ImageFormat.Png);
					}

					MessageBox.Show("작업이 완료 되었습니다.", "RTTrainTool", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void btnLocomotiveSetting_Click(object sender, EventArgs e)
		{
			new frmLocomotive(true, this).ShowDialog();
		}

		private void btnCarriage_Click(object sender, EventArgs e)
		{
			new frmCoach(true, this).ShowDialog();
		}
	}
}
