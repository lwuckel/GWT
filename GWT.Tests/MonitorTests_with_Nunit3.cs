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
			var list = new List<MonitorArgs>();
			Monitor.Instance.Processing += (args) => list.Add(args);

			this.Given(Given)
				.And(GivenAnd)
				.When(When)
				.And(WhenAnd)
				.Then(Then)
				.And(ThenAnd)
				.Run();

			(from m in list
			select (m.Name,m.State)
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

			var exception = Assert.Throws<GwtAssertException>(() =>
			{
				using (new TestExecutionContext.IsolatedContext())
				{
					this.Given(Given)
						.And(GivenAndFail)
						.When(When)
						.And(WhenAnd)
						.Then(Then)
						.And(ThenAnd)
						.Run();
				}
			});

			exception.Exceptions.Should().HaveCount(1);

			(from m in list
			 select (m.Name, m.State)
			)
			.Should().HaveCount(6)
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
			var list = new List<MonitorArgs>();
			Monitor.Instance.Processed += (args) => list.Add(args);

			var exception = Assert.Throws<GwtAssertException>(() =>
			{
				using (new TestExecutionContext.IsolatedContext())
				{
					this.Given(Given)
						.And(GivenAndFail)
						.When(When)
						.And(WhenAnd)
						.Then(Then)
						.And(ThenAnd)
						.Run();
				}
			});

			exception.Exceptions.Should().HaveCount(1);

			(from m in list
			 select (m.Name, m.State, m.Passed)
			)
			.Should().HaveCount(6)
				.And.ContainInOrder(new[] {
					("Given", State.Given, true)
				, ("GivenAndFail", State.GivenAnd,false)
				, ("When",State.When,true)
				, ("WhenAnd",State.WhenAnd,true)
				, ("Then",State.Then,true)
				, ("ThenAnd",State.ThenAnd,true)
				});
		}

		void Given() { }
		void GivenAnd() { }
		void GivenAndFail() { Assert.Fail(); }
		void When() { }
		void WhenAnd() { }
		void Then()	{	}
		void ThenAnd() { }
	}
}
