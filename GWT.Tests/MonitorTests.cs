using FluentAssertions;
using GWT.Simple;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.Tests
{
	[TestFixture]
	public class MonitorTests : IGwtScene
	{
		[Test]
		public void Processing()
		{
			string textResult = null;
			Monitor.Instance.Processing += text => textResult = text;
			this.Given(A);

			textResult.Should().Be("A");
		}

		void A()
		{

		}
	}
}
