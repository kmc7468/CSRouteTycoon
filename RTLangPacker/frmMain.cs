using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RTLangPacker
{
	partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private void btnPacker_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog od = new OpenFileDialog();
				od.Filter = "RouteTycoon 언어 파일|*.xml";
				od.Title = "Pack 할 RouteTycoon 언어 파일";

				if (od.ShowDialog() == DialogResult.OK)
				{
					string pack = od.FileName;

					SaveFileDialog sd = new SaveFileDialog();
					sd.Title = "저장할 Pack 된 RouteTycoon 언어 파일";
					sd.Filter = "Pack 된 RouteTycoon 언어 파일|*.txf";

					if (sd.ShowDialog() == DialogResult.OK)
					{
						string save = sd.FileName;

						List<string> path = new List<string>();
						List<string> name = new List<string>();

						path.Add(pack);
						name.Add("lang.xml");

						RTRM.ResourceManager.Pack(save, path, name, 6, 3, 2, 1, "RTRMPASSWORD-RTHONEYJAM");

						MessageBox.Show("완료", "RTLangPacker", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
			catch(Exception EX)
			{
				MessageBox.Show("작업 도중 오류 발생\n\n" + EX.ToString(), "RTLangPacker", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
