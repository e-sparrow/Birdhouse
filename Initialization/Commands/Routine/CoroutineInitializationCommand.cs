using System.Collections;
using ESparrow.Utils.Extensions;

namespace ESparrow.Utils.Initialization.Commands.Routine
{
    public class CoroutineInitializationCommand<T> : TaskInitializationCommand<T>
    {
        public CoroutineInitializationCommand(IEnumerator coroutine) : base(coroutine.StartAsync())
        {

        }
    }
}