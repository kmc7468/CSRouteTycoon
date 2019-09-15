using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class TrainDataAdd_Args_Page : Page
	{
		private Graphics g;
		private Page OldPage = null;

		private string name = string.Empty;
		public List<TrainParant> args = null;
		private Image image = null;

		private int np = 1, mp = 1;

		private Image imgUp, imgUpSel, imgDown, imgDownSel;
		private Image imgAdd, imgAddSel, imgRemove, imgRemoveSel;

		private void lbLocAdd_Click(object sender, EventArgs e)
		{
			try
			{
				List<TrainParant> cars = new List<TrainParant>();
				foreach (var it in args)
				{
					if (it is Locomotive)
						cars.Add(it);
					else if (it is EngineCoach)
						cars.Add(it);
				}

				if (cars.Count == 0)
					PageManager.SetPage(new TrainList_OKAdd_Locomotive_Page(this, null), AccessManager.AccessKey);
				else if (cars[0] is Locomotive)
					PageManager.SetPage(new TrainList_OKAdd_Locomotive_Page(this, (cars[0] as Locomotive).Rank), AccessManager.AccessKey);
				else if (cars[0] is EngineCoach)
					PageManager.SetPage(new TrainList_OKAdd_Locomotive_Page(this, (Locomotive.LocomotiveRank)(int)(cars[0] as EngineCoach).Locomotive.Rank), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbCarAdd_Click(object sender, EventArgs e)
		{
			try
			{
				List<Locomotive> loc = new List<Locomotive>();
				List<EngineCoach> lc = new List<EngineCoach>();
				foreach (var it in args)
				{
					if (it is Locomotive)
						loc.Add((Locomotive)it);
					else if (it is EngineCoach)
						lc.Add((EngineCoach)it);
				}

				if (loc.Count + lc.Count == 0)
				{
					MessageBox.Show(TextManager.Get().Text("noloc"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return;
				}

				List<Coach> car = new List<Coach>();
				foreach (var it in args)
					if (it is Coach)
						car.Add((Coach)it);

				long max_car = 0;

				foreach (var it in loc)
				{
					max_car += it.Carrying;
				}
				foreach (var it in lc)
				{
					max_car += it.Locomotive.Carrying;
				}

				if (car.Count >= max_car)
				{
					MessageBox.Show(TextManager.Get().Text("fullcar"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return;
				}

				PageManager.SetPage(new TrainList_OKAdd_Coach_Page(this), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private ToolTip tt = new ToolTip();

		public TrainDataAdd_Args_Page(Page _p = null, string _name = "", List<TrainParant> _args = null, Image _image = null)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				Title = TextManager.Get().Text("addtrainarg");
				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_train.png", 5, 7, 1, 6));

				name = _name;
				args = _args;
				image = _image;
				OldPage = _p;

				if (args == null) args = new List<TrainParant>();

				imgUp = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_up.png", 5, 7, 1, 6));
				imgUpSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_up_sel.png", 5, 7, 1, 6));
				imgDown = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_down.png", 5, 7, 1, 6));
				imgDownSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_down_sel.png", 5, 7, 1, 6));
				imgAdd = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_add.png", 5, 7, 1, 6));
				imgAddSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_add_sel.png", 5, 7, 1, 6));
				imgRemove = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_remove.png", 5, 7, 1, 6));
				imgRemoveSel = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "btn_remove_sel.png", 5, 7, 1, 6));

				lbTitle.Font = new Font(RTCore.Environment.Font, 30);
				lbTitle.Text = TextManager.Get().Text("traindata");

				lbNext.Font = new Font(RTCore.Environment.Font, 20);
				lbNext.Text = TextManager.Get().Text("next");
				lbNext.ForeColor = ResourceManager.Get("traindataadd.next.unsel");
				lbNext.SelColor = ResourceManager.Get("traindataadd.next.sel");
				lbNext.Location = new Point(Width - 25 - lbNext.Width, 553);
				lbNext.Click += delegate
				{
					if (args.Count <= 1)
					{
						MessageBox.Show(TextManager.Get().Text("nottrainargs"), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						return;
					}

					PageManager.SetPage(new TrainDataAdd_Image_Page(OldPage, name, args, image), AccessManager.AccessKey);
				};

				lbBack.ForeColor = ResourceManager.Get("traindataadd.back.unsel");
				lbBack.SelColor = ResourceManager.Get("traindataadd.back.sel");
				lbBack.Text = TextManager.Get().Text("back");
				lbBack.Font = new Font(RTCore.Environment.Font, 20);
				lbBack.Location = new Point(Width - lbNext.Width - lbBack.Width - 10 - (Width - (lbNext.Location.X + lbNext.Width)), lbNext.Location.Y);
				lbBack.Click += delegate
				{
					PageManager.SetPage(new TrainDataAdd_Name_Page(OldPage, name, args, image), AccessManager.AccessKey);
				};

				ListDraw();

				lbPage.Font = new Font(RTCore.Environment.Font, 12);
				lbPage.ForeColor = ResourceManager.Get("traindataadd.page");
				lbPage.Location = new Point(lbTitle.Location.X + lbTitle.Width + 7, lbPage.Location.Y);
				if (np == mp) picDown.Visible = false; else picDown.Visible = true;
				if (np == 1) { picUp.Enabled = false; picUp.Visible = false; picDown.Location = picUp.Location; } else { picUp.Enabled = true; picUp.Visible = true; picDown.Location = new Point(81, 554); }

				lbLocAdd.Text = TextManager.Get().Text("addloc");
				lbLocAdd.Font = new Font(RTCore.Environment.Font, 20);
				lbLocAdd.ForeColor = ResourceManager.Get("traindataadd.addloc.unsel");
				lbLocAdd.SelColor = ResourceManager.Get("traindataadd.addloc.sel");

				lbCarAdd.Text = TextManager.Get().Text("addcar");
				lbCarAdd.Font = new Font(RTCore.Environment.Font, 20);
				lbCarAdd.Location = new Point(lbLocAdd.Location.X, lbLocAdd.Location.Y + lbLocAdd.Height + 5);
				lbCarAdd.ForeColor = ResourceManager.Get("traindataadd.addcar.unsel");
				lbCarAdd.SelColor = ResourceManager.Get("traindataadd.addcar.sel");

				lbEngineAdd.Text = TextManager.Get().Text("addengine");
				lbEngineAdd.Font = new Font(RTCore.Environment.Font, 20);
				lbEngineAdd.Location = new Point(lbEngineAdd.Location.X, lbCarAdd.Location.Y + lbCarAdd.Height + 5);
				lbEngineAdd.ForeColor = ResourceManager.Get("traindataadd.addengine.unsel");
				lbEngineAdd.SelColor = ResourceManager.Get("traindataadd.addengine.sel");

				panListBack.BackColor = ResourceManager.Get("traindataadd.list");

				picUp.Image = imgUp;
				picUp.MouseEnter += delegate
				{
					picUp.Image = imgUpSel;
				};
				picUp.MouseLeave += delegate
				{
					picUp.Image = imgUp;
				};

				picDown.Image = imgDown;
				picDown.MouseEnter += delegate
				{
					picDown.Image = imgDownSel;
				};
				picDown.MouseLeave += delegate
				{
					picDown.Image = imgDown;
				};

				picRemove.Image = imgRemove;
				picRemove.MouseEnter += delegate
				{
					picRemove.Image = imgRemoveSel;
				};
				picRemove.MouseLeave += delegate
				{
					picRemove.Image = imgRemove;
				};
				picRemove.Click += delegate
				{
					List<CarList01> c = new List<CarList01>();
					foreach (Control it in panList.Controls)
						if (it is CarList01)
							if ((it as CarList01).isSelect)
								c.Add((CarList01)it);

					if (c.Count == 0) return;

					if (MessageBox.Show(TextManager.Get().Text("realunselcar"), "RouteTycoon", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
					{
						foreach (var it in c)
						{
							args.Remove(it.tp);
						}

						ListDraw();
					}

				};
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void SetPage()
		{
			try
			{
				string txt = TextManager.Get().Text("page");
				txt = txt.Replace("%NOW%", np.ToString());
				txt = txt.Replace("%MAX%", mp.ToString());
				lbPage.Text = txt;
				if (np == mp) picDown.Visible = false; else picDown.Visible = true;
				if (np == 1) { picUp.Enabled = false; picUp.Visible = false; picDown.Location = picUp.Location; } else { picUp.Enabled = true; picUp.Visible = true; picDown.Location = new Point(117, 554); }
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbEngineAdd_Click(object sender, EventArgs e)
		{
			try
			{
				List<TrainParant> a = new List<TrainParant>();
				foreach (var it in args)
				{
					if (it is Locomotive)
						a.Add(it);
					else if (it is EngineCoach)
						a.Add(it);
				}

				if (a.Count != 0)
				{
					if (a[0] is Locomotive)
					{
						PageManager.SetPage(new TrainList_OKAdd_EngineCoach_Page(this, (EngineCoach.LocomotiveData.LocomotiveRank)((int)(a[0] as Locomotive).Rank)), AccessManager.AccessKey);
					}
					else if (a[0] is EngineCoach)
					{
						PageManager.SetPage(new TrainList_OKAdd_EngineCoach_Page(this, (a[0] as EngineCoach).Locomotive.Rank), AccessManager.AccessKey);
					}
				}
				else
				{
					PageManager.SetPage(new TrainList_OKAdd_EngineCoach_Page(this, null), AccessManager.AccessKey);
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public void ListDraw()
		{
			try
			{
				tt.RemoveAll();
				panList.Controls.Clear();
				panList.Location = new Point(0, 0);
				panList.Size = new Size(530, 0);
				np = 1;

				int y = 0;

				foreach (var it in args)
				{
					CarList01 rl = new CarList01(it, this);
					rl.Location = new Point(0, y);
					panList.Controls.Add(rl);
					y += rl.Height;
					panList.Size = new Size(530, y);
					string type = "";
					if (it is Locomotive) type = TextManager.Get().Text("locomotive");
					else if (it is Coach) type = TextManager.Get().Text("coach");
					else if (it is EngineCoach) type = TextManager.Get().Text("enginecoach");
					tt.SetToolTip(rl, it.Name + "(" + type + ")");
				}

				mp = RTCore.Environment.CalcPage(args.Count, 10);

				SetPage();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void picUp_Click(object sender, EventArgs e)
		{
			try
			{
				if (np == 1) return;
				np--;
				{
					SetPage();
					if (np == mp) picDown.Visible = false; else picDown.Visible = true;
					if (np == 1) { picUp.Enabled = false; picUp.Visible = false; picDown.Location = picUp.Location; } else { picUp.Enabled = true; picUp.Visible = true; picDown.Location = new Point(117, 554); }
				}

				int max = panList.Location.Y + 400;

				Timer tm = new Timer();
				tm.Interval = 1;
				tm.Tick += delegate
				{
					// -400
					panList.Location = new Point(0, panList.Location.Y + 20);
					if (panList.Location.Y == max) { picUp.Enabled = true; tm.Stop(); tm.Dispose(); }
				};
				tm.Start();
				picUp.Enabled = false;
			}
			catch (Exception EX)
			{
				RTCore.Environment.ReportError(EX, AccessManager.AccessKey);
			}
		}

		private void picDown_Click(object sender, EventArgs e)
		{
			try
			{
				if (np == mp) return;
				np++;
				{
					SetPage();
					if (np == mp) picDown.Visible = false; else picDown.Visible = true;
					if (np == 1) { picUp.Enabled = false; picUp.Visible = false; picDown.Location = picUp.Location; } else { picUp.Enabled = true; picUp.Visible = true; picDown.Location = new Point(117, 554); }
				}

				int max = panList.Location.Y - 400;

				Timer tm = new Timer();
				tm.Interval = 1;
				tm.Tick += delegate
				{
					// -400
					panList.Location = new Point(0, panList.Location.Y - 20);
					if (panList.Location.Y == max) { picDown.Enabled = true; tm.Stop(); tm.Dispose(); }
				};
				tm.Start();
				picDown.Enabled = false;
			}
			catch (Exception EX)
			{
				RTCore.Environment.ReportError(EX, AccessManager.AccessKey);
			}
		}

		private void TrainDataAdd_Args_Page_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Draw(e);

				g = e.Graphics;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public void ChangeOrder(CarList01 cl1, CarList01 cl2)
		{
			if (cl1 == null || cl2 == null) return;

			Point p1 = cl1.Location;
			Point p2 = cl2.Location;

			cl2.Location = p1;
			cl1.Location = p2;

			cl2.BackColor = Color.Transparent;
			cl1.BackColor = Color.Transparent;
			cl2.isSelect = false;
			cl1.isSelect = false;

			int cl1_inx = args.IndexOf(cl1.tp);
			int cl2_inx = args.IndexOf(cl2.tp);

			args[cl1_inx] = cl2.tp;
			args[cl2_inx] = cl1.tp;
		}

		public CarList01 GetCarList(CarList01 cl, GetType t)
		{
			if (t == GetType.Up)
			{
				List<CarList01> tmp = new List<CarList01>();
				foreach (var it in panList.Controls)
					tmp.Add((CarList01)it);

				if (cl.Location.Y == 0) return null;

				Control ctrl = tmp.First(x => x.Location == new Point(0, cl.Location.Y - 40));

				return (CarList01)ctrl;
			}
			else
			{
				List<CarList01> tmp = new List<CarList01>();
				foreach (var it in panList.Controls)
					tmp.Add((CarList01)it);

				if (cl.Location.Y == panList.Height - 40) return null;

				Control ctrl = tmp.First(x => x.Location == new Point(0, cl.Location.Y + 40));

				return (CarList01)ctrl;
			}
		}

		public new enum GetType
		{
			Up, // 위에 있는 것
			Down // 밑에 있는 것
		}
	}
}
