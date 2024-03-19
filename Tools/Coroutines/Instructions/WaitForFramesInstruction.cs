namespace Birdhouse.Tools.Coroutines.Instructions
{
    public class WaitForFramesInstruction 
        : CoroutineInstructionBase
    {
        public WaitForFramesInstruction(int amount)
        {
            _amount = amount;
        }

        private readonly int _amount;
        
        private int _sum = 0;
        
        public override bool IsFinished(float deltaTime)
        {
            _sum++;

            var result = _sum >= _amount;
            return result;
        }
    }
}