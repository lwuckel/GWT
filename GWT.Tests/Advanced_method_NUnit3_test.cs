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
			var properties = new TestProperties();
			var exception = Assert.Throws<GwtAssertException>(() =>
			{
				using var _ = new TestExecutionContext.IsolatedContext();
				TestContext.Create(properties).Run(ScenarioA);
			});

			exception.Should().NotBeNull();
			exception?.Exceptions.Should().HaveCount(3);
			Console.WriteLine(exception);
			properties.Counter.Should().Be(4);
		}


		[Test]
		public void SceneContext_test_When()
		{
			var properties = new TestProperties();
			var exception = Assert.Throws<GwtAssertException>(() =>
			{
				using var _ = new TestExecutionContext.IsolatedContext();
				TestContext.Create(properties).Run(ScenarioB);
			});

			exception.Should().NotBeNull();
			exception?.Exceptions.Should().HaveCount(3);
			Console.WriteLine(exception);
			properties.Counter.Should().Be(3);
		}


		[Test]
		public void SceneContext2_test()
		{
			var properties = new TestProperties();
			var exception = Assert.Throws<GwtAssertException>(() =>
			{
				using var _ = new TestExecutionContext.IsolatedContext();
				TestContext.Create(properties).Run(ScenarioC);
			});

			exception.Should().NotBeNull();
			exception?.Exceptions.Should().HaveCount(3);
			Console.WriteLine(exception);
			properties.Counter.Should().Be(4);
		}
	}
}