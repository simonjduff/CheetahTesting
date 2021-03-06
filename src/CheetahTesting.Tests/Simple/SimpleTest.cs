using System.Threading.Tasks;
using Xunit;

namespace CheetahTesting.Tests.Simple
{
    public class SimpleTest
    {
        [Fact]
        public async Task Test1()
        {
            await CTest<TestContext>
                .Given(g => g.AValue())
                .And(g => g.AnotherValue(10))
                .When(w => w.IAddTheValues())
                .And(w => w.IDivideBy(2))
                .Then(t => t.TheAnswerIs(5.5d))
                .And(t => t.True())
                .ExecuteAsync();
        }
    }
}