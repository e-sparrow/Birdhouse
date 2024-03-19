using Birdhouse.Tools.Inputs.Pressures;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Tense.Providers.Interfaces;
using Birdhouse.Tools.Ticks.Interfaces;

namespace Birdhouse.Tools.Inputs.Unity
{
    public static class UnityInputExtensions
    {
        public static IPressureListener<TKey, TTime> AsListener<TKey, TTime>
        (
            this IPressureStateProvider<TKey> stateProvider, 
            ITenseProvider<TTime> tenseProvider, 
            ITickProvider tickProvider
        )
        {
            var result = new PressureListener<TKey, TTime>(tenseProvider, stateProvider, tickProvider);
            return result;
        }
    }
}