using Birdhouse.Tools.Tense.Providers.Interfaces;

namespace Birdhouse.Tools.Tense.Timestamps
{
    public class FloatTimestamp : TimestampBase<float>
    {
        public FloatTimestamp(ITenseProvider<float> tenseProvider) 
            : base(tenseProvider)
        {
            
        }

        protected override float GetDeltaTime(float current, float previous)
        {
            var result = current - previous;
            return result;
        }
    }
}