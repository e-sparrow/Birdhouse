using System.Collections.Generic;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Inputs.Services.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Inputs.Services.Listeners
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