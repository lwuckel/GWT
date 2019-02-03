using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GWT
{
	public class Processor
	{
		public static void ProcessActions(Action[] actions, State state, State andState)
		{
			actions.ToList()
				.ForEach(b =>
				{
					Processor.ProcessAction(b, state);
					state = andState;
				});
		}

		public static void ProcessAction(Action b, State state)
		{
			string text = ActionTextBuilder.GetText(b);
			Monitor.Instance.RaiseProcessing(text, state);
			bool failed = false;
			try
			{
				b(); 
			}
			// AssertFailedException 
			catch
			{
				failed = true;
				throw;
			}
			finally
			{
				Monitor.Instance.RaiseProcessed(text, state, failed);
			}
		}
	}
}
