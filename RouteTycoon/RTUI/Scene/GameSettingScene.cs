using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class GameSettingScene : Scene
	{
		public GameSettingScene()
		{
			try
			{
				InitializeComponent();

				BackgroundImage = Image.FromStream(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\images.npk", "main_background.png", 5, 7, 1, 6));

				foreach (Control it in Controls)
				{
					it.Font = new Font(RTCore.Environment.Font, it.Font.Size, it.Font.Style);
				}

				{
					lbAccept.Text = TextManager.Get().Text("accept");
					lbAccept.ForeColor = ResourceManager.Get("setting.game.accept.unsel");
					lbAccept.SelColor = ResourceManager.Get("setting.game.accept.sel");

					lbTitle.Text = TextManager.Get().Text("game");
					lbTitle.ForeColor = ResourceManager.Get("setting.game.title");

					cbUseAutoSave.Text = TextManager.Get().Text("autosave");
					cbUseAutoSave.ForeColor = ResourceManager.Get("setting.game.autosave");
					cbUseAutoSave.Checked = OptionManager.Get().AutoSave;

					nuAutoSaveTime.Value = OptionManager.Get().AutoSaveSecond;
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void GameSettingScene_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				e.Graphics.FillRectangle(new SolidBrush(ResourceManager.Get("main.rectangle")), new Rectangle(50, 100, Width - 100, Height - 150));

				{
					string text = TextManager.Get().Text("autosavetime");
					Size text_size = RTCore.Environment.CalcStringSize(text, new Font(RTCore.Environment.Font, 12));
                    e.Graphics.DrawString(text, new Font(RTCore.Environment.Font, 12), new SolidBrush(ResourceManager.Get("setting.game.autosavetime")), new Point(cbUseAutoSave.Location.X, cbUseAutoSave.Location.Y + cbUseAutoSave.Height + 5));
					nuAutoSaveTime.Location = new Point(cbUseAutoSave.Location.X + text_size.Width + 2, cbUseAutoSave.Location.Y + cbUseAutoSave.Height + 2);
				}
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}

		private void GameSettingScene_Resize(object sender, EventArgs e)
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

		public override void OnClosed()
		{
			BackgroundImage.Dispose();
		}

		private void lbAccept_Click(object sender, EventArgs e)
		{
			try
			{
				OptionManager.Get().Save("autosave", cbUseAutoSave.Checked.ToString().ToLower(), AccessManager.AccessKey);
				OptionManager.Get().Save("autosavesecond", nuAutoSaveTime.Value.ToString(), AccessManager.AccessKey);
				OptionManager.Get().Load(AccessManager.AccessKey);

				SettingScene ss = new SettingScene();

				SceneManager.SetScene(ss, AccessManager.AccessKey);
			}
			catch (Exception ex)
			{
				RTCore.Environment.ReportError(ex, AccessManager.AccessKey);
			}
		}
	}
}
