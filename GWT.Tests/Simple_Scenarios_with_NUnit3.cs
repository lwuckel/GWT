﻿using FluentAssertions;
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
			this.counter = 2;

			var exception = Assert.Throws<GwtAssertException>(() =>
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

			this.counter.Should().Be(10);
			exception.Exceptions.Should().HaveCount(2);
		}

		public void Counter() { this.counter*=2; }
		public void ShouldFailed()
		{
			++this.counter;
			int a = 1;
			a.Should().Be(2);
		}
	}
}
