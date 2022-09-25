using UnityEngine;

namespace Birdhouse.Tools.Interactions
{
    [RequireComponent(typeof(Collider))]
    [AddComponentMenu("ESparrow/Utils/Interactions/Implementations/Trigger")]
    public class Trigger : UnityTriggerBase
    {
        private void OnTriggerEnter(Collider other)
        {
            OnComponentEnter(other);
        }

        private void OnTriggerStay(Collider other)
        {
            OnComponentStay(other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnComponentExit(other);
        }
    }
}
