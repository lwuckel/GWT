using GWT.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GWT.Tests.StaticContext;

namespace GWT.Tests
{
	partial class Advanced_method_NUnit3_test
	{
		class Givens
		{
			private TestProperties testProperties;

			public Givens(TestProperties testProperties)
			{
				this.testProperties = testProperties;
			}

			void A_Implementation()
			{
				++this.testProperties.Counter;
			}

			public GivenResult<Givens, Whens> Add_1_to_counter 
				=> TestContext.CreateGiven(A_Implementation);
		}
	}
}
