using System;
using System.Collections.Generic;
using System.Text;

namespace GWT
{
	public class ActionTextBuilder
	{
		public static string GetText(Action a)
		{
			return a.Method.Name;
		}
	}
}
