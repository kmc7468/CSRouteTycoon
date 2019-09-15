using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTResourceMaker.UI.makes
{
    public partial class make : UserControl
    {
        public make()
        {
            InitializeComponent();

            txtInfo.Text = TempData.NewProjectData.resinfo;
            txtMaker.Text = TempData.NewProjectData.resmaker;
            txtName.Text = TempData.NewProjectData.resname;
        }

        public void load()
        {
            foreach (Control it in this.Controls)
            {
                it.Font = new Font(FontManager.Get().EnvironmentFont, it.Font.Size, it.Font.Style);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInfo.Text) || string.IsNullOrEmpty(txtMaker.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtver.Text))
            {
                MessageBox.Show("정보를 모두 입력해주세요", "RTResourceMaker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TempData.NewProjectData.resname = txtName.Text;
            TempData.NewProjectData.resmaker = txtMaker.Text;
            TempData.NewProjectData.resinfo = txtInfo.Text;
            TempData.NewProjectData.resver = txtver.Text;

            makes.make2 _make2 = new makes.make2();
            PageManager.SetPage(TempData.UIData._frmMain._myPanel, _make2);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            TempData.NewProjectData.loc = null;
            TempData.NewProjectData.resinfo = null;
            TempData.NewProjectData.resmaker = null;
            TempData.NewProjectData.resname = null;

            main _main = new main();
            PageManager.SetPage(TempData.UIData._frmMain._myPanel, _main);
        }

        private void make_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
