using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RTMapTool
{
	partial class frmTool : Form
	{
		private frmMain _frmMain;
		private Map _map = new Map();

		private bool isSaved = false;

		public frmTool(frmMain frm)
		{
			InitializeComponent();

			_frmMain = frm;
		}

		private void Clear()
		{
			txtImage.Text = string.Empty;
			_frmMain.MapImage = null;
			_map.Regions.Clear();
			lstRegion.Items.Clear();

			_map.Clear();
			isSaved = false;
		}

		private void btnAddRegion_Click(object sender, EventArgs e)
		{
			string region_name = Microsoft.VisualBasic.Interaction.InputBox("지역 이름을 입력해 주세요.");

			if (region_name.Trim() == string.Empty)
			{
				MessageBox.Show("지역 이름은 공백일 수 없습니다.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (_map.Regions.Keys.FirstOrDefault(x => x.Name == region_name) != null)
			{
				MessageBox.Show("이미 존재하는 지역입니다.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			PictureBox pb = new PictureBox();
			pb.Image = Image.FromFile(".\\ico_region.png");
			pb.Size = new Size(32, 32);
			pb.Location = new Point(_frmMain.ClientSize.Width / 2, _frmMain.ClientSize.Height / 2);
			pb.SizeMode = PictureBoxSizeMode.StretchImage;
			pb.BackColor = Color.Transparent;
			_frmMain.toolTip.SetToolTip(pb, region_name);
			pb.Draggable(true);

			_frmMain.Controls.Add(pb);

			Region reg = new Region();
			reg.Name = region_name;

			_map.Regions.Add(reg, pb);
			lstRegion.Items.Add(region_name);

			isSaved = false;
		}

		private void btnSelectImage_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "이미지|*.bmp;*.jpg;*.jpge;*.png;*.gif|모든 파일|*.*";

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				try
				{
					Image img = Image.FromFile(dlg.FileName);

					_frmMain.MapImage = img;

					txtImage.Text = dlg.FileName;

					isSaved = false;
				}
				catch (Exception ex)
				{
					MessageBox.Show("이미지 파일을 불러올 수 없습니다.\n" + ex.Message, "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			foreach (var pr in _map.Regions)
			{
				_frmMain.Controls.Remove(pr.Value);
			}

			Clear();
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			OpenFileDialog od = new OpenFileDialog();
			od.Filter = "RouteTycoon 맵|*.dat;*.xml|모든 파일|*.*";

			if (od.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if (Path.GetExtension(od.FileName) == ".xml")
						LoadXmlData(od.FileName);
					else if (Path.GetExtension(od.FileName) == ".dat")
					{
						Clear();

						_map.Load(od.FileName);

						txtImage.Text = _map.BackImage;
						_frmMain.BackgroundImage = Image.FromFile(txtImage.Text);

						foreach (var pr in _map.Regions)
						{
							_frmMain.Controls.Add(pr.Value);
							_frmMain.toolTip.SetToolTip(pr.Value, pr.Key.Name);

							lstRegion.Items.Add(pr.Key.Name);
						}

						isSaved = false;
					}
					else
					{
						MessageBox.Show("올바른 맵 파일이 아닙니다.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				catch (Exception ex)
				{
					Clear();
					MessageBox.Show("읽던 도중 오류가 발생 하였습니다.\n" + ex.Message, "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void LoadXmlData(string filename)
		{
			string path = Path.GetDirectoryName(filename) + "\\";

			XmlDocument xml = new XmlDocument();
			xml.Load(filename);

			XmlNode root = xml.SelectNodes("/map")[0];
			path += root.Attributes.GetNamedItem("name").InnerText + "\\";

			XmlNode image = xml.SelectNodes("/map/firstregion/image")[0];
			_frmMain.MapImage = Image.FromFile(path + image.InnerText);

			txtImage.Text = path + image.InnerText;

			lstRegion.Items.Clear();

			foreach (XmlNode pr in xml.SelectNodes("/map/firstregion/region"))
			{
				string name = pr.Attributes.GetNamedItem("text").InnerText;
				Point loc = new Point(Convert.ToInt32(pr.SelectNodes("loc")[0].InnerText.Split(',')[0]), Convert.ToInt32(pr.SelectNodes("loc")[0].InnerText.Split(',')[1]));

				PictureBox pb = new PictureBox();
				pb.Image = Image.FromFile(".\\ico_region.png");
				pb.Size = new Size(32, 32);
				pb.Location = loc;
				pb.SizeMode = PictureBoxSizeMode.StretchImage;
				pb.BackColor = Color.Transparent;
				_frmMain.toolTip.SetToolTip(pb, name);
				pb.Draggable(true);

				_frmMain.Controls.Add(pb);

				Region reg = new Region();
				reg.Name = name;

				_map.Regions.Add(reg, pb);
				lstRegion.Items.Add(name);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			string str = string.Empty;

			while (str == string.Empty)
			{
				str = Microsoft.VisualBasic.Interaction.InputBox("에드온의 이름을 입력해주세요.", "RTMapTool");
			}

			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.ShowNewFolderButton = true;

			if (fbd.ShowDialog() == DialogResult.OK)
			{
				while (_map.Developer == string.Empty)
				{
					_map.Developer = Microsoft.VisualBasic.Interaction.InputBox("개발자의 이름을 입력해주세요.", "RTMapTool");
				}

				while (!isSaved && _map.Password == string.Empty)
				{
					_map.Password = Microsoft.VisualBasic.Interaction.InputBox("비밀번호를 입력해주세요.", "RTMapTool");
				}

				_map.BackImage = txtImage.Text;

				_map.Name = str;

				_map.Save(fbd.SelectedPath + "\\" + str + ".dat");

				isSaved = true;
			}
		}

		private void txtImage_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				try
				{
					Image img = Image.FromFile(txtImage.Text);

					_frmMain.MapImage = img;

					isSaved = false;
				}
				catch (Exception exp)
				{
					MessageBox.Show("이미지 파일을 불러올 수 없습니다.\n" + exp.Message, "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnDelRegion_Click(object sender, EventArgs e)
		{
			if (lstRegion.SelectedItem == null)
			{
				MessageBox.Show("제거할 지역을 선택해주세요.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			_frmMain.Controls.Remove(_map.Regions.First(x => x.Key.Name == lstRegion.SelectedItem.ToString()).Value);

			_map.Regions.Remove(_map.Regions.First(x => x.Key.Name == lstRegion.SelectedItem.ToString()).Key);
			lstRegion.Items.Remove(lstRegion.SelectedItem);

			isSaved = false;
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (lstRegion.SelectedItem == null)
			{
				MessageBox.Show("이름 변경할 지역을 선택해주세요.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			List<Region> str_temp = new List<Region>();
			List<PictureBox> pic_temp = new List<PictureBox>();

			foreach (var pr in _map.Regions)
			{
				str_temp.Add(pr.Key);
				pic_temp.Add(pr.Value);
			}
			_map.Regions.Clear();

			string str = Interaction.InputBox("새로운 이름을 입력하세요.", "RTMapTool");
			if (str == string.Empty) return;

			str_temp.First(x => x.Name == lstRegion.SelectedIndex.ToString()).Name = str;
			lstRegion.Items[lstRegion.SelectedIndex] = str;

			for (int i = 0; i < str_temp.Count; i++)
			{
				_map.Regions.Add(str_temp[i], pic_temp[i]);
			}

			_frmMain.toolTip.SetToolTip(_map.Regions[str_temp.First(x => x.Name == str)], str);
		}

		private void btnEditCity_Click(object sender, EventArgs e)
		{
			if (lstRegion.SelectedItem == null)
			{
				MessageBox.Show("도시 수정할 지역을 선택해주세요.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			frmCity city = new frmCity(_map.Regions.First(x => x.Key.Name == lstRegion.SelectedItem.ToString()).Key, _map);

			city.ShowDialog();
		}

		private void lstRegion_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstRegion.SelectedItems != null)
			{
				foreach (var it in _map.Regions)
				{
					if (it.Key.Name == lstRegion.SelectedItem.ToString()) it.Value.Image = Image.FromFile(".\\ico_region_sel.png");
					else it.Value.Image = Image.FromFile(".\\ico_region.png");
				}
			}
		}
	}
}
