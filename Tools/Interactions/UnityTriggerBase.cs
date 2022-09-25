using System;
using Birdhouse.Tools.Interactions.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Interactions
{
    public abstract class UnityTriggerBase : MonoBehaviour, ITrigger
    {
        public event Action<IInteractor> OnTriggerEnterHandler = _ => { };
        public event Action<IInteractor> OnTriggerStayHandler = _ => { };
        public event Action<IInteractor> OnTriggerExitHandler = _ => { };

        protected void OnComponentEnter(Component component)
        {
            var interactor = component.GetComponent<IInteractor>();
            if (interactor != null)
            {
                interactor.EnterTo(this);
            }
            
            OnTriggerEnterHandler.Invoke(interactor);
        }

        protected void OnComponentStay(Component component)
        {
            var interactor = component.GetComponent<IInteractor>();
            if (interactor != null)
            {
                interactor.StayIn(this);
            }
            
            OnTriggerStayHandler.Invoke(interactor);
        }

        protected void OnComponentExit(Component component)
        {
            var interactor = component.GetComponent<IInteractor>();
            if (interactor != null)
            {
                interactor.ExitFrom(this);
            }
            
            OnTriggerExitHandler.Invoke(interactor);
        }
    }
}
