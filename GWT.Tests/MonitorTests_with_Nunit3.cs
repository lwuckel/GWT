using FluentAssertions;
using GWT.NUnit3;
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
	[TestFixture]
	public class MonitorTests_with_Nunit3 : IGwtScene
	{
		[Test]
		public void Given_When_Then_Text_Monitoring_Processing()
		{
			var list = new List<(string, State)>();
			Monitor.Instance.Processing += (text, state) => list.Add((text, state));

			this.Given(Given)
				.And(GivenAnd)
				.When(When)
				.And(WhenAnd)
				.Then(Then)
				.And(ThenAnd)
				.Run();

			list.Should().HaveCount(6)
				.And.ContainInOrder(new[] {
					("Given",State.Given)
				, ("GivenAnd",State.GivenAnd)
				, ("When",State.When)
				, ("WhenAnd",State.WhenAnd)
				, ("Then",State.Then)
				, ("ThenAnd",State.ThenAnd)
				});
		}

		[Test]
		public void Given_When_Then_Text_Monitoring_Processing_with_fail()
		{
			var list = new List<(string, State)>();
			var exception = Assert.Throws<MultipleAssertException>(() =>
			{
				using (new TestExecutionContext.IsolatedContext())
				{
					Monitor.Instance.Processing += (text, state) => list.Add((text, state));
					this.Given(Given)
						.And(GivenAndFail)
						.When(When)
						.And(WhenAnd)
						.Then(Then)
						.And(ThenAnd)
						.Run();
				}
			});
			exception.ResultState.Should().Be(ResultState.Failure);

			list.Should().HaveCount(6)
				.And.ContainInOrder(new[] {
					("Given",State.Given)
				, ("GivenAndFail",State.GivenAnd)
				, ("When",State.When)
				, ("WhenAnd",State.WhenAnd)
				, ("Then",State.Then)
				, ("ThenAnd",State.ThenAnd)
				});
		}

		[Test]
		public void Given_When_Then_Text_Monitoring_Processed_with_fail()
		{
			var list = new List<(string, State, bool)>();
			var exception = Assert.Throws<MultipleAssertException>(() =>
			{
				using (new TestExecutionContext.IsolatedContext())
				{
					Monitor.Instance.Processed += (text, state, b) => list.Add((text, state, b));
					this.Given(Given)
						.And(GivenAndFail)
						.When(When)
						.And(WhenAnd)
						.Then(Then)
						.And(ThenAnd)
						.Run();
				}
			});		
			exception.ResultState.Should().Be(ResultState.Failure);

			list.Should().HaveCount(6)
				.And.ContainInOrder(new[] {
					("Given", State.Given, false)
				, ("GivenAndFail", State.GivenAnd,true)
				, ("When",State.When,false)
				, ("WhenAnd",State.WhenAnd,false)
				, ("Then",State.Then,false)
				, ("ThenAnd",State.ThenAnd,false)
				});
		}

		void Given() { }
		void GivenAnd() { }
		void GivenAndFail() { Assert.Fail(); }
		void When() { }
		void WhenAnd() { }
		void Then() { }
		void ThenAnd() { }
	}
}
