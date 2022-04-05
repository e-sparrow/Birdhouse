using System.Collections.Generic;
using ESparrow.Utils.Inputs.Pressures.Interfaces;
using ESparrow.Utils.Tools.Tense.Controllers.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Inputs.Services
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
