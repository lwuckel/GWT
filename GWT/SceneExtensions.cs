using GWT.Simple;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT
{
	/// <summary>
	/// Extention methods for Given-When-Then
	/// </summary>
	public static class SceneExtensions
	{
		public static void Run<TThen>(this ThenResult<TThen, Action> thenResult, Action<Action[],Action[], Action[]> processor = null)
		{
			var then = (Scene)thenResult.To();
			then.Run(processor);
		}

		/// <summary>
		/// Run the definition of the Scene
		/// <see cref="Scene{TAction}"/>
		/// </summary>
		/// <param name="then">Then-object</param>
		public static void Run<TThen>(this IThen<TThen> then, Action<Action[], Action[], Action[]> processor = null)
		{
			var scene = (Scene)then;
			scene.Run(processor);
		}

		/// <summary>
		/// Run the definition of the Scene
		/// <see cref="Scene{TAction}"/>
		/// </summary>
		/// <param name="then">Then-object</param>
		public static void Run(this Scene scene, Action<Action[], Action[], Action[]> processor = null)
		{
			try
			{
				var steps = scene.AllSteps();

				if (processor != null)
					processor(steps.givens, steps.whens, steps.thens);
				else
					scene.Processor.Processing(steps.givens, steps.whens, steps.thens);
			}
			finally
			{
				Monitor.Instance.RaiseTestEnd();
				Monitor.Reset();

				scene.Clear();
			}
		}
	}
}
