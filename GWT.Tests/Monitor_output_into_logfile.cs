using NUnit.Framework;
using System;
using FluentAssertions;
using GWT.NUnit3;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;
using Moq;

namespace GWT.Tests
{
	[TestFixture]
	public class Monitor_output_into_logfile : IGwtScene
	{
		MonitorLogFile logFile = new MonitorLogFile();

		[Test, Explicit]
		public void Generate_output_for_every_exception()
		{
			var exception = Assert.Throws<GwtAssertException>(() =>
			{
				using (new TestExecutionContext.IsolatedContext())
				{
					this.Given(Given)
						.And(GivenAndFail)
						.When(When)
						.And(WhenAnd)
						.Then(Then)
						.And(ThenAndException)
						.And(ThenAndMoqException)
						.And(ThenAnd)
						.Run();
				}
			});
			exception.Exceptions.Should().HaveCount(3);
		}

		void Given() { }
		void GivenAnd() { }
		void GivenAndFail() { Assert.Fail(); }
		void When() { }
		void WhenAnd() { }
		void Then() { }
		void ThenAnd() { }
		void ThenAndException() { throw new Exception("Then failed"); }
		void ThenAndMoqException()
		{
			var mock = new Mock<IMockFail>();
			mock.Verify(m => m.Input());
		}

		public interface IMockFail
		{
			string Input();
		}
	}
}
