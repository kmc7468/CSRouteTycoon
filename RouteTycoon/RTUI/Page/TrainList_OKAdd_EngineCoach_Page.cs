using System;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class TrainList_OKAdd_EngineCoach_Page : Page
	{
		private TrainDataAdd_Args_Page oldpage;

		private Graphics g;
		private ToolTip tt = new ToolTip();

		public TrainList_OKAdd_EngineCoach_Page(TrainDataAdd_Args_Page _oldpage, EngineCoach.LocomotiveData.LocomotiveRank? _oldrank)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				Title = TextManager.Get().Text("addtrainarg");
				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_train.png", 5, 7, 1, 6));

				oldpage = _oldpage;

				ListDraw(_oldrank);

				lbTitle.Font = new Font(RTCore.Environment.Font, 30);
				lbTitle.Text = TextManager.Get().Text("okaddenginecoach");
				lbTitle.ForeColor = ResourceManager.Get("okaddenginecoach.title");

				panListBack.BackColor = ResourceManager.Get("okaddenginecoach.list");

				lbAdd.ForeColor = ResourceManager.Get("okaddenginecoach.add.unsel");
				lbAdd.SelColor = ResourceManager.Get("okaddenginecoach.add.sel");

				lbAdd.Font = new Font(RTCore.Environment.Font, 20);
				lbAdd.Text = TextManager.Get().Text("add");
				lbAdd.ForeColor = ResourceManager.Get("okaddenginecoach.add.unsel");
				lbAdd.SelColor = ResourceManager.Get("okaddenginecoach.add.sel");
				lbAdd.Location = new Point(Width - 25 - lbAdd.Width, 553);
				lbAdd.Click += delegate
				{
					EngineCoach car = null;
					foreach (var it in panList.Controls)
					{
						if (it is EngineCoachList01)
							if ((it as EngineCoachList01).isSelect)
							{
								car = (it as EngineCoachList01).car;
								break;
							}
					}

					if (car != null)
					{
						oldpage.args.Add(car);
						oldpage.ListDraw();
					}
					PageManager.SetPage(oldpage, AccessManager.AccessKey);
				};
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void ListDraw(EngineCoach.LocomotiveData.LocomotiveRank? rank)
		{
			try
			{
				tt.RemoveAll();
				panList.Size = new Size(730, 0);
				panList.Location = new Point(0, 0);

				int y = 0;
				foreach (var it in TrainManager.EngineCoachs)
				{
					if (rank != null && it.Locomotive.Rank != rank.GetValueOrDefault()) continue;
					EngineCoachList01 rl = new EngineCoachList01(it, this);
					rl.Location = new Point(0, y);
					panList.Controls.Add(rl);
					y += rl.Height;
					panList.Size = new Size(730, y);
				}

				if (panList.Controls.Count <= 2)
				{
					panListBack.AutoScroll = false;
					panListBack.Size = new Size(730, panListBack.Height);
				}
				else
				{
					panListBack.AutoScroll = true;
					panListBack.Size = new Size(750, panListBack.Height);
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void TrainList_OKAdd_EngineCoach_Page_Paint(object sender, PaintEventArgs e)
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

		public void SelectChange(EngineCoachList01 list)
		{
			try
			{
				foreach (var it in panList.Controls)
				{
					if (it is EngineCoachList01)
					{
						EngineCoachList01 l = (EngineCoachList01)it;

						l.isSelect = false;
						l.BackColor = Color.Transparent;
					}
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
