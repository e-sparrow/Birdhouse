using System;
using System.Collections.Generic;
using Birdhouse.Features.Idle.Interfaces;
using Birdhouse.Tools.Tense.Timestamps.Interfaces;

namespace Birdhouse.Features.Idle
{
    public abstract class RealtimeIdleManagerBase : IRealtimeIdleManager
    {
        protected RealtimeIdleManagerBase(ITimestamp<TimeSpan> timestamp)
        {
            _timestamp = timestamp;
        }
        
        private readonly ITimestamp<TimeSpan> _timestamp;
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