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
	public class Simple_Scenarios_with_NUnit3 : IGwtScene
	{
		private int counter;

		[Test]
		public void PostProcessing_should_fail_2_times()
		{
			this.counter = 0;

			var exception = Assert.Throws<MultipleAssertException>(() =>
			{
				using (new TestExecutionContext.IsolatedContext())
				{
					this
						.Given(Counter)
						.When(Counter)
						.Then(ShouldFailed)
						.And(ShouldFailed)
						.Run();
				}
			});

			exception.TestResult.AssertionResults.Should().HaveCount(2);
			exception.TestResult.AssertionResults.Select(a => a.Status)
				.Should()
				.OnlyContain(x => x == AssertionStatus.Failed);
		}

		public void Counter() { ++this.counter; }
		public void ShouldFailed() { ++this.counter; Assert.Fail(); }
	}
}
