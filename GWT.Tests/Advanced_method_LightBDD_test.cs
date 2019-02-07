using FluentAssertions;
using LightBDD.Core.Execution;
using LightBDD.Framework;
using LightBDD.NUnit3;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.Tests
{
	[FeatureDescription(
@"In order to access personal data
As an user
I want to login into system")] //feature description
	[Label("Story-1")]
	[TestFixture]
	partial class Advanced_method_LightBDD_test : FeatureFixture
	{
		[Scenario]
		[Label("Ticket-1")]
		[Test]
		public void SceneContext_test()
		{
			var exception = Assert.Throws<ScenarioExecutionException>(() =>
			{
				using (new TestExecutionContext.IsolatedContext())
				{
					new TestContext(this.Runner)
						.Given.A
						.When.B_Should_Fail
						.And.B_Should_Fail
						.Then.C
						.Run();
				}
			});

			Parameter.Counter.Should().Be(3);
		}
	}
}
