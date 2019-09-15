using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace RouteTycoon.RTCore
{
	public static class LogManager
	{
		private static bool isSaved = false;

		private static Scene _form = null;
		private static Page _page = null;

		private static List<Log> _logs = new List<Log>();

		internal static void SetScene(Scene frm)
		{
			try
			{
				Timer wait = new Timer();
				wait.Interval = 500;
				wait.Tick += delegate
				{
					wait.Stop();

					if (_form != null)
					{
						_form.KeyPress -= _frm_KeyPress;
						_form.MouseClick -= _frm_MouseClick;

						foreach (Control c in _form.Controls)
							c.Click -= _frm_Click;
					}

					_form = frm;
					frm.KeyPress += _frm_KeyPress;
					frm.MouseClick += _frm_MouseClick;
					foreach (Control c in frm.Controls)
					{
						c.Click += _frm_Click;
					}

					Timer tm = new Timer();
					tm.Interval = 10;
					tm.Tick += delegate
					{
						tm.Stop();

						_logs.Add(new Log() { evt = Log.Event.SCENE_LOAD, type = Log.Type.INFORMATION, Message = frm.Name });
						isSaved = false;

						PluginManager.SceneLoad(frm);

						tm.Dispose();
					};

					tm.Start();
					wait.Dispose();
				};

				wait.Start();
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		internal static void SetPage(Page frm)
		{
			try
			{
				if (_form != null)
				{
					_form.KeyPress -= _frm_KeyPress;
					_form.MouseClick -= _frm_MouseClick;

					foreach (Control c in _form.Controls)
						c.Click -= _frm_Click;
				}

				_page = frm;
				frm.KeyPress += _frm_KeyPress;
				frm.MouseClick += _frm_MouseClick;
				foreach (Control c in frm.Controls)
				{
					c.Click += _frm_Click;
				}

				Timer tm = new Timer();
				tm.Interval = 10;
				tm.Tick += delegate
				{
					tm.Stop();

					_logs.Add(new Log() { evt = Log.Event.PAGE_LOAD, type = Log.Type.INFORMATION, Message = frm.Name });
					isSaved = false;

					PluginManager.PageLoad(frm);

					tm.Dispose();
				};

				tm.Start();
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		internal static void _use_Cheat(string CheatKey)
		{
			try
			{
				_logs.Add(new Log() { evt = Log.Event.USE_CHEAT, Message = CheatKey });
				isSaved = false;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		internal static void _use_Command(string CommandKey)
		{
			try
			{
				_logs.Add(new Log() { evt = Log.Event.USE_COMMAND, Message = CommandKey });
				isSaved = false;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		internal static void _frm_Click(object sender, EventArgs e)
		{
			try
			{
				_logs.Add(new Log() { evt = Log.Event.CLICK, type = Log.Type.INFORMATION, ctrl = sender as System.Windows.Forms.Control });
				isSaved = false;

				PluginManager.Clicked(sender, e);
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		internal static void _frm_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			try
			{
				_logs.Add(new Log() { evt = Log.Event.MOUSE_CLICK, type = Log.Type.INFORMATION, MouseEventArgs = e, ctrl = sender as System.Windows.Forms.Control });
				isSaved = false;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		internal static void _frm_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			try
			{
				_logs.Add(new Log() { evt = Log.Event.KEY_PRESS, type = Log.Type.INFORMATION, Message = e.KeyChar.ToString() });
				isSaved = false;

				PluginManager.KeyPress(sender, e);
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		internal static void ExceptMessage(Exception e)
		{
			try
			{
				_logs.Add(new Log() { evt = Log.Event.THROW, type = Log.Type.ERROR, exp = e });
				isSaved = false;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public static void Add(Log log)
		{
			try
			{
				Timer tm = new Timer();
				tm.Interval = 100;
				tm.Tick += delegate
				{
					tm.Stop();

					_logs.Add(log);
					isSaved = false;

					tm.Dispose();
				};

				tm.Start();
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public static void Save(string filename)
		{
			try
			{
				if (isSaved) return;

				using (BinaryWriter sw = new BinaryWriter(File.Open(filename, FileMode.Create)))
				{
					OperatingSystem os = System.Environment.OSVersion;

					sw.Write(os.Platform.ToString());
					sw.Write(os.Version.ToString());
					sw.Write(os.ServicePack);
					sw.Write(os.VersionString);
					sw.Write(System.Environment.Version.ToString());
					sw.Write(System.Environment.Is64BitOperatingSystem);

					string subKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows NT\CurrentVersion";
					RegistryKey key = Registry.LocalMachine;
					RegistryKey skey = key.OpenSubKey(subKey);
					sw.Write(skey.GetValue("ProductName").ToString());

					sw.Write(Environment.Version);
					sw.Write(Environment.DebugMode);
					sw.Write(Application.ExecutablePath);

					sw.Write(_logs.Count);

					foreach (Log log in _logs)
					{
						sw.Write((int)log.type);
						sw.Write((int)log.evt);

						if (log.evt == Log.Event.THROW)
						{
							sw.Write(log.exp.ToString());
						}
						else if (log.evt == Log.Event.MOUSE_CLICK)
						{
							sw.Write(log.MouseEventArgs.Button.ToString());
							sw.Write(log.ctrl.Name);
							sw.Write(log.MouseEventArgs.X);
							sw.Write(log.MouseEventArgs.Y);
						}
						else if (log.evt == Log.Event.KEY_PRESS)
						{
							sw.Write(log.Message);
						}
						else if (log.evt == Log.Event.SCENE_LOAD)
						{
							sw.Write(log.Message);
						} else if (log.evt == Log.Event.PAGE_LOAD)
						{
							sw.Write(log.Message);
						}
						else if (log.evt == Log.Event.WEBBROWSER)
						{
							sw.Write(log.Message);
						}
						else if (log.evt == Log.Event.CLICK)
						{
							string res = "";
							Control par = log.ctrl;
							bool first = true;
							while (par != null)
							{
								if (first)
								{
									res = log.ctrl.Name;
								}
								else
									res = par.Name + "." + res;

								par = par.Parent;
								first = false;
							}
							sw.Write(res);
						}
						else if (log.evt == Log.Event.USE_CHEAT)
						{
							sw.Write(log.Message);
						}else if (log.evt == Log.Event.USE_COMMAND)
						{
							sw.Write(log.Message);
						}else if (log.evt == Log.Event.MESSAGE)
						{
							sw.Write(log.Message);
						}
					}

					isSaved = true;
				}
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
