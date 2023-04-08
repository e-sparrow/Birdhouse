using System.Threading.Tasks;

namespace Birdhouse.Common.Coroutines.YieldInstructions
{
    public class WaitForTask : YieldInstructionBase
    {
        public WaitForTask(Task task)
        {
            _task = task;
        }

        private readonly Task _task;
        
        protected override bool IsFinished()
        {
            var result = _task.IsCompleted;
            return result;
        }
    }
    
    public class WaitForTask<T> : YieldInstructionBase
    {
        public WaitForTask(Task<T> task)
        {
            _task = task;
        }

        private readonly Task<T> _task;

        protected override bool IsFinished()
        {
            var result = _task.IsCompleted;
            return result;
        }

        public T Result => _task.Result;
    }
}