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
			return new Scene(postProcessing: true, process: Processing)
				.Given(action);
		}

		public static void Processing(Action[] givens, Action[] whens, Action[] thens)
		{
			//			Assert.Multiple(() =>	Scene.Processing(givens, whens, thens));
			AssertAll.Execute(
				() => AssertAll.Execute(() => SceneProcessor.ProcessingGivens(givens)),
				() => AssertAll.Execute(() => SceneProcessor.ProcessingWhens(whens)),
				() => AssertAll.Execute(() => SceneProcessor.ProcessingThens(thens))
			);
		}
	}
}
