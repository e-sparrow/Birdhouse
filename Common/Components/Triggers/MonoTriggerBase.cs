using Birdhouse.Common.Components.Triggers.Interfaces;
using UnityEngine;

namespace Birdhouse.Common.Components.Triggers
{
    public abstract class MonoTriggerBase : MonoBehaviour, ITrigger
    {
        [ContextMenu("Debug/Trigger")]
        public abstract void Trigger();
    }
}