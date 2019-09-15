using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RouteTycoon.RTCore
{
	internal static class SoundManager
	{
		private static List<string> Main = new List<string>();
		private static int Main_Inx = 0;

		private static List<string> Play = new List<string>();
		private static int Play_Inx = 0;

		private static System.Media.SoundPlayer player = new System.Media.SoundPlayer();

		public static void Init()
		{
			try
			{
				player.Stop();

				Main_Inx = 0;
				Play_Inx = 0;

				Main = new List<string>();
				Play = new List<string>();

				player.Dispose();
				player = new System.Media.SoundPlayer();

				using (StreamReader sr = new StreamReader(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\sounds.npk", "sounds.xml", 5, 7, 1, 6), Encoding.Default))
				{
					XmlDocument xml = new XmlDocument();
					xml.LoadXml(sr.ReadToEnd());

					XmlNode sounds = xml.SelectNodes("Sounds")[0];

					XmlNode main = sounds.SelectNodes("Main")[0];
					foreach (XmlNode it in main.SelectNodes("Sound"))
					{
						Main.Add(it.Attributes["Name"].Value);
					}

					XmlNode play = sounds.SelectNodes("Play")[0];
					foreach (XmlNode it in play.SelectNodes("Sound"))
					{
						Play.Add(it.Attributes["Name"].Value);
					}
				}
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public async static void Stop()
		{
			try
			{
				await Task.Delay(100);

				var t = Task.Run(() => _Stop());
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private static void _Stop()
		{
			try
			{
				player.Stop();
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public static async void Start(PlayType pt)
		{
			try
			{
				await Task.Delay(100);

				var t = Task.Run(() => _Start(pt));
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private static void _Start(PlayType pt)
		{
			try
			{
				if (pt == PlayType.MAIN)
				{
					while (true)
					{
						player.Stream = ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\sounds.npk", Main[Main_Inx], 5, 7, 1, 6);
						player.PlaySync();

						Main_Inx++;
						if (Main_Inx == Main.Count) Main_Inx = 0;
					}
				}
				else
				{
					while (true)
					{
						player.Stream = ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\sounds.npk", Play[Play_Inx], 5, 7, 1, 6);
						player.PlaySync();

						Play_Inx++;
						if (Play_Inx == Play.Count) Play_Inx = 0;
					}
				}
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public enum PlayType
		{
			MAIN,
			PLAY
		}
	}
}
