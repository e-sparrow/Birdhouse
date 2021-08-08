using UnityEngine;
using ESparrow.Utils.Interactions.Interfaces;
using System;

namespace ESparrow.Utils.Interactions.Implementations
{
    [RequireComponent(typeof(Collider2D))]
    [AddComponentMenu("ESparrow/Utils/Interactions/Implementations/Trigger2D")]
    public class Trigger2D : MonoBehaviour, IUnityTrigger2D, ITrigger
    {
        public event Action<Collider2D> OnTriggerEnterUnityHandler = _ => { };
        public event Action<Collider2D> OnTriggerStayUnityHandler = _ => { };
        public event Action<Collider2D> OnTriggerExitUnityHandler = _ => { };

        public event Action OnTriggerEnterHandler;
        public event Action OnTriggerStayHandler;
        public event Action OnTriggerExitHandler;

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnterUnityHandler.Invoke(other);
            OnTriggerEnterHandler.Invoke();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            OnTriggerStayUnityHandler.Invoke(other);
            OnTriggerStayHandler.Invoke();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnTriggerExitUnityHandler.Invoke(other);
            OnTriggerExitHandler.Invoke();
        }
    }
}
