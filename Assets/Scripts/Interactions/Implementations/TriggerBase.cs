using ESparrow.Utils.Interactions.Interfaces;
using System;

namespace ESparrow.Utils.Interactions.Implementations
{
    public class TriggerBase : ITrigger
    {
        public event Action OnTriggerEnterHandler;
        public event Action OnTriggerStayHandler;
        public event Action OnTriggerExitHandler;
    }
}
