using System;
using Birdhouse.Mechanics.Idle.Interfaces;

namespace Birdhouse.Mechanics.Idle
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