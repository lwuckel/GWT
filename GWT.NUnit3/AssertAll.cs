using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GWT.NUnit3
{
	public class AssertAll
	{
		List<Exception> Exceptions
		{
			get;
		} = new List<Exception>();

		public void Execute(bool collectExceptions, params Action[] assertionsToRun)
		{
			foreach (var action in assertionsToRun)
			{
				try
				{
					action.Invoke();
				}
				catch (Exception exc)
				{
					if (collectExceptions)
						Exceptions.Add(exc);
					else
						throw;
				}
			}
		}

		public void ThrowAsserts()
		{
			if (this.Exceptions.Count >0)
				throw new GwtAssertException(this.Exceptions.ToArray());
		}
	}
}
