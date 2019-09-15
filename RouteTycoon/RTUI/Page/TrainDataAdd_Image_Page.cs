using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;
using System.Xml;

namespace RouteTycoon.RTUI
{
	internal partial class TrainDataAdd_Image_Page : Page
	{
		private Page OldPage = null;
		private string name = string.Empty;
		private List<TrainParant> args = null;
		private Image image
		{
			get
			{
				return picImage.Image;
			}
			set
			{
				picImage.Image = value;
			}
		}
		private Graphics g;

		public TrainDataAdd_Image_Page(Page _oldpage = null, string _name = "", List<TrainParant> _args = null, Image img = null)
		{
			try
			{
				InitializeComponent();
				AddControl(this);

				OldPage = _oldpage;
				name = _name;
				args = _args;

				Title = TextManager.Get().Text("addtrainarg");
				IconImg = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "ico_train.png", 5, 7, 1, 6));

				if (img == null)
					image = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "img_no.png", 5, 7, 1, 6));
				else
					image = img;

				lbBack.ForeColor = ResourceManager.Get("traindataadd.back.unsel");
				lbBack.SelColor = ResourceManager.Get("traindataadd.back.sel");
				lbBack.Location = new Point(25, 553);
				lbBack.Text = TextManager.Get().Text("back");
				lbBack.Font = new Font(RTCore.Environment.Font, 20);
				lbBack.Click += delegate
				{
					PageManager.SetPage(new TrainDataAdd_Args_Page(OldPage, name, args, image), AccessManager.AccessKey);
				};

				lbAdd.Font = new Font(RTCore.Environment.Font, 20);
				lbAdd.Text = TextManager.Get().Text("add");
				lbAdd.ForeColor = ResourceManager.Get("traindataadd.next.unsel");
				lbAdd.SelColor = ResourceManager.Get("traindataadd.next.sel");
				lbAdd.Location = new Point(Width - 25 - lbAdd.Width, 553);
				lbAdd.Click += delegate
				{
					{ // data.xml
						XmlDocument xml = new XmlDocument();

						XmlNode root = xml.CreateElement("traindata");

						XmlNode args = xml.CreateElement("args");
						args.InnerText = "args.xml";
						root.AppendChild(args);

						XmlNode __name = xml.CreateElement("name");
						__name.InnerText = name;
						root.AppendChild(__name);

						XmlNode images = xml.CreateElement("image");
						images.InnerText = "img.png";
						root.AppendChild(images);

						xml.AppendChild(root);

						if (!System.IO.Directory.Exists(".\\data\\trains\\datas\\" + name)) System.IO.Directory.CreateDirectory(".\\data\\trains\\datas\\" + name);
						xml.Save(".\\data\\trains\\datas\\" + name + "\\data.xml");
					}

					{ // args.xml
						XmlDocument xml = new XmlDocument();

						XmlNode root = xml.CreateElement("args");

						foreach (var it in args)
						{
							XmlNode arg = xml.CreateElement("arg");

							if (it is Locomotive)
							{
								XmlAttribute type = xml.CreateAttribute("type");
								type.Value = "locomotive";

								XmlAttribute file = xml.CreateAttribute("name");
								file.Value = it.Name;

								arg.Attributes.Append(type);
								arg.Attributes.Append(file);
							}
							else if (it is Coach)
							{
								XmlAttribute type = xml.CreateAttribute("type");
								type.Value = "coach";

								XmlAttribute file = xml.CreateAttribute("name");
								file.Value = it.Name;

								arg.Attributes.Append(type);
								arg.Attributes.Append(file);
							}
							else if (it is EngineCoach)
							{
								XmlAttribute type = xml.CreateAttribute("type");
								type.Value = "enginecoach";

								XmlAttribute file = xml.CreateAttribute("name");
								file.Value = it.Name;

								arg.Attributes.Append(type);
								arg.Attributes.Append(file);
							}

							root.AppendChild(arg);
						}

						xml.AppendChild(root);

						xml.Save(".\\data\\trains\\datas\\" + name + "\\args.xml");
					}

					image.Save(".\\data\\trains\\datas\\" + name + "\\img.png", System.Drawing.Imaging.ImageFormat.Png);
					TrainData d = new TrainData();
					d.Load(name);

					TrainManager.TrainDatas.Add(d);

					if (OldPage == null)
					{
						PageManager.Close(false, AccessManager.AccessKey);
						return;
					}

					PageManager.SetPage(OldPage, AccessManager.AccessKey);
				};
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void TrainDataAdd_Image_Page_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Draw(e);

				g = e.Graphics;

				g.DrawString(TextManager.Get().Text("clickchangeimg"),
					new Font(RTCore.Environment.Font, 15),
					new SolidBrush(ResourceManager.Get("traindataadd.info")),
					RTCore.Environment.CalcRectangle(new Point(Width / 2, picImage.Location.Y + picImage.Height + 25),
					RTCore.Environment.CalcStringSize(TextManager.Get().Text("clickchangeimg"),
					new Font(RTCore.Environment.Font, 15))));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void picImage_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog ofd = new OpenFileDialog();

				ofd.Title = "이미지 선택";
				ofd.Filter = "이미지 파일|*.png;*.jpg;*.jpge;*.gif;*.bmp|모든 파일|*.*";

				if (ofd.ShowDialog() == DialogResult.OK)
				{
					image = Image.FromFile(ofd.FileName);
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
