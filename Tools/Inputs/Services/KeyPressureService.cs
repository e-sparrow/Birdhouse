using System.Collections.Generic;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Tense.Controllers.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Inputs.Services
{
    public class KeyPressureService : PressureServiceBase<KeyCode>
    {
        public KeyPressureService(ITenseController<float> tenseController)
            : this(new Dictionary<KeyCode, IPressureActivation<IPressureInfo<KeyCode>, KeyCode>>(), tenseController)
        {
            
        }
        
        public KeyPressureService
            (IDictionary<KeyCode, IPressureActivation<IPressureInfo<KeyCode>, KeyCode>> activations, ITenseController<float> tenseController) 
            : base(activations, tenseController)
        {
            
        }
    }
}
