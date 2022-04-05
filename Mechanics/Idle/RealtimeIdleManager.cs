using System;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Tools.Offline.Interfaces;
using ESparrow.Utils.Tools.Tense.Timestamps;

namespace ESparrow.Utils.Mechanics.Idle
{
    public class RealtimeIdleManager : RealtimeIdleManagerBase
    {
        public RealtimeIdleManager() : base(TenseHelper.Unix.CreateDefaultUnixTimestamp())
        {
            
        }
        
        protected override void Execute(IIdleController controller, TimeSpan timeSpan)
        {
            controller.IdleFor(timeSpan);
        }
    }
}