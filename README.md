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
    
    [Fact]
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
        
        public static async Task AValueAsync(this IGiven<MyTestContext> given, int value)
        {
            given.Context.AValue = value;
            await Task.Delay(1); // Simulating an async call
        }
    }
    
    [Fact]
    public async Task SimpleTest()
    {
        await CTest.Given<MyTestContext>(g => g.AValue(5));
    }
    
### Full sample
See CheetahTesting.Tests/Simple/SimpleTestExtensions for the extensions used here.

    [Fact]
    public async Task SimpleTest()
    {
        await CTest
            .Given<TestContext>(g => g.AValue())
            .And(g => g.AnotherValue(10))
            .When(w => w.IAddTheValues())
            .And(w => w.IDivideBy(2))
            .Then(t => t.TheAnswerIs(5.5d))
            .ExecuteAsync();
    }

## Async
Async is fully supported, using the Async versions of each definition
    
    [Fact]
    public async Task Test1()
    {
        await CTest
            .GivenAsync<TestContext>(async g => await g.AValue())
            .AndAsync(async g => await g.AnotherValue(10))
            .WhenAsync(async w => await w.IAddTheValues())
            .AndAsync(async w => await w.IDivideBy(2))
            .ThenAsync(async t => await t.TheAnswerIs(5.5d))
            .ExecuteAsync();
    }
        
## Lambdas
Given these are all just Funcs and Actions, you can use inline lambdas, sync and async

    [Fact]
    public async Task Test1()
    {
        await CTest
            .GivenAsync<TestContext>(g => Task.FromResult(g.Context.FirstValue = 1))
            .And(g => g.Context.SecondValue = 10)
            .WhenAsync(w => Task.FromResult(w.Context.Added = w.Context.FirstValue + w.Context.SecondValue))
            .And(w => w.Context.Final = w.Context.Added / 2d)
            .Then(t => Assert.Equal(5.5d, t.Context.Final))
            .ExecuteAsync();
    }
