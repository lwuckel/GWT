using System;
using System.Collections.Generic;
using System.Text;

namespace GWT
{
	public abstract class DefaultProcessor : ISceneProcessor
	{
		public abstract void Processing(Action[] givens, Action[] whens, Action[] thens);
	
		public ISceneProcessor Processor => new SceneProcessor();
		public void ProcessingGiven(Action given) 
			=> this.Processor.ProcessingGiven(given);
		public void ProcessingGivenAnd(Action given) 
			=> this.Processor.ProcessingGivenAnd(given);
		public void ProcessingWhen(Action when) 
			=> this.Processor.ProcessingWhen(when);
		public void ProcessingWhenAnd(Action when) 
			=> this.Processor.ProcessingWhenAnd(when);
		public void ProcessingThen(Action then) 
			=> this.Processor.ProcessingThen(then);
		public void ProcessingThenAnd(Action then) 
			=> this.Processor.ProcessingThenAnd(then);
		public void ProcessingGivens(Action[] givens) 
			=> this.Processor.ProcessingGivens(givens);
		public void ProcessingWhens(Action[] whens) 
			=> this.Processor.ProcessingWhens(whens);
		public void ProcessingThens(Action[] thens) 
			=> this.Processor.ProcessingThens(thens);
	}
}