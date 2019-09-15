using System;
using System.Windows.Forms;

namespace RouteTycoon.RTCore.Plugin
{
	public interface ILogPlugin
	{
		void Clicked(object sender, EventArgs e);
		void KeyPress(object sender, KeyPressEventArgs e);
		void SceneLoad(object sender, EventArgs e);
		void PageLoad(object sender, EventArgs e);
	}
}
