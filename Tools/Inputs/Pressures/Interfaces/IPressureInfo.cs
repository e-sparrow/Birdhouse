using Birdhouse.Tools.Inputs.Pressures.Enums;

namespace Birdhouse.Tools.Inputs.Pressures.Interfaces
{
    public interface IPressureInfo<TPressure>
    {
        TPressure Pressure
        {
            get;
        }

        EPressureState State
        {
            get;
        }
    }
}