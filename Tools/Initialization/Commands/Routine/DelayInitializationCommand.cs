using System;
using System.Threading.Tasks;

namespace Birdhouse.Tools.Initialization.Commands.Routine
{
    public class DelayInitializationCommand<T> : TaskInitializationCommand<T>
    {
        public DelayInitializationCommand(TimeSpan delay) : base(Task.Delay(delay))
        {
            
        }
    }
}