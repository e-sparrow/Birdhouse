using System;
using UnityEngine;

namespace Birdhouse.Tools.UnityMessages
{
    public class UpdateUnityTickProvider 
        : UnityTickProviderBase
    {
        public UpdateUnityTickProvider(Type subsystemType) 
            : base(subsystemType)
        {
            
        }

        protected override float GetDeltaTime()
        {
            return Time.deltaTime;
        }
    }
}