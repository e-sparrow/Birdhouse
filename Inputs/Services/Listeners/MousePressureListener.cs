using System.Collections.Generic;
using ESparrow.Utils.Inputs.Pressures.Interfaces;
using ESparrow.Utils.Services.Interfaces;

namespace ESparrow.Utils.Inputs.Services
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