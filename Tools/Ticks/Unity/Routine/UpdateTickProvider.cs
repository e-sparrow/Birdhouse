using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Birdhouse.Tools.Ticks.Unity.Routine
{
    public class UpdateTickProvider 
        : UnityTickProviderBase
    {
        public UpdateTickProvider() 
            : base(typeof(Update))
        {
            
        }

        protected override float GetDeltaTime()
        {
            return Time.deltaTime;
        }
    }
}