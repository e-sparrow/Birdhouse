using System.Collections.Generic;
using Birdhouse.Education.Patterns.Listening.Interfaces;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Inputs.Services.Interfaces;

namespace Birdhouse.Tools.Inputs.Services.Listeners
{
    public abstract class PressureListenerBase<TPressure> : IListener
    {
        protected PressureListenerBase
            (IPressureService<TPressure> service, IPressureStateProvider<TPressure> stateProvider, IEnumerable<TPressure> targetPressures)
        {
            _service = service;
            _stateProvider = stateProvider;
            _targetPressures = targetPressures;
        }

        private readonly IPressureService<TPressure> _service;
        private readonly IPressureStateProvider<TPressure> _stateProvider;
        private readonly IEnumerable<TPressure> _targetPressures;

        protected abstract void Check(TPressure pressure, IPressureStateProvider<TPressure> stateProvider, IPressureService<TPressure> service);
        
        public void Listen()
        {
            foreach (var pressure in _targetPressures)
            {
                Check(pressure, _stateProvider, _service);
            }
        }
    }
}