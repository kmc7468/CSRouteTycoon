using RouteTycoon.RTCore;
using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace RouteTycoon.RTUI
{
	internal partial class DeveloperScene : Scene
	{
		public DeveloperScene()
		{
			try
			{
				InitializeComponent();

				if (RTAPI.WebAPI.CheckInternetConnection())
				{
					byte[] d = new WebClient().DownloadData("https://www.dropbox.com/s/vpd4botg9unnegi/credit.png?dl=1");
					MemoryStream ms = new MemoryStream(d);
					BackgroundImage = Image.FromStream(ms);
					ms.Close();
					ms.Dispose();
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
