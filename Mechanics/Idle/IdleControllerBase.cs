using System;
using ESparrow.Utils.Tools.Offline.Interfaces;

namespace ESparrow.Utils.Mechanics.Idle
{
    public abstract class IdleControllerBase : IIdleController
    {
        protected abstract void Reward(float seconds);
        
        public void IdleFor(TimeSpan time)
        {
            var seconds = (float) time.TotalSeconds;
            Reward(seconds);
        }
    }
}