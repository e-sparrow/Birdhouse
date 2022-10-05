using UnityEngine;

namespace Birdhouse.Common.Coroutines.YieldInstructions
{
    public class CancellableYieldInstruction : CancellableYieldInstructionBase
    {
        public CancellableYieldInstruction(CustomYieldInstruction instruction) 
            : base(instruction)
        {
            
        }
    }
}