namespace ESparrow.Utils.Navigation.Interfaces
{
    public interface IPointContainer<out TPoint, in TKey, T> where TPoint : IPoint<T>
    {
        TPoint GetPoint(TKey key);
    }
}