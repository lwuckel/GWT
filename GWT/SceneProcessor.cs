using System;
using System.Collections.Generic;
using System.Text;

namespace GWT
{
	public class SceneProcessor : ISceneProcessor
	{
		IProcessor processor = new Processor();

		public void Processing(Action[] givens, Action[] whens, Action[] thens)
		{
			ProcessingGivens(givens);
			ProcessingWhens(whens);
			ProcessingThens(thens);
		}

		public void ProcessingGiven(Action given)
		{
			this.processor.ProcessAction(given, State.Given);
		}
		public void ProcessingGivenAnd(Action given)
		{
			this.processor.ProcessAction(given, State.GivenAnd);
		}
		public void ProcessingWhen(Action when)
		{
			this.processor.ProcessAction(when, State.When);
		}
		public void ProcessingWhenAnd(Action when)
		{
			this.processor.ProcessAction(when, State.WhenAnd);
		}
		public void ProcessingThen(Action then)
		{
			this.processor.ProcessAction(then, State.Then);
		}
		public void ProcessingThenAnd(Action then)
		{
			this.processor.ProcessAction(then, State.ThenAnd);
		}
		public void ProcessingGivens(Action[] givens)
		{
			this.processor.ProcessActions(givens, State.Given, State.GivenAnd);
		}

		public void ProcessingWhens(Action[] whens)
		{
			this.processor.ProcessActions(whens, State.When, State.WhenAnd);
		}

		public void ProcessingThens(Action[] thens)
		{
			this.processor.ProcessActions(thens, State.Then, State.ThenAnd);
		}
	}
}
