using System;

namespace Birdhouse.Tools.Interactions.Interfaces
{
    public interface ITrigger
    {
        event Action<IInteractor> OnTriggerEnterHandler;
        event Action<IInteractor> OnTriggerStayHandler;
        event Action<IInteractor> OnTriggerExitHandler;
    }
}
