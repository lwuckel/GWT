using System;

namespace GWT.LightBDD
{
	public class SceneRunnerProcessor : DefaultProcessor
	{
		private readonly Scene scene;

		public SceneRunnerProcessor(Scene scene) 
		{
			this.scene = scene;
		}

		public override void Processing(Action[] givens, Action[] whens, Action[] thens)
		{
			scene.Run(givens, whens, thens);
		}
	}
}
