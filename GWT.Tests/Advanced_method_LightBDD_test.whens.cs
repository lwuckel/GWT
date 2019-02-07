using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.Tests
{
	partial class Advanced_method_LightBDD_test
	{
		class Whens {
			void B_Implementation() {
				++Parameter.Counter;
				++Parameter.Counter;
				Assert.Fail();
			}
			public WhenResult<Whens, Thens> B_Should_Fail => TestContext.CreateWhen(B_Implementation);

		}
	}
}
