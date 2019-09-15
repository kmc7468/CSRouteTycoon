using System;
using System.Collections.Generic;

namespace RouteTycoon.RTCore
{
	public class AchievementManager
	{
		private static List<Achievement> _acs = new List<Achievement>();

		public static List<Achievement> Achievements
		{
			get
			{
				return _acs;
			}
		}

		internal static void Init()
		{
			try
			{
				_acs.Clear();

				_acs.Add(new Achievement(new Base.FirstMove()));
				_acs.Add(new Achievement(new Base.FirstRoute()));
				_acs.Add(new Achievement(new Base.Income50000000()));

				Load();
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private static void Load()
		{
			try
			{
				foreach (string it in System.IO.Directory.GetFiles(".\\data\\achievements"))
				{
					if (System.IO.Path.GetExtension(it) == ".dll")
					{
						Achievement a = new Achievement();

						a.Load(it);

						bool same = false;
						string same_dev = "";

						foreach(var ac in _acs)
						{
							if(ac.Plugin.Name == a.Plugin.Name)
							{
								same = true;
								same_dev = ac.Plugin.Developer;
								break;
							}
						}

						if (same)
							throw new AchievementCrashException(a.Name, same_dev, a.Plugin.Developer);

						_acs.Add(a);
					}
				}
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		internal static bool Update()
		{
			try
			{
				bool ret = false;

				foreach(var it in Achievements)
				{
					if(!it.Clear) // 도전과제 미 달성시
					{
						if(it.Plugin.isClear()) // 도전과제 플러그인에서 클리어 했는지 함수를 통해 받아오고 true 면
						{
							it.Clear = true; // 클리어 했다고 처리하고
							it.Plugin.Reward(); // 보상 함수 실행
							ret = true;
						}
					}
				}

				return ret;
			}
			catch (Exception EX)
			{
				Environment.ReportError(EX, AccessManager.AccessKey);
				return false;
			}
		}
	}
}