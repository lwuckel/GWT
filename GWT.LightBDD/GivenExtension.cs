using LightBDD.Core.Configuration;
using LightBDD.Core.Execution;
using LightBDD.Core.Formatting;
using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GWT.LightBDD
{
	public static class GivenExtension
	{
		public static IGiven<Action> Given(this IGwtScene runner, Action action)
		{
			return new Scene(new SceneProcessor(), postProcessing: true)
				.Given(action);
		}

		public static IGiven<Action> Given(this IBddRunner runner, Action given)
		{
			var scene = new Scene(null, postProcessing: true, tag: runner);
			scene.Processor = new SceneRunnerProcessor(scene);
			return scene.Given(given);
		}

		public static void Run(this Scene scene, Action[] givens,Action[] whens, Action[] thens)
		{
			var runner = (IBddRunner)scene.Tag;
			var integration = runner.Integrate();
			var steps = scene.AllSteps();
			//var provider = new NameProvider(integration.Core.Configuration);
			var _formatter = integration.Core.Configuration.NameFormatterConfiguration().GetFormatter();

			foreach (var action in steps.givens)
			{
				integration.AddStep(
						"Given " + action.GetMethodInfo().Name,
						_ => action());
			}
			foreach (var action in steps.whens)
			{
				integration.AddStep(
						"When " + action.GetMethodInfo().Name,
						_ => action());
			}
			foreach (var action in steps.thens)
			{
				integration.AddStep(
						"Then " + action.GetMethodInfo().Name,
						_ => action());
			}

			integration.Core
					.WithCapturedScenarioDetailsIfNotSpecified()
					.Build()
					.ExecuteSync();
		}

		//internal class NameProvider
		//{
		//	private readonly INameFormatter _formatter;

		//	public NameProvider(LightBddConfiguration cfg)
		//	{
		//		_formatter = cfg.NameFormatterConfiguration().GetFormatter();
		//	}

		//	public string GetStepName(MemberInfo member)
		//	{
		//		var attr = member.GetCustomAttribute<StepNameAttribute>();
		//		if (attr == null)
		//			return _formatter.FormatName(member.Name);

		//		var description = attr.Description ?? _formatter.FormatName(member.Name);
		//		return $"{attr.Name} {description}";
		//	}
		//}

	}
}