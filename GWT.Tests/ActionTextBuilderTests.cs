using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.Tests
{
	[TestFixture]
	public class ActionTextBuilderTests
	{
		[Test]
		public void Action_Name()
		{
			string name = ActionTextBuilder.GetText(TestName);
			name.Should().Be("TestName");
		}

		void TestName() { }
	}
}
