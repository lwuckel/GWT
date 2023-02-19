using GWT.NUnit3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.Tests
{
	partial class Advanced_method_NUnit3_test
	{
		class TestProperties
		{
			public int Counter = 0;
		}

		class TestContext : SceneContext<Givens, Whens, Thens>, IDisposable
		{
			private bool disposedValue;

			public bool IsDisposed => disposedValue;

			public static TestContext Create(TestProperties testProperties = null)
			{
				testProperties = testProperties ?? new TestProperties();
				return new TestContext(testProperties);
			}

			TestContext(TestProperties testProperties) 
				: base(new Givens(testProperties), new Whens(testProperties), new Thens(testProperties))
			{
				testProperties.Counter = 0;
			}

			protected virtual void Dispose(bool disposing)
			{
				if (!disposedValue)
				{
					if (disposing)
					{
						// TODO: Verwalteten Zustand (verwaltete Objekte) bereinigen
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
