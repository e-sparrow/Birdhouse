using Birdhouse.Tools.Inputs.Pressures.Enums;

namespace Birdhouse.Tools.Inputs.Pressures
{
    public readonly struct PressureStateChange<TTime>
    {
        public PressureStateChange(EPressureState state, TTime time)
        {
            State = state;
            Time = time;
        }

        public EPressureState State
        {
            get;
        }
        
        public TTime Time
        {
            get;
        }
    }
}