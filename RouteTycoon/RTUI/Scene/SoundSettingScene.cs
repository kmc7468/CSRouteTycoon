using System;
using System.Drawing;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class SoundSettingScene : Scene
	{
		public SoundSettingScene()
		{
			try
			{
				InitializeComponent();

				BackgroundImage = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "main_background.png", 5, 7, 1, 6));

				lbTitle.Text = TextManager.Get().Text("sound");
				lbTitle.Font = new Font(RTCore.Environment.Font, 30);
				lbTitle.ForeColor = ResourceManager.Get("setting.sound.title");

				lbAccept.Text = TextManager.Get().Text("accept");
				lbAccept.Font = new Font(RTCore.Environment.Font, 30);
				lbAccept.ForeColor = ResourceManager.Get("setting.sound.accept.unsel");
				lbAccept.SelColor = ResourceManager.Get("setting.sound.accept.sel");

				cbUse.Font = new Font(RTCore.Environment.Font, 20);
				cbUse.Text = TextManager.Get().Text("playsound");
				cbUse.ForeColor = ResourceManager.Get("setting.sound.use");
				cbUse.Checked = OptionManager.Get().Sound;
			}
			catch(Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void lbAccept_Click(object sender, EventArgs e)
		{
			try
			{
				OptionManager.Get().Save("sound", cbUse.Checked.ToString().ToLower(), AccessManager.AccessKey);
				OptionManager.Get().Load(AccessManager.AccessKey);

				SceneManager.SetScene(new SettingScene(), AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void SoundSettingScene_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				e.Graphics.FillRectangle(new SolidBrush(ResourceManager.Get("main.rectangle")), new Rectangle(50, 100, Width - 100, Height - 150));
				e.Graphics.DrawString("Music: http://www.bensound.com", new Font(RTCore.Environment.Font, 12), new SolidBrush(ResourceManager.Get("setting.sound.url")), new Point(cbUse.Location.X, cbUse.Location.Y + cbUse.Height + 5));
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void SoundSettingScene_Resize(object sender, EventArgs e)
		{
			try
			{
				lbAccept.Location = new Point(Width - 80 - lbAccept.Width, Height - 70 - lbAccept.Height);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
