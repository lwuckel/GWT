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

		public void Execute(params Action[] assertionsToRun)
		{
			foreach (var action in assertionsToRun)
			{
				try
				{
					action.Invoke();
				}
				catch (Exception exc)
				{
					Exceptions.Add(exc);
				}
			}
		}

		public void ThrowAsserts()
		{
			this.Exceptions
				.ForEach(e =>
			{
				if (!(e is AssertionException))
					Assert.Fail(e.ToString());
			}
			);
		}
	}
}
