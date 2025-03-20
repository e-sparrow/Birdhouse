using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Birdhouse.Tools.Ticks.Unity
{
    public sealed class LateUpdateTickProvider
        : UnityTickProviderBase
    {
        public LateUpdateTickProvider() 
            : base(typeof(PreLateUpdate))
        {
            
        }

        protected override float GetDeltaTime() => Time.captureDeltaTime;
    }
}