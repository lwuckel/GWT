using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.Tests
{
	class MonitorLogFile
	{
		private string logfile;
		public MonitorLogFile Instance = null;

		public MonitorLogFile()
		{
			if (this.Instance == null)
			{
				this.Instance = this;
				this.logfile = Path.Combine(TestContext.CurrentContext.TestDirectory, @"log.txt");
				var stream = File.Create(logfile);
				stream.Dispose();

				Monitor.Instance.Processed += (args) =>
					AddOutput($@"{ (args.Passed ? "PASSED" : "FAILED")} #{args.State}: {args.Name}
{args.Exception?.ToString()}
---------------------------");

				Monitor.Instance.TestBegin += () =>
				{
					AddOutput($@"########################
Scenario: {TestContext.CurrentContext.Test.ClassName}
Begin: {TestContext.CurrentContext.Test.MethodName}");
				};

				bool openFile = true;
				Monitor.Instance.TestEnd += () =>
				{
					AddOutput($@"End: {TestContext.CurrentContext.Test.FullName}
########################");

					if (openFile)
					{
						openFile = false;
						Process.Start(this.logfile);
					}
				};
			}
		}

		void AddOutput(string message)
		{
			File.AppendAllText(logfile, message);
			File.AppendAllText(logfile, Environment.NewLine);
		}
	}
}
