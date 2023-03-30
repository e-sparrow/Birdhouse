using System.Collections.Generic;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Tense.Providers.Interfaces;

namespace Birdhouse.Tools.Inputs.Services
{
    public class ButtonPressureService : PressureServiceBase<string>
    {
        public ButtonPressureService
            (ITenseProvider<float> tenseProvider)
            : this(new Dictionary<string, IPressureActivation<IPressureInfo<string>, string>>(), tenseProvider)
        {
            
        }
        
        public ButtonPressureService
            (IDictionary<string, IPressureActivation<IPressureInfo<string>, string>> activations, ITenseProvider<float> tenseProvider) 
            : base(activations, tenseProvider)
        {

        }
    }
}