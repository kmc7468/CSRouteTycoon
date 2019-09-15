using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTResourceMaker.UI.settings.programs
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

            checkboxUseAutoSave.Checked = Properties.Settings.Default.useAutoSave;
        }

        private void checkboxUseAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.useAutoSave = checkboxUseAutoSave.Checked;
            Properties.Settings.Default.Save();
        }

        private void setedit_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
