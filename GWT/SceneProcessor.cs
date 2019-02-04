using System;
using System.Collections.Generic;
using System.Text;

namespace GWT
{
	public class SceneProcessor
	{
		public static void Processing(Action[] givens, Action[] whens, Action[] thens)
		{
			ProcessingGivens(givens);
			ProcessingWhens(whens);
			ProcessingThens(thens);
		}

		public static void ProcessingGiven(Action given)
		{
			Processor.ProcessAction(given, State.Given);
		}
		public static void ProcessingGivenAnd(Action given)
		{
			Processor.ProcessAction(given, State.GivenAnd);
		}
		public static void ProcessingWhen(Action when)
		{
			Processor.ProcessAction(when, State.When);
		}
		public static void ProcessingWhenAnd(Action when)
		{
			Processor.ProcessAction(when, State.WhenAnd);
		}
		public static void ProcessingThen(Action then)
		{
			Processor.ProcessAction(then, State.Then);
		}
		public static void ProcessingThenAnd(Action then)
		{
			Processor.ProcessAction(then, State.ThenAnd);
		}
		public static void ProcessingGivens(Action[] givens)
		{
			Processor.ProcessActions(givens, State.Given, State.GivenAnd);
		}

		public static void ProcessingWhens(Action[] whens)
		{
			Processor.ProcessActions(whens, State.When, State.WhenAnd);
		}

		public static void ProcessingThens(Action[] thens)
		{
			Processor.ProcessActions(thens, State.Then, State.ThenAnd);
		}

	}
}
