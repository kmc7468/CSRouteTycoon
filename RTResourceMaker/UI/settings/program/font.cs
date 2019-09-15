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
    public partial class font : UserControl
    {
        public font()
        {
            InitializeComponent();
        }

        public void load()
        {
            foreach (Control it in this.Controls)
            {
                it.Font = new Font(FontManager.Get().EnvironmentFont, it.Font.Size, it.Font.Style);
            }

            List<string> fonts = new List<string>();
            fonts = FontManager.Get().GetFontNameByWindowsFontDir();

            foreach (string font in fonts)
            {
                comboboxFonts.Items.Add(font);
            }

            comboboxFonts.Text = Properties.Settings.Default.fontName;
        }

        private void font_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.fontName = comboboxFonts.Text;
            Properties.Settings.Default.Save();
            FontManager.Get().SetFontByString(Properties.Settings.Default.fontName);
			load();

            MessageBox.Show("적용이 완료되었습니다.", "RTResourceMaker", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboboxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxFonts.SelectedIndex <= 0) return;

            txtboxPreview.Font = new Font(comboboxFonts.Text, txtboxPreview.Font.Size, txtboxPreview.Font.Style);
        }
    }
}
