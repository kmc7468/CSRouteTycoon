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
    public partial class setting : UserControl
    {
        public setting()
        {
            InitializeComponent();
        }

        public void load()
        {
            foreach (Control it in this.Controls)
            {
                it.Font = new Font(FontManager.Get().EnvironmentFont, it.Font.Size, it.Font.Style);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            main _main = new main();
            PageManager.SetPage(TempData.UIData._frmMain._myPanel, _main);
        }

        private void setting_Load(object sender, EventArgs e)
        {
            load();
        }

        private void treeSettingCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string select = treeSettingCategory.SelectedNode.Name;

            #region Program
            if (select.Equals("programDefault"))
            {
                settings.programs._default _default = new settings.programs._default();
                PageManager.SetPage(myPanel, _default);
            }
            else if (select.Equals("programFont"))
            {
                settings.programs.font _font = new settings.programs.font();
                _font.Parent = this;
                PageManager.SetPage(myPanel, _font);
            }
            #endregion

            #region Editer
            if (select.Equals("editDefault"))
            {
                settings.editers._default _default = new settings.editers._default();
                PageManager.SetPage(myPanel, _default);
            }
            else if (select.Equals("editImageTab"))
            {
                settings.editers.image _image = new settings.editers.image();
                PageManager.SetPage(myPanel, _image);
            }
            else if (select.Equals("editSoundTab"))
            {
                settings.editers.sound _sound = new settings.editers.sound();
                PageManager.SetPage(myPanel, _sound);
            }
            #endregion
        }
    }
}
