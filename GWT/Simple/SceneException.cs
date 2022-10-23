using System;
using System.Collections.Generic;
using System.Text;

namespace GWT.Simple
{
	public class SceneException : Exception
	{
		public SceneException(string message, Exception innerException) : base(message,innerException)
		{

		}
	}
}
