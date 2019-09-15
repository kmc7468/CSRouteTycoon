using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace RTDataChanger
{
    internal partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private static bool dataExist { get; set; }
        private static string loc = null;

        public void load()
        {
            if (string.IsNullOrEmpty(loc))
            {
                btnChangeData.Text = "data.zip 파일을 선택해주세요";
                btnChangeData.Enabled = false;
            }
            else
            {
                btnChangeData.Text = "선택한 data.zip 파일로 교체";
                btnChangeData.Enabled = true;
            }

            if (Directory.Exists(".//data"))
            {
                dataExist = true;
            }
            else
            {
                dataExist = false;
            }
        }

        public void showdialog()
        {
            OpenFileDialog od = new OpenFileDialog();

            od.Filter = "RouteTycoon data.zip 파일|*.zip";
            od.Title = "교체할 RouteTycoon data.zip 파일";

            if (od.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(od.FileName)) return;

                loc = od.FileName;
                txtPath.Text = loc;
                load();
            }
        }

        public void changedata()
        {
            try
            {
                if (string.IsNullOrEmpty(loc)) return;

                if (dataExist)
                {
                    string backname;
                    backname = $"RTDATABACKUP{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.bak";

                    ZipFile.CreateFromDirectory(".//data", backname);

                    Directory.Delete(".//data", true);

                    Directory.CreateDirectory(".//data");

                    ZipFile.ExtractToDirectory(loc, ".//data");

                    MessageBox.Show("작업이 모두 완료되었습니다\r\n기존 data 폴더는 '" + backname + "' 으로 백업되었습니다.", "RTDataChanger", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Directory.CreateDirectory(".//data");

                    ZipFile.ExtractToDirectory(loc, ".//data");

                    MessageBox.Show("작업이 모두 완료되었습니다", "RTDataChanger", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("알 수 없는 오류가 발생했습니다\r\n\r\n" + ex.ToString(), "RTDataChanger", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            showdialog();
        }

        private void btnChangeData_Click(object sender, EventArgs e)
        {
            changedata();
        }
    }
}
