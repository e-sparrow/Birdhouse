namespace Birdhouse.Mechanics.DailyBonus.Interfaces
{
    public interface IDailyBonusManager<in TReward>
    {
        void Visit();
        bool TryGetReward(TReward reward);
    }
}
