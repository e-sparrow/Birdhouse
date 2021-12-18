using System;
using System.Collections.Generic;
using ESparrow.Utils.Mechanics.Idle.Interfaces;
using ESparrow.Utils.Tools.Offline.Interfaces;
using ESparrow.Utils.Tools.DateAndTime.Pendulums;

namespace ESparrow.Utils.Mechanics.Idle
{
    public abstract class RealtimeIdleManagerBase : IRealtimeIdleManager
    {
        protected RealtimeIdleManagerBase(IPendulum pendulum)
        {
            _pendulum = pendulum;
            pendulum.OnTickPerformed += Execute;
        }

        private readonly IPendulum _pendulum;
        
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

        private void Execute()
        {
            foreach (var controller in _controllers)
            {
                Execute(controller, _pendulum.Period);
            }
        }
    }
}