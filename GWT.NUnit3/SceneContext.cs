namespace GWT.NUnit3
{
	public class SceneContext<TGiven, TWhen, TThen> : Simple.SceneContext<TGiven, TWhen, TThen>
	{
		public SceneContext(TGiven givenContext, TWhen whenContext, TThen thenContext) 
			: base(givenContext, whenContext, thenContext)
		{
			EnablePostProcessing<AssertAllProcessor>();
		}
	}
}
