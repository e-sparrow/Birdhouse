using System;
using UnityEngine;

namespace ESparrow.Utils.Interactions.Interfaces
{
    public interface IUnityTrigger2D
    {
        event Action<Collider2D> OnTriggerEnterUnityHandler;
        event Action<Collider2D> OnTriggerStayUnityHandler;
        event Action<Collider2D> OnTriggerExitUnityHandler;
    }
}
