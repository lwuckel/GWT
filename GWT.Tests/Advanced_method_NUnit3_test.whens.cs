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
			void B_Implementation() {
				++Parameter.Counter;
				Assert.Fail();

			}
			void B_Implementation2()
			{
				int a = 2;
				a.Should().Be(3);
			}
			public WhenResult<Whens, Thens> B_Should_Fail => TestContext.CreateWhen(B_Implementation);
			public WhenResult<Whens, Thens> B_Should_Fail2 => TestContext.CreateWhen(B_Implementation2);

		}
	}
}
