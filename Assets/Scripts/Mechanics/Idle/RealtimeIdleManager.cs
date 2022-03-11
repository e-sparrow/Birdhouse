using System;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Tools.Offline.Interfaces;
using Tools.DateAndTime.Timestamps;

namespace ESparrow.Utils.Mechanics.Idle
{
    public class RealtimeIdleManager : RealtimeIdleManagerBase
    {
        public RealtimeIdleManager() : base(DateAndTimeHelper.UnixHelper.CreateDefaultUnixTimestamp())
        {
            
        }
        
        protected override void Execute(IIdleController controller, TimeSpan timeSpan)
        {
            controller.IdleFor(timeSpan);
        }
    }
}