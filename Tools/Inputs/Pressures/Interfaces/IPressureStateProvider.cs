using Birdhouse.Tools.Inputs.Pressures.Enums;

namespace Birdhouse.Tools.Inputs.Pressures.Interfaces
{
    public interface IPressureStateProvider<in TKey>
    {
        EPressureState GetPressureState(TKey key);
    }
}