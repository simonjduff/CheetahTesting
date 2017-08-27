using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheetahTesting
{
    public class Given<T> : IGiven<T> where T : new()
    {
        private readonly List<Func<IContextExecutor<T>, Task>> _actions = new List<Func<IContextExecutor<T>, Task>>();

        internal Given(T context, Func<IGiven<T>, Task> initialAction)
        {
            Context = context;
            _actions.Add(initialAction);
        }

        public T Context { get; }

        public Given<T> And(Action<IGiven<T>> action)
        {
            _actions.Add(action.ToAsync());
            return this;
        }

        public Given<T> AndAsync(Func<IGiven<T>, Task> action)
        {
            _actions.Add(action);
            return this;
        }

        public When<T> When(Action<IWhen<T>> action)
        {
            _actions.Add(action.ToAsync());
            return new When<T>(Context, _actions);
        }

        public When<T> WhenAsync(Func<IWhen<T>, Task> action)
        {
            _actions.Add(action);
            return new When<T>(Context, _actions);
        }
    }
}