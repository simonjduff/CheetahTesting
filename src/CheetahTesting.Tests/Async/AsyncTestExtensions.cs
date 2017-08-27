using System.Threading.Tasks;
using Xunit;

namespace CheetahTesting.Tests.Async
{
    public static class AsyncTestExtensions
    {
        public static async Task AValue(this IGiven<TestContext> given)
        {
            given.Context.FirstValue = 1;
            await Task.Delay(1);
        }

        public static async Task AnotherValue(this IGiven<TestContext> given, int secondValue)
        {
            given.Context.SecondValue = secondValue;
            await Task.Delay(1);
        }

        public static async Task IAddTheValues(this IWhen<TestContext> when)
        {
            when.Context.Added = when.Context.FirstValue + when.Context.SecondValue;
            await Task.Delay(1);
        }
        
        public static async Task IDivideBy(this IWhen<TestContext> when, int divisor)
        {
            when.Context.Final = when.Context.Added / (double)divisor;
            await Task.Delay(1);
        }

        public static async Task TheAnswerIs(this IThen<TestContext> then, double result)
        {
            Assert.Equal(result, then.Context.Final);
            await Task.Delay(1);
        }
    }
}