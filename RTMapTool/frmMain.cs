using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTMapTool
{
	partial class frmMain : Form
	{
		private frmTool _frmTool;
		private bool _isActivated = true;

		public Image MapImage
		{
			get
			{
				return BackgroundImage;
			}
			set
			{
				BackgroundImage = value;
			}
		}

		public frmMain()
		{
			InitializeComponent();

			_frmTool = new frmTool(this);
			_frmTool.Show();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{

		}

		private void timer_Tick(object sender, EventArgs e)
		{
			foreach(var it in Controls)
			{
				if(it is PictureBox)
				{
					PictureBox pb = it as PictureBox;

					if (UIRegion1.ClientRectangle.IntersectsWith(new Rectangle(pb.Location, pb.Size)) ||
						(new Rectangle(UIRegion2.Location, UIRegion2.Size)).IntersectsWith(new Rectangle(pb.Location, pb.Size)))
					{
						pb.Location = new Point(ClientSize.Width / 2, ClientSize.Height / 2);

						MessageBox.Show("UI 영역에 컨트롤을 놓을 수 없습니다.", "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
			}
		}

		private void frmMain_LocationChanged(object sender, EventArgs e)
		{
			_frmTool.Location = new Point(Location.X + ClientRectangle.Width + 10, Location.Y);
		}

		private void frmMain_Activated(object sender, EventArgs e)
		{
			if (!_isActivated)
				_frmTool.Activate();

			_isActivated = true;
		}

		private void frmMain_Deactivate(object sender, EventArgs e)
		{
			_isActivated = false;
		}
	}
}
