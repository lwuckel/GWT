using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.NUnit3
{
	public static class GivenExtension
	{
		public static IGiven<Action> Given(this IGwtScene runner, Action action)
		{
			var scene = new Scene(null, postProcessing: true);
			scene.Processor = new AssertAllProcessor(scene);
			return scene.Given(action);
		}
	}

	public class AssertAllProcessor : DefaultProcessor
	{
		public AssertAllProcessor(Scene scene) : base(scene)
		{
		}

		public override void Processing(Action[] givens, Action[] whens, Action[] thens)
		{
			//			Assert.Multiple(() =>	Scene.Processing(givens, whens, thens));
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
