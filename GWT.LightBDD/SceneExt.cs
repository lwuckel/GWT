//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GWT
//{
//	/// <summary>
//	/// Extention methods for Given-When-Then
//	/// </summary>
//	public static class SceneExtensions
//	{
//		/// <summary>
//		/// Given Extention for IBddRunner 
//		/// </summary>
//		/// <param name="runner">Test-Runner</param>
//		/// <param name="given">Test-Action to be executed</param>
//		/// <returns>Given-object</returns>
//		public static IGiven<Action> Given(this IBddRunner runner, Action given)
//		{
//			return new Scene<Action>(runner)
//					.Given(given);
//		}

//		/// <summary>
//		/// Run the definition of the SceneContext.
//		/// <see cref="SceneContext{TGiven, TWhen, TThen, TFunc_Given}"/>
//		/// Execute the steps
//		/// </summary>
//		/// <typeparam name="TThen">Type of then-methods class</typeparam>
//		/// <param name="then">ThenResult object</param>
//		public static void Run<TThen>(this ThenResult<TThen, Action> then)
//		{
//			var scene = (Scene<Action>)then.To();
//			RunScene(scene);
//		}

//		/// <summary>
//		/// Run the definition of the Scene
//		/// <see cref="Scene{TAction}"/>
//		/// </summary>
//		/// <param name="then">Then-object</param>
//		public static void Run(this IThen<Action> then)
//		{
//			var scene = (Scene<Action>)then;
//			RunScene(scene);
//		}

//		private static void RunScene(Scene<Action> scene)
//		{
//			var integration = scene.Runner.Integrate();
//			var provider = new NameProvider(integration.Core.Configuration);
//			foreach (var action in scene.End())
//			{
//				integration.AddStep(
//						provider.GetStepName(action.GetMethodInfo()),
//						_ => action());
//			}

//			integration.Core
//					.WithCapturedScenarioDetailsIfNotSpecified()
//					.Build()
//					.ExecuteSync();
//		}
//	}

//	internal class NameProvider
//	{
//		private readonly INameFormatter _formatter;

//		public NameProvider(LightBddConfiguration cfg)
//		{
//			_formatter = cfg.NameFormatterConfiguration().GetFormatter();
//		}

//		public string GetStepName(MemberInfo member)
//		{
//			var attr = member.GetCustomAttribute<StepNameAttribute>();
//			if (attr == null)
//				return _formatter.FormatName(member.Name);

//			var description = attr.Description ?? _formatter.FormatName(member.Name);
//			return $"{attr.Name} {description}";
//		}
//	}
//}
