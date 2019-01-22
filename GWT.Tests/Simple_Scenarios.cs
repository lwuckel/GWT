using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWT;
using FluentAssertions;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;
using GWT.Simple;

namespace GWT.Tests
{
	[TestFixture]
	public class Simple_Scenarios : IGwtScene
	{
		int counter = 0;


		[Test]
		public void Processing_should_fail_1_time()
		{
			this.counter = 0;

			var exception = Assert.Throws<AssertionException>(() =>
			{
				using (new TestExecutionContext.IsolatedContext())
				{
					this
						.Given(Counter)
						.When(Counter)
						.Then(ShouldFailed)
						.And(ShouldFailed);
				}
			});

			exception.ResultState.Should().Be(ResultState.Failure);
		}

		[Test]
		public void Processing_should_count()
		{
			this.counter = 0;

			this
				.Given(Counter)
				.And(Counter)
				.When(Counter)
				.And(Counter)
				.Then(Counter)
				.And(Counter);

			this.counter.Should().Be(6);
		}

		[Test]
		public void PostProcessing_should_count()
		{
			this.counter = 0;

			this
				.Given(Counter)
				.And(Counter)
				.When(Counter)
				.And(Counter)
				.Then(Counter)
				.And(Counter)
				.Run();

			this.counter.Should().Be(6);
		}

		public void Counter()	{ ++this.counter; }
		public void ShouldFailed() { ++this.counter; Assert.Fail(); }
	}
}
