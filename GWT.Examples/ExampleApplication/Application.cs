using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.Examples.ExampleApplication
{
	internal class Application
	{
		public object Data { get; private set; }
		public void Start() { }
		public void Stop() { }
		public void Read() 
		{
			this.Data = 1;
		}
		public void Write() { }
		public void Input() { }
	}
}
