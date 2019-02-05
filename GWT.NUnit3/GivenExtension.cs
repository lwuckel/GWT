using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.NUnit3
{
	public static class GivenExtension
	{
		public static IGiven<Action> Given(this IGwtScene runner, Action action)
		{
			var scene = new Scene(new AssertAllProcessor(), postProcessing: true);
			return scene.Given(action);
		}
	}
}
