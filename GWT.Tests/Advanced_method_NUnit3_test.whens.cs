using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.Tests
{
	partial class Advanced_method_NUnit3_test
	{
		class Whens {
			private TestProperties testProperties;

			public Whens(TestProperties testProperties)
			{
				this.testProperties = testProperties;
			}

			void B_Implementation() {
				++this.testProperties.Counter;
				Assert.Fail();

			}

			// Description for Monitor Output
			[System.ComponentModel.Description("Description B")]
			void B_Implementation2()
			{
				int a = 2;
				a.Should().Be(3);
			}

			void _Empty()
			{
			}
			public WhenResult<Whens, Thens> Add_1_to_counter_and_fail => TestContext.CreateWhen(B_Implementation);
			public WhenResult<Whens, Thens> Fail_2_should_be_3 => TestContext.CreateWhen(B_Implementation2);
			public WhenResult<Whens, Thens> Empty => TestContext.CreateWhen(_Empty);

		}
	}
}
