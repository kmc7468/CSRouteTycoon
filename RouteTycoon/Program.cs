using System;
using Microsoft.VisualBasic.ApplicationServices;
using System.Collections.Generic;
using System.Reflection;

namespace RouteTycoon
{
	class Program : WindowsFormsApplicationBase
	{
		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			if (args.Length > 0)
			{
				RTCore.Environment.CommandLine = args[0];
				for (int i = 1; i < args.Length; i++)
					RTCore.Environment.CommandLine += " " + args[i].ToLower();
			}
			
			AppDomain.CurrentDomain.AssemblyResolve += Assembly_Resolve;
			LoadDll("WinFormAnimation.dll");
			LoadDll("QuizAPI.dll");
			LoadDll("KStringExtension.dll");

			var app = new Program();
			app.EnableVisualStyles = true;
			app.ShutdownStyle = ShutdownMode.AfterAllFormsClose;
			app.MainForm = new RTUI.frmMain();
			app.Run(args);

			if (RTCore.Environment.DebugMode)
				RTCore.LogManager.Save("log.rte");

			RTCore.OptionManager.Get().SaveAll(RTCore.AccessManager.AccessKey);
			RTCore.PluginManager.Shutdown();
		}

		static Dictionary<string, Assembly> dict = new Dictionary<string, Assembly>();
		static bool LoadDll(string path)
		{
			Assembly curAssm = Assembly.GetExecutingAssembly();
			string appName = curAssm.GetName().Name.Replace(" ", "_");
			Assembly dllAssm = null;
			byte[] dllData;
			using (System.IO.Stream s = curAssm.GetManifestResourceStream($"{appName}.{path}"))
			{
				if (s != null)
				{
					dllData = new byte[s.Length];
					s.Read(dllData, 0, (int)s.Length);
					dllAssm = Assembly.Load(dllData);
				}
				else
				{
					return false;
				}
			}
			dict.Add(dllAssm.FullName, dllAssm);
			return true;
		}
		static Assembly Assembly_Resolve(object sender, ResolveEventArgs e)
		{
			if (dict.ContainsKey(e.Name))
			{
				Assembly assm = dict[e.Name];
				dict.Remove(e.Name);
				return assm;
			}
			return null;
		}
	}
}
