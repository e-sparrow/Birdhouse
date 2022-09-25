using System;
using System.Collections.Generic;
using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Inputs.Pressures.Enums;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Inputs.Services.Interfaces;
using Birdhouse.Tools.Tense.Controllers.Interfaces;

namespace Birdhouse.Tools.Inputs.Services
{
    public abstract class PressureServiceBase<TPressure> : IPressureService<TPressure>
    {
        protected PressureServiceBase
            (IDictionary<TPressure, IPressureActivation<IPressureInfo<TPressure>, TPressure>> activations, ITenseController<float> tenseController)
        {
            _activations = activations;
            _tenseController = tenseController;
        }

        public event Action<TPressure, IPressureActivation<IPressureInfo<TPressure>, TPressure>> OnPressureActivated 
            = (pressure, activation) => { };

        private readonly IDictionary<TPressure, IPressureActivation<IPressureInfo<TPressure>, TPressure>> _activations;
        private readonly ITenseController<float> _tenseController;

        public void Activate(TPressure pressure)
        {
            var activation = PressureHelper.CreateActivation(pressure, EPressureState.Pressed, _tenseController.Now());
            _activations[pressure] = activation;
            
            OnPressureActivated.Invoke(pressure, activation);
        }

        public void SetState(TPressure pressure, EPressureState state)
        {
            if (!_activations.ContainsKey(pressure) && state != EPressureState.Untouched)
            {
                Activate(pressure);
            }
            
            var time = _activations[pressure].ActivationTime;
            
            var activation = PressureHelper.CreateActivation(pressure, state, time);
            _activations[pressure] = activation;
        }

        public void Deactivate(TPressure pressure)
        {
            _activations.Remove(pressure);
        }

        public IPressureActivation<IPressureInfo<TPressure>, TPressure> GetPressureActivation(TPressure pressure)
        {
            return _activations[pressure];
        }
    }
}
