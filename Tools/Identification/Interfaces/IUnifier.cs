namespace Birdhouse.Tools.Identification.Interfaces
{
    public interface IUnifier<T>
    {
        T Unify(T value);
    }
}