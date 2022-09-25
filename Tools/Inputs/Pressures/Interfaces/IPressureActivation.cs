namespace Birdhouse.Tools.Inputs.Pressures.Interfaces
{
    public interface IPressureActivation<out TInfo, T> where TInfo : IPressureInfo<T>
    {
        TInfo Info
        {
            get;
        }
        
        float ActivationTime
        {
            get;
        }
    }
}