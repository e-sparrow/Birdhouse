using System;
using Birdhouse.Tools.Inputs.Pressures.Enums;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;

namespace Birdhouse.Tools.Inputs.Services.Interfaces
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