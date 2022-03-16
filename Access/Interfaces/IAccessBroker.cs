namespace ESparrow.Utils.Access.Interfaces
{
    public interface IAccessBroker<T>
    {
        void Set(T value);
        T Get();
    }
}