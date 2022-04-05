using System.Collections.Generic;
using ESparrow.Utils.Inputs.Pressures.Interfaces;
using ESparrow.Utils.Services.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Inputs.Services
{
    public class KeyPressureListener : PressureListenerBase<KeyCode>
    {
        public KeyPressureListener
            (IPressureService<KeyCode> service, IPressureStateProvider<KeyCode> stateProvider, IEnumerable<KeyCode> targetPressures) 
            : base(service, stateProvider, targetPressures)
        {
            
        }

        protected override void Check(KeyCode pressure, IPressureStateProvider<KeyCode> stateProvider, IPressureService<KeyCode> service)
        {
            service.SetState(pressure, stateProvider.GetPressureState(pressure));
        }
    }
}