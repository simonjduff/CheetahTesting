namespace CheetahTesting
{
    public interface IGiven<T> : IContextWrapper<T> where T : new()
    {
    }

    public interface IWhen<T> : IContextWrapper<T> where T : new()
    {
    }

    public interface IThen<T> : IContextWrapper<T> where T : new()
    {
    }

    public interface IContextWrapper<T> where T : new()
    {
        T Context { get; }
    }

    public interface IContextExecutor<T> : IGiven<T>, IWhen<T>, IThen<T> where T : new()
    {
    }
}