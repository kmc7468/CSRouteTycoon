using System;
using RouteTycoon.RTCore;
using System.ComponentModel;
using System.Drawing;

namespace RouteTycoon.RTUI
{
	internal partial class LogoScene : Scene
	{
		private bool LoadCompleted = false;
		private RTCore.Environment.CommandLineResult res = RTCore.Environment.CommandLineResult.NONE;
		private Graphics g;

		private string _text = "";

		private bool isLoad = false;

		public new string Text
		{
			get
			{
				return _text;
			}
			set
			{
				_text = value;

				using (BufferedGraphics bG = BufferedGraphicsManager.Current.Allocate(g, ClientRectangle))
				{
					bG.Graphics.Clear(Color.White);
					bG.Graphics.DrawString(_text, new Font("맑은 고딕", 11), new SolidBrush(Color.Black), new PointF(10, 655));
					bG.Render(g);
				}
			}
		}

		public LogoScene()
		{
			try
			{
				InitializeComponent();

				g = CreateGraphics();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void Go()
		{
			try
			{
				if (res == RTCore.Environment.CommandLineResult.TRAP)
					SceneManager.SetScene(new FakeScene(), AccessManager.AccessKey);
				else if (res == RTCore.Environment.CommandLineResult.PICK_ICO)
					SceneManager.SetScene(new PickIconScene(), AccessManager.AccessKey);

				SceneManager.SetScene(new MainMenuScene(), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			try
			{
				timer.Stop();

				if (!isLoad)
				{
					BackgroundWorker bw = new BackgroundWorker();
					bw.DoWork += delegate
					{
						res = RTCore.Environment.InitRouteTycoon(this);
					};
					bw.RunWorkerCompleted += delegate
					{
						LoadCompleted = true;
					};
					bw.RunWorkerAsync();
					isLoad = true;
					timer.Start();
					return;
				}

				if (LoadCompleted)
				{
					Go();
				}
				else
				{
					BackgroundWorker bw = new BackgroundWorker();
					bw.DoWork += delegate
					{
						while (true)
							if (LoadCompleted)
								break;
					};
					bw.RunWorkerCompleted += delegate
					{
						Go();
					};
					bw.RunWorkerAsync();
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
