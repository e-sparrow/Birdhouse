using System.Collections.Generic;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Tense.Controllers.Interfaces;

namespace Birdhouse.Tools.Inputs.Services
{
    public class MousePressureService : PressureServiceBase<int>
    {
        public MousePressureService(ITenseProvider<float> tenseProvider) 
            : this(new Dictionary<int, IPressureActivation<IPressureInfo<int>, int>>(), tenseProvider)
        {
            
        }
        
        public MousePressureService
            (IDictionary<int, IPressureActivation<IPressureInfo<int>, int>> activations, ITenseProvider<float> tenseProvider) 
            : base(activations, tenseProvider)
        {
            
        }
    }
}