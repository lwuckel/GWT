using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using GWT.NUnit3;
using GWT;
using System.IO;
using System.Diagnostics;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;
using Moq;

namespace GWT.Tests
{
	[TestFixture]
	public class Monitor_output_into_logfile : IGwtScene
	{
		private string logfile;

		public Monitor_output_into_logfile()
		{
			this.logfile = Path.Combine(TestContext.CurrentContext.TestDirectory, @"log.txt");
			var stream = File.Create(logfile);
			stream.Dispose();

			Monitor.Instance.Processed += (args) =>
				AddOutput($@"{ (args.Passed ? "PASSED" : "FAILED")} #{args.State}: {args.Name}
{args.Exception.ToString()}
---------------------------");

			Monitor.Instance.TestBegin += () => 
			{
				AddOutput($@"########################
Scenario: {TestContext.CurrentContext.Test.ClassName}
Begin: {TestContext.CurrentContext.Test.MethodName}");
			};
			Monitor.Instance.TestEnd += () =>
			{
				AddOutput($@"End: {TestContext.CurrentContext.Test.FullName}
########################");
				Process.Start(this.logfile);
			};
		}

		void AddOutput(string message)
		{
			File.AppendAllText(logfile, message);
			File.AppendAllText(logfile, Environment.NewLine);
		}

		[Test, Explicit]
		public void Generate_output_for_every_exception()
		{
			var exception = Assert.Throws<MultipleAssertException>(() =>
			{
				using (new TestExecutionContext.IsolatedContext())
				{
					this.Given(Given)
						.And(GivenAndFail)
						.When(When)
						.And(WhenAnd)
						.Then(Then)
						.And(ThenAndException)
						.And(ThenAndMoqException)
						.And(ThenAnd)
						.Run();
				}
			});
			exception.ResultState.Should().Be(ResultState.Failure);
		}

		void Given() { }
		void GivenAnd() { }
		void GivenAndFail() { Assert.Fail(); }
		void When() { }
		void WhenAnd() { }
		void Then() { }
		void ThenAnd() { }
		void ThenAndException() { throw new Exception("Then failed"); }
		void ThenAndMoqException()
		{
			var mock = new Mock<IMockFail>();
			mock.Verify(m => m.Input());
		}

		public interface IMockFail
		{
			string Input();
		}
	}
}
