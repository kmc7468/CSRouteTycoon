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
    public partial class sound : UserControl
    {
        public sound()
        {
            InitializeComponent();
            load();
        }

        public void load()
        {
            foreach (Control it in this.Controls)
            {
                it.Font = new Font(FontManager.Get().EnvironmentFont, it.Font.Size, it.Font.Style);
            }

            comboBox1.Text = Properties.Settings.Default.soundViewType;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.soundViewType = comboBox1.Text;
            Properties.Settings.Default.Save();
        }
    }
}
