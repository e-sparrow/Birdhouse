using System.Collections.Generic;
using ESparrow.Utils.Inputs.Pressures.Interfaces;
using ESparrow.Utils.Tools.Tense.Controllers.Interfaces;

namespace ESparrow.Utils.Inputs.Services
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