using System;
using System.Collections.Generic;
using System.Text;

namespace GWT.Simple
{
	/// <summary>
	/// fluent design of the Given-When-then definition.
	/// Every part can be collect in class. So you have
	/// a seperate class for givens, whens and thens.
	/// In huge scenarios maybe is easier to share functionality.
	/// </summary>
	/// <typeparam name="TGiven">Type of the class for given-methods</typeparam>
	/// <typeparam name="TWhen">Type of the class for when-methods</typeparam>
	/// <typeparam name="TThen">Type of the class for then-methods</typeparam>
	/// <typeparam name="Action">Func to return the first Given-object</typeparam>
	public class SceneContext<TGiven,TWhen,TThen>
	{
		TWhen whenContext;
		TThen thenContext;
		protected object Tag=null;

		static SceneContext<TGiven, TWhen, TThen> Instance = null;

		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="givenContext">given-methods object</param>
		/// <param name="whenContext">when-methods object</param>
		/// <param name="thenContext">then-methods object</param>
		/// <param name="createGiven">Func for the first given-object</param>
		public SceneContext(TGiven givenContext, TWhen whenContext, TThen thenContext)
		{
			Init(givenContext, whenContext, thenContext);

			Instance = this;
            then = null;
			PostProcessing = false;
			Processor = new SceneProcessor(); 
		}

		/// <summary>
		/// Initialization the context objects.
		/// </summary>
		/// <param name="givenContext"></param>
		/// <param name="whenContext"></param>
		/// <param name="thenContext"></param>
		protected void Init(TGiven givenContext, TWhen whenContext, TThen thenContext)
		{
			this.thenContext = thenContext;
			this.whenContext = whenContext;
			this.Given = givenContext;
		}

		bool PostProcessing = false;
		ISceneProcessor Processor;

		public virtual SceneContext<TGiven, TWhen, TThen> EnablePostProcessing(ISceneProcessor processor = null)
		{
			PostProcessing = true;
			Processor = processor ?? new SceneProcessor();
			return this;
		}

		protected IGiven<Action> given = null;
		IWhen<Action> when = null;
		IThen<Action> then
		{
			get => ThenResult<TThen, Action>.then;
			set => ThenResult<TThen, Action>.then = value;
		}

		/// <summary>
		/// Create a GivenResult. 
		/// Every Given-method has to return such a GivenResult
		/// </summary>
		/// <param name="given">Action or Func that should be executed as test</param>
		/// <returns>GivenResult</returns>
		public static GivenResult<TGiven, TWhen> CreateGiven(Action given)
		{
			if (Instance.given != null)
				Instance.given = Instance.given.And(given);
			else
			{
				Instance.given = new Scene(
					Instance.Processor, 
					Instance.PostProcessing,  
					Instance.Tag
				)
					.Given(given);
			}
			return new GivenResult<TGiven, TWhen>(Instance.Given, Instance.whenContext);
		}

		/// <summary>
		/// Create a WhenResult. 
		/// Every When-method has to return such a WhenResult
		/// </summary>
		/// <param name="when">Action or Func that should be executed as test</param>
		/// <returns>WhenResult</returns>
		public static WhenResult<TWhen, TThen> CreateWhen(Action when)
		{
			if (Instance.when == null)
				Instance.when = Instance.given.When(when);
			else
				Instance.when = Instance.when.And(when);

			return new WhenResult<TWhen, TThen>(Instance.whenContext, Instance.thenContext);
		}

		/// <summary>
		/// Create a ThenResult. 
		/// Every Then-method has to return such a ThenResult
		/// </summary>
		/// <param name="then">Action or Func that should be executed as test</param>
		/// <returns>ThenResult</returns>
		public static ThenResult<TThen,Action> CreateThen(Action then)
		{
			if (Instance.then == null)
				Instance.then = Instance.when.Then(then);
			else
				Instance.then = Instance.then.And(then);

			return new ThenResult<TThen,Action>(Instance.thenContext);
		}

		/// <summary>
		/// First Given call.
		/// </summary>
		public TGiven Given { get; private set; }
	}
}
