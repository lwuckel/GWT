using System;
using System.Collections.Generic;
using System.Text;

namespace GWT
{
	public class Monitor
	{
		public readonly static Monitor Instance = new Monitor();

		public event Action<string> Processing;
		public event Action<string,bool> Processed;

		public void RaiseProcessing(string text) => this.Processing?.Invoke(text);
		public void RaiseProcessed(string text, bool failed) => this.Processed?.Invoke(text,failed);

	}
}
