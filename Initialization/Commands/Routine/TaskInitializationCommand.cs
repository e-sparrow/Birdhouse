using System.Threading.Tasks;

namespace ESparrow.Utils.Initialization.Commands.Routine
{
    public class TaskInitializationCommand<T> : InitializationCommandBase<T>
    {
        public TaskInitializationCommand(Task task)
        {
            _task = task;
        }

        private readonly Task _task;

        public override async Task Initialize(T context)
        {
            await _task;
        }
    }
}