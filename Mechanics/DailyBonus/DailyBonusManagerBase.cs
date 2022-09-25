// Цепочка бонусов может прерываться, бонус может быть активен только день. 
using System;
using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using Birdhouse.Mechanics.DailyBonus.Interfaces;
using Birdhouse.Mechanics.Streaks;
using Birdhouse.Mechanics.Streaks.Interfaces;
using Birdhouse.Tools.Generalization.Summation.Interfaces;

//TODO:TODO:TODO:TODO:
namespace Birdhouse.Mechanics.DailyBonus
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