using System.Collections.Generic;
using UnityEngine;

namespace Birdhouse.Common.Components.Triggers
{
    [AddComponentMenu(ComponentMenuName)]
    public class CompositeTrigger : MonoTriggerBase
    {
        private const string ComponentMenuName = "Birdhouse/Common/Components/Triggers/Composite Trigger";
        
        [SerializeField] private List<MonoTriggerBase> triggers;

        public override void Trigger()
        {
            triggers.ForEach(value => value.Trigger());
        }
    }
}