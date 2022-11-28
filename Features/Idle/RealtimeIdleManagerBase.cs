using System;
using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using Birdhouse.Features.Idle.Interfaces;
using Birdhouse.Features.Registries;
using Birdhouse.Features.Registries.Interfaces;
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
        private readonly IRegistryEnumerable<IIdleController> _registry = new RegistryEnumerable<IIdleController>();

        protected abstract void Execute(IIdleController controller, TimeSpan timeSpan); 

        public void Check()
        {
            var timeDelta = _timestamp.Stamp();
            foreach (var controller in _registry)
            {
                Execute(controller, timeDelta);
            }
        }

        public IDisposable Register(IIdleController element)
        {
            var result = _registry.Register(element);
            return result;
        }

        public void Dispose()
        {
            _registry.Dispose();
        }
    }
}