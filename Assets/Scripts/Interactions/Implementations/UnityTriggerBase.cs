using UnityEngine;
using ESparrow.Utils.Interactions.Interfaces;
using System;

namespace ESparrow.Utils.Interactions.Implementations
{
    public abstract class UnityTriggerBase : MonoBehaviour, IUnityTrigger, ITrigger
    {
        public event Action<Collider> OnTriggerEnterUnityHandler;
        public event Action<Collider> OnTriggerStayUnityHandler;
        public event Action<Collider> OnTriggerExitUnityHandler;

        public event Action OnTriggerEnterHandler;
        public event Action OnTriggerStayHandler;
        public event Action OnTriggerExitHandler;
    }
}
