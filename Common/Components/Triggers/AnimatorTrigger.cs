using System;
using Birdhouse.Common.Extensions;
using UnityEngine;

namespace Birdhouse.Common.Components.Triggers
{
    [AddComponentMenu(ComponentMenuName)]
    public class AnimatorTrigger : MonoTriggerBase
    {
        private const string ComponentMenuName = @"Birdhouse/Common/Components/Triggers/Animator Trigger";
        
        [SerializeField] private string keyName;
        [SerializeField] private Animator animator;

        public override void Trigger()
        {
            var nameHash = Animator.StringToHash(keyName);
            
            var hasKey = animator.HasTrigger(nameHash);
            if (hasKey)
            {
                animator.SetTrigger(nameHash);
            }

            throw new ArgumentException($"Animator has no trigger named {keyName} with hash {nameHash}");
        }
    }
}