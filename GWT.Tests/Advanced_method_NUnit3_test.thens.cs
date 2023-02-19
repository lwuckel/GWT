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
		class Thens {
			private TestProperties testProperties;

			public Thens(TestProperties testProperties)
			{
				this.testProperties = testProperties;
			}

			void C_Implementation()
			{
				++this.testProperties.Counter;
			}
			public ThenResult<Thens, Action> Add_1_to_counter => TestContext.CreateThen(C_Implementation);
			public ThenResult<Thens, Action> ItFail => TestContext.CreateThen(() => Assert.Fail());

		}
	}
}
