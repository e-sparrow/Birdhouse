using UnityEngine;

namespace Birdhouse.Tools.Tense.Providers
{
    public class UnityRealtimeTenseProvider 
        : TenseProviderBase<float>
    {
        public override float Now()
        {
            var result = Time.realtimeSinceStartup;
            return result;
        }
    }
}