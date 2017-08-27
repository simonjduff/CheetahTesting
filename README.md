Fluent interface for BDD style testing

# Reason
I had used SpecFlow for BDD style testing in the past, but found the tooling too heavy, with dependencies on extensions and external tools.
This is especially annoying for people working on different OSes or toolchains.

# Goal
I wanted to preserve the setup of a SpecFlow style test, but all the tooling is simple C#. I have no particular need for Cucumber in my projects. (If you need cucumber, this is not the interface for you).
I have Given, When, Then, and And definitions, each mutating a shared test context, with assertions validating the state of that context at the end of the run. You can use whatever assertion framework you prefer.

# Use

## Simple Scenario

### The beginning
All tests start by setting up a context, and initializing the Given/When/Then chain.
    public class MyTestContext
    {
        public int AValue{get;set;}
    }
    
    [Test]
    public async Task SimpleTest()
    {
      await CTest.Given<MyTestContext>(g => g.Context.AValue = 5);
    }

### Extension methods for readability and reusability
    public static class Extensions
    {
        public static void AValue(this IGiven<MyTestContext> given, int value)
        {
            given.Context.AValue = value;
        }
    }
    
    [Test]
    public async Task SimpleTest()
    {
        await CTest.Given<MyTestContext>(g => g.AValue(5));
    }
    
### Full sample
See CheetahTesting.Tests/Simple/SimpleTestExtensions for the extensions used here.

    await CTest
        .Given<TestContext>(g => g.AValue())
        .And(g => g.AnotherValue(10))
        .When(w => w.IAddTheValues())
        .And(w => w.IDivideBy(2))
        .Then(t => t.TheAnswerIs(5.5d))
        .ExecuteAsync();
