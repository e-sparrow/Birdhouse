using System.Collections.Generic;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Inputs.Services.Interfaces;

namespace Birdhouse.Tools.Inputs.Services.Listeners
{
    public class MousePressureListener : PressureListenerBase<int>
    {
        public MousePressureListener
            (IPressureService<int> service, IPressureStateProvider<int> stateProvider, IEnumerable<int> targetPressures) 
            : base(service, stateProvider, targetPressures)
        {
            
        }

        protected override void Check(int pressure, IPressureStateProvider<int> stateProvider, IPressureService<int> service)
        {
            service.SetState(pressure, stateProvider.GetPressureState(pressure));
        }
    }
}