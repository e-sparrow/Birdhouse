using System;
using ESparrow.Utils.Tools.Offline.Interfaces;
using ESparrow.Utils.Tools.DateAndTime.Pendulums;

namespace ESparrow.Utils.Mechanics.Idle
{
    public class RealtimeIdleManager : RealtimeIdleManagerBase
    {
        public RealtimeIdleManager(IPendulum pendulum) : base(pendulum)
        {
            
        }

        protected override void Execute(IIdleController controller, TimeSpan timeSpan)
        {
            controller.IdleFor(timeSpan);
        }
    }
}