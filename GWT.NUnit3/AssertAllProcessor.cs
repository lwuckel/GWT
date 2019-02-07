using NUnit.Framework;
using System;
using System.Linq;

namespace GWT.NUnit3
{
	public class AssertAllProcessor : DefaultProcessor
	{

		public override void Processing(Action[] givens, Action[] whens, Action[] thens)
		{
			var assertAll = new AssertAll();

			Processing(assertAll, givens,
			a => this.Processor.ProcessingGiven(a),
			a => this.Processor.ProcessingGivenAnd(a)
		);

			Processing(assertAll, whens,
				a => this.Processor.ProcessingWhen(a),
				a => this.Processor.ProcessingWhenAnd(a)
			);

			Processing(assertAll, thens,
				a => this.Processor.ProcessingThen(a),
				a => this.Processor.ProcessingThenAnd(a)
			);

			// generate MultipleAssertException
			Assert.Multiple(() => { });
		}

		void Processing(
			AssertAll assertAll, 
			Action[] actions, 
			Action<Action> process, 
			Action<Action> processAnd
		)
		{
			bool first = true;
			actions.ToList()
				.ForEach(action => assertAll.Execute(()=>
				{
					if (first)
					{
						first = false;
						process(action);
					}
					else
						processAnd(action);
				}));
		}
	}
}
