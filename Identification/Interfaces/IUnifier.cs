namespace ESparrow.Utils.Identification.Interfaces
{
    public interface IUnifier<T>
    {
        T Unify(T value);
    }
}