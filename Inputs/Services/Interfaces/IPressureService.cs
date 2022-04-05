using System;
using System.Collections.Generic;
using ESparrow.Utils.Inputs.Pressures.Enums;
using ESparrow.Utils.Inputs.Pressures.Interfaces;

namespace ESparrow.Utils.Services.Interfaces
{
    public interface IPressureService<TPressure>
    {
        event Action<TPressure, IPressureActivation<IPressureInfo<TPressure>, TPressure>> OnPressureActivated;

        void Activate(TPressure pressure);
        void SetState(TPressure pressure, EPressureState state);
        void Deactivate(TPressure pressure);
        
        IPressureActivation<IPressureInfo<TPressure>, TPressure> GetPressureActivation(TPressure pressure);
    }
}