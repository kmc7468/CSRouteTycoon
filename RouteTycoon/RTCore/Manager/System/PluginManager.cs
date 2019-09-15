using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RouteTycoon.RTCore.Plugin;
using System.Windows.Forms;
using System.IO;

namespace RouteTycoon.RTCore
{
	public class PluginManager
	{
		private static List<IPlugin> _plugins = new List<IPlugin>();
		private static List<IPluginMain> _pluginmains = new List<IPluginMain>();

		private static List<IGamePlugin> _gameplugs = new List<IGamePlugin>();
		private static List<ILogPlugin> _logplugs = new List<ILogPlugin>();

		public static void RegistryPlugin(IPlugin plug)
		{
			try
			{
				_plugins.Add(plug);
			}
			catch (Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
			}
		}

		public static void RegistryPlugin(IGamePlugin plug)
		{
			try
			{
				_gameplugs.Add(plug);
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public static void RegistryPlugin(ILogPlugin plug)
		{
			try
			{
				_logplugs.Add(plug);
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public static void RemovePlugin(IPlugin plug)
		{
			try
			{
				_plugins.Remove(plug);
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public static void RemovePlugin(IGamePlugin plug)
		{
			try
			{
				_gameplugs.Remove(plug);
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public static void RemovePlugin(ILogPlugin plug)
		{
			try
			{
				_logplugs.Remove(plug);
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public static IPlugin FindPluginByName(string name)
		{
			try
			{
				return _plugins.FirstOrDefault(x => x.Name == name);
			}
			catch (Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
				return null;
			}
		}

		internal static T CreateObject<T>(string file, string type) where T : class
		{
			try
			{
				return (T)Assembly.LoadFile(file).GetType(type, true, true).GetConstructor(new Type[0]).Invoke(new object[0]);
			}
			catch (Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
				return null;
			}
		}

		public static List<IPlugin> GetPluginList()
		{
			List<IPlugin> r = new List<IPlugin>();

			foreach (var it in _plugins)
				r.Add(it);

			return r;
		}

		public static List<IPluginMain> GetPluginMainList()
		{
			List<IPluginMain> r = new List<IPluginMain>();

			foreach (var it in _pluginmains)
				r.Add(it);

			return r;
		}

		public static List<IGamePlugin> GetGamePluginList()
		{
			List<IGamePlugin> r = new List<IGamePlugin>();

			foreach (var it in _gameplugs)
				r.Add(it);

			return r;
		}

		public static List<ILogPlugin> GetLogPluginList()
		{
			List<ILogPlugin> r = new List<ILogPlugin>();

			foreach (var it in _logplugs)
				r.Add(it);

			return r;
		}

		private static void LoadRTM(string name)
		{
			try
			{
				IPluginMain main = CreateObject<IPluginMain>(name, Assembly.LoadFile(name).GetName().Name + ".PluginMain");

				main.Startup();

				_pluginmains.Add(main);
			}
			catch (Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
			}
		}

		internal static void Shutdown()
		{
			foreach (var main in _pluginmains)
				main.Shutdown();
		}

		internal static void NewGame()
		{
			LogManager.Add(new Log() { type = Log.Type.INFORMATION, evt = Log.Event.MESSAGE, Message = $@"GameManager - 새 게임을 만듬\n회사 명: {GameManager.Company.Name}\n파일 명: {GameManager.Filename}" });
			foreach (var main in _gameplugs)
				main.NewGame();
		}

		internal static void LoadGame()
		{
			LogManager.Add(new Log() { type = Log.Type.INFORMATION, evt = Log.Event.MESSAGE, Message = $@"GameManager - 게임을 불러옴\n회사 명: {GameManager.Company.Name}\n파일 명: {GameManager.Filename}" });
			foreach (var main in _gameplugs)
				main.LoadGame();
		}

		internal static void SaveGame()
		{
			LogManager.Add(new Log() { type = Log.Type.INFORMATION, evt = Log.Event.MESSAGE, Message = $@"GameManager - 게임을 저장함\n회사 명: {GameManager.Company.Name}\n파일 명: {GameManager.Filename}" });
			foreach (var main in _gameplugs)
				main.SaveGame();
		}

		internal static void Clicked(object sender, EventArgs e)
		{
			foreach (var main in _logplugs)
				main.Clicked(sender, e);
		}

		internal static void KeyPress(object sender, KeyPressEventArgs e)
		{
			foreach (var main in _logplugs)
				main.KeyPress(sender, e);
		}

		#region Game

		// Route

		internal static void AddedRoute(Route route)
		{
			string way = "";
			foreach (var it in route.Stations)
			{
				way += it.Name + " - ";
			}
			way = way.Remove(way.Length - 4, 3);
			LogManager.Add(new Log() { type = Log.Type.INFORMATION, evt = Log.Event.MESSAGE, Message = $@"GameManager - 노선이 건설 됨\n노선 명: {route.Name}\n구간: {way}" });
			foreach (var main in _gameplugs)
				main.RouteAdded(new RouteEventArgs() { Route = route });
		}

		internal static void DeletedRoute(Route route)
		{
			LogManager.Add(new Log() { type = Log.Type.INFORMATION, evt = Log.Event.MESSAGE, Message = $@"GameManager - 노선이 폐선 됨\n노선 명: {route.Name}" });
			foreach (var main in _gameplugs)
				main.RouteDeleted(new RouteEventArgs() { Route = route });
		}

		// Station

		internal static void AddedStation(Station sta)
		{
			LogManager.Add(new Log() { type = Log.Type.INFORMATION, evt = Log.Event.MESSAGE, Message = $@"GameManager - 역이 건설 됨\n역명: {sta.Name}\n위치: {sta.Parent.Parent.Name}.{sta.Parent.Name}" });
			foreach (var main in _gameplugs)
				main.StationAdded(new StationEventArgs() { Station = sta });
		}

		internal static void DeletedStation(Station sta)
		{
			LogManager.Add(new Log() { type = Log.Type.INFORMATION, evt = Log.Event.MESSAGE, Message = $@"GameManager - 역이 철거 됨\n역명: {sta.Name}\n위치: {sta.Parent.Parent.Name}.{sta.Parent.Name}" });
			foreach (var main in _gameplugs)
				main.StationDeleted(new StationEventArgs() { Station = sta });
		}

		// Train

		internal static void BoughtTrain(Train train)
		{
			LogManager.Add(new Log() { type = Log.Type.INFORMATION, evt = Log.Event.MESSAGE, Message = $@"GameManager - 열차를 구입함\n이름: {train.Name}\n데이터명: {train.Data.Name}" });
			foreach (var main in _gameplugs)
				main.TrainBought(new TrainEventArgs() { Train = train });
		}

		internal static void SoldTrain(Train train)
		{
			LogManager.Add(new Log() { type = Log.Type.INFORMATION, evt = Log.Event.MESSAGE, Message = $@"GameManager - 열차를 판매함\n이름: {train.Name}\n데이터명: {train.Data.Name}" });
			foreach (var main in _gameplugs)
				main.TrainBought(new TrainEventArgs() { Train = train });
		}

		internal static void InputedTrain(Train train, Route route)
		{
			LogManager.Add(new Log() { type = Log.Type.INFORMATION, evt = Log.Event.MESSAGE, Message = $@"GameManager - 열차를 투입함\n이름: {train.Name}\n데이터명: {train.Data.Name}\n투입된 노선 명: {route.Name}" });
			foreach (var main in _gameplugs)
				main.TrainInputed(new TrainInputedEventArgs() { Train = train, InputRoute = route });
		}

		internal static void OutputedTrain(Train train, Route route)
		{
			LogManager.Add(new Log() { type = Log.Type.INFORMATION, evt = Log.Event.MESSAGE, Message = $@"GameManager - 열차를 투입 해제 함\n이름: {train.Name}\n데이터명: {train.Data.Name}\n투입 해제된 노선 명: {route.Name}" });
			foreach (var main in _gameplugs)
				main.TrainOutputed(new TrainOutputedEventArgs() { Train = train, OutputRoute = route });
		}

		internal static void AddedTrainData(TrainData data)
		{
			LogManager.Add(new Log() { type = Log.Type.INFORMATION, evt = Log.Event.MESSAGE, Message = $@"GameManager - 열차 편성을 만듬\n편성 명: {data.Name}\n구입 비: {data.Price.ToString()}\n수송력: {data.Carrying.ToString()}" });
			foreach (var main in _gameplugs)
				main.TrainDataAdded(new TrainDataAddedEventArgs() { Data = data });
		}

		// Bank

		internal static void Loaned(decimal value)
		{
			LogManager.Add(new Log() { type = Log.Type.INFORMATION, evt = Log.Event.MESSAGE, Message = $@"GameManager - {string.Format("{0:n0}", value)}RTW 만큼 대출함" });
			foreach (var main in _gameplugs)
				main.Loan(new LoanEventArgs() { Value = value });
		}

		internal static void ClearedLoan(decimal value)
		{
			LogManager.Add(new Log() { type = Log.Type.INFORMATION, evt = Log.Event.MESSAGE, Message = $@"GameManager - {string.Format("{0:n0}", value)}RTW 만큼 값음" });
			foreach (var main in _gameplugs)
				main.ClearLoan(new LoanEventArgs() { Value = value });
		}

		internal static void DepositedBankBook(decimal value)
		{
			LogManager.Add(new Log() { type = Log.Type.INFORMATION, evt = Log.Event.MESSAGE, Message = $@"GameManager - {string.Format("{0:n0}", value)}RTW 만큼 입금함" });
			foreach (var main in _gameplugs)
				main.DepositBankBook(new BankBookEventArgs() { Value = value });
		}

		internal static void WithdrawedBankBook(decimal value)
		{
			LogManager.Add(new Log() { type = Log.Type.INFORMATION, evt = Log.Event.MESSAGE, Message = $@"GameManager - {string.Format("{0:n0}", value)}RTW 만큼 출금함" });
			foreach (var main in _gameplugs)
				main.WithdrawBankBook(new BankBookEventArgs() { Value = value });
		}
		#endregion

		internal static void SceneLoad(Scene scene)
		{
			foreach (var main in _logplugs)
				main.SceneLoad(scene, null);
		}

		internal static void PageLoad(Page page)
		{
			foreach (var main in _logplugs)
				main.PageLoad(page, null);
		}

		internal static void LoadPlugins()
		{
			try
			{
				foreach (string str in Directory.GetFiles(Application.StartupPath + "\\data\\plugins"))
				{
					if (Path.GetExtension(str) == ".rtp")
						LoadRTM(str);
				}
			}
			catch (Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
			}
		}
	}
}
