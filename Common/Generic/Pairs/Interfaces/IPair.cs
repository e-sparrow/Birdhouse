namespace Birdhouse.Common.Generic.Pairs.Interfaces
{
    public interface IPair<out TKey, out TValue>
    {
        TKey Key
        {
            get;
        }

        TValue Value
        {
            get;
        }
    }
}