using GWT.LightBDD;
using LightBDD.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.Tests
{
	partial class Advanced_method_LightBDD_test
	{
		class Parameter
		{
			public static int Counter = 0;
		}

		class TestContext : GWT.LightBDD.SceneContext<Givens, Whens, Thens>
		{
			public TestContext(IBddRunner bddRunner) 
				: base(bddRunner, new Givens(), new Whens(), new Thens())
			{
				Parameter.Counter = 0;
			}
		}
	}
}
