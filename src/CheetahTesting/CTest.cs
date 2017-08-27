using System;
using System.Threading.Tasks;

namespace CheetahTesting
{
    public class CTest
    {
        public static Given<T> Given<T>(Action<IGiven<T>> initialAction) where T : new()
        {
            return new Given<T>(new T(), initialAction.ToAsync());
        }

        public static Given<T> GivenAsync<T>(Func<IGiven<T>, Task> initialAction) where T : new()
        {
            return new Given<T>(new T(), initialAction);
        }
    }
}