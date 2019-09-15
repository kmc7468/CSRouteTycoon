using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace RTResourceMaker.UI.edits
{
    public partial class loading : UserControl
    {
        public loading()
        {
            InitializeComponent();
            foreach (Control it in this.Controls)
            {
                it.Font = new Font(FontManager.Get().EnvironmentFont, it.Font.Size, it.Font.Style);
            }
        }

        public string myInfo
        {
            get
            {
                return lbInfo.Text;
            }
            set
            {
                lbInfo.Text = value;
            }
        }

        public void StartAnimation()
        {
            if (animation.Enabled == true)
            {
                animation.Stop();
                animation.Start();
            }
            else
            {
                animation.Start();
            }
        }

        private void animation_Tick(object sender, EventArgs e)
        {
            string type = Regex.Split(lbTitle.Text, "프로젝트를 로딩하는 중 입니다")[1];
            string fin = string.Empty;

            if (type.Equals("."))
            {
                fin = "..";
            }
            else if (type.Equals(".."))
            {
                fin = "...";
            }
            else if (type.Equals("..."))
            {
                fin = ".";
            }

            lbTitle.Text = lbTitle.Text.Replace(type, fin);
        }
    }
}
