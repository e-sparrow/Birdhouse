using System;
using System.Threading.Tasks;

namespace ESparrow.Utils.Initialization.Commands.Routine
{
    public class DelayInitializationCommand<T> : TaskInitializationCommand<T>
    {
        public DelayInitializationCommand(TimeSpan delay) : base(Task.Delay(delay))
        {
            
        }
    }
}