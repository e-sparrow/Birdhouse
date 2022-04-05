using ESparrow.Utils.Enums;
using ESparrow.Utils.Inputs.Pressures.Enums;

namespace ESparrow.Utils.Inputs.Pressures.Interfaces
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