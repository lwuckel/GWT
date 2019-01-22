using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.Tests
{
	partial class Advanced_method_NUnit3_test
	{
		class Givens
		{
			void A_Implementation() { ++Parameter.Counter;  }
			public GivenResult<Givens, Whens> A => TestContext.CreateGiven(A_Implementation);
		}
	}
}
