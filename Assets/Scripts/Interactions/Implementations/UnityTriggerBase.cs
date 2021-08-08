using System;
using UnityEngine;
using ESparrow.Utils.Interactions.Interfaces;

namespace ESparrow.Utils.Interactions.Implementations
{
    public abstract class UnityTriggerBase : MonoBehaviour, ITrigger
    {
        public event Action<IInteractor> OnTriggerEnterHandler;
        public event Action<IInteractor> OnTriggerStayHandler;
        public event Action<IInteractor> OnTriggerExitHandler;

        protected void OnComponentEnter(Component component)
        {
            var interactor = component.GetComponent<IInteractor>();
            OnTriggerEnterHandler.Invoke(interactor);

            if (interactor != null)
            {
                interactor.EnterTo(this);
            }
        }

        protected void OnComponentStay(Component component)
        {
            var interactor = component.GetComponent<IInteractor>();
            OnTriggerStayHandler.Invoke(interactor);

            if (interactor != null)
            {
                interactor.StayIn(this);
            }
        }

        protected void OnComponentExit(Component component)
        {
            var interactor = component.GetComponent<IInteractor>();
            OnTriggerExitHandler.Invoke(interactor);

            if (interactor != null)
            {
                interactor.ExitFrom(this);
            }
        }
    }
}
