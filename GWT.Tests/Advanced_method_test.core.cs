using GWT.NUnit3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.Tests
{
	partial class Advanced_method_test
	{
		class Parameter
		{
			public static int Counter = 0;
		}

		class TestContext : SceneContext<Givens, Whens, Thens>, IDisposable
		{
			private bool disposedValue;

			public TestContext() 
				: base(new Givens(), new Whens(), new Thens())
			{
				Parameter.Counter = 0;
			}

			public bool IsDisposed => this.disposedValue;

			protected virtual void Dispose(bool disposing)
			{
				if (!disposedValue)
				{
					if (disposing)
					{

					}

					// TODO: Nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalizer überschreiben
					// TODO: Große Felder auf NULL setzen
					disposedValue = true;
				}
			}

			// // TODO: Finalizer nur überschreiben, wenn "Dispose(bool disposing)" Code für die Freigabe nicht verwalteter Ressourcen enthält
			// ~TestContext()
			// {
			//     // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
			//     Dispose(disposing: false);
			// }

			public void Dispose()
			{
				// Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}
		}
	}
}
