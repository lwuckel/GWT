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
				throw new Exception("B_Implementation");

			}

			// Description for Monitor Output
			[System.ComponentModel.Description("Description B")]
			void B_Implementation2()
			{
			}

			void _Empty()
			{

			}

			public WhenResult<Whens, Thens> BAction 
				=> TestContext.CreateWhen(B_Implementation2);
			public WhenResult<Whens, Thens> Empty => TestContext.CreateWhen(_Empty);

			public WhenResult<Whens, Thens> ThrowException	=> TestContext.CreateWhen(()=>throw new Exception());

		}
	}
}
