namespace Birdhouse.Tools.Coroutines.Instructions
{
    public sealed class WaitForFrameInstruction 
        : CoroutineInstructionBase
    {
        public override bool IsFinished(float deltaTime)
        {
            return true;
        }
    }
}