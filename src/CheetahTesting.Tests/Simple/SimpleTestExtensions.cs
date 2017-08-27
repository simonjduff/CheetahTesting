using Xunit;

namespace CheetahTesting.Tests.Simple
{
    public static class SimpleTestExtensions
    {
        public static void AValue(this IGiven<TestContext> given)
        {
            given.Context.FirstValue = 1;
        }

        public static void AnotherValue(this IGiven<TestContext> given, int secondValue)
        {
            given.Context.SecondValue = secondValue;
        }

        public static void IAddTheValues(this IWhen<TestContext> when)
        {
            when.Context.Added = when.Context.FirstValue + when.Context.SecondValue;
        }

        public static void IDivideBy(this IWhen<TestContext> when, int divisor)
        {
            when.Context.Final = when.Context.Added / (double) divisor;
        }

        public static void TheAnswerIs(this IThen<TestContext> then, double result)
        {
            Assert.Equal(result, then.Context.Final);
        }
    }
}