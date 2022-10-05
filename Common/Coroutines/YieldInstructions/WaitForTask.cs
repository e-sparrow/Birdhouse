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
}