using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTResourceMaker.UI
{
    public partial class main : UserControl
    {
        public main()
        {
            InitializeComponent();
        }

        private string cmd = string.Empty;

        public void load()
        {
            foreach (Control it in this.Controls)
            {
                it.Font = new Font(FontManager.Get().EnvironmentFont, it.Font.Size, it.Font.Style);
            }

			lbVersion.Location = new Point(lbTitle.Width + lbTitle.Location.X + 10, lbVersion.Location.Y);
		}

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMake_Click(object sender, EventArgs e)
        {
            makes.make _make = new makes.make();
            PageManager.SetPage(TempData.UIData._frmMain._myPanel, _make);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            load _load = new load();
            PageManager.SetPage(TempData.UIData._frmMain._myPanel, _load);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            setting _setting = new setting();
            PageManager.SetPage(TempData.UIData._frmMain._myPanel, _setting);
        }

        private void main_Load(object sender, EventArgs e)
        {
            load();
        }
	}
}
