using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RTMapTool
{
	partial class frmCity : Form
	{
		Region _reg;
		Map _map;

		public frmCity(Region reg, Map map)
		{
			InitializeComponent();

			_reg = reg;
			_map = map;

			foreach (var str in reg.Citys)
			{
				ListViewItem lv = new ListViewItem(str.Name);
				lv.SubItems.Add(str.Price.ToString());
				lv.SubItems.Add(str.Population.ToString());

				lstCity.Items.Add(lv);
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				string name = Microsoft.VisualBasic.Interaction.InputBox("도시 이름 입력", "RTMapTool").Trim();

				if (name == string.Empty)
				{
					MessageBox.Show("도시 이름은 null일 수 없습니다.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				try
				{
					if (_reg.Citys.First(x => x.Name == name) != null)
					{
						MessageBox.Show("이미 있는 지역입니다.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
				catch (Exception)
				{

				}

				long price = Convert.ToInt64(Microsoft.VisualBasic.Interaction.InputBox("가격 입력", "RTMapTool"));

				if (price <= 0)
				{
					MessageBox.Show("도시 가격은 0 보다 낮거나, 0 일 수 없습니다.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				long pop = Convert.ToInt64(Microsoft.VisualBasic.Interaction.InputBox("인구 입력", "RTMapTool"));

				if (pop <= 0)
				{
					MessageBox.Show("도시 인구는 0 보다 낮거나, 0 일 수 없습니다,", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				_reg.Citys.Add(new City() { Name = name, Population = pop, Price = price, Description = "", Location = _map.Regions[_reg].Location });

				ListViewItem lvi = new ListViewItem(name);
				lvi.SubItems.Add(price.ToString());
				lvi.SubItems.Add(pop.ToString());

				lstCity.Items.Add(lvi);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnDel_Click(object sender, EventArgs e)
		{
			if (lstCity.SelectedItems == null)
			{
				MessageBox.Show("제거할 도시를 선택하세요.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			foreach (ListViewItem it in lstCity.SelectedItems)
			{
				_reg.Citys.Remove(_reg.Citys.First(x => x.Name == it.SubItems[0].Text));
				lstCity.Items.Remove(it);
			}
		}

		private void btnPop_Click(object sender, EventArgs e)
		{
			try
			{
				if (lstCity.SelectedItems == null)
				{
					MessageBox.Show("수정할 도시를 선택하세요.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				long pop = Convert.ToInt64(Microsoft.VisualBasic.Interaction.InputBox("인구 입력", "RTMapTool").Replace(",", ""));

				if (pop <= 0)
				{
					MessageBox.Show("도시 인구는 0 보다 낮거나, 0 일 수 없습니다.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				foreach (ListViewItem lst in lstCity.SelectedItems)
				{
					_reg.Citys.First(x => x.Name == lst.SubItems[0].Text).Population = pop;
					lst.SubItems[2].Text = pop.ToString();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (lstCity.SelectedItems == null)
			{
				MessageBox.Show("수정할 도시를 선택하세요.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (lstCity.SelectedItems.Count > 1)
			{
				MessageBox.Show("이름 변경은 한개의 도시만 선택 해야 변경할 수 있습니다.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string name = Microsoft.VisualBasic.Interaction.InputBox("도시 이름 입력", "RTMapTool").Trim();

			if (name == string.Empty)
			{
				MessageBox.Show("도시 이름은 null일 수 없습니다.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			_reg.Citys.First(x => x.Name == lstCity.SelectedItems[0].SubItems[0].Text).Name = name;
			lstCity.SelectedItems[0].SubItems[0].Text = name;
		}

		private void btnPrice_Click(object sender, EventArgs e)
		{
			try
			{
				if (lstCity.SelectedItems == null)
				{
					MessageBox.Show("수정할 도시를 선택하세요.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				long price = Convert.ToInt64(Microsoft.VisualBasic.Interaction.InputBox("가격 입력", "RTMapTool").Replace(",", ""));

				if (price <= 0)
				{
					MessageBox.Show("땅값은 0 보다 낮거나, 0 일 수 없습니다.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				foreach (ListViewItem lst in lstCity.SelectedItems)
				{
					_reg.Citys.First(x => x.Name == lst.SubItems[0].Text).Price = price;
					lst.SubItems[1].Text = price.ToString();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnDes_Click(object sender, EventArgs e)
		{
			try
			{
				if (lstCity.SelectedItems == null)
				{
					MessageBox.Show("수정할 도시를 선택하세요.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				string des = Microsoft.VisualBasic.Interaction.InputBox("설명 입력\n(도시를 여러개 선택하면 선택한 도시의 모든 설명이 바뀌며, " + @"\n" + " 입력시 엔터 처리 됩니다.)", "RTMapTool").Trim();

				if (MessageBox.Show("아래 내용을 도시 설명으로 적용할까요?\n'" + des + "'", "RTMapTool", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					foreach (ListViewItem lst in lstCity.SelectedItems)
					{
						_reg.Citys.First(x => x.Name == lst.SubItems[0].Text).Description = des.Replace(@"\n", "\n");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnLocation_Click(object sender, EventArgs e)
		{
			try
			{
				if (lstCity.SelectedItems == null)
				{
					MessageBox.Show("수정할 도시를 선택하세요.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				List<City> cs = new List<City>();

				foreach (ListViewItem lst in lstCity.SelectedItems)
				{
					cs.Add(_reg.Citys.First(x => x.Name == lst.SubItems[0].Text));
				}

				MessageBox.Show("새로 나타나는 창을 그냥 닫으시면 위치가 변경 되지 않고,\n지역 마커를 클릭하면 지역의 위치로 도시 위치가 설정 됩니다.\n확인을 누르면 설정 창을 엽니다.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Information);

				frmCityLocation c = new frmCityLocation(_map, _reg, cs, this);

				c.ShowDialog();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void SetCityLocation(Point point, List<City> citys)
		{
			try
			{
				foreach(var it in citys)
				{
					it.Location = point;
				}
				MessageBox.Show("도시 위치를 성공적으로 설정 했습니다!", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
