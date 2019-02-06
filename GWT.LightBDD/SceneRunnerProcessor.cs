using System;

namespace GWT.LightBDD
{
	public class SceneRunnerProcessor : DefaultProcessor
	{
		private readonly Func<Scene> scene;

		public SceneRunnerProcessor(Func<Scene> scene) 
		{
			this.scene = scene;
		}

		public override void Processing(Action[] givens, Action[] whens, Action[] thens)
		{
			this.scene().Run(givens, whens, thens);
		}
	}
}
