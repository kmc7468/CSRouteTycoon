using System.Drawing;

namespace RouteTycoon.RTCore.Plugin
{
	public interface INews
	{
		string Name { get; }
		string Developer { get; }
		string Message { get; }

		Image Image { get; }

		bool AlreadyDo { get; set; }

		bool IsAvailable();

		void Update();
	}
}
