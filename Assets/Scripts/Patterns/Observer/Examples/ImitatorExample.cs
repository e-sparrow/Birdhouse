using UnityEngine;

namespace ESparrow.Utils.Patterns.Observer.Examples
{
    public class ImitatorExample : MonoBehaviour
    {
        [SerializeField] private string messageToImitator;

        [SerializeField] private ImitatorExample objectToImitate;

        private Imitator<ImitatorExample> _imitator;

        private void OnEnable()
        {
            if (objectToImitate != null)
            {
                _imitator = new Imitator<ImitatorExample>(objectToImitate, this);
                _imitator.SubscribeToMember("messageToImitator");
            }
        }

        private void OnDisable()
        {
            _imitator = null;
        }
    }
}
