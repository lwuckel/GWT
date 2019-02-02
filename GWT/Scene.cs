using System;
using System.Collections.Generic;
using System.Linq;

namespace GWT
{
	/// <summary>
	/// Implementation of the fluent design for Given-When-Then definition.
	/// By design you have to start with 'Given'-method, then came 'When' and 'Then'.
	/// </summary>
	public class Scene : IGiven<Action>, IWhen<Action>, IThen<Action>
	{
		public Scene(bool postProcessing=false, Action<Action[],Action[], Action[]> process = null, object tag = null)
		{
			this.PostProcessing = postProcessing;
			this.Process = process ?? Processing;
			this.Tag = tag;
		}

		public Action<Action[],Action[],Action[]> Process { get; set; }
		public object Tag { get; private set; }

		void Processing(Action[] givens, Action[] whens, Action[] thens)
		{
			givens.ToList()
				.ForEach(b => b());

			whens.ToList()
				.ForEach(b => b());

			thens.ToList()
				.ForEach(b => b());
		}

		public bool PostProcessing = false;

		List<List<Action>> Givens { get; } = new List<List<Action>>();
		List<List<Action>> Whens { get; } = new List<List<Action>>();
		List<List<Action>> Thens { get; } = new List<List<Action>>();

		public (Action[] givens,Action[] whens,Action[] thens) AllSteps()
		{
			var list = new List<Action>();

			AddTo(list, this.Givens);

			var givensArray = list.ToArray();

			list.Clear();
			AddTo(list, this.Whens);

			var whensArray = list.ToArray();
			list.Clear();
			AddTo(list, this.Thens);
			var thensArray = list.ToArray();

			return (givensArray, whensArray, thensArray);
		}

		private void AddTo(List<Action> list, List<List<Action>> childList)
		{
			foreach (var item in childList)
				list.AddRange(item);
		}

		/// <summary>
		/// Given implementation
		/// </summary>
		/// <param name="given">Action or Func that has to be executed</param>
		/// <returns>Given object</returns>
		public IGiven<Action> Given(Action given)
		{
			if (given != null)
			{
				if (PostProcessing)
					AddToList(this.Givens, given, newList: true);
				else
					given();
			}

			return this;
		}

		/// <summary>
		/// And-Given implementation
		/// </summary>
		/// <param name="given">Action or Func that has to be executed</param>
		/// <returns>given object</returns>
		public IGiven<Action> And(Action given)
		{
			if (PostProcessing)
				AddToList(this.Givens, given);
			else
				given();

			return this;
		}

		private void AddToList(List<List<Action>> list, Action add, bool newList = false)
		{
			if (list.Count == 0 || newList)
				list.Add(new List<Action>());

			list[list.Count - 1].Add(add);
		}

		/// <summary>
		/// When implementation
		/// </summary>
		/// <param name="when">Action or Func that has to be executed</param>
		/// <returns>when-object</returns>
		public IWhen<Action> When(Action when)
		{
			if (PostProcessing)
				AddToList(this.Whens, when, newList: true);
			else
				when();

			return this;
		}

		IWhen<Action> IWhen<Action>.And(Action when)
		{
			if (PostProcessing)
				AddToList(this.Whens, when);
			else
				when();

			return this;
		}

		/// <summary>
		/// Then implementation
		/// </summary>
		/// <param name="then">Action or Func that has to be executed</param>
		/// <returns>Then-object</returns>
		public IThen<Action> Then(Action then)
		{
			if (PostProcessing)
				AddToList(this.Thens, then, newList: true);
			else
				then();

			return this;
		}
		IThen<Action> IThen<Action>.And(Action then)
		{
			if (PostProcessing)
				AddToList(this.Thens, then);
			else
				then();

			return this;
		}
	}
}
