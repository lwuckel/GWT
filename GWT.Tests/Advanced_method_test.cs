using FluentAssertions;
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
	partial class Advanced_method_test
	{
		[Test]
		public void SceneContext_test()
		{
			var exception = Assert.Throws<AssertionException>(() =>
			{
				using (new TestExecutionContext.IsolatedContext())
				{
					new TestContext()
						.Given.A
						.When.B_Should_Fail
						.And.B_Should_Fail
						.Then.C
						.Run();
				}
			});

			exception.ResultState.Should().Be(ResultState.Failure);

			Parameter.Counter.Should().Be(2);
		}
	}
}
