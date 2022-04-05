using System.Collections.Generic;
using ESparrow.Utils.Inputs.Pressures.Interfaces;
using ESparrow.Utils.Tools.Tense.Controllers.Interfaces;

namespace ESparrow.Utils.Inputs.Services
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