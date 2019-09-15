using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RouteTycoon.RTCore;
using RouteTycoon.RTAPI;

namespace RouteTycoon.RTUI
{
	internal partial class UpdateingScene : Scene
	{
		private VersionInfoParmas vi;
		private string backname = "";

		public UpdateingScene(VersionInfoParmas parm)
		{
			try
			{
				InitializeComponent();

				vi = parm;

				BackgroundImage = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "main_background.png", 5, 7, 1, 6));

				pbProgress.Font = new Font(RTCore.Environment.Font, 30);
				pbProgress.ForeColor = ResourceManager.Get("setting.update.progressbar.caption");
				pbProgress.InnerCircleColor = ResourceManager.Get("setting.update.progressbar.backcolor");
				pbProgress.ProgressCircleColor = ResourceManager.Get("setting.update.progressbar.bar");
				if (vi.InstallData)
					pbProgress.MaxValue = 300;
				else
					pbProgress.MaxValue = 200;

				lbProgress.ForeColor = ResourceManager.Get("setting.update.textprogress");
				lbProgress.Font = new Font(RTCore.Environment.Font, 20);
				SetProgressText(TextManager.Get().Text("readyupdate"));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void SetProgressText(string caption)
		{
			try
			{
				lbProgress.Text = caption;
				Size p_size = RTCore.Environment.CalcStringSize(caption, new Font(RTCore.Environment.Font, 20));
				Point p_loc = RTCore.Environment.CalcRectangle(new Point(Width / 2, lbProgress.Location.Y + (lbProgress.Height / 2)), p_size).Location.ToPoint();
				lbProgress.Location = p_loc;
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void GoUpdate()
		{
			try
			{
				if (System.IO.File.Exists(".\\RouteTycoon.bak"))
					System.IO.File.Delete(".\\RouteTycoon.bak");
				if (System.IO.File.Exists(".\\RTRM.bak"))
					System.IO.File.Delete(".\\RTRM.bak");

				if (System.IO.File.Exists(".\\RouteTycoon.exe"))
					System.IO.File.Move(".\\RouteTycoon.exe", ".\\RouteTycoon.bak");
				if (System.IO.File.Exists(".\\RTRM.dll"))
					System.IO.File.Move(".\\RTRM.dll", ".\\RTRM.bak");

				backname = $"RTBACKUP{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.zip";
				if (vi.InstallData)
				{
					System.IO.Compression.ZipFile.CreateFromDirectory(".\\data", RTCore.Environment.Desktop + $"\\{backname}");
				}

				WebClient wc = new WebClient();
				wc.DownloadProgressChanged += exe_prgress;
				wc.DownloadFileCompleted += exe_com;
				wc.DownloadFileAsync(new Uri("https://www.dropbox.com/s/wo1dgyef6ohml6i/RouteTycoon.exe?dl=1"), ".\\RouteTycoon.exe");
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private double ConvertBytesToMegabytes(long bytes)
		{
			double tmp = (bytes / 1024f) / 1024f;

			tmp = Convert.ToDouble(string.Format("{0:n1}", tmp).Replace(",", ""));

			return tmp;
		}

		private void exe_com(object sender, AsyncCompletedEventArgs e)
		{
			try
			{
				WebClient wc = new WebClient();
				wc.DownloadProgressChanged += dll_progress;
				wc.DownloadFileCompleted += dll_completed;
				wc.DownloadFileAsync(new Uri("https://www.dropbox.com/s/79zgudnz3je2eb9/RTRM.dll?dl=1"), ".\\RTRM.dll");
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void dll_completed(object sender, AsyncCompletedEventArgs e)
		{
			try
			{
				if (vi.InstallData)
				{
					WebClient wc = new WebClient();
					wc.DownloadProgressChanged += data_progress;
					wc.DownloadFileCompleted += data_com;
					wc.DownloadFileAsync(new Uri("https://www.dropbox.com/s/bkruilvx539c0fo/data.zip?dl=1"), ".\\data.zip");
				}
				else
				{
					SetProgressText(TextManager.Get().Text("completeddownload"));
					Dictionary<string, string> d = new Dictionary<string, string>();
					d.Add("%PATH%", Application.StartupPath + "\\RouteTycoon.exe");
					MessageBox.Show(TextManager.Get().Text("updateokmsg", true, d), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
					SceneManager.MainForm.ExitGame();
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void data_com(object sender, AsyncCompletedEventArgs e)
		{
			try
			{
				SetProgressText(TextManager.Get().Text("completeddownload"));
				Dictionary<string, string> d = new Dictionary<string, string>();
				d.Add("%PATH%", Application.StartupPath + "\\RouteTycoon.exe");
				d.Add("%BACKUP_PATH%", RTCore.Environment.Desktop + $@"\{backname}");
				MessageBox.Show(TextManager.Get().Text("updateokmsgdatainstall", true, d), "RouteTycoon", MessageBoxButtons.OK, MessageBoxIcon.Information);
				SceneManager.MainForm.ExitGame();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void data_progress(object sender, DownloadProgressChangedEventArgs e)
		{
			try
			{
				Dictionary<string, string> d = new Dictionary<string, string>();
				d.Add("%FILENAME%", "data.zip");
				d.Add("%ALLMB%", string.Format("{0:n1}", ConvertBytesToMegabytes(e.TotalBytesToReceive)));
				d.Add("%PROMB%", string.Format("{0:n1}", ConvertBytesToMegabytes(e.BytesReceived)));

				SetProgressText(TextManager.Get().Text("updatepro", true, d));
				if (vi.InstallData)
				{
					pbProgress.Value = 200 + e.ProgressPercentage;
					pbProgress.Caption = string.Format("{0:n0}", pbProgress.Value / 3) + "%";
				}
				else
				{
					pbProgress.Value = 200 + e.ProgressPercentage;
					pbProgress.Caption = string.Format("{0:n0}", pbProgress.Value / 2) + "%";
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void dll_progress(object sender, DownloadProgressChangedEventArgs e)
		{
			try
			{
				Dictionary<string, string> d = new Dictionary<string, string>();
				d.Add("%FILENAME%", "RTRM.dll");
				d.Add("%ALLMB%", string.Format("{0:n1}", ConvertBytesToMegabytes(e.TotalBytesToReceive)));
				d.Add("%PROMB%", string.Format("{0:n1}", ConvertBytesToMegabytes(e.BytesReceived)));

				SetProgressText(TextManager.Get().Text("updatepro", true, d));
				if (vi.InstallData)
				{
					pbProgress.Value = 100 + e.ProgressPercentage;
					pbProgress.Caption = string.Format("{0:n0}", pbProgress.Value / 3) + "%";
				}
				else
				{
					pbProgress.Value = 100 + e.ProgressPercentage;
					pbProgress.Caption = string.Format("{0:n0}", pbProgress.Value / 2) + "%";
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void exe_prgress(object sender, DownloadProgressChangedEventArgs e)
		{
			try
			{
				Dictionary<string, string> d = new Dictionary<string, string>();
				d.Add("%FILENAME%", "RouteTycoon.exe");
				d.Add("%ALLMB%", string.Format("{0:n1}", ConvertBytesToMegabytes(e.TotalBytesToReceive)));
				d.Add("%PROMB%", string.Format("{0:n1}", ConvertBytesToMegabytes(e.BytesReceived)));

				SetProgressText(TextManager.Get().Text("updatepro", true, d));
				if (vi.InstallData)
				{
					pbProgress.Value = e.ProgressPercentage;
					pbProgress.Caption = string.Format("{0:n0}", pbProgress.Value / 3) + "%";
				}
				else
				{
					pbProgress.Value = e.ProgressPercentage;
					pbProgress.Caption = string.Format("{0:n0}", pbProgress.Value / 2) + "%";
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		bool goupdate = false;

		private void UpdateingScene_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				e.Graphics.FillRectangle(new SolidBrush(ResourceManager.Get("main.rectangle")), new Rectangle(50, 100, Width - 100, Height - 150));

				if (goupdate) return;

				Timer tm = new Timer();
				tm.Interval = 300;
				tm.Tick += delegate
				{
					tm.Stop();
					GoUpdate();
					tm.Dispose();
				};
				goupdate = true;
				tm.Start();
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
