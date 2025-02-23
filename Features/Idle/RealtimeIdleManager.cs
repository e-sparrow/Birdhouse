using System;
using Birdhouse.Features.Idle.Interfaces;
using Birdhouse.Tools.Tense;

namespace Birdhouse.Features.Idle
{
    public class RealtimeIdleManager : RealtimeIdleManagerBase
    {
        public RealtimeIdleManager() 
            : base(UnixHelper.CreateDefaultUnixTimestamp())
        {
            
        }
        
        protected override void Execute(IIdleController controller, TimeSpan timeSpan)
        {
            controller.IdleFor(timeSpan);
        }
    }
}