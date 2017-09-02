namespace CheetahTesting
{
    public interface IGiven<T> : IContextWrapper<T>
    {
    }

    public interface IWhen<T> : IContextWrapper<T>
    {
    }

    public interface IThen<T> : IContextWrapper<T>
    {
    }

    public interface IContextWrapper<T>
    {
        T Context { get; }
    }

    public interface IContextExecutor<T> : IGiven<T>, IWhen<T>, IThen<T>
    {
    }
}