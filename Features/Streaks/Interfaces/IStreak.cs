namespace Birdhouse.Mechanics.Streaks.Interfaces
{
    public interface IStreak<TSelf>
    {
        void Increase(TSelf amount);
        void CancelStreak();

        TSelf Current
        {
            get;
        }
    }
}
