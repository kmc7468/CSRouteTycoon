using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace RTResourceMaker.UI.edits
{
    public partial class edit : UserControl
    {
        public edit(string path)
        {
            InitializeComponent();

            this.path = path;
        }

        private const int loadhex = 5;
        public bool isExitMode { get; set; }

        private string path;
        private string _path;
        private string folder;

        private List<string> read = new List<string>();
        private List<string> read2 = new List<string>();
        private List<string> rts_read = new List<string>();

        private List<string> dat = new List<string>();
        private List<string> vals = new List<string>();

        private Dictionary<string, string> _dat = new Dictionary<string, string>();
        private Dictionary<string, string> _vals = new Dictionary<string, string>();

        private List<string> __read2 = new List<string>();

        private string resname;
        private string resmaker;
        private string resinfo;
        private string resver;

        public bool isSaving;

        private string imageloc;
        private string soundloc;

        public async void load()
        {
            this.Enabled = false;

            await Task.Delay(500);
            frmDialog fm = new frmDialog();
            loading _loading = new loading();

            PageManager.SetPage(fm._myPanel, _loading);
            _loading.StartAnimation();
            fm.Show();

            await Task.Delay(100);

            var hex = _loading;

            read.Clear();
            read2.Clear();
            dat.Clear();
            vals.Clear();
            _dat.Clear();
            _vals.Clear();

            //hex.myInfo = "컨트롤을 초기화 하는 중입니다...";
            //await Task.Delay(loadhex);
            foreach (Control it in Controls)
            {
                //hex.myInfo = "' " + it.Name + " ' 컨트롤을 초기화 하는 중입니다...";
                //await Task.Delay(loadhex);
                it.Font = new Font(FontManager.Get().EnvironmentFont, it.Font.Size, it.Font.Style);
                if (it is TabControl)
                {
                    TabControl t = it as TabControl;

                    foreach (TabPage p in t.TabPages)
                    {
                        foreach (Control c in p.Controls)
                        {
                            if (c is SplitContainer)
                            {
                                SplitContainer sp = c as SplitContainer;

                                foreach (Control its in sp.Panel1.Controls)
                                {
                                    //hex.myInfo = "' " + its.Name + " ' 컨트롤을 초기화 하는 중입니다...";
                                    //await Task.Delay(loadhex);
                                    its.Font = new Font(FontManager.Get().EnvironmentFont, its.Font.Size, its.Font.Style);
                                    if (its is ListView)
                                    {
                                        ListView lv = its as ListView;
                                        lv.MultiSelect = false;
                                    }
                                }

                                foreach (Control its2 in sp.Panel2.Controls)
                                {
                                    //hex.myInfo = "' " + its2.Name + " ' 컨트롤을 초기화 하는 중입니다...";
                                    //await Task.Delay(loadhex);
                                    its2.Font = new Font(FontManager.Get().EnvironmentFont, its2.Font.Size, its2.Font.Style);
                                    if (its2 is ListView)
                                    {
                                        ListView lv = its2 as ListView;
                                        lv.MultiSelect = false;
                                    }
                                }
                            }

                            //hex.myInfo = "' " + c.Name + " ' 컨트롤을 초기화 하는 중입니다...";
                            //await Task.Delay(loadhex);
                            c.Font = new Font(FontManager.Get().EnvironmentFont, c.Font.Size, c.Font.Style);
                        }
                    }
                }
            }

            switch (Properties.Settings.Default.imagesViewType)
            {
                case "LargeIcon": listView1.View = View.LargeIcon; listView2.View = View.LargeIcon; break;
                case "Details": listView1.View = View.Details; listView2.View = View.Details; break;
                case "List": listView1.View = View.List; listView2.View = View.List; break;
                case "SmallIcon": listView1.View = View.SmallIcon; listView2.View = View.SmallIcon; break;
                case "Tile": listView1.View = View.Tile; listView2.View = View.Tile; break;
                default: listView1.View = View.LargeIcon; listView2.View = View.LargeIcon; break;
            }

            switch (Properties.Settings.Default.soundViewType)
            {
                case "LargeIcon": listView3.View = View.LargeIcon; listView4.View = View.LargeIcon; break;
                case "Details": listView3.View = View.Details; listView4.View = View.Details; break;
                case "List": listView3.View = View.List; listView4.View = View.List; break;
                case "SmallIcon": listView3.View = View.SmallIcon; listView4.View = View.SmallIcon; break;
                case "Tile": listView3.View = View.Tile; listView4.View = View.Tile; break;
                default: listView3.View = View.LargeIcon; listView4.View = View.LargeIcon; break;
            }

            hex.myInfo = "프로젝트 정보를 가져오는 중 입니다...";
            await Task.Delay(loadhex);
            _path = Path.GetDirectoryName(path);
            int index = _path.LastIndexOf("\\");
            folder = _path.Substring(index + 1);

            hex.myInfo = "' " + _path + "\\" + folder + "\\data_res.dat" + " ' 데이터를 읽는 중 입니다...";
            await Task.Delay(loadhex);
            read = File.ReadAllLines(_path + "\\" + folder + "\\data_res.dat", Encoding.Default).ToList();
            hex.myInfo = "' " + _path + "\\" + folder + "\\data_color.dat" + " ' 데이터를 읽는 중 입니다...";
            await Task.Delay(loadhex);
            read2 = File.ReadAllLines(_path + "\\" + folder + "\\data_color.dat", Encoding.Default).ToList();

            resname = folder;
            resmaker = read[1];
            resinfo = read[2];
            resver = read[0];

            textBox1.Text = resname;
            textBox2.Text = resmaker;
            textBox3.Text = resinfo;
            textBox10.Text = resver;

            listBox1.Items.Clear();
            listBox2.Items.Clear();

            hex.myInfo = "받아온 정보로 부터 데이터를 저장 중 입니다...";
            await Task.Delay(loadhex);
            foreach (string item in read2)
            {
                if (string.IsNullOrEmpty(item)) continue;
                if (item[0] == '/' && item[1] == '/') continue;

                if (item[0] == '$')
                {
                    string node = Regex.Split(item, ":")[0];
                    string val = Regex.Split(item, ":")[1];

                    //hex.myInfo = "' " + node + " ' 값을 저장하는 중 입니다...";
                    //await Task.Delay(loadhex);
                    vals.Add(node);
                    //hex.myInfo = "' " + val + " ' 값을 저장하는 중 입니다...";
                    //await Task.Delay(loadhex);
                    _vals.Add(node, val);

                    //hex.myInfo = "' " + listBox2.Name + " ' 컨트롤을 초기화 하는 중 입니다...";
                    //await Task.Delay(loadhex);
                    listBox2.Items.Add(node);

                    continue;
                }

                string node2 = Regex.Split(item, "=")[0];
                string val2 = Regex.Split(item, "=")[1];

                //hex.myInfo = "' " + node2 + " ' 값을 저장하는 중 입니다...";
                //await Task.Delay(loadhex);
                dat.Add(node2);
                //hex.myInfo = "' " + val2 + " ' 값을 저장하는 중 입니다...";
                //await Task.Delay(loadhex);
                _dat.Add(node2, val2);

                //hex.myInfo = "' " + listBox1.Name + " ' 컨트롤을 초기화 하는 중 입니다...";
                //await Task.Delay(loadhex);
                listBox1.Items.Add(node2);
            }

            hex.myInfo = "솔루션 파일을 읽는 중 입니다...";
            await Task.Delay(loadhex);
            string line = string.Empty; ;
            if (!File.Exists((_path + "\\" + folder + ".rts"))) createrts();
            using (StreamReader sr2 = new StreamReader(_path + "\\" + folder + ".rts", Encoding.Default))
            {
                while ((line = sr2.ReadLine()) != null)
                {
                    //hex.myInfo = "' " + line + " ' 값을 읽는 중 입니다...";
                    //await Task.Delay(loadhex);
                    rts_read.Add(line);
                    if (Regex.Split(line, "=")[0].Equals("imageloc"))
                    {
                        imageloc = Regex.Split(line, "=")[1];
                    }
                    if (Regex.Split(line, "=")[0].Equals("soundloc"))
                    {
                        soundloc = Regex.Split(line, "=")[1];
                    }
                }
            }

            textBox13.Text = imageloc;
            hex.myInfo = "' " + imageloc + " ' 로 부터 이미지를 읽는 중 입니다...";
            await Task.Delay(loadhex);
            loadimagesfromloc();
            hex.myInfo = "NPK 파일로 부터 이미지를 읽는 중 입니다...";
            await Task.Delay(loadhex);
            loadimagesfromnpk();

            textBox16.Text = soundloc;
            hex.myInfo = "' " + soundloc + " ' 로 부터 사운드를 읽는 중 입니다...";
            await Task.Delay(loadhex);
            imageList3.Images.Clear();
            imageList3.Images.Add(Properties.Resources.music_file);
            loadsoundsfromloc();
            hex.myInfo = "NPK 파일로 부터 사운드를 읽는 중 입니다...";
            await Task.Delay(loadhex);
            loadsoundsfromnpk();

            if (Properties.Settings.Default.useAutoSave)
            {
                autoSave();
                hex.myInfo = "자동 저장 기능을 활성화 합니다...";
                await Task.Delay(loadhex);
            }

            hex.myInfo = "데이터를 저장하는 중 입니다...";
            await Task.Delay(loadhex);
            TempData.UIData._edit_set = this;
            TempData.UIData.Init();

            hex.myInfo = "프로젝트 로딩 작업이 모두 완료 되었습니다.";
            await Task.Delay(200);

            this.Enabled = true;
            fm.Close();
        }

        public void createrts()
        {
            string rts = "modify=" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + System.Environment.NewLine + "imageloc=";
            string loc = BenchManager.EnvironmentLoc + BenchManager.projects + "\\" + folder + "\\" + folder + BenchManager.pextension;

            File.WriteAllText(BenchManager.EnvironmentLoc + BenchManager.projects + "\\" + folder + "\\" + folder + "." + BenchManager.pextension, rts, Encoding.Default);
        }

        public async void autoSave()
        {
            while (true)
            {
                await Task.Delay(600000);
                if (!needSave()) continue;

                isSaving = true;
                label11.Text = "프로젝트를 저장 중입니다...";

                using (StreamWriter sw = new StreamWriter(_path + "\\" + folder + "\\data_color.dat", false, Encoding.Default))
                {
                    sw.WriteLine("//Edit by RRM");
                    foreach (string item in vals)
                    {
                        sw.WriteLine(item + ":" + _vals[item]);
                    }
                    foreach (string item in dat)
                    {
                        sw.WriteLine(item + "=" + _dat[item]);
                    }
                }

                using (StreamWriter sw = new StreamWriter(_path + "\\" + folder + "\\data_res.dat", false, Encoding.Default))
                {
                    sw.WriteLine(resver);
                    sw.WriteLine(resmaker);
                    sw.WriteLine(resname);
                }

                string rts = "modify=" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + "\r\nimageloc=" + imageloc + Environment.NewLine + "soundloc=" + soundloc;

                File.WriteAllText(_path + "\\" + folder + ".rts", rts, Encoding.Default);

                if (folder != textBox1.Text)
                {
                    Directory.Move(_path, BenchManager.EnvironmentLoc + "\\" + BenchManager.projects + "\\" + textBox1.Text);
                    Directory.Move(BenchManager.EnvironmentLoc + "\\" + BenchManager.projects + "\\" + textBox1.Text + "\\" + folder, BenchManager.EnvironmentLoc + "\\" + BenchManager.projects + "\\" + textBox1.Text + "\\" + textBox1.Text);
                    File.Move(BenchManager.EnvironmentLoc + "\\" + BenchManager.projects + "\\" + textBox1.Text + "\\" + folder + ".rts", BenchManager.EnvironmentLoc + "\\" + BenchManager.projects + "\\" + textBox1.Text + "\\" + textBox1.Text + ".rts");
                    _path = BenchManager.EnvironmentLoc + "\\" + BenchManager.projects + "\\" + textBox1.Text + "\\" + textBox1.Text + ".rts";
                }
                load();

                isSaving = false;
                label11.Text = "프로젝트 저장을 완료했습니다";
                await Task.Delay(200);
                label11.Text = string.Empty;
            }
        }

        public async void Save()
        {

            isSaving = true;
            label11.Text = "프로젝트를 저장 중입니다...";

            using (StreamWriter sw = new StreamWriter(_path + "\\" + folder + "\\data_color.dat", false, Encoding.Default))
            {
                sw.WriteLine("//Edit by RRM");
                foreach (string item in vals)
                {
                    sw.WriteLine(item + ":" + _vals[item]);
                }
                foreach (string item in dat)
                {
                    sw.WriteLine(item + "=" + _dat[item]);
                }
            }

            using (StreamWriter sw = new StreamWriter(_path + "\\" + folder + "\\data_res.dat", false, Encoding.Default))
            {
                sw.WriteLine(resver);
                sw.WriteLine(resmaker);
                sw.WriteLine(resname);
            }

            string rts = "modify=" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + "\r\nimageloc=" + imageloc + Environment.NewLine + "soundloc=" + soundloc;

            File.WriteAllText(_path + "\\" + folder + ".rts", rts, Encoding.Default);

            if (folder != textBox1.Text)
            {
                Directory.Move(_path, BenchManager.EnvironmentLoc + "\\" + BenchManager.projects + "\\" + textBox1.Text);
                Directory.Move(BenchManager.EnvironmentLoc + "\\" + BenchManager.projects + "\\" + textBox1.Text + "\\" + folder, BenchManager.EnvironmentLoc + "\\" + BenchManager.projects + "\\" + textBox1.Text + "\\" + textBox1.Text);
                File.Move(BenchManager.EnvironmentLoc + "\\" + BenchManager.projects + "\\" + textBox1.Text + "\\" + folder + ".rts", BenchManager.EnvironmentLoc + "\\" + BenchManager.projects + "\\" + textBox1.Text + "\\" + textBox1.Text + ".rts");
                _path = BenchManager.EnvironmentLoc + "\\" + BenchManager.projects + "\\" + textBox1.Text + "\\" + textBox1.Text + ".rts";
            }

            if (isExitMode) return;
            load();

            isSaving = false;
            label11.Text = "프로젝트 저장을 완료했습니다";
            await Task.Delay(5000);
            label11.Text = string.Empty;
        }

        public static string HexConverter(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public static string RGBConverter(Color c)
        {
            return c.R.ToString();
        }

        public bool needSave()
        {
            __read2.Clear();
            if (!read[0].Equals(resver)) return true;
            if (!read[1].Equals(resmaker)) return true;
            if (!read[2].Equals(resinfo)) return true;
            if (!folder.Equals(resname)) return true;

            foreach (string item in vals)
            {
                __read2.Add(item + ":" + _vals[item]);
            }
            foreach (string item in dat)
            {
                __read2.Add(item + "=" + _dat[item]);
            }

            for (int y = 0; y < read2.Count; y++)
            {
                if (string.IsNullOrEmpty(read2[y])) read2.RemoveAt(y);
            }

            for (int z = 0; z < __read2.Count; z++)
            {
                if (string.IsNullOrEmpty(__read2[z])) __read2.RemoveAt(z);
            }

            for (int y1 = 0; y1 < read2.Count; y1++)
            {
                if (read2[y1][0] == ('/') && read2[y1][1] == ('/')) read2.RemoveAt(y1);
            }

            for (int z1 = 0; z1 < __read2.Count; z1++)
            {
                if (__read2[z1][0] == ('/') && __read2[z1][1] == ('/')) __read2.RemoveAt(z1);
            }

            for (int i = 0; i < __read2.Count(); i++)
            {
                if (string.IsNullOrEmpty(__read2[i]) || string.IsNullOrEmpty(read2[i])) continue;

                if (!__read2[i].Equals(read2[i])) return true;
            }

            foreach (string item2 in rts_read)
            {
                if (Regex.Split(item2, "=")[0].Equals("imageloc"))
                {
                    if (!Regex.Split(item2, "=")[1].Equals(imageloc)) return true;
                }
                if (Regex.Split(item2, "=")[0].Equals("soundloc"))
                {
                    if (!Regex.Split(item2, "=")[1].Equals(soundloc)) return true;
                }
            }

            return false;
        }

        public enum types
        {
            none,
            hex,
            alpha
        };

        private void edit_Load(object sender, EventArgs e)
        {
            load();

            if (Properties.Settings.Default.useAutoSave) autoSave();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말로 삭제하시겠습니까?\r\n삭제 후 복구는 불가능합니다", "RTResourceMaker", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Directory.Delete(path, true);

                main _main = new main();
                PageManager.SetPage(TempData.UIData._frmMain._myPanel, _main);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start(path);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말로 삭제하시겠습니까?\r\n삭제 후 복구는 불가능합니다", "RTResourceMaker", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!File.Exists(BenchManager.EnvironmentLoc + "\\" + "rts_his.rts")) return;

                read = File.ReadAllLines(BenchManager.EnvironmentLoc + "\\" + "rts_his.rts", Encoding.Default).ToList();

                for (int i = 0; i < read.Count; i++)
                {
                    if (read[i].Equals(path))
                    {
                        read[i] = null;
                    }
                }

                using (StreamWriter sw = new StreamWriter(BenchManager.EnvironmentLoc + "\\" + "rts_his.rts", false, Encoding.Default))
                {
                    for (int i = 0; i < read.Count; i++)
                    {
                        if (string.IsNullOrEmpty(read[i])) continue;
                        sw.WriteLine(read[i]);
                    }
                }

                Directory.Delete(Path.GetDirectoryName(path), true);

                main _main = new main();
                PageManager.SetPage(TempData.UIData._frmMain._myPanel, _main);
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Process.Start(Path.GetDirectoryName(path));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count <= 0) return;

            string[] vals = listBox1.GetItemText(listBox1.SelectedItem).Split('.');

            textBox4.Text = listBox1.GetItemText(listBox1.SelectedItem);
            textBox5.Text = vals.Last();
            textBox6.Text = _dat[listBox1.GetItemText(listBox1.SelectedItem)];
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItems.Count <= 0) return;

            string[] vals = listBox2.GetItemText(listBox2.SelectedItem).Split('_');

            textBox9.Text = listBox2.GetItemText(listBox2.SelectedItem);
            textBox8.Text = vals.Last();
            textBox7.Text = _vals[listBox2.GetItemText(listBox2.SelectedItem)];
        }

        private async void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox11.Text))
            {
                foreach (string item in read2)
                {
                    if (string.IsNullOrEmpty(item)) continue;
                    if (item[0] == '/' && item[1] == '/') continue;

                    if (item[0] == '$')
                    {
                        string node = Regex.Split(item, ":")[0];
                        string val = Regex.Split(item, ":")[1];
                        listBox2.Items.Add(node);

                        continue;
                    }
                    string node2 = Regex.Split(item, "=")[0];
                    listBox1.Items.Add(node2);
                }
            }

            listBox1.Items.Clear();
            for (int i = 0; i < dat.Count; i++)
            {
                if (dat[i].Contains(textBox11.Text))
                {
                    listBox1.Items.Add(dat[i]);
                }
            }
        }

        private async void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox12.Text))
            {
                foreach (string item in read2)
                {
                    if (string.IsNullOrEmpty(item)) continue;
                    if (item[0] == '/' && item[1] == '/') continue;

                    if (item[0] == '$')
                    {
                        string node = Regex.Split(item, ":")[0];
                        listBox2.Items.Add(node);
                        continue;
                    }
                    string node2 = Regex.Split(item, "=")[0];
                    listBox1.Items.Add(node2);
                }
            }

            listBox2.Items.Clear();
            for (int i = 0; i < vals.Count; i++)
            {
                if (vals[i].Contains(textBox12.Text))
                {
                    listBox2.Items.Add(vals[i]);
                }
            }
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void 저장하지않고종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TempData.UIData._frmMain.MaximumSize = new Size(580, 440);
            TempData.UIData._frmMain.MaximizeBox = false;
            TempData.UIData._frmMain.MinimizeBox = false;

            main _main = new main();
            PageManager.SetPage(TempData.UIData._frmMain._myPanel, _main);
        }

        private void 저장하고종료하기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
            TempData.UIData._frmMain.MaximumSize = new Size(580, 440);
            TempData.UIData._frmMain.MaximizeBox = false;
            TempData.UIData._frmMain.MinimizeBox = false;

            main _main = new main();
            PageManager.SetPage(TempData.UIData._frmMain._myPanel, _main);
        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listBox2_SelectedIndexChanged(sender, e);
            page2.Text = (listBox2.SelectedIndex + 1) + " / " + listBox2.Items.Count;
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listBox1_SelectedIndexChanged(sender, e);
            page.Text = (listBox1.SelectedIndex + 1) + " / " + listBox1.Items.Count;
        }

        private void splitContainer1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void splitContainer1_Panel2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void splitContainer1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void splitContainer1_Panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void btnMake_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex + 1 >= listBox1.Items.Count)
            {
                listBox1.SelectedIndex = 0;
                return;
            }

            listBox1.SelectedIndex++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex - 1 < 0)
            {
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                return;
            }

            listBox1.SelectedIndex--;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex - 1 < 0)
            {
                listBox2.SelectedIndex = listBox2.Items.Count - 1;
                return;
            }

            listBox2.SelectedIndex--;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex + 1 >= listBox2.Items.Count)
            {
                listBox2.SelectedIndex = 0;
                return;
            }

            listBox2.SelectedIndex++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog m = new ColorDialog();
            if (textBox5.Text.Equals(types.hex.ToString()))
            {
                if (m.ShowDialog() == DialogResult.OK)
                {
                    Color myColor = m.Color;

                    _dat[listBox1.GetItemText(listBox1.SelectedItem)] = HexConverter(myColor);
                    textBox6.Text = HexConverter(myColor);
                }
            }
            else
            {
                MessageBox.Show("Type 이 Hex 인 경우에만 사용할 수 있습니다.", "RTResourceMaker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool isAlphaNumeric(string strToCheck)
        {
            Regex rg = new Regex(@"^[a-zA-Z0-9\s,]*$");
            return rg.IsMatch(strToCheck);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            types key_type = types.none;

            switch (textBox5.Text.ToLower())
            {
                case "hex": key_type = types.hex; break;
                case "alpha": key_type = types.alpha; break;
                default: throw new ArgumentException();
            }

            if (key_type == types.hex)
            {
                textBox6.MaxLength = 7;

                if (textBox6.Text.Length > 0 && textBox6.Text[0] != '#')
                {
                    textBox6.Text = $"#{textBox6.Text}";
                    textBox6.SelectionStart = textBox6.Text.Length;
                    textBox6.SelectionLength = 0;

                    _dat[listBox1.GetItemText(listBox1.SelectedItem)] = textBox6.Text;
                    return;
                }

                if (textBox6.Text.Length > 1/*>= 2와 같음*/ && !isAlphaNumeric(textBox6.Text[textBox6.Text.Length - 1].ToString()))
                {
                    textBox6.Text = textBox6.Text.Substring(0, textBox6.Text.Length - 1);
                    textBox6.Select(textBox6.Text.Length, 0);
                    _dat[listBox1.GetItemText(listBox1.SelectedItem)] = textBox6.Text;
                }
            }
            else if (key_type == types.alpha)
            {
                textBox6.MaxLength = 3;

                foreach (char it in textBox6.Text)
                {
                    if (!char.IsDigit(it))
                    {
                        textBox6.Text = textBox6.Text.Substring(0, textBox6.Text.Length - 1);
                        textBox6.Select(textBox6.Text.Length, 0);

                        _dat[listBox1.GetItemText(listBox1.SelectedItem)] = textBox6.Text;
                        return;
                    }
                }

                if (textBox6.Text.Length > 0 && !(Convert.ToInt32(textBox6.Text) >= 0 && Convert.ToInt32(textBox6.Text) <= 255))
                {
                    if (Convert.ToInt32(textBox6.Text) < 0)
                    {
                        textBox6.Text = "0";
                        _dat[listBox1.GetItemText(listBox1.SelectedItem)] = textBox6.Text;
                    }
                    else if (Convert.ToInt32(textBox6.Text) > 255)
                    {
                        textBox6.Text = "255";
                        _dat[listBox1.GetItemText(listBox1.SelectedItem)] = textBox6.Text;
                    }


                    textBox6.Select(textBox6.Text.Length, 0);
                    _dat[listBox1.GetItemText(listBox1.SelectedItem)] = textBox6.Text;
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            resname = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            resmaker = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            resinfo = textBox3.Text;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            resver = textBox10.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            types key_type = types.none;

            switch (textBox8.Text.ToLower())
            {
                case "hex": key_type = types.hex; break;
                case "alpha": key_type = types.alpha; break;
                default: throw new ArgumentException();
            }

            if (key_type == types.hex)
            {
                textBox7.MaxLength = 7;

                if (textBox7.Text.Length > 0 && textBox7.Text[0] != '#')
                {
                    textBox7.Text = $"#{textBox6.Text}";
                    textBox7.SelectionStart = textBox7.Text.Length;
                    textBox7.SelectionLength = 0;

                    _vals[listBox2.GetItemText(listBox2.SelectedItem)] = textBox7.Text;
                    return;
                }

                if (textBox7.Text.Length > 1/*>= 2와 같음*/ && !isAlphaNumeric(textBox7.Text[textBox7.Text.Length - 1].ToString()))
                {
                    textBox7.Text = textBox7.Text.Substring(0, textBox7.Text.Length - 1);
                    textBox7.Select(textBox7.Text.Length, 0);
                    _vals[listBox2.GetItemText(listBox2.SelectedItem)] = textBox7.Text;
                }
            }
            else if (key_type == types.alpha)
            {
                textBox7.MaxLength = 3;

                foreach (char it in textBox7.Text)
                {
                    if (!char.IsDigit(it))
                    {
                        textBox7.Text = textBox7.Text.Substring(0, textBox7.Text.Length - 1);
                        textBox7.Select(textBox7.Text.Length, 0);

                        _vals[listBox2.GetItemText(listBox2.SelectedItem)] = textBox7.Text;
                        return;
                    }
                }

                if (textBox7.Text.Length > 0 && !(Convert.ToInt32(textBox7.Text) >= 0 && Convert.ToInt32(textBox7.Text) <= 255))
                {
                    if (Convert.ToInt32(textBox7.Text) < 0)
                    {
                        textBox7.Text = "0";
                        _vals[listBox2.GetItemText(listBox2.SelectedItem)] = textBox7.Text;
                    }
                    else if (Convert.ToInt32(textBox7.Text) > 255)
                    {
                        textBox7.Text = "255";
                        _vals[listBox2.GetItemText(listBox2.SelectedItem)] = textBox7.Text;
                    }


                    textBox7.Select(textBox7.Text.Length, 0);
                    _vals[listBox2.GetItemText(listBox2.SelectedItem)] = textBox7.Text;
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog m = new ColorDialog();
            if (textBox8.Text.Equals(types.hex.ToString()))
            {
                if (m.ShowDialog() == DialogResult.OK)
                {
                    Color myColor = m.Color;

                    _vals[listBox2.GetItemText(listBox1.SelectedItem)] = HexConverter(myColor);
                    textBox7.Text = HexConverter(myColor);
                }
            }
            else if (textBox8.Text.Equals(types.alpha.ToString()))
            {
                if (m.ShowDialog() == DialogResult.OK)
                {
                    Color myColor = m.Color;

                    _vals[listBox1.GetItemText(listBox1.SelectedItem)] = RGBConverter(myColor);
                    textBox7.Text = RGBConverter(myColor);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();

            if (fb.ShowDialog() == DialogResult.OK)
            {
                imageloc = fb.SelectedPath;
                textBox13.Text = imageloc;

                loadimagesfromloc();
            }
        }

        public void loadimagesfromloc()
        {
            if (string.IsNullOrEmpty(imageloc)) return;

            listView1.Items.Clear();
            listView1.Columns.Clear();
            imageList1.Images.Clear();

            listView1.Columns.Add("파일명", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("위치", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("크기", 70, HorizontalAlignment.Left);

            List<string> files = new List<string>();
            List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
            int index;

            files = Directory.GetFiles(imageloc).ToList();

            for (int i = 0; i < files.Count(); i++)
            {
                for (int j = 0; j < ImageExtensions.Count; j++)
                {
                    if (Path.GetExtension(files[i]).ToLower().Equals(ImageExtensions[j].ToLower()))
                    {
                        imageList1.Images.Add(Image.FromFile(files[i]));
                        index = imageList1.Images.Keys.Count - 1;
                        imageList1.Images.SetKeyName(index, Path.GetFileName(files[i]));

                        FileInfo fi = new FileInfo(files[i]);
                        long numberOfBytes = fi.Length;

                        double newsize = (double)numberOfBytes * 0.000001;
                        string size = newsize.ToString("0.0") + "mb";

                        ListViewItem lv = new ListViewItem(Path.GetFileName(files[i]), index);
                        lv.SubItems.Add(files[i]);
                        lv.SubItems.Add(size);

                        listView1.Items.Add(lv);
                    }
                }
            }
        }

        public void loadimagesfromnpk()
        {
            listView2.Items.Clear();
            listView2.Columns.Clear();
            imageList2.Images.Clear();

            listView2.Columns.Add("파일명", 200, HorizontalAlignment.Left);
            listView2.Columns.Add("크기", 70, HorizontalAlignment.Left);

            List<string> files = new List<string>();
            List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
            List<string> hides = new List<string>();
            int index;

            hides = Properties.Resources.images_hides.Split(new[] { '\r', '\n' }).ToList();

            files = RTRM.ResourceManager.Items(BenchManager.EnvironmentLoc + BenchManager.projects + "\\" + folder + "\\" + folder + "\\images\\images.npk", 5, 7, 1, 6, "RTRMPASSWORD-RTHONEYJAM");

            for (int i = 0; i < files.Count(); i++)
            {
                for (int j = 0; j < ImageExtensions.Count; j++)
                {
                    if (Path.GetExtension(files[i]).ToLower().Equals(ImageExtensions[j].ToLower()))
                    {
                        if (hides.Contains((Path.GetFileName(files[i])))) continue;

                        imageList2.Images.Add(Image.FromStream(RTRM.ResourceManager.Get(BenchManager.EnvironmentLoc + BenchManager.projects + "\\" + folder + "\\" + folder + "\\images\\images.npk", files[i], 5, 7, 1, 6, "RTRMPASSWORD-RTHONEYJAM")));
                        index = imageList2.Images.Keys.Count - 1;
                        imageList2.Images.SetKeyName(index, Path.GetFileName(files[i]));

                        int _rtrm = RTRM.ResourceManager.GetSize(BenchManager.EnvironmentLoc + BenchManager.projects + "\\" + folder + "\\" + folder + "\\images\\images.npk", Path.GetFileName(files[i]), 5, 7, 1, 6, "RTRMPASSWORD-RTHONEYJAM");
                        double newsize = (double)_rtrm * 0.000001;
                        string size = newsize.ToString("0.0") + "mb";

                        ListViewItem lv = new ListViewItem(Path.GetFileName(files[i]), index);
                        lv.SubItems.Add(size);

                        listView2.Items.Add(lv);
                    }
                }
            }
        }

        public void loadsoundsfromloc()
        {
            if (string.IsNullOrEmpty(soundloc)) return;

            listView3.Items.Clear();
            listView3.Columns.Clear();

            listView3.Columns.Add("파일명", 200, HorizontalAlignment.Left);
            listView3.Columns.Add("위치", 200, HorizontalAlignment.Left);
            listView3.Columns.Add("크기", 70, HorizontalAlignment.Left);

            List<string> files = new List<string>();
            List<string> SoundExtensions = new List<string> { ".MP3", ".WAV", ".ROW" };
            int index = 0;

            files = Directory.GetFiles(soundloc).ToList();

            for (int i = 0; i < files.Count(); i++)
            {
                for (int j = 0; j < SoundExtensions.Count; j++)
                {
                    if (Path.GetExtension(files[i]).ToLower().Equals(SoundExtensions[j].ToLower()))
                    {
                        FileInfo fi = new FileInfo(files[i]);
                        long numberOfBytes = fi.Length;

                        double newsize = (double)numberOfBytes * 0.000001;
                        string size = newsize.ToString("0.0") + "mb";

                        ListViewItem lv = new ListViewItem(Path.GetFileName(files[i]));
                        lv.SubItems.Add(files[i]);
                        lv.SubItems.Add(size);
                        lv.ImageIndex = 0;

                        listView3.Items.Add(lv);
                    }
                }
            }
        }

        public void loadsoundsfromnpk()
        {
            listView4.Items.Clear();
            listView4.Columns.Clear();

            listView4.Columns.Add("파일명", 200, HorizontalAlignment.Left);
            listView4.Columns.Add("크기", 70, HorizontalAlignment.Left);

            List<string> files = new List<string>();
            List<string> SoundExtensions = new List<string> { ".MP3", ".WAV", ".ROW" };
            List<string> hides = new List<string>();
            int index = 0;

            hides = Properties.Resources.sounds_hides.Split(new[] { '\r', '\n' }).ToList();

            files = RTRM.ResourceManager.Items(BenchManager.EnvironmentLoc + BenchManager.projects + "\\" + folder + "\\" + folder + "\\sounds\\sounds.npk", 5, 7, 1, 6, "RTRMPASSWORD-RTHONEYJAM");

            for (int i = 0; i < files.Count(); i++)
            {
                for (int j = 0; j < SoundExtensions.Count; j++)
                {
                    if (Path.GetExtension(files[i]).ToLower().Equals(SoundExtensions[j].ToLower()))
                    {
                        if (hides.Contains(Path.GetFileName(files[i]))) continue;

                        int _rtrm = RTRM.ResourceManager.GetSize(BenchManager.EnvironmentLoc + BenchManager.projects + "\\" + folder + "\\" + folder + "\\sounds\\sounds.npk", Path.GetFileName(files[i]), 5, 7, 1, 6, "RTRMPASSWORD-RTHONEYJAM");
                        double newsize = (double)_rtrm * 0.000001;
                        string size = newsize.ToString("0.0") + "mb";

                        ListViewItem lv = new ListViewItem(Path.GetFileName(files[i]));
                        lv.SubItems.Add(size);
                        lv.ImageIndex = 0;

                        listView4.Items.Add(lv);
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = listView1.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                string text = listView1.Items[intselectedindex].SubItems[1].Text;
                textBox15.Text = text;
            }
        }

        private void splitContainer5_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();

            if (fb.ShowDialog() == DialogResult.OK)
            {
                soundloc = fb.SelectedPath;
                textBox16.Text = imageloc;

                loadsoundsfromloc();
            }
        }

        public async void build()
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox14.Text) || string.IsNullOrEmpty(textBox15.Text))
            {
                MessageBox.Show("교체 될 파일 및 교체 할 파일을 선택해 주세요", "RTResourceMaker", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            replace("\\images\\images.npk", textBox14.Text, textBox15.Text, textBox14.Text);
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = listView2.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                String text = listView2.Items[intselectedindex].Text;
                textBox14.Text = text;
            }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = listView3.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                string text = listView3.Items[intselectedindex].Text;
                textBox17.Text = text;
            }
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView4.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = listView4.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                String text = listView4.Items[intselectedindex].Text;
                textBox18.Text = text;
            }
        }

        private void ChangeKeyByValue(Dictionary<string, string> d, string value/*바꿀 Key 의 Value*/, string key/*바뀐 Key*/)
        {
            int value_inx = d.Values.ToList().IndexOf(value);

            d[d.Keys.ToList()[value_inx]] = key;
        }

        public async void replace(string loc, string r, string r2, string r3)
        {
            RTRM.ResourceManager.ReplaceEntity(BenchManager.EnvironmentLoc + BenchManager.projects + "\\" + folder + "\\" + folder + loc, r, r2, r3, 5, 7, 1, 6, "RTRMPASSWORD-RTHONEYJAM");
            label11.Text = "성공적으로 파일이 교체되었습니다";
            loadimagesfromnpk();
            await Task.Delay(5000);
            label11.Text = string.Empty;
        }
    }
}
