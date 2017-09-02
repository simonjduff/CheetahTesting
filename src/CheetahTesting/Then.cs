using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheetahTesting
{
    public class Then<T> : IContextExecutor<T>, IThen<T>
    {
        private readonly List<Func<IContextExecutor<T>, Task>> _actions;

        internal Then(T context, List<Func<IContextExecutor<T>, Task>> actions)
        {
            Context = context;
            _actions = actions;
        }

        public Then<T> AndAsync(Func<IThen<T>, Task> action)
        {
            _actions.Add(action);
            return this;
        }

        public Then<T> And(Action<IThen<T>> action)
        {
            _actions.Add(action.ToAsync());
            return this;
        }

        public T Context { get; }

        public async Task ExecuteAsync()
        {
            foreach (var action in _actions)
                await action(this);

            if (Context is IDisposable)
                (Context as IDisposable).Dispose();
        }
    }
}