# GWT
Given-When-Then  

This framework can be used to define integration tests in the style of Given-When-Then definition.

Given - setup  
When - action  
Then - asserts  

## Description

To use this framework you have to implement [IGwtScene](https://github.com/lwuckel/GWT/blob/master/GWT/IGwtScene.cs).

### Simple

The simplest version fire every assertion just when it happens. So only one Assert is shown.

```C#
[TestFixture]
public class Simple_Scenarios : IGwtScene
{
  [Test]
  public void Processing_should_fail_1_time()
  {
    this
      .Given(Counter)
      .When(Counter)
      .Then(ShouldFailed) // shown
      .And(ShouldFailed); // is not shown
  }
}
```

### NUnit3

The Nunit3 verion runs all steps. So every Assert is shown.

```C#
[TestFixture]
public class Simple_Scenarios_with_NUnit3 : IGwtScene
{
  [Test]
  public void PostProcessing_should_fail_2_times()
  {
    this
      .Given(Counter)
      .When(Counter)
      .Then(ShouldFailed) / shown 
      .And(ShouldFailed) // shown
      .Run();
  }
}
```

### LightBDD

You can use the LightBDD framework too.

```C#
[FeatureDescription(
@"In order to access personal data
As an user
I want to login into system")] //feature description
[Label("Story-1")]
[TestFixture]
public class LightBDD_Scenarios : FeatureFixture, IGwtScene
{
  [Scenario]
  [Label("Ticket-1")]
  [Test]
  public void Counter_test() //scenario name
  {
    this.Runner
      .Given(Counter)
      .When(Counter)
      .Then(Counter)
      .Run();
  }

  int counter = 0;
  public void Counter() { ++this.counter; }
}
```

### Complex definition

[Example](https://github.com/lwuckel/GWT/blob/master/GWT.Tests/Advanced_method_NUnit3_test.cs)

## Result output

To generate an output you can use the [Monitor](https://github.com/lwuckel/GWT/blob/master/GWT/Monitor.cs) class.
It's possible to write a Logfile for every step and result ([example](https://github.com/lwuckel/GWT/blob/master/GWT.Tests/MonitorLogFile.cs)).

Here an simple example to write in a log file.

```C#
[TestFixture]
public class Output : IGwtScene
{
  public Output()
  {
    string path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"log.txt");
    var stream = File.Create(path);
    stream.Dispose();

    Monitor.Instance.Processed += (args) =>
      File.AppendAllText(path, $@"{args.Passed} #{args.State}: {args.Name}
");
  }

  [Test]
  public void Ausgabe()
  {
    this.Given(Given)
      .And(GivenAndFail)
      .When(When)
      .And(WhenAnd)
      .Then(Then)
      .And(ThenAnd)
      .Run();
  }

  void Given() { }
  void GivenAnd() { }
  void GivenAndFail() { Assert.Fail(); }
  void When() { }
  void WhenAnd() { }
  void Then() { }
  void ThenAnd() { }
}
```


