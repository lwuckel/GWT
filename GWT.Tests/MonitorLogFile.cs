using NUnit.Framework;
using System;
using System.IO;

namespace GWT.Tests
{
	class MonitorLogFile
	{
		private string logfile;
		public static MonitorLogFile Instance = null;

		public MonitorLogFile()
		{
			if (Instance == null)
			{
				Instance = this;
				this.logfile = Path.Combine(TestContext.CurrentContext.TestDirectory, @"log.txt");
				var stream = File.Create(logfile);
				stream.Dispose();

				Monitor.Instance.Processed += (args) =>
					AddOutput($@"{ (args.Passed ? "PASSED" : "FAILED")} #{args.State}: {args.Name}
Exception: {args.Exception?.ToString()}
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
					Console.WriteLine($"Log is written to '{this.logfile}'");
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
