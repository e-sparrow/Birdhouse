using UnityEngine;

namespace ESparrow.Utils.UI.ViewControllers
{
    [AddComponentMenu("ESparrow/Utils/UI/ViewControllers/ConcreteViewController")]
    public class ConcreteViewController : ViewControllerBase
    {
        [SerializeField] private bool logging; 

        private void Log(bool active)
        {
            if (logging)
            {
                Debug.Log($"ConcreteViewController called {gameObject.name} active state changed to {active}");
            } 
        }

        private void Start()
        {
            OnActiveStateChanged += Log;
        }
    }
}
