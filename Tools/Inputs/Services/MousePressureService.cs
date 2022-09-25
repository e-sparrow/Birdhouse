using System.Collections.Generic;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Tense.Controllers.Interfaces;

namespace Birdhouse.Tools.Inputs.Services
{
    public class MousePressureService : PressureServiceBase<int>
    {
        public MousePressureService(ITenseController<float> tenseController) 
            : this(new Dictionary<int, IPressureActivation<IPressureInfo<int>, int>>(), tenseController)
        {
            
        }
        
        public MousePressureService
            (IDictionary<int, IPressureActivation<IPressureInfo<int>, int>> activations, ITenseController<float> tenseController) 
            : base(activations, tenseController)
        {
            
        }
    }
}