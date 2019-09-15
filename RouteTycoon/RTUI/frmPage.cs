using RouteTycoon.RTCore;
using System.Drawing;
using System.Windows.Forms;

namespace RouteTycoon.RTUI
{
	internal partial class frmPage : Form
	{
		public frmPage()
		{
			InitializeComponent();

			Icon = SceneManager.MainForm.Icon;
		}
	}
}
