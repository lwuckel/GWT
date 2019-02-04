using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GWT.NUnit3
{
	public class AssertAll
	{
		public static void Execute(params Action[] assertionsToRun)
		{
			var errorMessages = new List<Exception>();
			foreach (var action in assertionsToRun)
			{
				try
				{
					action.Invoke();
				}
				catch (Exception exc)
				{
					errorMessages.Add(exc);
				}
			}

			if (errorMessages.Any())
			{
				var separator = string.Format("{0}{0}", Environment.NewLine);
				string errorMessageString = string.Join(separator, errorMessages);

				Assert.Fail($@"The following condtions failed:
{errorMessageString}");
			}
		}
	}
}
