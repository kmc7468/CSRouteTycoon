using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace RouteTycoon.RTCore
{
	public class Map
	{
		private string _Name = string.Empty;
		private string _Developer = string.Empty;
		private Image _BackImg = null;
		
		public void Load(string path, Label lb = null)
		{
			try
			{
				if (!File.Exists(path) && lb != null)
				{
					lb.Text = TextManager.Get().Text("nomap");
					return;
				}
				else if (!File.Exists(path) && lb == null)
					throw new NoMapException();

				using (BinaryReader sr = new BinaryReader(File.Open(path, FileMode.Open)))
				{
					byte[] mark = sr.ReadBytes(4);
					if (Encoding.UTF8.GetString(mark) != "RTAF")
					{
						if (lb == null)
							throw new NotMapException();
						else
						{
							lb.Text = TextManager.Get().Text("notmap");
							return;
						}
                    }

					int ver = sr.ReadInt32();

					switch(ver)
					{
						case 130: Load_v130(Path.GetFileNameWithoutExtension(path), sr); break;
						case 140: Load_v140(Path.GetFileNameWithoutExtension(path), sr); break;
						case 150: Load_v150(Path.GetFileNameWithoutExtension(path), sr); break;
						default: if (lb == null) { throw new CanNotSupportVersionMapException(); } else { lb.Text = TextManager.Get().Text("oldmap"); return; }
					}
				}
			}
			catch(Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void Load_v130(string name, BinaryReader sr)
		{
			try
			{
				bool pass = sr.ReadBoolean();
				_Developer = GetDecodeStr(sr.ReadString(), pass);

				if (pass) sr.ReadString();

				// 맵 정보
				_Name = GetDecodeStr(sr.ReadString(), pass);
				_BackImg = Image.FromFile($".\\data\\maps\\{name}\\{GetDecodeStr(sr.ReadString(), pass)}");

				// Region
				int reg_count = sr.ReadInt32();

				for (int i = 0; i < reg_count; i++)
				{
					string reg_name = GetDecodeStr(sr.ReadString(), pass);
					Point reg_loc = new Point(sr.ReadInt32(), sr.ReadInt32());

					Region r = new Region();
					r.Name = reg_name;
					r.Location = reg_loc;
					r.Parent = this;

					int city_count = sr.ReadInt32();
					for (int j = 0; j < city_count; j++)
					{
						string city_name = GetDecodeStr(sr.ReadString(), pass);
						long price = sr.ReadInt64();
						long pop = sr.ReadInt64();

						r.Childs.Add(new City() { Name = city_name, Population = pop, Price = price, Parent = r, Description = "", Location = r.Location });
					}

					Regions.Add(r);
				}

				#region old
				//bool pass = sr.ReadBoolean();
				//_Developer = GetDecodeStr(sr.ReadString(), pass);

				//if (pass) sr.ReadString();

				//// 맵 정보
				//_Name = GetDecodeStr(sr.ReadString(), pass);
				//_BackImg = Image.FromFile($@".\data\maps\{name}\{GetDecodeStr(sr.ReadString(), pass)}");

				//// Region
				//int count = sr.ReadInt32();

				//for (int i = 0; i < count; i++)
				//{
				//	Region reg = new Region();
				//	reg.Name = GetDecodeStr(sr.ReadString(), pass);
				//	reg.Location = new Point(sr.ReadInt32(), sr.ReadInt32());

				//	// City
				//	int city_count = sr.ReadInt32();

				//	if (city_count == 0)
				//		reg.Childs.Add(new City() { Name = reg.Name, Parent = reg });

				//	for (int j = 0; i < city_count; j++)
				//	{
				//		City city = new City();
				//		city.Parent = reg;
				//		city.Name = GetDecodeStr(sr.ReadString(), pass);
				//		city.Price = sr.ReadInt64();
				//		city.Population = sr.ReadInt64();

				//		reg.Childs.Add(city);
				//	}

				//	_regions.Add(reg);
				//}
				#endregion
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void Load_v140(string name, BinaryReader sr)
		{
			try
			{
				bool pass = sr.ReadBoolean();
				_Developer = GetDecodeStr(sr.ReadString(), pass);

				if (pass) sr.ReadString();

				// 맵 정보
				_Name = GetDecodeStr(sr.ReadString(), pass);
				_BackImg = Image.FromFile($".\\data\\maps\\{name}\\{GetDecodeStr(sr.ReadString(), pass)}");

				// Region
				int reg_count = sr.ReadInt32();

				for (int i = 0; i < reg_count; i++)
				{
					string reg_name = GetDecodeStr(sr.ReadString(), pass);
					Point reg_loc = new Point(sr.ReadInt32(), sr.ReadInt32());

					Region r = new Region();
					r.Name = reg_name;
					r.Location = reg_loc;
					r.Parent = this;

					int city_count = sr.ReadInt32();
					for (int j = 0; j < city_count; j++)
					{
						string city_name = GetDecodeStr(sr.ReadString(), pass);
						long price = sr.ReadInt64();
						long pop = sr.ReadInt64();
						string des = GetDecodeStr(sr.ReadString(), pass);

						r.Childs.Add(new City() { Name = city_name, Population = pop, Price = price, Parent = r, Description = des, Location = r.Location });
					}

					Regions.Add(r);
				}
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void Load_v150(string name, BinaryReader sr)
		{
			try
			{
				bool pass = sr.ReadBoolean();
				_Developer = GetDecodeStr(sr.ReadString(), pass);

				if (pass) sr.ReadString();

				// 맵 정보
				_Name = GetDecodeStr(sr.ReadString(), pass);
				_BackImg = Image.FromFile($".\\data\\maps\\{name}\\{GetDecodeStr(sr.ReadString(), pass)}");

				// Region
				int reg_count = sr.ReadInt32();

				for (int i = 0; i < reg_count; i++)
				{
					string reg_name = GetDecodeStr(sr.ReadString(), pass);
					Point reg_loc = new Point(sr.ReadInt32(), sr.ReadInt32());

					Region r = new Region();
					r.Name = reg_name;
					r.Location = reg_loc;
					r.Parent = this;

					int city_count = sr.ReadInt32();
					for (int j = 0; j < city_count; j++)
					{
						string city_name = GetDecodeStr(sr.ReadString(), pass);
						long price = sr.ReadInt64();
						long pop = sr.ReadInt64();
						string des = GetDecodeStr(sr.ReadString(), pass);
						Point loc = new Point(sr.ReadInt32(), sr.ReadInt32());

						r.Childs.Add(new City() { Name = city_name, Population = pop, Price = price, Parent = r, Description = des, Location = loc });
					}

					Regions.Add(r);
				}
			}
			catch (Exception ex)
			{
				Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private string GetDecodeStr(string str, bool process)
		{
			RSACryptoServiceProvider oEnc = new RSACryptoServiceProvider();

			oEnc.FromXmlString("<RSAKeyValue><Modulus>qqWAJL8ZKJRwZMW5Am8Z9sjbxkiC8nCrUkmy/nxWJ+OnL4NTfNucVa6e7U5uB0wPNUqT19h9fvpFxcMO82VymEIa844+C4+8jE+ehJB/BIv+ZNR48kGIhhrGTOjbHTcep2iW0DZf+kSgDcurquvFbHxJrMR1fCreTGfHCrz8VrM=</Modulus><Exponent>AQAB</Exponent><P>6TRbjwmZaZp1eepQYLNfZNBcqSq6ovPyzbpbvq3KDVmxo/4rvXyHRhx7Vyu10b9gSMjIjG4sIakKQgVvd6KkGQ==</P><Q>u1O1ca5k0/eS0Du8Crl9IzzHLR/PaxRTTZjwGmw3JXhdloi7o//voCs4Vhkq5u1rsz/fmGxZGfhbQejCwGXKqw==</Q><DP>U+q6U8NxiBXD1kYh/Fovpphv75Pnq0G7ippX70qcXad8C/YniT0pdGpFW/3npH2ISUivGhF/IfGxNka8cMF+6Q==</DP><DQ>M6LKZBCvSGJ4/J9KoSYqIVlyibS4BwsuPziGDrJ/rPt1yLXeC0HUOrFPMSR01/zf8CQOLUTIdskn1o4jiMdGSw==</DQ><InverseQ>cm3qmpm7T7NJ8nd+wMEznCEAShRHQHzTDGgKK33euzHxXxBLAA4G6LxXTGo3CFaN9I3bQeg4/bQAzaJofYtPcA==</InverseQ><D>S+FoB+8J6ueGyui5CgIJU5mhUJxxzgiXxfGLrGnxja9HanNFLqIg9GC/vto/RvNlV9cfwr07oLj9SaEhBs43lA3hgOhZkZbV3PrpxNMHLdAC+VmNnTw5bTvUEcbFogWvYYQqAuiXepT7SKd4IbVy3/vn7XxjViavuCPdCvqj0qE=</D></RSAKeyValue>");

			return (process) ? (new UTF8Encoding()).GetString(oEnc.Decrypt(Convert.FromBase64String(str), false)) : str;
		}

		public string Name
		{
			get
			{
				return _Name;
			}
		}

		public string Developer
		{
			get
			{
				return _Developer;
			}
		}

		public Image BackImg
		{
			get
			{
				return _BackImg;
			}
		}

		private List<Region> _regions = new List<Region>();

		public List<Region> Regions
		{
			get
			{
				return _regions;
			}
		}
	}
}