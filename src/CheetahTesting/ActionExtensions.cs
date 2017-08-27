using System;
using System.Threading.Tasks;

namespace CheetahTesting
{
    public static class ActionExtensions
    {
        public static Func<T, Task> ToAsync<T>(this Action<T> action)
        {
            return a => 
            {
                action(a);
                return Task.FromResult(0);
            };
        }
    }
}