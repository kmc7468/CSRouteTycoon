using RouteTycoon.RTCore;

namespace RouteTycoon.RTUI
{
	internal partial class FakeScene : Scene
	{
		public FakeScene()
		{
			InitializeComponent();

			System.Media.SoundPlayer p = new System.Media.SoundPlayer(ResourceManager.Get($".\\data\\res\\{OptionManager.Get().ResFolder}\\sounds.npk", "hamjung.wav", 5, 7, 1, 6));
			p.PlayLooping();
		}
	}
}
