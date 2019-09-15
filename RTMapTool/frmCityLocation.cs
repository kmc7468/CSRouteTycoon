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
	internal partial class frmCityLocation : Form
	{
		private Map _map;
		private Region _reg;
		private List<City> _citys;
		private frmCity _city;

		private Graphics g;
		private ToolTip tt = new ToolTip();

		public frmCityLocation(Map map, Region reg, List<City> citys, frmCity city)
		{
			InitializeComponent();

			_map = map;
			_reg = reg;
			_citys = citys;
			_city = city;

			BackgroundImage = Image.FromFile(map.BackImage);

			g = CreateGraphics();

			using (BufferedGraphics bG = BufferedGraphicsManager.Current.Allocate(g, ClientRectangle))
			{
				foreach (var r in map.Regions)
				{
					foreach (var c in r.Key.Citys)
					{
						PictureBox pbc = new PictureBox();
						pbc.Size = new Size(3, 3);
						pbc.Location = new Point(c.Location.X, c.Location.Y);
						pbc.BackColor = Color.White;
						if (citys.Contains(c))
							pbc.BackColor = Color.FromArgb(212, 67, 46);
						pbc.MouseClick += (object sender, MouseEventArgs e) =>
						{
							Pb_MouseClick(sender, e, pbc);
						};
						tt.SetToolTip(pbc, c.Name);
						Controls.Add(pbc);
					}

					PictureBox pb = new PictureBox();
					pb.Image = r.Value.Image;
					pb.Size = new Size(30, 30);
					pb.SizeMode = PictureBoxSizeMode.StretchImage;
					pb.BackColor = Color.Transparent;
					pb.Location = r.Value.Location;
					pb.MouseClick += (object sender, MouseEventArgs e) => {
						Pb_MouseClick(sender, e, pb);
					};
					tt.SetToolTip(pb, r.Key.Name);
					Controls.Add(pb);
					pb.BringToFront();
				}
			}
		}

		private void Pb_MouseClick(object sender, MouseEventArgs e, PictureBox pb)
		{
			try
			{
				_city.SetCityLocation(pb.Location, _citys);
				this.Close();
			}
			catch (Exception EX)
			{
				MessageBox.Show(EX.Message, "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}
		}

		private void frmCityLocation_MouseClick(object sender, MouseEventArgs e)
		{
			try
			{
				_city.SetCityLocation(e.Location, _citys);
				this.Close();
			}
			catch (Exception EX)
			{
				MessageBox.Show(EX.Message, "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}
		}
	}
}
