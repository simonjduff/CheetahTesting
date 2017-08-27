using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CheetahTesting.Tests.Mixed
{
    public class MixedTest
    {
        [Fact]
        public async Task Test1()
        {
            await CTest
                .Given<TestContext>(g => g.Context.FirstValue = 1)
                    .And(g => g.AnotherValue(10))
                .WhenAsync(async w => await w.IAddTheValues())
                    .AndAsync(async w => await w.IDivideBy(2))
                .ThenAsync(async t => await t.TheAnswerIs(5.5d))
                .ExecuteAsync();
        }
    }
}