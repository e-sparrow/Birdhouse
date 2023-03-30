using UnityEngine;
using UnityEngine.UI;

namespace Birdhouse.Common.Components.Triggers
{
    [AddComponentMenu(ComponentMenuName)]
    public class MonoButtonTrigger : MonoTriggerBase
    {
        private const string ComponentMenuName = @"Birdhouse/Common/Components/Triggers/Button Trigger";
        
        [SerializeField] private Button button;
        
        public override void Trigger()
        {
            button.onClick.Invoke();
        }
    }
}