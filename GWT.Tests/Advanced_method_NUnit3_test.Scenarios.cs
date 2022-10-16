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

Given.A.

When.B_Should_Fail2.
And.B_Should_Fail.
And.B_Should_Fail.

Then.C;


		private ThenResult<Thens, Action> ScenarioB(Simple.SceneContext<Givens, Whens, Thens> context) => context
		.
When.B_Should_Fail2.
And.B_Should_Fail.
And.B_Should_Fail.

Then.C;

		private ThenResult<Thens, Action> ScenarioC(Simple.SceneContext<Givens, Whens, Thens> context) => context.
			Given.A.

			When.B_Should_Fail2.
			And.B_Should_Fail.
			And.B_Should_Fail.

			Then.C;

		private ThenResult<Thens, Action> ScenarioD(Simple.SceneContext<Givens, Whens, Thens> context) => context.

			GivenScenario(ScenarioA).

			When.B_Should_Fail2.
			And.B_Should_Fail.
			And.B_Should_Fail.

			Then.C;
	}
}
