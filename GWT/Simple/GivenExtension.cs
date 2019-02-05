using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.Simple
{
	public static class GivenExtension
	{
		public static IGiven<Action> Given(this IGwtScene runner, Action given)
		{
			return new Scene(new SceneProcessor())
				.Given(given);
		}
	}
}
