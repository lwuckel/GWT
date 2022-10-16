using FluentAssertions;
using GWT.NUnit3;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;

namespace GWT.Tests
{
	[TestFixture]
	partial class Advanced_method_NUnit3_test
	{
		MonitorLogFile logFile = new MonitorLogFile();

		[Test]
		public void SceneContext_test()
		{
			var exception = Assert.Throws<GwtAssertException>(() =>
			{
				using (new TestExecutionContext.IsolatedContext())
				{
					new TestContext()
						.Run(ScenarioA);
				}
			});

			exception.Exceptions.Should().HaveCount(3);
			Console.WriteLine(exception);
			Parameter.Counter.Should().Be(4);
		}


		[Test]
		public void SceneContext_test_When()
		{
			var exception = Assert.Throws<GwtAssertException>(() =>
			{
				using (new TestExecutionContext.IsolatedContext())
				{
					new TestContext().Run(ScenarioB);
				}
			});

			exception.Exceptions.Should().HaveCount(3);
			Console.WriteLine(exception);
			Parameter.Counter.Should().Be(3);
		}


		[Test]
		public void SceneContext2_test()
		{
			var exception = Assert.Throws<GwtAssertException>(() =>
			{
				using (new TestExecutionContext.IsolatedContext())
				{
					new TestContext().Run(ScenarioC);
				}
			});

			exception.Exceptions.Should().HaveCount(3);
			Console.WriteLine(exception);
			Parameter.Counter.Should().Be(4);
		}
	}
}
	