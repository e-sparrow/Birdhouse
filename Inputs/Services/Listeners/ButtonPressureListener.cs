using System.Collections.Generic;
using ESparrow.Utils.Inputs.Pressures.Interfaces;
using ESparrow.Utils.Services.Interfaces;

namespace ESparrow.Utils.Inputs.Services
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