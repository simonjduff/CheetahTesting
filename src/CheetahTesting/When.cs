using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheetahTesting
{
    public class When<T> : IWhen<T> where T : new()
    {
        private readonly List<Func<IContextExecutor<T>, Task>> _actions;

        public T Context {get;}
        internal When(T context, List<Func<IContextExecutor<T>, Task>> actions)
        {
            Context = context;
            _actions = actions;
        }

        public When<T>And(Action<IWhen<T>> action)
        {
            _actions.Add(action.ToAsync());
            return this;
        }

        public When<T>AndAsync(Func<IWhen<T>, Task> action)
        {
            _actions.Add(action);
            return this;
        }

        public Then<T> Then(Action<IThen<T>> action)
        {
            _actions.Add(action.ToAsync());
            return new Then<T>(Context, _actions);
        }

        public Then<T> ThenAsync(Func<IThen<T>, Task> action)
        {
            _actions.Add(action);
            return new Then<T>(Context, _actions);
        }
    }
}