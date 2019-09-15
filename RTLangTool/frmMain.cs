using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTLangTool
{
	partial class frmMain : Form
	{
		private List<string> Values = new List<string>();

		private bool isEdited = false;
		private string filename = string.Empty;

		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			새로운파일NToolStripMenuItem_Click(sender, e);
		}

		private void 끝내기QToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (isEdited)
			{
				if (MessageBox.Show("편집중이던 데이터가 날아갑니다.\n계속하시겠습니까?", "RTLangTool", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
					return;
			}

			Application.Exit();
		}

		private void 불러오기LToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (isEdited)
			{
				if (MessageBox.Show("편집중이던 데이터가 날아갑니다.\n계속하시겠습니까?", "RTLangTool", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
					return;
			}

			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Unpack Language File (*.xml)|*.xml|All Files (*.*)|*.*";

			if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				lstLang.Items.Clear();
				Values.Clear();

				TextManager.Get().Set(dlg.FileName);

				foreach (var pr in TextManager.Get().Texts)
				{
					lstLang.Items.Add(pr.Key);

					Values.Add(pr.Value);
				}

				filename = dlg.FileName;
				isEdited = false;

				txtKey.Text = string.Empty;
				txtValue.Text = string.Empty;

				txtName.Text = TextManager.Get().Name;
				txtRegion.Text = TextManager.Get().Region;
				txtCode.Text = TextManager.Get().Code;
			}
		}

		private void lstLang_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstLang.SelectedIndices.Count == 0)
				return;

			txtKey.Text = lstLang.SelectedItem.ToString();
			txtValue.Text = Values[lstLang.SelectedIndex];
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			Values[lstLang.SelectedIndex] = txtValue.Text;

			lstLang.Items[lstLang.SelectedIndex] = txtKey.Text;

			isEdited = true;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (txtKey.Text == string.Empty)
			{
				MessageBox.Show("Key는 빈칸일 수 없습니다.", "RTLangTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (lstLang.Items.IndexOf(txtKey.Text) != -1)
			{
				MessageBox.Show("이미 존재하는 Key입니다", "RTLangTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			lstLang.Items.Add(txtKey.Text);
			Values.Add(txtValue.Text);

			lstLang.SelectedItem = txtKey.Text;

			isEdited = true;
		}

		private void btnDel_Click(object sender, EventArgs e)
		{
			if (lstLang.SelectedItems.Count == 0)
			{
				MessageBox.Show("제거할 Key를 선택해주세요.", "RTLangTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Values.RemoveAt(lstLang.SelectedIndex);
			lstLang.Items.RemoveAt(lstLang.SelectedIndex);

			isEdited = true;
		}

		private void 새로운파일NToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (isEdited)
			{
				if (MessageBox.Show("편집중이던 데이터가 날아갑니다.\n계속하시겠습니까?", "RTLangTool", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
					return;
			}

			lstLang.Items.Clear();
			Values.Clear();

			TextManager.Get().SetByString(Properties.Resources.korean);

			foreach (var pr in TextManager.Get().Texts)
			{
				lstLang.Items.Add(pr.Key);

				Values.Add(pr.Value);
			}

			txtKey.Text = string.Empty;
			txtValue.Text = string.Empty;

			isEdited = false;
			filename = string.Empty;

			txtName.Text = TextManager.Get().Name;
			txtRegion.Text = TextManager.Get().Region;
			txtCode.Text = TextManager.Get().Code;
		}

		private void 저장SToolStripMenuItem_Click(object sender, EventArgs e)
		{
			List<string> keys = new List<string>();
			foreach (var pr in lstLang.Items) keys.Add(pr.ToString());

			TextManager.Get().ChangeTextsByList(keys, Values);

			if (filename == string.Empty)
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.Filter = "Unpack Language File (*.xml)|*.xml|All Files (*.*)|*.*";

				if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					filename = dlg.FileName;
				else
					return;
			}

			TextManager.Get().Save(filename,txtName.Text, txtRegion.Text, txtCode.Text);
			isEdited = false;
		}

		private void 다른이름으로저장ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			List<string> keys = new List<string>();
			foreach (var pr in lstLang.Items) keys.Add(pr.ToString());

			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Unpack Language File (*.xml)|*.xml|All Files (*.*)|*.*";

			if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				filename = dlg.FileName;
			else
				return;

			TextManager.Get().Save(filename, txtName.Text, txtRegion.Text, txtCode.Text);
		}
	}
}
