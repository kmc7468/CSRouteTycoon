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

namespace RTResourceMaker.UI
{
    public partial class load : UserControl
    {
        public load()
        {
            InitializeComponent();
        }

        private List<string> read = new List<string>();

        public void load_2()
        {
            foreach (Control it in this.Controls)
            {
                it.Font = new Font(FontManager.Get().EnvironmentFont, it.Font.Size, it.Font.Style);
            }

            loadfile();
        }

        public void loadfile()
        {
            if (!File.Exists(BenchManager.EnvironmentLoc + "\\" + "rts_his.rts")) return;

            read = File.ReadAllLines(BenchManager.EnvironmentLoc + "\\" + "rts_his.rts", Encoding.Default).ToList();

            listboxSln.Items.Clear();

            foreach (string item in read)
            {
                listboxSln.Items.Add(Path.GetFileName(item));
            }
        }

        public void save()
        {
            using (StreamWriter sw = new StreamWriter(BenchManager.EnvironmentLoc + "\\" + "rts_his.rts", false, Encoding.Default))
            {
                for (int i = 0; i < read.Count; i++)
                {
                    if (string.IsNullOrEmpty(read[i])) continue;
                    sw.WriteLine(read[i]);
                }
            }
        }

        public void add()
        {
            OpenFileDialog of = new OpenFileDialog();

            of.Filter = "RTResourceMaker|*.rts";
            of.Title = "RTResourceMaker 프로젝트 파일을 선택해 주세요";
            of.InitialDirectory = BenchManager.EnvironmentLoc + BenchManager.projects;

            if (of.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < read.Count; i++)
                {
                    if (read[i].Equals(of.FileName))
                    {
                        MessageBox.Show("이미 존재 하는 프로젝트 입니다", "RTResourceMaker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                read.Add(of.FileName);

                save();
                loadfile();
            }
            else
            {
                return;
            }
        }

        public void remove()
        {
            for (int i = 0; i < read.Count; i++)
            {
                if (Path.GetFileName(read[i]).Equals(listboxSln.GetItemText(listboxSln.SelectedItem)))
                {
                    read[i] = null;
                }
            }

            save();
            loadfile();
        }

        public void loadsln()
        {
            for (int i = 0; i < read.Count; i++)
            {
                if (Path.GetFileName(read[i]).Equals(listboxSln.GetItemText(listboxSln.SelectedItem)))
                {
                    edits.edit _edit = new edits.edit(read[i]);
                    TempData.UIData._frmMain.MaximumSize = new Size(0, 0);
                    TempData.UIData._frmMain.MaximizeBox = true;
                    TempData.UIData._frmMain.MinimizeBox = true;
                    PageManager.SetPage(TempData.UIData._frmMain._myPanel, _edit);
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            add();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listboxSln.SelectedItems.Count <= 0) return;
            remove();
        }

        private void load_Load(object sender, EventArgs e)
        {
            load_2();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            main _main = new main();
            PageManager.SetPage(TempData.UIData._frmMain._myPanel, _main);
        }

        private void listboxSln_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listboxSln_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listboxSln.SelectedItems.Count <= 0) return;

            loadsln();
        }
    }
}
