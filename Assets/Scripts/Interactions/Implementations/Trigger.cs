using UnityEngine;
using ESparrow.Utils.Interactions.Interfaces;
using System;

namespace ESparrow.Utils.Interactions.Implementations
{
    [RequireComponent(typeof(Collider))]
    [AddComponentMenu("ESparrow/Utils/Interactions/Implementations/Trigger")]
    public class Trigger : MonoBehaviour, IUnityTrigger, ITrigger
    {
        public event Action<Collider> OnTriggerEnterUnityHandler = _ => { };
        public event Action<Collider> OnTriggerStayUnityHandler = _ => { };
        public event Action<Collider> OnTriggerExitUnityHandler = _ => { };

        public event Action OnTriggerEnterHandler;
        public event Action OnTriggerStayHandler;
        public event Action OnTriggerExitHandler;

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterUnityHandler.Invoke(other);
            OnTriggerEnterHandler.Invoke();
        }

        private void OnTriggerStay(Collider other)
        {
            OnTriggerStayUnityHandler.Invoke(other);
            OnTriggerStayHandler.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            OnTriggerExitUnityHandler.Invoke(other);
            OnTriggerExitHandler.Invoke();
        }
    }
}
