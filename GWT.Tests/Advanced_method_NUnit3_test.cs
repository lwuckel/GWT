using FluentAssertions;
using GWT.NUnit3;
using GWT.Simple;
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
		public void SceneContext_FailTwoTimeAndCounterShouldBe1()
		{
			var properties = new TestProperties();
			var exception = Assert.Throws<GwtAssertException>(() =>
			{
				using var _ = new TestExecutionContext.IsolatedContext();
				TestContext.Create(properties).Run(ScenarioFailTwoTimes);
			});

			exception.Should().NotBeNull();
			exception?.Exceptions.Should().HaveCount(2);
			Console.WriteLine(exception);
			properties.Counter.Should().Be(1);
		}


		[Test]
		public void SceneContext_ThrowException()
		{
			var properties = new TestProperties();
			var exception = Assert.Throws<Exception>(() =>
			{
				using var _ = new TestExecutionContext.IsolatedContext();
				TestContext.Create(properties).Run(ScenarioThrowExceptionInWhen);
			});

			Console.WriteLine(exception);
			properties.Counter.Should().Be(0);
		}


		[Test]
		public void SceneContextD_test()
		{
			var properties = new TestProperties();
			var testContext = TestContext.Create(properties);

			var exception = Assert.Throws<SceneException>(() =>
			{
				using var _ = new TestExecutionContext.IsolatedContext();
				testContext.Run(Scenario_GivenSceneFailed);
			});

			exception.Should().NotBeNull();
			Console.WriteLine(exception);
			properties.Counter.Should().Be(1);
		}

	}
}