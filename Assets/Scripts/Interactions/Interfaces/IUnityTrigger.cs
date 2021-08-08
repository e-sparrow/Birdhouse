using System;
using UnityEngine;

namespace ESparrow.Utils.Interactions.Interfaces
{
    public interface IUnityTrigger
    {
        event Action<Collider> OnTriggerEnterUnityHandler;
        event Action<Collider> OnTriggerStayUnityHandler;
        event Action<Collider> OnTriggerExitUnityHandler;
    }
}
