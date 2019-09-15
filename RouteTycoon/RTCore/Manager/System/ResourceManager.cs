using RouteTycoon.RTAPI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RouteTycoon.RTCore
{
	public class ResourceManager
	{
		private enum ResourceType
		{
			Image,
		}

		private static Dictionary<ResourceType, Dictionary<string, object>> items = new Dictionary<ResourceType, Dictionary<string, object>>();

		public static MemoryStream Get(string path, string item, int k1, int k2, int k3, int k4)
		{
			try
			{
				string tmp01 = Path.GetFileName(path);

				if (tmp01 == "images.npk")
				{
					if (!items.Keys.ToList().Contains(ResourceType.Image)) items.Add(ResourceType.Image, new Dictionary<string, object>());

					if (items[ResourceType.Image].Keys.ToList().Contains(item))
					{
						return items[ResourceType.Image][item] as MemoryStream;
					}
					else
					{
						var tmp02 = RTRM.ResourceManager.Get(path, item, k1, k2, k3, k4, AccessManager.RTRMPassword);
						items[ResourceType.Image].Add(item, tmp02);
						return tmp02;
					}
				}
				else
				{
					return RTRM.ResourceManager.Get(path, item, k1, k2, k3, k4, AccessManager.RTRMPassword);
				}
			}
			catch (Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
				return null;
			}
		}

		public static MemoryStream Get(string path, string item, string rsa_key)
		{
			try
			{
				int k1 = 0, k2 = 0, k3 = 0, k4 = 0;

				string tmp1 = rsa_key.FromRSAStr("<RSAKeyValue><Modulus>4k1NwPQV+RKuN5Z1RIZYws45sOgeXOx5erQF2X+OVKJ4ilNBCzyoKupC1WPXLboR6oFeYDXC9hwVFCuZe0odzHkxZ1kg4JtOGipDkHV7tt2IItB6SARE3PJ6hc5PU7jw1B1w3FJqQJ3PeVkw/StAG/14oTePLcAa/bb+zaEB7GM=</Modulus><Exponent>AQAB</Exponent><P>8DfS+eFvN+zVIhTrWmylEI3dvWkwP9fBmL4UE1I1r75yKNMekWeinVeMHIbeel19t9iN4CdYf3IBLOTtrptVww==</P><Q>8Sttg59QVKAJbarOtijApjoBQ8u6eJbqmB+uBDIoaYYG5f0IgOT9cYzsa/AQ2BaT/A56aoNpHLyEX3XHCYGE4Q==</Q><DP>wQXKZHnN+Z03gcRXfXhxhoTIWavNVm+TI54Q2ZmkhAw/BSjnliU1WMMBVebVnHPFUlYTYrua9AVyhlWJ21T8Kw==</DP><DQ>Bfj0WlkcrSvVb/DV867ornUrSNmHwarDHodSUOpJE+vsyc9NYZvKJwC9biLg1+kfOxPEtlSQytRkVtTc3ABoIQ==</DQ><InverseQ>Q2PrH8Lxp0lAOzcVWSBTsXC/t6Ypl96sUSwcvTqerGbRVczEqxYKAYWrSrW2y5a1H9kh7fw4HQz/YMJ0iB8cYw==</InverseQ><D>CC0dKo6xvoqEveBomJMMC5nHhCiWyZUHpz3FhQAH+e8sJhSaTILNW/jpH5bttCq9W/jURUCcAdKuQPN5pkvdZgT0aftUaUKvC5gVEalv7YMAvlJzofUhUNNQoSeZD0/Muot9lfQyPdX8D/mlRzvL1ManWobwknxSc7MCs8hdAmE=</D></RSAKeyValue>");

				for (int i = 0; i < 4; i++)
				{
					if (i == 0) k1 = tmp1[i];
					else if (i == 1) k2 = tmp1[i];
					else if (i == 2) k3 = tmp1[i];
					else if (i == 3) k4 = tmp1[i];
					else break;
				}

				return Get(path, item, k1, k2, k3, k4);
			}
			catch (Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
				return null;
			}
		}

		public static void Pack(string filename, Dictionary<string, string> files, int k1, int k2, int k3, int k4)
		{
			try
			{
				RTRM.ResourceManager.Pack(filename, files.Keys.ToList(), files.Values.ToList(), k1, k2, k3, k4, "RTRMPASSWORD-RTHONEYJAM");
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public static void Pack(string filename, Dictionary<string, string> files, string rsa_key)
		{
			try
			{
				int k1 = 0, k2 = 0, k3 = 0, k4 = 0;

				string tmp1 = rsa_key.FromRSAStr("<RSAKeyValue><Modulus>4k1NwPQV+RKuN5Z1RIZYws45sOgeXOx5erQF2X+OVKJ4ilNBCzyoKupC1WPXLboR6oFeYDXC9hwVFCuZe0odzHkxZ1kg4JtOGipDkHV7tt2IItB6SARE3PJ6hc5PU7jw1B1w3FJqQJ3PeVkw/StAG/14oTePLcAa/bb+zaEB7GM=</Modulus><Exponent>AQAB</Exponent><P>8DfS+eFvN+zVIhTrWmylEI3dvWkwP9fBmL4UE1I1r75yKNMekWeinVeMHIbeel19t9iN4CdYf3IBLOTtrptVww==</P><Q>8Sttg59QVKAJbarOtijApjoBQ8u6eJbqmB+uBDIoaYYG5f0IgOT9cYzsa/AQ2BaT/A56aoNpHLyEX3XHCYGE4Q==</Q><DP>wQXKZHnN+Z03gcRXfXhxhoTIWavNVm+TI54Q2ZmkhAw/BSjnliU1WMMBVebVnHPFUlYTYrua9AVyhlWJ21T8Kw==</DP><DQ>Bfj0WlkcrSvVb/DV867ornUrSNmHwarDHodSUOpJE+vsyc9NYZvKJwC9biLg1+kfOxPEtlSQytRkVtTc3ABoIQ==</DQ><InverseQ>Q2PrH8Lxp0lAOzcVWSBTsXC/t6Ypl96sUSwcvTqerGbRVczEqxYKAYWrSrW2y5a1H9kh7fw4HQz/YMJ0iB8cYw==</InverseQ><D>CC0dKo6xvoqEveBomJMMC5nHhCiWyZUHpz3FhQAH+e8sJhSaTILNW/jpH5bttCq9W/jURUCcAdKuQPN5pkvdZgT0aftUaUKvC5gVEalv7YMAvlJzofUhUNNQoSeZD0/Muot9lfQyPdX8D/mlRzvL1ManWobwknxSc7MCs8hdAmE=</D></RSAKeyValue>");

				for (int i = 0; i < 4; i++)
				{
					if (i == 0) k1 = tmp1[i];
					else if (i == 1) k2 = tmp1[i];
					else if (i == 2) k3 = tmp1[i];
					else if (i == 3) k4 = tmp1[i];
					else break;
				}

				RTRM.ResourceManager.Pack(filename, files.Keys.ToList(), files.Values.ToList(), k1, k2, k3, k4, AccessManager.RTRMPassword);
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		public static List<string> Items(string filename, int k1, int k2, int k3, int k4)
		{
			try
			{
				return RTRM.ResourceManager.Items(filename, k1, k2, k3, k4, AccessManager.RTRMPassword);
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
				return null;
			}
		}

		public static List<string> Items(string filename, string rsa_key)
		{
			try
			{
				int k1 = 0, k2 = 0, k3 = 0, k4 = 0;

				string tmp1 = rsa_key.FromRSAStr("<RSAKeyValue><Modulus>4k1NwPQV+RKuN5Z1RIZYws45sOgeXOx5erQF2X+OVKJ4ilNBCzyoKupC1WPXLboR6oFeYDXC9hwVFCuZe0odzHkxZ1kg4JtOGipDkHV7tt2IItB6SARE3PJ6hc5PU7jw1B1w3FJqQJ3PeVkw/StAG/14oTePLcAa/bb+zaEB7GM=</Modulus><Exponent>AQAB</Exponent><P>8DfS+eFvN+zVIhTrWmylEI3dvWkwP9fBmL4UE1I1r75yKNMekWeinVeMHIbeel19t9iN4CdYf3IBLOTtrptVww==</P><Q>8Sttg59QVKAJbarOtijApjoBQ8u6eJbqmB+uBDIoaYYG5f0IgOT9cYzsa/AQ2BaT/A56aoNpHLyEX3XHCYGE4Q==</Q><DP>wQXKZHnN+Z03gcRXfXhxhoTIWavNVm+TI54Q2ZmkhAw/BSjnliU1WMMBVebVnHPFUlYTYrua9AVyhlWJ21T8Kw==</DP><DQ>Bfj0WlkcrSvVb/DV867ornUrSNmHwarDHodSUOpJE+vsyc9NYZvKJwC9biLg1+kfOxPEtlSQytRkVtTc3ABoIQ==</DQ><InverseQ>Q2PrH8Lxp0lAOzcVWSBTsXC/t6Ypl96sUSwcvTqerGbRVczEqxYKAYWrSrW2y5a1H9kh7fw4HQz/YMJ0iB8cYw==</InverseQ><D>CC0dKo6xvoqEveBomJMMC5nHhCiWyZUHpz3FhQAH+e8sJhSaTILNW/jpH5bttCq9W/jURUCcAdKuQPN5pkvdZgT0aftUaUKvC5gVEalv7YMAvlJzofUhUNNQoSeZD0/Muot9lfQyPdX8D/mlRzvL1ManWobwknxSc7MCs8hdAmE=</D></RSAKeyValue>");

				for (int i = 0; i < 4; i++)
				{
					if (i == 0) k1 = tmp1[i];
					else if (i == 1) k2 = tmp1[i];
					else if (i == 2) k3 = tmp1[i];
					else if (i == 3) k4 = tmp1[i];
					else break;
				}

				return Items(filename, k1, k2, k3, k4);
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
				return null;
			}
		}

		public static Dictionary<string, MemoryStream> GetItems(string filename, int k1, int k2, int k3, int k4)
		{
			try
			{
				Dictionary<string, MemoryStream> r = new Dictionary<string, MemoryStream>();

				List<string> items = Items(filename, k1, k2, k3, k4);

				foreach (var it in items)
				{
					r.Add(it, RTRM.ResourceManager.Get(filename, it, k1, k2, k3, k4, AccessManager.RTRMPassword));
				}

				return r;
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
				return null;
			}
		}

		public static Dictionary<string, MemoryStream> GetItems(string filename, string rsa_key)
		{
			try
			{
				int k1 = 0, k2 = 0, k3 = 0, k4 = 0;

				string tmp1 = rsa_key.FromRSAStr("<RSAKeyValue><Modulus>4k1NwPQV+RKuN5Z1RIZYws45sOgeXOx5erQF2X+OVKJ4ilNBCzyoKupC1WPXLboR6oFeYDXC9hwVFCuZe0odzHkxZ1kg4JtOGipDkHV7tt2IItB6SARE3PJ6hc5PU7jw1B1w3FJqQJ3PeVkw/StAG/14oTePLcAa/bb+zaEB7GM=</Modulus><Exponent>AQAB</Exponent><P>8DfS+eFvN+zVIhTrWmylEI3dvWkwP9fBmL4UE1I1r75yKNMekWeinVeMHIbeel19t9iN4CdYf3IBLOTtrptVww==</P><Q>8Sttg59QVKAJbarOtijApjoBQ8u6eJbqmB+uBDIoaYYG5f0IgOT9cYzsa/AQ2BaT/A56aoNpHLyEX3XHCYGE4Q==</Q><DP>wQXKZHnN+Z03gcRXfXhxhoTIWavNVm+TI54Q2ZmkhAw/BSjnliU1WMMBVebVnHPFUlYTYrua9AVyhlWJ21T8Kw==</DP><DQ>Bfj0WlkcrSvVb/DV867ornUrSNmHwarDHodSUOpJE+vsyc9NYZvKJwC9biLg1+kfOxPEtlSQytRkVtTc3ABoIQ==</DQ><InverseQ>Q2PrH8Lxp0lAOzcVWSBTsXC/t6Ypl96sUSwcvTqerGbRVczEqxYKAYWrSrW2y5a1H9kh7fw4HQz/YMJ0iB8cYw==</InverseQ><D>CC0dKo6xvoqEveBomJMMC5nHhCiWyZUHpz3FhQAH+e8sJhSaTILNW/jpH5bttCq9W/jURUCcAdKuQPN5pkvdZgT0aftUaUKvC5gVEalv7YMAvlJzofUhUNNQoSeZD0/Muot9lfQyPdX8D/mlRzvL1ManWobwknxSc7MCs8hdAmE=</D></RSAKeyValue>");

				for (int i = 0; i < 4; i++)
				{
					if (i == 0) k1 = tmp1[i];
					else if (i == 1) k2 = tmp1[i];
					else if (i == 2) k3 = tmp1[i];
					else if (i == 3) k4 = tmp1[i];
					else break;
				}

				return GetItems(filename, k1, k2, k3, k4);
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
				return null;
			}
		}

		public static bool Init()
		{
			string key_origin = string.Empty;
			try
			{
				StreamReader sr = new StreamReader($".\\data\\res\\{OptionManager.Get().ResFolder}\\data_color.dat", System.Text.Encoding.Default);

				string str;

				_colors.Clear();

				Dictionary<string, string> tmp1 = new Dictionary<string, string>();

				Dictionary<string, string> vars = new Dictionary<string, string>();

				while ((str = sr.ReadLine()) != null)
				{
					if (str.Trim() == string.Empty)
						continue;
					if (str.IndexOf("//") == 0)
						continue;
					if (str.First() == '$')
					{
						string[] t = str.Split(':');
						vars.Add(t[0].Replace("$", ""), t[1]);
						continue;
					}
					if (!str.Contains("="))
						continue;

					string[] token = str.Split('=');
					bool isAlpha = false;

					if (token[0].Contains(".hex"))
						key_origin = token[0].Replace(".hex", "");
					else if (token[0].Contains(".alpha"))
					{
						key_origin = token[0].Replace(".alpha", "");
						isAlpha = true;
					}
					else
						continue;

					if (token[1].First() == '$')
					{
						token[1] = vars[token[1].Replace("$", "")];
					}

					if (tmp1.Keys.ToList().Contains(key_origin))
					{
						if (isAlpha)
							_colors.Add(key_origin, Color.FromArgb(Convert.ToInt32(token[1]), ColorTranslator.FromHtml(tmp1[key_origin])));
						else
							_colors.Add(key_origin, Color.FromArgb(Convert.ToInt32(tmp1[key_origin]), ColorTranslator.FromHtml(token[1])));
					}
					else
						tmp1.Add(key_origin, token[1]);
				}

				return true;
			}
			catch (Exception ex)
			{
				LogManager.Add(new Log() { Message = key_origin, evt = Log.Event.MESSAGE, type = Log.Type.ERROR });
				Environment.ReportError(ex, AccessManager.AccessKey);

				return false;
			}
		}

		internal static Dictionary<string, Color> _colors = new Dictionary<string, Color>();

		public static Color Get(string key)
		{
			try
			{
				if (!_colors.Keys.ToList().Contains(key)) LogManager.Add(new Log() { evt = Log.Event.MESSAGE, type = Log.Type.ERROR, Message = $"ResourceManager - '{key}' 라는 색 데이터를 요청 했으나 그 색 데이터는 시퀀스에 존재하지 않음." });
				return _colors[key];
			}
			catch (Exception e)
			{
				Environment.ReportError(e, AccessManager.AccessKey);
				return Color.Black;
			}
		}
	}
}
