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
		public static void Run(this IThen<Action> then, Action<Action[], Action[],Action[]> processor = null )
		{
			var scene = (Scene)then;
			var steps = scene.AllSteps();

			if (processor != null)
				processor(steps.givens,steps.whens,steps.thens);
			else
				scene.Process(steps.givens,steps.whens,steps.thens);
		}
	}
}
