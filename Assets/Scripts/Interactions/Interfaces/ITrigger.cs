using System;

namespace ESparrow.Utils.Interactions.Interfaces
{
    public interface ITrigger
    {
        event Action OnTriggerEnterHandler;
        event Action OnTriggerStayHandler;
        event Action OnTriggerExitHandler;
    }
}
