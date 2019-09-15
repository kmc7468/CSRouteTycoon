using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace RTLangTool
{
	internal class TextManager
	{
		private Dictionary<string, string> _Texts = new Dictionary<string, string>();
		public Dictionary<string, string> Texts
		{
			get { return _Texts; }
		}

		private string _name, _region, _code = string.Empty;

		public string Name { get { return _name; } }
		public string Region { get { return _region; } }
		public string Code { get { return _code; } }

		public void Set(string url)
		{
			XmlDocument doc = new XmlDocument();

			doc.LoadXml(File.ReadAllText(url));

			XmlNode root = doc.SelectNodes("/Texts")[0];
			_name = root.SelectNodes("Name")[0].Value;
			_region = root.SelectNodes("Region")[0].Value;
			_code = root.SelectNodes("Code")[0].Value;

			Texts.Clear();

			foreach (XmlNode it in root.SelectNodes("Text"))
			{
				string key = it.Attributes["Key"].Value;
				string value = it.Attributes["Value"].Value;

				Texts.Add(key, value);
			}
		}

		public void SetByString(string str)
		{
			XmlDocument doc = new XmlDocument();

			doc.LoadXml(str);

			XmlNode root = doc.SelectNodes("/Texts")[0];
			_name = root.SelectNodes("Name")[0].InnerText;
			_region = root.SelectNodes("Region")[0].InnerText;
			_code = root.SelectNodes("Code")[0].InnerText;

			Texts.Clear();

			foreach (XmlNode it in root.SelectNodes("Text"))
			{
				string key = it.Attributes["Key"].Value;
				string value = it.Attributes["Value"].Value;

				Texts.Add(key, value);
			}
		}

		public void ChangeTextsByList(List<string> key, List<string> value)
		{
			Texts.Clear();

			int i = 0;
			foreach(var k in key)
			{
				Texts.Add(k, value[i]);
				i++;
			}
		}

		public void Save(string path, string name, string region, string code)
		{
			XmlDocument xml = new XmlDocument();

			XmlNode root = xml.CreateElement("Texts");
			XmlNode xml_name = xml.CreateElement("Name");
			xml_name.InnerText = name;
			XmlNode xml_region = xml.CreateElement("Region");
			xml_region.InnerText = region;
			XmlNode xml_code = xml.CreateElement("Code");
			xml_code.InnerText = code;
			root.AppendChild(xml_name);
			root.AppendChild(xml_region);
			root.AppendChild(xml_code);

			foreach(var it in Texts)
			{
				XmlNode text = xml.CreateElement("Text");
				XmlAttribute key = xml.CreateAttribute("Key");
				key.Value = it.Key;
				XmlAttribute value = xml.CreateAttribute("Value");
				value.Value = it.Value;
				text.Attributes.Append(key);
				text.Attributes.Append(value);
				root.AppendChild(text);
			}

			xml.Save(path);
		}

		private static TextManager _Instance = null;
		public static TextManager Get()
		{
			if (_Instance == null)
				_Instance = new TextManager();

			return _Instance;
		}
	}
}
