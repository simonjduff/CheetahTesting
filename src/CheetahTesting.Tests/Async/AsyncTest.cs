using System.Threading.Tasks;
using Xunit;

namespace CheetahTesting.Tests.Async
{
    public class AsyncTest
    {
        [Fact]
        public async Task Test1()
        {
            await CTest<TestContext>
                .GivenAsync(g => g.AValue())
                .AndAsync(g => g.AnotherValue(10))
                .WhenAsync(w => w.IAddTheValues())
                .AndAsync(w => w.IDivideBy(2))
                .ThenAsync(t => t.TheAnswerIs(5.5d))
                .AndAsync(t => t.True())
                .ExecuteAsync();
        }
    }
}