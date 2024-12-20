using System.Threading.Tasks;

namespace Birdhouse.Tools.Coroutines.Instructions
{
    public sealed class WaitForTaskInstruction
        : CoroutineInstructionBase
    {
        public WaitForTaskInstruction(Task task)
        {
            _task = task;
        }

        private readonly Task _task;
        
        public override bool IsFinished(float deltaTime)
        {
            var result = _task.IsCompleted;
            return result;
        }
    }
    
    public class WaitForTaskInstruction<T> 
        : CoroutineInstructionBase
    {
        public WaitForTaskInstruction(Task<T> task)
        {
            _task = task;
        }

        private readonly Task<T> _task;

        public override bool IsFinished(float deltaTime)
        {
            var result = _task.IsCompleted;
            return result;
        }

        public T Result => _task.Result;
    }
}