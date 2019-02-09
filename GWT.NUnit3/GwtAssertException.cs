using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GWT.NUnit3
{
	public class GwtAssertException : AssertionException
	{
		public GwtAssertException(Exception[] exceptions) : base("")
		{
			this.Exceptions = exceptions;
		}

		public Exception[] Exceptions
		{
			get; private set;
		}

		public override string ToString()
		{
			var builder = new StringBuilder($"{this.Exceptions.Length} Exceptions are collected");
			builder.AppendLine();
			builder.AppendLine();

			foreach (var exception in this.Exceptions)
			{
				builder.Append(exception);
				builder.AppendLine();
				builder.AppendLine();
			}

			return builder.ToString();
		}
	}
}
