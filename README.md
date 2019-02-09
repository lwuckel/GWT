# GWT
Given-When-Then  
Mit diesem Framework kann man Integrationstests definieren, die nach dem Given-When-Then Prinzip aufgebaut sind.

Given - beinhaltet das Setup  
When - die Aktionen  
Then - die Tests  

## Anwendung

Die Klasse, die das Framework nutzen will, muss das Interface IGwtScene implementieren.

### Simple

Die einfache Version löst bei einem Assert sofort aus. 

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
      .Then(ShouldFailed) 
      .And(ShouldFailed); // wird nicht mehr ausgeführt
  }
}
```

### NUnit3

Die NUnit3 Version führt immer alle Schritt aus.

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
      .Then(ShouldFailed)
      .And(ShouldFailed) // wird auch ausgeführt
      .Run();
  }
}
```

### LightBDD

Man kann das Framework auch mit LightBDD verwenden.

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

### Komplexe Definitionen

Beschreibung folgt.
[Beispiel](https://github.com/lwuckel/GWT/blob/master/GWT.Tests/Advanced_method_NUnit3_test.cs)

## Ausgabe der Testergebnisse

For die Ausgabe von Testergebnissen kann man die Monitor-Klasse verwenden. Folgendes Beispiel erzeugt eine Datei im Testverzeichnis und speichert die Testergebnisse dort.


```C#
[TestFixture]
public class Output : IGwtScene
{
  public Output()
  {
    string path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"out.txt");
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

[Beispiel für eine Logdatei](https://github.com/lwuckel/GWT/blob/master/GWT.Tests/MonitorLogFile.cs).
