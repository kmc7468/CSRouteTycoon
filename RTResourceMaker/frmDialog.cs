using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTResourceMaker
{
    public partial class frmDialog : Form
    {
        public frmDialog()
        {
            InitializeComponent();
        }

        public Panel _myPanel { get { return myPanel; } }
        public void end()
        {
            this.Close();
        }

        private void frmDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
