using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RTResourceMaker.UI.makes
{
    public partial class make2 : UserControl
    {
        public make2()
        {
            InitializeComponent();
        }

        public void load()
        {
            foreach (Control it in this.Controls)
            {
                it.Font = new Font(FontManager.Get().EnvironmentFont, it.Font.Size, it.Font.Style);
            }
        }

        public void create()
        {
            string name = TempData.NewProjectData.resname + "_" + BenchManager.pextension.ToUpper();

            Directory.CreateDirectory(TempData.NewProjectData.loc + "\\" + TempData.NewProjectData.resname);
            Directory.CreateDirectory(TempData.NewProjectData.loc + "\\" + TempData.NewProjectData.resname + "\\" + TempData.NewProjectData.resname);
            Directory.CreateDirectory(TempData.NewProjectData.loc + "\\" + TempData.NewProjectData.resname + "\\" + TempData.NewProjectData.resname + "\\images");
            Directory.CreateDirectory(TempData.NewProjectData.loc + "\\" + TempData.NewProjectData.resname + "\\" + TempData.NewProjectData.resname + "\\sounds");

            string data = TempData.NewProjectData.resver + "\r\n" + TempData.NewProjectData.resmaker + "\r\n" + TempData.NewProjectData.resinfo;
            string data2 = Properties.Resources.data_color_dat;

            File.WriteAllText(TempData.NewProjectData.loc + "\\" + TempData.NewProjectData.resname + "\\" + TempData.NewProjectData.resname + "\\" + "data_res.dat", data, Encoding.Default);
            File.WriteAllText(TempData.NewProjectData.loc + "\\" + TempData.NewProjectData.resname + "\\" + TempData.NewProjectData.resname + "\\" + "data_color.dat", data2, Encoding.Default);

            string rts = "modify=" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + Environment.NewLine + "imageloc=" + Environment.NewLine + "soundloc=";

            File.WriteAllText(TempData.NewProjectData.loc + "\\" + TempData.NewProjectData.resname + "\\" + TempData.NewProjectData.resname + "." + BenchManager.pextension, rts, Encoding.Default);

            MessageBox.Show("성공적으로 새 프로젝트 생성이 완료되었습니다", "RTResourceManager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (MessageBox.Show("지금 생성한 새 프로젝트를 열겠습니까?", "RTResourceManager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                edits.edit _edit = new edits.edit(TempData.NewProjectData.loc + "\\" + TempData.NewProjectData.resname + "\\" + TempData.NewProjectData.resname + ".rts");
                PageManager.SetPage(TempData.UIData._frmMain._myPanel, _edit);
            }
            else
            {
                main _main = new main();
                PageManager.SetPage(TempData.UIData._frmMain._myPanel, _main);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            make _make = new make();
            PageManager.SetPage(TempData.UIData._frmMain._myPanel, _make);
        }

        private void checkboxUseDefaultloc_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLoc.Text))
            {
                MessageBox.Show("정보를 모두 입력해주세요", "RTResourceMaker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                TempData.NewProjectData.loc = txtLoc.Text;

                create();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();

            if (fb.ShowDialog() == DialogResult.OK)
            {
                TempData.NewProjectData.loc = fb.SelectedPath;
                txtLoc.Text = TempData.NewProjectData.loc;
            }
        }

        private void make2_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
