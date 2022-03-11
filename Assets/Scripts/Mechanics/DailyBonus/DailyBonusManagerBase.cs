// Цепочка бонусов может прерываться, бонус может быть активен только день. 
using System;
using System.Collections.Generic;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Generalization.Summation.Interfaces;
using ESparrow.Utils.Mechanics.DailyBonus.Interfaces;
using ESparrow.Utils.Mechanics.Streaks;
using ESparrow.Utils.Mechanics.Streaks.Interfaces;
using ESparrow.Utils.Serialization.Interfaces;
using ESparrow.Utils.Tools.Offline.Interfaces;

//TODO:TODO:TODO:TODO:
namespace ESparrow.Utils.Mechanics.DailyBonus
{
    public abstract class DailyBonusManagerBase<TReward> : IDailyBonusManager<TReward>
    {
        protected DailyBonusManagerBase(Dictionary<int, TReward> rewards, bool interrupt, bool waste)
        {
            _rewards = rewards;
        }

        private bool _bonusIsReady = false;

        private readonly IStreak<int> _streak = new Streak<int, ISummable<int>>(0.AsSummable(), 0);
        
        private readonly Dictionary<int, TReward> _rewards;

        public void Visit() 
        {
            throw new NotImplementedException();
        }

        public bool TryGetReward(TReward reward)
        {
            throw new NotImplementedException();
        }
    }
}