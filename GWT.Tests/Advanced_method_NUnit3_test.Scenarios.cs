using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.Tests
{
	partial class Advanced_method_NUnit3_test
	{
		ThenResult<Thens, Action> ScenarioA(Simple.SceneContext<Givens, Whens, Thens> context) => context.

Given.Add_1_to_counter.

When.Fail_2_should_be_3.
And.Add_1_to_counter_and_fail.
And.Add_1_to_counter_and_fail.

Then.Add_1_to_counter;


		private ThenResult<Thens, Action> ScenarioB(Simple.SceneContext<Givens, Whens, Thens> context) => context
		.
When.Fail_2_should_be_3.
And.Add_1_to_counter_and_fail.
And.Add_1_to_counter_and_fail.

Then.Add_1_to_counter;

		private ThenResult<Thens, Action> ScenarioC(Simple.SceneContext<Givens, Whens, Thens> context) => context.
			Given.Add_1_to_counter.

			When.Fail_2_should_be_3.
			And.Add_1_to_counter_and_fail.
			And.Add_1_to_counter_and_fail.

			Then.Add_1_to_counter;

		private ThenResult<Thens, Action> ScenarioD(Simple.SceneContext<Givens, Whens, Thens> context) => context.

			// counter = 4; fail 3 => 1 Exception
			GivenScenario(ScenarioA).

			When.Fail_2_should_be_3.

			Then.Add_1_to_counter;
	}
}
