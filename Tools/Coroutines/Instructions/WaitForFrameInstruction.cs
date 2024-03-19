namespace Birdhouse.Tools.Coroutines.Instructions
{
    public class WaitForFrameInstruction 
        : CoroutineInstructionBase
    {
        public override bool IsFinished(float deltaTime)
        {
            return true;
        }
    }
}