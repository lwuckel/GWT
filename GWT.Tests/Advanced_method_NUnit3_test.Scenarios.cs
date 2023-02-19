using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.Tests
{
	partial class Advanced_method_NUnit3_test
	{
		ThenResult<Thens, Action> ScenarioFailTwoTimes(Simple.SceneContext<Givens, Whens, Thens> context) => context.

			Given.Add_1_to_counter.

			When.BAction.

			Then.ItFail.
			And.ItFail;


		private ThenResult<Thens, Action> ScenarioThrowExceptionInWhen(Simple.SceneContext<Givens, Whens, Thens> context) => context
		.
When.ThrowException.

Then.Add_1_to_counter;

		private ThenResult<Thens, Action> Scenario_GivenSceneFailed(Simple.SceneContext<Givens, Whens, Thens> context) => context.

			// counter = 4; fail 3 => 1 Exception
			GivenScenario(ScenarioFailTwoTimes).

			When.BAction.

			Then.Add_1_to_counter;
	}
}
