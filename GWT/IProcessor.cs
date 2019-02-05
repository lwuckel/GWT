using System;

namespace GWT
{
	public interface IProcessor
	{
		void ProcessAction(Action b, State state);
		void ProcessActions(Action[] actions, State state, State andState);
	}
}