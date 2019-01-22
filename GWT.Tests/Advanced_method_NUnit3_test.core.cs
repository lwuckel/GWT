﻿using GWT.NUnit3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.Tests
{
	partial class Advanced_method_NUnit3_test
	{
		class Parameter
		{
			public static int Counter = 0;
		}

		class TestContext : SceneContext<Givens, Whens, Thens>
		{
			public TestContext() 
				: base(new Givens(), new Whens(), new Thens())
			{
				Parameter.Counter = 0;
			}
		}
	}
}
