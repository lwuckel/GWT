using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GWT
{
	public class Processor : IProcessor
	{
		public void ProcessActions(Action[] actions, State state, State andState)
		{
			//var actionList = 
			(from action in actions
			select new Action(() =>
			{
				ProcessAction(action, state);
				state = andState;
			})
			).ToList()
			.ForEach( a=> a() );
		}

		public void ProcessAction(Action b, State state)
		{
			string text = ActionTextBuilder.GetText(b);
			Monitor.Instance.RaiseProcessing(text, state);
			Exception exception = null;
			bool failed = false;

			try
			{
				b(); 
			}
			// AssertFailedException 
			catch(Exception ex)
			{
				exception = ex;
				failed = true;
				throw;
			}
			finally
			{
				Monitor.Instance.RaiseProcessed(text, state,exception, !failed);
			}
		}
	}
}
