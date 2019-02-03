using System;
using System.Collections.Generic;
using System.Text;

namespace GWT
{
	public class Monitor
	{
		public readonly static Monitor Instance = new Monitor();

		public event Action<string, State> Processing;
		public event Action<string, State, bool> Processed;

		public void RaiseProcessing(string text, State state) => 
			this.Processing?.Invoke(text,state);
		public void RaiseProcessed(string text, State state, bool failed) => 
			this.Processed?.Invoke(text,state,failed);

	}

	public enum State
		{ Given, GivenAnd, When, WhenAnd, Then, ThenAnd};
}
