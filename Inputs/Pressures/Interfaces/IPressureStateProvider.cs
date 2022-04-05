using ESparrow.Utils.Inputs.Pressures.Enums;

namespace ESparrow.Utils.Inputs.Pressures.Interfaces
{
    public interface IPressureStateProvider<in TPressure>
    {
        EPressureState GetPressureState(TPressure pressure);
    }
}