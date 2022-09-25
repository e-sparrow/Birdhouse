using System.Collections.Generic;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Inputs.Services.Interfaces;

namespace Birdhouse.Tools.Inputs.Services.Listeners
{
    public class ButtonPressureListener : PressureListenerBase<string>
    {
        public ButtonPressureListener
            (IPressureService<string> service, IPressureStateProvider<string> stateProvider, IEnumerable<string> targetPressures) : base(service, stateProvider, targetPressures)
        {
            
        }

        protected override void Check(string pressure, IPressureStateProvider<string> stateProvider, IPressureService<string> service)
        {
            service.SetState(pressure, stateProvider.GetPressureState(pressure));
        }
    }
}