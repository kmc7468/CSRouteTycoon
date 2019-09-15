using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTTrainTool
{
	internal partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private void btnLoc_Click(object sender, EventArgs e)
		{
			new frmLocomotive().ShowDialog();
		}

		private void btnCar_Click(object sender, EventArgs e)
		{
			new frmCoach().ShowDialog();
		}

		private void btnData_Click(object sender, EventArgs e)
		{
			MessageBox.Show("개발 중인 기능 입니다.", "RTTrainTool", MessageBoxButtons.OK, MessageBoxIcon.Information);
			//new frmData().ShowDialog();
		}
       
		private void btnInstitutionsCarriage_Click(object sender, EventArgs e)
		{
			new frmEngineCoach().ShowDialog();
		}
	}
}
