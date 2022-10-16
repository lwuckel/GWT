using GWT.NUnit3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.Tests
{
	partial class Advanced_method_NUnit3_test
	{
		class TestProperties
		{
			public int Counter = 0;
		}

		class TestContext : SceneContext<Givens, Whens, Thens>
		{
			public static TestContext Create(TestProperties testProperties = null)
			{
				testProperties = testProperties ?? new TestProperties();
				return new TestContext(testProperties);
			}

			TestContext(TestProperties testProperties) 
				: base(new Givens(testProperties), new Whens(testProperties), new Thens(testProperties))
			{
				testProperties.Counter = 0;
			}
		}
	}
}
