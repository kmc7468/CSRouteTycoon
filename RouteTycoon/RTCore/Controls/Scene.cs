using System.Windows.Forms;

namespace RouteTycoon.RTCore
{
	public class Scene : UserControl
	{
		public virtual void OnClosed() { }

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// Scene
			// 
			this.DoubleBuffered = true;
			this.Name = "Scene";
			this.ResumeLayout(false);
		}
	}
}
