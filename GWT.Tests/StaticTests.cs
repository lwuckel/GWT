using FluentAssertions;
using GWT.NUnit3;
using NUnit.Framework;
using System;

namespace GWT.Tests
{
	public class StaticContext : SceneContext<StaticContext.Givens, StaticContext.Whens, StaticContext.Thens>
    {
        public static StaticContext Instance;

        public StaticContext() : base(new Givens(), new Whens(), new Thens())
        {
            Instance = this;
        }

        public class Givens
        {
            public GivenResult<Givens, Whens> TestHashCode(int code) => CreateGiven(() =>
            {
                code.Should().Be(Instance.GetHashCode());
            });
        }

        public class Whens {
            public WhenResult<Whens,Thens> TestHashCode(int code) => CreateWhen(() =>
            {
                code.Should().Be(Instance.GetHashCode());
            });

        }
        public class Thens {
            public ThenResult<Thens,Action> TestHashCode(int code) => CreateThen(() =>
            {
                code.Should().Be(Instance.GetHashCode());   
            });
        }
    }

    [TestFixture]
    public class StaticTests
    {
        [Test]
        public void Test1()
        {
            var context = new StaticContext();

            int code = context.GetHashCode();

            context.Given.TestHashCode(code)
                .When.TestHashCode(code)
                .Then.TestHashCode(code)
                .Run();
        }
        [Test]
        public void Test2()
        {
            var context = new StaticContext();

            int code = context.GetHashCode();

            context.Given.TestHashCode(code)
                .When.TestHashCode(code)
                .Then.TestHashCode(code)
                .Run();
        }

        [Test]
        public void Test3()
        {
            var context = new StaticContext();

            int code = context.GetHashCode();

            context.Given.TestHashCode(code)
                .When.TestHashCode(code)
                .Then.TestHashCode(code)
                .Run();
        }

    }
}
