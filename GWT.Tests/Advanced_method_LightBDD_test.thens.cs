using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.Tests
{
	partial class Advanced_method_LightBDD_test
	{
		class Thens {
			void C_Implementation() { ++Parameter.Counter; }
			public ThenResult<Thens, Action> C => TestContext.CreateThen(C_Implementation);

		}
	}
}
