using System;
using System.Linq;

namespace GWT.NUnit3
{
	public class AssertAllProcessor : DefaultProcessor
	{

		public override void Processing(Action[] givens, Action[] whens, Action[] thens)
		{
			AssertAll.Execute(
				() => AssertAll.Execute(() => Processing(givens, a => this.Processor.ProcessingGiven(a))),
				() => AssertAll.Execute(() => Processing(whens, a => this.Processor.ProcessingWhen(a))),
				() => AssertAll.Execute(() => Processing(thens, a => this.Processor.ProcessingThen(a)))
			);
		}

		void Processing(Action[] actions, Action<Action> process)
		{
			var list = (from action in actions
									select new Action(() => process(action))
								 ).ToList();
			AssertAll.Execute(list.ToArray());
		}
	}
}
