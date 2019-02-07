using FluentAssertions;
using GWT.Simple;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;

namespace GWT.Tests
{
	[TestFixture]
	public class MonitorTests : IGwtScene
	{
			[Test]
			public void Given_When_Then_Text_Monitoring_Processing()
			{
				var list = new List<MonitorArgs>();
				Monitor.Instance.Processing += (args) => list.Add(args);

				this.Given(Given)
					.And(GivenAnd)
					.When(When)
					.And(WhenAnd)
					.Then(Then)
					.And(ThenAnd);

			(from m in list
			 select (m.Name, m.State)
			)
			.Should().HaveCount(6)
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
				var list = new List<MonitorArgs>();
				Monitor.Instance.Processing += (args) => list.Add(args);

				var exception = Assert.Throws<AssertionException>(() =>
				{
					using (new TestExecutionContext.IsolatedContext())
					{
						this.Given(Given)
							.And(GivenAndFail)
							.When(When)
							.And(WhenAnd)
							.Then(Then)
							.And(ThenAnd);
					}
				});
				exception.ResultState.Should().Be(ResultState.Failure);

			(from m in list
			 select (m.Name, m.State)
			)
			.Should().HaveCount(2)
					.And.ContainInOrder(new[] {
						("Given",State.Given)
					,("GivenAndFail",State.GivenAnd)
					});
			}

			[Test]
			public void Given_When_Then_Text_Monitoring_Processed_with_fail()
			{
				var list = new List<MonitorArgs>();
				var exception = Assert.Throws<AssertionException>(() =>
				{
					using (new TestExecutionContext.IsolatedContext())
					{
						Monitor.Instance.Processed += (args) => list.Add(args);
						this.Given(Given)
							.And(GivenAndFail)
							.When(When)
							.And(WhenAnd)
							.Then(Then)
							.And(ThenAnd);
					}
				});
				exception.ResultState.Should().Be(ResultState.Failure);

			list.Should().HaveCount(2);
			(from m in list
			select (m.Name,m.State,m.Passed)
			)
			.Should()
			.ContainInOrder(new[] {
						("Given", State.Given, true)
					, ("GivenAndFail", State.GivenAnd,false)
					});
			}

			void Given(){	}
			void GivenAnd()	{	}
			void GivenAndFail() { Assert.Fail(); }
			void When()	{	}
			void WhenAnd() { }
			void Then() { }
			void ThenAnd() { }
	}
}
