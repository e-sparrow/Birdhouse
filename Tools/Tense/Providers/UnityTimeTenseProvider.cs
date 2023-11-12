using UnityEngine;

namespace Birdhouse.Tools.Tense.Providers
{
    public class UnityTimeTenseProvider 
        : TenseProviderBase<float>
    {
        public override float Now()
        {
            var result = Time.time;
            return result;
        }
    }
}