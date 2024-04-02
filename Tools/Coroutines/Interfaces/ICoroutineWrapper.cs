using System.Collections.Generic;

namespace Birdhouse.Tools.Coroutines.Interfaces
{
    public interface ICoroutineWrapper<in TFrom>
    {
        IEnumerator<ICoroutineInstruction> Wrap(TFrom input);
    }
}