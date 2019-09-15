using System;
using System.Collections.Generic;
using System.IO;

namespace RouteTycoon.RTCore
{
	public static class NewsManager
	{
		private static List<News> _news = new List<News>();

		public static List<News> News
		{
			get { return _news; }
		}

		internal static void Init()
		{
			try
			{
				_news.Clear();

				_news.Add(new News(new Base.Bankruptcy()));
				_news.Add(new News(new Base.Mansour()));
				_news.Add(new News(new Base.OpeningRoute()));
				_news.Add(new News(new Base.IncomeUp()));
				_news.Add(new News(new Base.IncomeDown()));
				_news.Add(new News(new Base.NewCompany()));

				Load();
			}catch(Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private static void Load()
		{
			try
			{
				foreach (string filename in Directory.GetFiles(".\\data\\news"))
				{
					if (Path.GetExtension(filename) == ".dll")
					{
						News news = new News();

						news.Load(filename);

						news.Plugin.AlreadyDo = false;

						string same_dev = "";
						bool same = false;

						foreach(var it in _news)
						{
							if(it.Plugin.Name == news.Plugin.Name)
							{
								same = true;
								same_dev = it.Plugin.Developer;
								break;
							}
						}

						if(same)
							throw new NewsCrashException(news.Plugin.Name, same_dev, news.Plugin.Developer);

						News.Add(news);
					}
				}
			}
			catch (Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
			}
		}

		internal static bool Update()
		{
			try
			{
				bool ret = false;

				foreach (News it in _news)
				{
					if (it.Plugin.IsAvailable() && !it.Plugin.AlreadyDo)
					{
						ret = true;
						it.Plugin.Update();

						it.Plugin.AlreadyDo = true;

						NEWS_SAV n = new NEWS_SAV();

						n.Data = it;
						n.Message = it.Message;
						n.Time = GameManager.Time;

						GameManager.News.Add(n);
					}
				}

				return ret;
			}
			catch(Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
				return false;
			}
		}
	}
}
