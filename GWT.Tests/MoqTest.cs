using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using GWT.NUnit3;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace GWT.Tests
{
	[TestFixture]
	public class MoqTest : IGwtScene
	{
		[Test]
		public void VerifyTest()
		{
			var list = new List<MonitorArgs>();
			Monitor.Instance.Processed += (args) => list.Add(args);

			var exception = Assert.Throws<GwtAssertException>(() =>
			{
				using (new TestExecutionContext.IsolatedContext())
				{
					this.Given(Given)
						.And(GivenAnd)
						.When(When)
						.And(WhenAnd)
						.Then(ThenMoqException)
						.And(ThenAnd)
						.Run();
				}
			});

			(from m in list
			 select (m.Name, m.State, m.Passed)
			)
			.Should().HaveCount(6)
				.And.ContainInOrder(new[] {
					("Given", State.Given, true)
				, ("GivenAnd", State.GivenAnd,true)
				, ("When",State.When,true)
				, ("WhenAnd",State.WhenAnd,true)
				, ("ThenMoqException",State.Then,false)
				, ("ThenAnd",State.ThenAnd,true)
				});

		}

		void Given()
		{
		}
		void GivenAnd()
		{
		}
		void When()
		{
		}
		void WhenAnd()
		{
		}
		void ThenMoqException()
		{
			var moq = Mock.Of<IMoqTest>();		
			var mock = Mock.Get(moq);

			mock.Verify(m => m.Call(),Times.AtLeastOnce());
		}
		void ThenAnd()
		{
		}

		public interface IMoqTest
		{
			void Call();
		}
	}
}
