using System;
using System.Threading.Tasks;
using Xunit;

namespace CheetahTesting.Tests.Disposable
{
    public class DisposableTests
    {
        [Fact]
        public async Task DisposeIsCalled()
        {
            bool disposed = false;
            Action<bool> setDisposed = d => disposed = d;

            await CTest<DisposableContext>.Given(q => q.Context.Disposer = setDisposed)
            .When(q => {})
            .Then(q => {})
            .ExecuteAsync();

            Assert.True(disposed);
        }

        public class DisposableContext : IDisposable
        {
            public Action<bool> Disposer {get;set;}
            public void Dispose()
            {
                Disposer(true);
            }
        }
    }
}