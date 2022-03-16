namespace ESparrow.Utils.Mechanics.DailyBonus.Interfaces
{
    public interface IDailyBonusManager<in TReward>
    {
        void Visit();
        bool TryGetReward(TReward reward);
    }
}
