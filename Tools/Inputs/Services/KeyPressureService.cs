using System.Collections.Generic;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Tense.Providers.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Inputs.Services
{
    public class KeyPressureService : PressureServiceBase<KeyCode>
    {
        public KeyPressureService(ITenseProvider<float> tenseProvider)
            : this(new Dictionary<KeyCode, IPressureActivation<IPressureInfo<KeyCode>, KeyCode>>(), tenseProvider)
        {
            
        }
        
        public KeyPressureService
            (IDictionary<KeyCode, IPressureActivation<IPressureInfo<KeyCode>, KeyCode>> activations, ITenseProvider<float> tenseProvider) 
            : base(activations, tenseProvider)
        {
            
        }
    }
}
