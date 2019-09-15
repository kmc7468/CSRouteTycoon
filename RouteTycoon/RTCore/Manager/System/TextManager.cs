using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace RouteTycoon.RTCore
{
	public class TextManager
	{
		private Dictionary<string, string> Texts = new Dictionary<string, string>();

		private string _name, _region, _code, _filename = string.Empty;

		public string Name { get { return _name; } }
		public string Region { get { return _region; } }
		public string Code { get { return _code; } }
		public string FileName { get { return _filename; } }

		public string Text(string Key, bool AutoEnter = true, Dictionary<string, string> Parmas = null)
		{
			if (Texts.Keys.ToList().Contains(Key))
			{
				string txt = Texts[Key.ToLower()];
				if (AutoEnter) txt = txt.Replace(@"\n", "\n");
				if(Parmas != null)
					foreach(string it in Parmas.Keys.ToList())
						txt = txt.Replace(it, Parmas[it]);

				return txt;
			}
			else
			{
				LogManager.Add(new Log() { evt = Log.Event.MESSAGE, type = Log.Type.WARNING, Message = $"TextManager - '{Key}' 요청하였으나 값이 없어 <null> 값 return." });
				return "<null>";
			}
		}

		public void Set(string filename, bool DefaultLoad = false)
		{
			try
			{
				XmlDocument doc = new XmlDocument();

				if(!DefaultLoad)
				{
					if (Environment.DeveloperMode)
					{
						filename = filename.Replace(".txf", ".xml");
						doc.Load(".\\data\\langs\\" + filename);
					}
					else
					{
						using (StreamReader sr = new StreamReader(ResourceManager.Get(".\\data\\langs\\" + filename, "lang.xml", 6, 3, 2, 1), Encoding.Default))
						{
							doc.LoadXml(sr.ReadToEnd());
						}
					}
				}else
				{
					using (StreamReader sr = new StreamReader(ResourceManager.Get(".\\data\\langs\\" + filename, "lang.xml", 6, 3, 2, 1), Encoding.Default))
					{
						doc.LoadXml(sr.ReadToEnd());
					}
				}

				XmlNode root = doc.SelectNodes("Texts")[0];
				_name = root.SelectNodes("Name")[0].InnerText;
				_region = root.SelectNodes("Region")[0].InnerText;
				_code = root.SelectNodes("Code")[0].InnerText;

				Texts.Clear();

				foreach (XmlNode it in root.SelectNodes("Text"))
				{
					string key = it.Attributes["Key"].Value.ToLower();
					string value = it.Attributes["Value"].Value;

					Texts.Add(key, value);
				}

				_filename = filename;
			}
			catch(Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private static TextManager _Instance = null;
		public static TextManager Get()
		{
			try
			{
				if (_Instance == null)
					_Instance = new TextManager();

				return _Instance;
			}
			catch(Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
				return null;
			}
		}
	}
}
