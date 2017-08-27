using System.Threading.Tasks;
using Xunit;

namespace CheetahTesting.Tests.Async
{
    public class AsyncTest
    {
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
    }
}
