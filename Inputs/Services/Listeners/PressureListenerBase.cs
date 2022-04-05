using System.Collections.Generic;
using ESparrow.Utils.Patterns.Listening.Interfaces;
using ESparrow.Utils.Inputs.Pressures.Interfaces;
using ESparrow.Utils.Services.Interfaces;

namespace ESparrow.Utils.Inputs.Services
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