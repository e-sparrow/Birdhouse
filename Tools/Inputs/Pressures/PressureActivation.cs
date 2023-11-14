using Birdhouse.Tools.Inputs.Pressures.Interfaces;

namespace Birdhouse.Tools.Inputs.Pressures
{
    public class PressureActivation<TInfo, T> 
        : IPressureActivation<TInfo, T> 
        where TInfo : IPressureInfo<T>
    {
        public PressureActivation(TInfo info, float activationTime)
        {
            Info = info;
            ActivationTime = activationTime;
        }

        public TInfo Info
        {
            get;
        }

        public float ActivationTime
        {
            get;
        }
    }
}