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
						.Given.A
						.When.B_Should_Fail2
						.And.B_Should_Fail
						.And.B_Should_Fail
						.Then.C
						.Run();
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
					new TestContext()
						.When.B_Should_Fail2
						.And.B_Should_Fail
						.And.B_Should_Fail
						.Then.C
						.Run();
				}
			});

			exception.Exceptions.Should().HaveCount(3);
			Console.WriteLine(exception);
			Parameter.Counter.Should().Be(4);
		}
		[Test]
        public void SceneContext2_test()
        {
            var exception = Assert.Throws<GwtAssertException>(() =>
            {
                using (new TestExecutionContext.IsolatedContext())
                {
                    new TestContext()
                        .Given.A
                        .When.B_Should_Fail2
                        .And.B_Should_Fail
                        .And.B_Should_Fail
                        .Then.C
                        .Run();
                }
            });

            exception.Exceptions.Should().HaveCount(3);
            Console.WriteLine(exception);
            Parameter.Counter.Should().Be(4);
        }
    }
}
	