using System.Collections.Generic;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Tense.Controllers.Interfaces;

namespace Birdhouse.Tools.Inputs.Services
{
    public class ButtonPressureService : PressureServiceBase<string>
    {
        public ButtonPressureService
            (ITenseController<float> tenseController)
            : this(new Dictionary<string, IPressureActivation<IPressureInfo<string>, string>>(), tenseController)
        {
            
        }
        
        public ButtonPressureService
            (IDictionary<string, IPressureActivation<IPressureInfo<string>, string>> activations, ITenseController<float> tenseController) 
            : base(activations, tenseController)
        {

        }
    }
}