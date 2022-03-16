using UnityEngine;

namespace ESparrow.Utils.Tools.Graduating
{
    public class Gradual : GradualBase
    {
        protected override YieldInstruction SkipFrame()
        { 
            return new WaitForEndOfFrame();
        }
    }
}
