using System;
using System.Threading.Tasks;

namespace CheetahTesting
{
    public static class CTest<T>where T : new()
    {
        public static Given<T> Given(Action<IGiven<T>> initialAction) 
        {
            return new Given<T>(new T(), initialAction.ToAsync());
        }

        public static Given<T> GivenAsync(Func<IGiven<T>, Task> initialAction)
        {
            return new Given<T>(new T(), initialAction);
        }
    }
}