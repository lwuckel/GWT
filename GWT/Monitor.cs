using System;
using System.Collections.Generic;
using System.Text;

namespace GWT
{
	public class Monitor
	{
		public static Monitor Instance
		{
			get;
			private set;
		}	= new Monitor();

		public event Action TestBegin;
		public event Action TestEnd;

		public event Action<MonitorArgs> Processing;
		public event Action<MonitorArgs> Processed;

		public void RaiseProcessing(string text, State state) => 
			this.Processing?.Invoke(new MonitorArgs(text,state,null,true));
		public void RaiseProcessed(string text, State state, Exception exception, bool passed) => 
			this.Processed?.Invoke(new MonitorArgs(text,state,exception,passed));
		public void RaiseTestBegin() => TestBegin?.Invoke();
		public void RaiseTestEnd() => TestEnd?.Invoke();
		public static void Reset() => Instance = new Monitor();
	}

	public class MonitorArgs : EventArgs
	{
		public MonitorArgs(string name, State state, Exception exception, bool passed)
		{
			this.State = state;
			this.Name = name;
			this.Exception = exception;
			this.Passed = passed;
		}

		public Exception Exception { get; }
		public State State { get; }
		public string Name { get; }
		public bool Passed { get; }
	}

	public enum State
		{ Given, GivenAnd, When, WhenAnd, Then, ThenAnd};
}
