using System;

namespace RouteTycoon.RTCore.Plugin
{
	public interface IPlugin
	{
		string Name { get; }
		string Developer { get; }
		Version Ver { get; }
	}
}
