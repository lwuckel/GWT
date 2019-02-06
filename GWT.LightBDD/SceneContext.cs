using LightBDD.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWT.LightBDD
{
	public class SceneContext<TGiven, TWhen, TThen> : Simple.SceneContext<TGiven, TWhen, TThen>
	{
		public SceneContext(IBddRunner bddRunner, TGiven givenContext, TWhen whenContext, TThen thenContext) : base(givenContext, whenContext, thenContext)
		{
			this.Tag = bddRunner;

			EnablePostProcessing(new SceneRunnerProcessor(()=>(Scene)given));
		}
	}
}
