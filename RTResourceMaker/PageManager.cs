using System.Drawing;
using System.Windows.Forms;

namespace RTResourceMaker
{
    internal static class PageManager
    {
        internal static void SetPage(Panel myPanel, UserControl myControl)
        {
            Remove(myPanel);

            myPanel.Controls.Add(myControl);

            myControl.Location = new Point(0, 0);
            myControl.Dock = DockStyle.Fill;
        }

        internal static void Remove(Panel myPanel)
        {
            foreach (Control it in myPanel.Controls)
            {
                it.Dispose();
            }
        }
    }
}
