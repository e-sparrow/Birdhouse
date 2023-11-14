using System.Collections.Generic;

namespace Birdhouse.Tools.Coroutines.Interfaces
{
    public interface ICoroutineStarter
    {
        void Start(IEnumerator<ICoroutineInstruction> coroutine);
    }
}