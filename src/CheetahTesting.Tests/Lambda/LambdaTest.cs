using System.Threading.Tasks;
using Xunit;

namespace CheetahTesting.Tests.Lambda
{
    public class LambdaTest
    {
        [Fact]
        public async Task Test1()
        {
            await CTest<TestContext>
                .GivenAsync(g => Task.FromResult(g.Context.FirstValue = 1))
                .And(g => g.Context.SecondValue = 10)
                .WhenAsync(w => Task.FromResult(w.Context.Added = w.Context.FirstValue + w.Context.SecondValue))
                .And(w => w.Context.Final = w.Context.Added / 2d)
                .Then(t => Assert.Equal(5.5d, t.Context.Final))
                .ExecuteAsync();
        }
    }
}