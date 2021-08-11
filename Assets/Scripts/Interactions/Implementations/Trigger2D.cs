using UnityEngine;

namespace ESparrow.Utils.Interactions.Implementations
{
    [RequireComponent(typeof(Collider2D))]
    [AddComponentMenu("ESparrow/Utils/Interactions/Implementations/Trigger2D")]
    public class Trigger2D : UnityTriggerBase
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnComponentEnter(other);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            OnComponentStay(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnComponentExit(other);
        }
    }
}
