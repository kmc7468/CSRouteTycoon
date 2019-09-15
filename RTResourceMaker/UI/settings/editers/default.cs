using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTResourceMaker.UI.settings.editers
{
    public partial class _default : UserControl
    {
        public _default()
        {
            InitializeComponent();
        }

        public void load()
        {
            foreach (Control it in this.Controls)
            {
                it.Font = new Font(FontManager.Get().EnvironmentFont, it.Font.Size, it.Font.Style);
            }

            checkboxUseIntelliSense.Checked = Properties.Settings.Default.useIntelliSense;
        }

        private void checkboxUseIntelliSense_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.useIntelliSense = checkboxUseIntelliSense.Checked;
            Properties.Settings.Default.Save();
        }

        private void setprogram_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
