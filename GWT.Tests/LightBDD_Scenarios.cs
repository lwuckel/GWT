using FluentAssertions;
using GWT.LightBDD;
using LightBDD.Framework;
using LightBDD.NUnit3;
using NUnit.Framework;

[assembly: LightBddScopeAttribute]

namespace GWT.Tests
{
	[FeatureDescription(
@"In order to access personal data
As an user
I want to login into system")] //feature description
	[Label("Story-1")]
	[TestFixture]
	public class LightBDD_Scenarios : FeatureFixture, IGwtScene
	{
		[Scenario]
		[Label("Ticket-1")]
		[Test]
		public void Counter_test() //scenario name
		{
			counter = 0;
			this.Runner
				.Given(Counter)
				.When(Counter)
				.Then(Counter)
				.Run();

			counter.Should().Be(3);
		}

		int counter = 0;
		public void Counter() { ++this.counter; }
	}
}
