using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;

namespace RouteTycoon.RTCore
{
	public static class SceneManager
	{
		internal static RTUI.frmMain MainForm = null;
		private static Scene nowscene = null;
		private static bool isPlay = false;
		private static bool isMain = false;
		private static SoundPlayer player = new SoundPlayer();

		public static void SetScene(Scene scene, string password = "")
		{
			try
			{
				if (password != AccessManager.AccessKey)
				{
					if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.SceneManager_SetScene))
						throw new UnabletoAccessPermission();
				}

				if (nowscene is RTUI.FakeScene)
				{
					return;
				}
				else if (nowscene is RTUI.PickIconScene)
				{
					return;
				}

				Scene ctrl = scene;
				Scene oldscene = nowscene;

				ctrl.Size = new Size(980, 680);
				ctrl.Location = new Point(0, 0);

				if (MainForm.Controls.Count != 0)
					if (MainForm.Controls[0] is Scene)
						(MainForm.Controls[0] as Scene).OnClosed();

				MainForm.Controls.Clear();
				MainForm.Controls.Add(ctrl);
				nowscene = ctrl;

				LogManager.SetScene(scene as Scene);

				if (ctrl is RTUI.FakeScene)
				{
					if (oldscene != null) oldscene.Dispose();
					return;
				}
				else if (ctrl is RTUI.PickIconScene)
				{
					if (oldscene != null) oldscene.Dispose();
					return;
				}

				if (OptionManager.Get().Sound)
				{
					if (!isMain)
					{
						if (scene is RTUI.LogoScene)
						{

						}
						else
						{
							if (isPlay && scene is PlayScene) return;
							player.Stop();
							if (player.Stream != null)
							{
								player.Stream.Close();
								player.Stream.Dispose();
							}
							player.Stream = ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\sounds.npk", "main.wav", 5, 7, 1, 6);
							player.PlayLooping();
							isMain = true;
							return;
						}
					}
					else
					{
						if (scene is PlayScene)
						{
							player.Stop();
							if (player.Stream != null)
							{
								player.Stream.Close();
								player.Stream.Dispose();
							}
							isMain = false;
							isPlay = false;
						}
						else return;
					}

					if (!isPlay)
					{
						if (scene is PlayScene)
						{
							player.Stop();
							if (player.Stream != null)
							{
								player.Stream.Close();
								player.Stream.Dispose();
							}
							player.Stream = ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\sounds.npk", "play.wav", 5, 7, 1, 6);
							player.PlayLooping();
							isPlay = true;
						}
					}
					else
					{
						if (scene is PlayScene)
						{

						}
						else
						{
							player.Stop();
							if (player.Stream != null)
							{
								player.Stream.Close();
								player.Stream.Dispose();
							}
							isPlay = false;
						}
					}
				}
				else
				{
					player.Stop();
					if (player.Stream != null)
					{
						player.Stream.Close();
						player.Stream.Dispose();
					}
					isMain = false;
					isPlay = false;
				}

				#region SoundManager 식 소리 처리 (현재 주석 처리)
				// sounds.npk 에 xml 로 거기에 재생목록 저장, SoundManager 에서 재생목록을 바탕으로 재생
				// 하지만 실패 (...) 추후 해결 방법을 알게 되면 수정할 것.

				//if (OptionManager.Get().Sound)
				//{
				//	if(!isPlay)
				//	{
				//		isPlay = true;

				//		//sound = new BackgroundWorker();
				//		//sound.WorkerSupportsCancellation = true;
				//		//sound.DoWork += delegate
				//		//{
				//			SoundManager.Start(SoundManager.PlayType.MAIN);
				//		//	return;
				//		//};
				//		//sound.RunWorkerAsync();

				//		if (oldscene != null) oldscene.Dispose();
				//		return;
				//	}

				//	if (oldscene is PlayScene)
				//	{
				//		if (nowscene is PlayScene)
				//		{
				//			// 무 필요
				//		}
				//		else
				//		{
				//			// 기존: play + 현재: def

				//			SoundManager.Stop();
				//			//sound = new BackgroundWorker();
				//			//sound.WorkerSupportsCancellation = true;
				//			//sound.DoWork += delegate
				//			//{
				//				SoundManager.Start(SoundManager.PlayType.MAIN);
				//				//return;
				//			//};
				//			//sound.RunWorkerAsync();

				//			if (oldscene != null) oldscene.Dispose();
				//			return;
				//		}
				//	}

				//	if (oldscene is PlayScene)
				//	{
				//		// 무 필요
				//	}
				//	else
				//	{
				//		if(nowscene is PlayScene)
				//		{
				//                        // 기존: def + 현재: play

				//                        SoundManager.Stop();
				//                        //sound = new BackgroundWorker();
				//                        //sound.WorkerSupportsCancellation = true;
				//                        //sound.DoWork += delegate
				//                        //{
				//                        SoundManager.Start(SoundManager.PlayType.PLAY);
				//				//return;
				//			//};
				//			//sound.RunWorkerAsync();

				//			if (oldscene != null) oldscene.Dispose();
				//			return;
				//		}
				//	}
				//}
				//else
				//{
				//	SoundManager.Stop();
				//}
				#endregion

				if (oldscene != null) oldscene.Dispose();
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public static Scene GetNowScene(string password = "")
		{
			if (password != AccessManager.AccessKey)
			{
				if (!AccessManager.GetPluginPermission(AccessManager.PluginPermission.SceneManager_GetScene))
					throw new UnabletoAccessPermission();
			}

			return nowscene;
		}
	}
}