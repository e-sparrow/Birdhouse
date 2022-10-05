using System;
using Birdhouse.Common.Helpers;
using Birdhouse.Mechanics.Idle.Interfaces;
using Birdhouse.Tools.Tense;
using Birdhouse.Tools.Tense.Timestamps;

namespace Birdhouse.Mechanics.Idle
{
    public class RealtimeIdleManager : RealtimeIdleManagerBase
    {
        public RealtimeIdleManager() : base(UnixHelper.CreateDefaultUnixTimestamp())
        {
            
        }
        
        protected override void Execute(IIdleController controller, TimeSpan timeSpan)
        {
            controller.IdleFor(timeSpan);
        }
    }
}