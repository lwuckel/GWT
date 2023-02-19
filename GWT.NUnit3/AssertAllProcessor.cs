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
				a => this.Processor.ProcessingGivenAnd(a),
				collectExceptions: false
			);

			Processing(assertAll, whens,
				a => this.Processor.ProcessingWhen(a),
				a => this.Processor.ProcessingWhenAnd(a),
				collectExceptions: false
			);

			Processing(assertAll, thens,
				a => this.Processor.ProcessingThen(a),
				a => this.Processor.ProcessingThenAnd(a),
				collectExceptions: true
			);

			assertAll.ThrowAsserts(); 
		}

		void Processing(
			AssertAll assertAll, 
			Action[] actions, 
			Action<Action> process, 
			Action<Action> processAnd,
			bool collectExceptions
		)
		{
			bool first = true;
			actions.ToList()
				.ForEach(action => assertAll.Execute(collectExceptions , ()=>
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
