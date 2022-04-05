using ESparrow.Utils.Inputs.Pressures.Interfaces;

namespace ESparrow.Utils.Inputs.Pressures
{
    public readonly struct PressureActivation<TInfo, T> : IPressureActivation<TInfo, T> where TInfo : IPressureInfo<T>
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