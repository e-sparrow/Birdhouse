using UnityEngine;

namespace Birdhouse.Tools.Graduating
{
    public class Gradual : GradualBase
    {
        protected override YieldInstruction SkipFrame()
        { 
            return new WaitForEndOfFrame();
        }
    }
}
