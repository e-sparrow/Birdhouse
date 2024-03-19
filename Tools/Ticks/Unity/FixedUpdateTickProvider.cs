using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Birdhouse.Tools.Ticks.Unity
{
    public class FixedUpdateTickProvider 
        : UnityTickProviderBase
    {
        public FixedUpdateTickProvider() 
            : base(typeof(FixedUpdate))
        {
            
        }

        protected override float GetDeltaTime()
        {
            return Time.fixedDeltaTime;
        }
    }
}