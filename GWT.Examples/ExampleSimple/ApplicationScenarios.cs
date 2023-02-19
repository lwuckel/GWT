using FluentAssertions;
using GWT.Examples.ExampleApplication;
using GWT.LightBDD;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.Examples.ExampleSimple
{
	[TestFixture]
	internal class ApplicationScenarios : IGwtScene
	{
		private Application? application = null;

		[Test]
		public void Scenario_Read() 
		{
			this.Given(User_run_application)
				.And(User_start_operation)
				.When(Application_read_something)
				.Then(Data_should_be_avaiable);
		}

		private void Data_should_be_avaiable()
		{
			this.application?.Data.Should().NotBeNull();
		}

		private void Application_read_something()
		{
			this.application?.Read();
		}

		private void User_start_operation()
		{
			this.application?.Start();
		}

		void User_run_application() 
		{
			this.application = new Application();
		}
	}
}
