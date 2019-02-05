using System;

namespace GWT
{
	public interface ISceneProcessor
	{
		void Processing(Action[] givens, Action[] whens, Action[] thens);
		void ProcessingGiven(Action given);
		void ProcessingGivenAnd(Action given);
		void ProcessingGivens(Action[] givens);
		void ProcessingThen(Action then);
		void ProcessingThenAnd(Action then);
		void ProcessingThens(Action[] thens);
		void ProcessingWhen(Action when);
		void ProcessingWhenAnd(Action when);
		void ProcessingWhens(Action[] whens);
	}
}