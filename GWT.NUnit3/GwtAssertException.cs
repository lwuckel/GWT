using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GWT.NUnit3
{
	public class GwtAssertException : AssertionException
	{
		public GwtAssertException(Exception[] exceptions) : base("", exceptions.FirstOrDefault())
		{
			this.Exceptions = exceptions;			
		}

		public override ResultState ResultState
		{
			get
			{
				return this.Exceptions.Where( e => e is AssertionException)
					.Cast<AssertionException>()
					.Select(ex => ex.ResultState)
					.FirstOrDefault();
			}
		}

		public override string StackTrace
		{
			get => GetOutout(ex => ex.StackTrace);
		}

		public Exception[] Exceptions
		{
			get; private set;
		}

		public override string Message
		{
			get => ToString();
		}

		public override string ToString()
		{
			return GetOutout( ex => ex.ToString());
		}

		private string GetOutout(Func<Exception, string> text)
		{
			var builder = new StringBuilder($"{this.Exceptions.Length} Exceptions are collected");
			builder.AppendLine();
			builder.AppendLine();

			foreach (var exception in this.Exceptions)
			{
				builder.Append(text(exception));
				builder.AppendLine();
				builder.AppendLine("_____________________________________");
			}

			return builder.ToString();
		}
	}
}
