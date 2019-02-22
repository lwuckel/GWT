using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;
using System.Reflection;

namespace GWT
{
	public class ActionTextBuilder
	{
		public static string GetText(Action a)
		{
			var attribute = a.Method.GetCustomAttribute<DescriptionAttribute>();

			if (attribute != null)
				return ((DescriptionAttribute)attribute).Description;

			return a.Method.Name;
		}
	}
}
