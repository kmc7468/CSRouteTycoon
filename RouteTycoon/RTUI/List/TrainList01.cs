using System;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class TrainList01 : UserControl
	{
		public Train t;
		private Graphics g;
		private bool _isOkAddTrain = false;
		private bool _isAllTrainList = false;
		private string _typeString = "";
		private string _routeName = "";

		internal bool isSelect
		{
			get;
			set;
		} = false;

		public TrainList01(Train _T, bool isOkAddTrain = false, string typeString = "", bool isAllTrainList = false, string routeName = "")
		{
			try
			{
				InitializeComponent();

				t = _T;
				_isOkAddTrain = isOkAddTrain;
				_typeString = typeString;
				_isAllTrainList = isAllTrainList;
				_routeName = routeName;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void TrainList01_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				g = e.Graphics;

				if (!_isOkAddTrain && !_isAllTrainList)
					g.DrawString($"{t.Name} ({t.Data.Name})", new Font(RTCore.Environment.Font, 15), new SolidBrush(ResourceManager.Get("list.trainlist01.name")), new RectangleF(8, 7, 644, Height - 7));
				else if (_isOkAddTrain)
					g.DrawString($"{t.Name} ({t.Data.Name}, {_typeString})", new Font(RTCore.Environment.Font, 15), new SolidBrush(ResourceManager.Get("list.trainlist01.name")), new RectangleF(8, 7, 644, Height - 7));
				else if (_isAllTrainList)
					g.DrawString($"{t.Name} ({t.Data.Name}, {_typeString}, {_routeName})", new Font(RTCore.Environment.Font, 15), new SolidBrush(ResourceManager.Get("list.trainlist01.name")), new RectangleF(8, 7, 644, Height - 7));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void TrainList01_MouseEnter(object sender, EventArgs e)
		{
			try
			{
				if (isSelect) return;
				BackColor = ResourceManager.Get("list.trainlist01.background.sel");
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void TrainList01_MouseLeave(object sender, EventArgs e)
		{
			try
			{
				if (isSelect) return;
				BackColor = Color.Transparent;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void TrainList01_Click(object sender, EventArgs e)
		{
			try
			{
				if (isSelect)
				{
					isSelect = false;
					BackColor = Color.Transparent;
				}
				else
				{
					isSelect = true;
					BackColor = ResourceManager.Get("list.trainlist01.background.select");
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void TrainList01_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				if ((_routeName != TextManager.Get().Text("uninputtrain") && _isAllTrainList) || (_routeName != "" && _isOkAddTrain))
				{
					PageManager.SetPage(new TrainWayPage(t, PageManager.GetNowPage(AccessManager.AccessKey)), AccessManager.AccessKey);
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
