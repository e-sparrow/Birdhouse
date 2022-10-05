using System.Collections;
using Birdhouse.Common.Coroutines;
using Birdhouse.Common.Extensions;

namespace Birdhouse.Tools.Initialization.Commands.Routine
{
    public class CoroutineInitializationCommand<T> : TaskInitializationCommand<T>
    {
        public CoroutineInitializationCommand(IEnumerator coroutine) : base(coroutine.StartAsync())
        {

        }
    }
}