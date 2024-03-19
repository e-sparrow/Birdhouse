namespace Birdhouse.Tools.Coroutines.Instructions
{
    public sealed class WaitForSecondsInstruction 
        : CoroutineInstructionBase
    {
        public WaitForSecondsInstruction(float amount)
        {
            _amount = amount;
        }

        private readonly float _amount;

        private float _sum = 0f;
        
        public override bool IsFinished(float deltaTime)
        {
            _sum += deltaTime;

            var result = _sum >= _amount;
            return result;
        }
    }
}