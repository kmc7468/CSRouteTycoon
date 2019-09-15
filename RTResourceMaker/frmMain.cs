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

namespace RTResourceMaker
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private bool isFirst = true;
        private bool RTExist { get; set; }

        public async void load()
        {
            if (File.Exists(".\\RouteTycoon.exe"))
            {
                RTExist = true;
            }
            else
            {
                RTExist = false;
            }

            BenchManager.Init();
            FontManager.Get().Init();
            TempData.UIData._frmMain_set = this;
            TempData.UIData.Init();

            FontManager.Get().SetFontByString(Properties.Settings.Default.fontName);

            if (isFirst)
            {
                await Task.Delay(2000);
                pictureBox1.Visible = false;

                UI.main _main = new UI.main();
                PageManager.SetPage(myPanel, _main);

                isFirst = false;
            }
            else
            {
                TempData.NewProjectData.loc = null;
                TempData.NewProjectData.resinfo = null;
                TempData.NewProjectData.resmaker = null;
                TempData.NewProjectData.resname = null;
            }
        }

        public Panel _myPanel { get { return myPanel; } }

        private void frmMain_Load(object sender, EventArgs e)
        {
            load();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (UserControl it in myPanel.Controls)
            {
                if (it.GetType().Name == "edit")
                {
                    if (TempData.UIData._edit.isSaving)
                    {
                        e.Cancel = true;
                        MessageBox.Show("프로젝트 저장 중에는 종료할 수 없습니다", "RTResourceMaker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (TempData.UIData._edit.needSave())
                    {
                        DialogResult result = MessageBox.Show("프로젝트를 저장하고 종료하시겠습니까?", "RTResourceMaker", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            TempData.UIData._edit.isExitMode = true;
                            TempData.UIData._edit.Save();

                            e.Cancel = true;
                            this.MaximumSize = new Size(580, 440);
                            this.MaximizeBox = false;
                            this.MinimizeBox = false;
                            this.WindowState = FormWindowState.Normal;
                            UI.main _main = new UI.main();
                            PageManager.SetPage(myPanel, _main);
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            e.Cancel = true;
                            this.MaximumSize = new Size(580, 440);
                            this.MaximizeBox = false;
                            this.MinimizeBox = false;
                            this.WindowState = FormWindowState.Normal;
                            UI.main _main2 = new UI.main();
                            PageManager.SetPage(myPanel, _main2);
                        }
                        return;
                    }

                    e.Cancel = true;
                    this.MaximumSize = new Size(580, 440);
                    this.MaximizeBox = false;
                    this.MinimizeBox = false;
                    this.WindowState = FormWindowState.Normal;
                    UI.main _main3 = new UI.main();
                    PageManager.SetPage(myPanel, _main3);
                }
            }
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            foreach (UserControl it in myPanel.Controls)
            {
                if (it.GetType().Name.Equals("edit"))
                {

                }
            }
        }

        private void logo_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
