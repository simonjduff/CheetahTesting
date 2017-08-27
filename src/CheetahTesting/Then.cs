using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheetahTesting
{
    public class Then<T> : IContextExecutor<T>, IThen<T> where T : new()
    {
        private readonly List<Func<IContextExecutor<T>, Task>> _actions;

        internal Then(T context, List<Func<IContextExecutor<T>, Task>> actions)
        {
            Context = context;
            _actions = actions;
        }

        public T Context { get; }

        public async Task ExecuteAsync()
        {
            foreach (var action in _actions)
                await action(this);
        }
    }
}