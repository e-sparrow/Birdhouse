namespace ESparrow.Utils.Generic.Pairs.Interfaces
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