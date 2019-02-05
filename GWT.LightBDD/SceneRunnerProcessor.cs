using System;

namespace GWT.LightBDD
{
	public class SceneRunnerProcessor : DefaultProcessor
	{
		public SceneRunnerProcessor(Scene scene) : base(scene)
		{
		}

		public override void Processing(Action[] givens, Action[] whens, Action[] thens)
		{
			scene.Run(givens, whens, thens);
		}
	}
}
