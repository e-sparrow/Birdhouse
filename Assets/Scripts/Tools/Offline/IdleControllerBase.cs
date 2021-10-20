using System;
using ESparrow.Utils.Tools.Offline.Interfaces;

namespace ESparrow.Utils.Tools.Idle
{
    public abstract class IdleControllerBase : IIdleController
    {
        protected IdleControllerBase(float rewardPerSecond)
        {
            _rewardPerSecond = rewardPerSecond;
        }

        private readonly float _rewardPerSecond;

        protected abstract void Reward(float reward);
        
        public void IdleFor(TimeSpan time)
        {
            var seconds = (float) time.TotalSeconds;
            Reward(seconds);
        }
    }
}