using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace RTMapTool
{
    class Map
	{
		private const int MAP_VERSION = 150;
		
		public string Name
		{
			get;
			set;
		}	

		public string Password
		{
			get;
			set;
		}

		public string Developer
		{
			get;
			set;
		}

		public string BackImage
		{
			get;
			set;
		}

		private Dictionary<Region, PictureBox> _regions = new Dictionary<Region, PictureBox>();
		public Dictionary<Region, PictureBox> Regions
		{
			get
			{
				return _regions;
			}
		}

		private string GetEncodeStr(string str, bool process)
		{
			RSACryptoServiceProvider oEnc = new RSACryptoServiceProvider();

			oEnc.FromXmlString("<RSAKeyValue><Modulus>qqWAJL8ZKJRwZMW5Am8Z9sjbxkiC8nCrUkmy/nxWJ+OnL4NTfNucVa6e7U5uB0wPNUqT19h9fvpFxcMO82VymEIa844+C4+8jE+ehJB/BIv+ZNR48kGIhhrGTOjbHTcep2iW0DZf+kSgDcurquvFbHxJrMR1fCreTGfHCrz8VrM=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");

			return (process) ? Convert.ToBase64String(oEnc.Encrypt((new UTF8Encoding()).GetBytes(str), false)) : str;
		}

		private string GetDecodeStr(string str, bool process)
		{
			RSACryptoServiceProvider oEnc = new RSACryptoServiceProvider();

			oEnc.FromXmlString("<RSAKeyValue><Modulus>qqWAJL8ZKJRwZMW5Am8Z9sjbxkiC8nCrUkmy/nxWJ+OnL4NTfNucVa6e7U5uB0wPNUqT19h9fvpFxcMO82VymEIa844+C4+8jE+ehJB/BIv+ZNR48kGIhhrGTOjbHTcep2iW0DZf+kSgDcurquvFbHxJrMR1fCreTGfHCrz8VrM=</Modulus><Exponent>AQAB</Exponent><P>6TRbjwmZaZp1eepQYLNfZNBcqSq6ovPyzbpbvq3KDVmxo/4rvXyHRhx7Vyu10b9gSMjIjG4sIakKQgVvd6KkGQ==</P><Q>u1O1ca5k0/eS0Du8Crl9IzzHLR/PaxRTTZjwGmw3JXhdloi7o//voCs4Vhkq5u1rsz/fmGxZGfhbQejCwGXKqw==</Q><DP>U+q6U8NxiBXD1kYh/Fovpphv75Pnq0G7ippX70qcXad8C/YniT0pdGpFW/3npH2ISUivGhF/IfGxNka8cMF+6Q==</DP><DQ>M6LKZBCvSGJ4/J9KoSYqIVlyibS4BwsuPziGDrJ/rPt1yLXeC0HUOrFPMSR01/zf8CQOLUTIdskn1o4jiMdGSw==</DQ><InverseQ>cm3qmpm7T7NJ8nd+wMEznCEAShRHQHzTDGgKK33euzHxXxBLAA4G6LxXTGo3CFaN9I3bQeg4/bQAzaJofYtPcA==</InverseQ><D>S+FoB+8J6ueGyui5CgIJU5mhUJxxzgiXxfGLrGnxja9HanNFLqIg9GC/vto/RvNlV9cfwr07oLj9SaEhBs43lA3hgOhZkZbV3PrpxNMHLdAC+VmNnTw5bTvUEcbFogWvYYQqAuiXepT7SKd4IbVy3/vn7XxjViavuCPdCvqj0qE=</D></RSAKeyValue>");

			return (process) ? (new UTF8Encoding()).GetString(oEnc.Decrypt(Convert.FromBase64String(str), false)) : str;
		}

		public Map()
		{
			Clear();
		}

		public void Clear()
		{
			Name = string.Empty;
			Password = string.Empty;
			Developer = string.Empty;
			BackImage = string.Empty;

			_regions.Clear();
		}

		public bool Load_v100(string filename)
		{
			try
			{
				using (BinaryReader sr = new BinaryReader(File.Open(filename, FileMode.Open)))
				{
					string path = Path.GetDirectoryName(filename) + @"\";

					byte[] mark = sr.ReadBytes(4);
					if (Encoding.UTF8.GetString(mark) != "RTAF")
						throw new Exception("올바른 에드온 파일이 아닙니다.");

					int ver = sr.ReadInt32();

					if (ver != 100)
						throw new Exception("지원하지 않는 에드온 파일 버전 입니다.");

					bool pass = sr.ReadBoolean();
					Developer = GetDecodeStr(sr.ReadString(), pass);

					if (pass)
					{
						string temp = sr.ReadString();

						Password = string.Empty;
						while (Password == string.Empty)
						{
							Password = Microsoft.VisualBasic.Interaction.InputBox("비밀 번호를 입력하세요.", "RTMapTool");

							if (Password != GetDecodeStr(temp, true))
							{
								Password = string.Empty;

								if (MessageBox.Show("올바르지 않은 비밀번호 입니다.", "RTMapTool", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Cancel)
									return false;
							}
						}
					}

					// 맵 정보
					string proj_name = GetDecodeStr(sr.ReadString(), pass);
					path += proj_name + "\\";
					Name = proj_name;

					// 1차 행정구역
					string image = GetDecodeStr(sr.ReadString(), pass);
					BackImage = path + image;
					int count = sr.ReadInt32();

					for (int i = 0; i < count; i++)
					{
						string name = GetDecodeStr(sr.ReadString(), pass);

						PictureBox pb = new PictureBox();
						pb.Image = Image.FromFile(".\\ico_region.png");
						pb.Size = new Size(32, 32);
						pb.Location = new Point(sr.ReadInt32(), sr.ReadInt32());
						pb.SizeMode = PictureBoxSizeMode.StretchImage;
						pb.BackColor = Color.Transparent;
						pb.Draggable(true);

						Region reg = new Region();
						reg.Name = name;

						_regions.Add(reg, pb);
					}
				}

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		public bool Load_v110(string filename)
		{
			try
			{
				using (BinaryReader sr = new BinaryReader(File.Open(filename, FileMode.Open)))
				{
					string path = Path.GetDirectoryName(filename) + @"\";

					byte[] mark = sr.ReadBytes(4);
					if (Encoding.UTF8.GetString(mark) != "RTAF")
						throw new Exception("올바른 에드온 파일이 아닙니다.");

					int ver = sr.ReadInt32();

					if (ver != 110)
						throw new Exception("지원하지 않는 에드온 파일 버전 입니다.");

					bool pass = sr.ReadBoolean();
					Developer = GetDecodeStr(sr.ReadString(), pass);

					if (pass)
					{
						string temp = sr.ReadString();

						Password = string.Empty;
						while (Password == string.Empty)
						{
							Password = Microsoft.VisualBasic.Interaction.InputBox("비밀 번호를 입력하세요.", "RTMapTool");

							if (Password != GetDecodeStr(temp, true))
							{
								Password = string.Empty;

								if (MessageBox.Show("올바르지 않은 비밀번호 입니다.", "RTMapTool", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Cancel)
								{
									return false;
								}
							}
						}
					}

					// 맵 정보
					string proj_name = GetDecodeStr(sr.ReadString(), pass);
					path += proj_name + "\\";
					Name = proj_name;

					// 1차 행정구역
					string image = GetDecodeStr(sr.ReadString(), pass);
					BackImage = path + image;
					int count = sr.ReadInt32();

					for (int i = 0; i < count; i++)
					{
						string name = GetDecodeStr(sr.ReadString(), pass);

						PictureBox pb = new PictureBox();
						pb.Image = Image.FromFile(".\\ico_region.png");
						pb.Size = new Size(32, 32);
						pb.Location = new Point(sr.ReadInt32(), sr.ReadInt32());
						pb.SizeMode = PictureBoxSizeMode.StretchImage;
						pb.BackColor = Color.Transparent;
						pb.Draggable(true);

						Region reg = new Region();
						reg.Name = name;

						int city_count = sr.ReadInt32();
						for (int j = 0; j < city_count; j++)
						{
							reg.Citys.Add(new City() { Name = GetDecodeStr(sr.ReadString(), pass), Price = 0, Population = 0, Description = "", Location = pb.Location });
						}

						_regions.Add(reg, pb);
					}
				}

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "RouteTycoon Map Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		public bool Load_v120(string filename)
		{
			try
			{
				using (BinaryReader sr = new BinaryReader(File.Open(filename, FileMode.Open)))
				{
					string path = Path.GetDirectoryName(filename) + @"\";

					byte[] mark = sr.ReadBytes(4);
					if (Encoding.UTF8.GetString(mark) != "RTAF")
						throw new Exception("올바른 에드온 파일이 아닙니다.");

					int ver = sr.ReadInt32();

					if (ver != 120)
						throw new Exception("지원하지 않는 에드온 파일 버전 입니다.");

					bool pass = sr.ReadBoolean();
					Developer = GetDecodeStr(sr.ReadString(), pass);

					if (pass)
					{
						string temp = sr.ReadString();

						Password = string.Empty;
						while (Password == string.Empty)
						{
							Password = Microsoft.VisualBasic.Interaction.InputBox("비밀 번호를 입력하세요.", "RTMapTool");

							if (Password != GetDecodeStr(temp, true))
							{
								Password = string.Empty;

								if (MessageBox.Show("올바르지 않은 비밀번호 입니다.", "RTMapTool", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Cancel)
								{
									return false;
								}
							}
						}
					}

					// 맵 정보
					string proj_name = GetDecodeStr(sr.ReadString(), pass);
					path += proj_name + "\\";
					Name = proj_name;

					// 1차 행정구역
					string image = GetDecodeStr(sr.ReadString(), pass);
					BackImage = path + image;
					int count = sr.ReadInt32();

					for (int i = 0; i < count; i++)
					{
						string name = GetDecodeStr(sr.ReadString(), pass);

						PictureBox pb = new PictureBox();
						pb.Image = Image.FromFile(".\\ico_region.png");
						pb.Size = new Size(32, 32);
						pb.Location = new Point(sr.ReadInt32(), sr.ReadInt32());
						pb.SizeMode = PictureBoxSizeMode.StretchImage;
						pb.BackColor = Color.Transparent;
						pb.Draggable(true);

						Region reg = new Region();
						reg.Name = name;

						int city_count = sr.ReadInt32();
						for (int j = 0; j < city_count; j++)
						{
							string city_name = GetDecodeStr(sr.ReadString(), pass);
							long price = sr.ReadInt64();

							reg.Citys.Add(new City() { Name = city_name, Price = price, Population = 0, Description = "", Location = pb.Location });
						}

						_regions.Add(reg, pb);
					}
				}

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		public bool Load_v130(string filename)
		{
			try
			{
				using (BinaryReader sr = new BinaryReader(File.Open(filename, FileMode.Open)))
				{
					string path = Path.GetDirectoryName(filename) + @"\";

					byte[] mark = sr.ReadBytes(4);
					if (Encoding.UTF8.GetString(mark) != "RTAF")
						throw new Exception("올바른 에드온 파일이 아닙니다.");

					int ver = sr.ReadInt32();

					if (ver != 130)
						throw new Exception("지원하지 않는 에드온 파일 버전 입니다.");

					bool pass = sr.ReadBoolean();
					Developer = GetDecodeStr(sr.ReadString(), pass);

					if (pass)
					{
						string temp = sr.ReadString();

						Password = string.Empty;
						while (Password == string.Empty)
						{
							Password = Microsoft.VisualBasic.Interaction.InputBox("비밀 번호를 입력하세요.", "RTMapTool");

							if (Password != GetDecodeStr(temp, true))
							{
								Password = string.Empty;

								if (MessageBox.Show("올바르지 않은 비밀번호 입니다.", "RTMapTool", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Cancel)
								{
									return false;
								}
							}
						}
					}

					// 맵 정보
					string proj_name = GetDecodeStr(sr.ReadString(), pass);
					path += proj_name + "\\";
					Name = proj_name;

					// 1차 행정구역
					string image = GetDecodeStr(sr.ReadString(), pass);
					BackImage = path + image;
					int count = sr.ReadInt32();

					for (int i = 0; i < count; i++)
					{
						string name = GetDecodeStr(sr.ReadString(), pass);

						PictureBox pb = new PictureBox();
						pb.Image = Image.FromFile(".\\ico_region.png");
						pb.Size = new Size(32, 32);
						pb.Location = new Point(sr.ReadInt32(), sr.ReadInt32());
						pb.SizeMode = PictureBoxSizeMode.StretchImage;
						pb.BackColor = Color.Transparent;
						pb.Draggable(true);

						Region reg = new Region();
						reg.Name = name;

						int city_count = sr.ReadInt32();
						for (int j = 0; j < city_count; j++)
						{
							string city_name = GetDecodeStr(sr.ReadString(), pass);
							long price = sr.ReadInt64();
							long pop = sr.ReadInt64(); //인구

							reg.Citys.Add(new City() { Name = city_name, Population = pop, Price = price, Description = "", Location = pb.Location });
						}

						_regions.Add(reg, pb);
					}
				}

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		public bool Load_v140(string filename)
		{
			try
			{
				using (BinaryReader sr = new BinaryReader(File.Open(filename, FileMode.Open)))
				{
					string path = Path.GetDirectoryName(filename) + @"\";

					byte[] mark = sr.ReadBytes(4);
					if (Encoding.UTF8.GetString(mark) != "RTAF")
						throw new Exception("올바른 에드온 파일이 아닙니다.");

					int ver = sr.ReadInt32();

					if (ver != 140)
						throw new Exception("지원하지 않는 에드온 파일 버전 입니다.");

					bool pass = sr.ReadBoolean();
					Developer = GetDecodeStr(sr.ReadString(), pass);

					if (pass)
					{
						string temp = sr.ReadString();

						Password = string.Empty;
						while (Password == string.Empty)
						{
							Password = Microsoft.VisualBasic.Interaction.InputBox("비밀 번호를 입력하세요.", "RTMapTool");

							if (Password != GetDecodeStr(temp, true))
							{
								Password = string.Empty;

								if (MessageBox.Show("올바르지 않은 비밀번호 입니다.", "RTMapTool", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Cancel)
								{
									return false;
								}
							}
						}
					}

					// 맵 정보
					string proj_name = GetDecodeStr(sr.ReadString(), pass);
					path += proj_name + "\\";
					Name = proj_name;

					// 1차 행정구역
					string image = GetDecodeStr(sr.ReadString(), pass);
					BackImage = path + image;
					int count = sr.ReadInt32();

					for (int i = 0; i < count; i++)
					{
						string name = GetDecodeStr(sr.ReadString(), pass);

						PictureBox pb = new PictureBox();
						pb.Image = Image.FromFile(".\\ico_region.png");
						pb.Size = new Size(32, 32);
						pb.Location = new Point(sr.ReadInt32(), sr.ReadInt32());
						pb.SizeMode = PictureBoxSizeMode.StretchImage;
						pb.BackColor = Color.Transparent;
						pb.Draggable(true);

						Region reg = new Region();
						reg.Name = name;

						int city_count = sr.ReadInt32();
						for (int j = 0; j < city_count; j++)
						{
							string city_name = GetDecodeStr(sr.ReadString(), pass);
							long price = sr.ReadInt64();
							long pop = sr.ReadInt64(); //인구
							string des = GetDecodeStr(sr.ReadString(), pass);

							reg.Citys.Add(new City() { Name = city_name, Population = pop, Price = price, Description = des, Location = pb.Location });
						}

						_regions.Add(reg, pb);
					}
				}

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		public bool Load_v150(string filename)
		{
			try
			{
				using (BinaryReader sr = new BinaryReader(File.Open(filename, FileMode.Open)))
				{
					string path = Path.GetDirectoryName(filename) + @"\";

					byte[] mark = sr.ReadBytes(4);
					if (Encoding.UTF8.GetString(mark) != "RTAF")
						throw new Exception("올바른 에드온 파일이 아닙니다.");

					int ver = sr.ReadInt32();

					if (ver != 150)
						throw new Exception("지원하지 않는 에드온 파일 버전 입니다.");

					bool pass = sr.ReadBoolean();
					Developer = GetDecodeStr(sr.ReadString(), pass);

					if (pass)
					{
						string temp = sr.ReadString();

						Password = string.Empty;
						while (Password == string.Empty)
						{
							Password = Microsoft.VisualBasic.Interaction.InputBox("비밀 번호를 입력하세요.", "RTMapTool");

							if (Password != GetDecodeStr(temp, true))
							{
								Password = string.Empty;

								if (MessageBox.Show("올바르지 않은 비밀번호 입니다.", "RTMapTool", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Cancel)
								{
									return false;
								}
							}
						}
					}

					// 맵 정보
					string proj_name = GetDecodeStr(sr.ReadString(), pass);
					path += proj_name + "\\";
					Name = proj_name;

					// 1차 행정구역
					string image = GetDecodeStr(sr.ReadString(), pass);
					BackImage = path + image;
					int count = sr.ReadInt32();

					for (int i = 0; i < count; i++)
					{
						string name = GetDecodeStr(sr.ReadString(), pass);

						PictureBox pb = new PictureBox();
						pb.Image = Image.FromFile(".\\ico_region.png");
						pb.Size = new Size(32, 32);
						pb.Location = new Point(sr.ReadInt32(), sr.ReadInt32());
						pb.SizeMode = PictureBoxSizeMode.StretchImage;
						pb.BackColor = Color.Transparent;
						pb.Draggable(true);

						Region reg = new Region();
						reg.Name = name;

						int city_count = sr.ReadInt32();
						for (int j = 0; j < city_count; j++)
						{
							string city_name = GetDecodeStr(sr.ReadString(), pass);
							long price = sr.ReadInt64();
							long pop = sr.ReadInt64(); //인구
							string des = GetDecodeStr(sr.ReadString(), pass);
							Point loc = new Point(sr.ReadInt32(), sr.ReadInt32());

							reg.Citys.Add(new City() { Name = city_name, Population = pop, Price = price, Description = des, Location = loc });
						}

						_regions.Add(reg, pb);
					}
				}

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		public bool Load(string filename)
		{
			try
			{
				int ver = 0;

				using (BinaryReader sr = new BinaryReader(File.Open(filename, FileMode.Open)))
				{
					string path = Path.GetDirectoryName(filename) + @"\";

					byte[] mark = sr.ReadBytes(4);
					if (Encoding.UTF8.GetString(mark) != "RTAF")
						throw new Exception("올바른 에드온 파일이 아닙니다.");

					ver = sr.ReadInt32();
				}

				switch (ver)
				{
					case 100: return Load_v100(filename);
					case 110: return Load_v110(filename);
					case 120: return Load_v120(filename);
					case 130: return Load_v130(filename);
					case 140: return Load_v140(filename);
					case 150: return Load_v150(filename);
					default: return false;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		public void Save(string filename)
		{
			try
			{
				string path = Path.GetDirectoryName(filename);

				using (BinaryWriter sw = new BinaryWriter(File.Open(filename, FileMode.Create)))
				{
					Directory.CreateDirectory(path + "\\" + Name);
					File.Copy(BackImage, path + "\\" + Name + "\\" + System.IO.Path.GetFileName(BackImage), true);

					// Header
					byte[] mark = Encoding.UTF8.GetBytes("RTAF");
					sw.Write(mark);
					sw.Write(MAP_VERSION);

					// 개발자 정보
					sw.Write(Password != string.Empty);
					sw.Write(GetEncodeStr(Developer, Password != string.Empty));

					if (Password != string.Empty)
						sw.Write(GetEncodeStr(Password, true));

					// 맵 정보
					sw.Write(GetEncodeStr(Name, Password != string.Empty));

					// 1차 행정구역
					sw.Write(GetEncodeStr(Path.GetFileName(BackImage), Password != string.Empty));
					sw.Write(_regions.Count);

					foreach (var pr in _regions)
					{
						int j = 0;
						sw.Write(GetEncodeStr(pr.Key.Name, Password != string.Empty));
						sw.Write(pr.Value.Location.X);
						sw.Write(pr.Value.Location.Y);

						sw.Write(pr.Key.Citys.Count);
						foreach (var str in pr.Key.Citys)
						{
							sw.Write(GetEncodeStr(str.Name, Password != string.Empty));
							sw.Write(str.Price);
							sw.Write(str.Population);
							sw.Write(GetEncodeStr(str.Description, Password != string.Empty));
							sw.Write(str.Location.X);
							sw.Write(str.Location.Y);
							j++;
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "RTMapTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}