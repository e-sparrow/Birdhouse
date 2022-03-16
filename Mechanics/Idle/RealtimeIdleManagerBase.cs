using System;
using System.Collections.Generic;
using ESparrow.Utils.Mechanics.Idle.Interfaces;
using ESparrow.Utils.Tools.Offline.Interfaces;
using Tools.DateAndTime.Timestamps.Interfaces;

namespace ESparrow.Utils.Mechanics.Idle
{
    public abstract class RealtimeIdleManagerBase : IRealtimeIdleManager
    {
        protected RealtimeIdleManagerBase(ITimestamp timestamp)
        {
            _timestamp = timestamp;
        }
        
        private readonly ITimestamp _timestamp;
        private readonly List<IIdleController> _controllers = new List<IIdleController>();

        protected abstract void Execute(IIdleController controller, TimeSpan timeSpan); 
        
        public void Register(IIdleController controller)
        {
            _controllers.Add(controller);
        }

        public void Unregister(IIdleController controller)
        {
            _controllers.Add(controller);
        }

        public void Check()
        {
            var timeDelta = _timestamp.Stamp();
            foreach (var controller in _controllers)
            {
                Execute(controller, timeDelta);
            }
        }
    }
}