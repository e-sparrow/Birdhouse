using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Tense.Providers.Interfaces;
using Birdhouse.Tools.Ticks.Interfaces;

namespace Birdhouse.Tools.Inputs.Pressures
{
    public class PressureListener<TKey, TTime> 
        : PressureListenerBase<TKey, TTime> 
    {
        public PressureListener
            (ITenseProvider<TTime> tenseProvider, IPressureStateProvider<TKey> stateProvider, ITickProvider tickProvider) 
            : base(tenseProvider, stateProvider, tickProvider)
        {
            
        }
    }
}