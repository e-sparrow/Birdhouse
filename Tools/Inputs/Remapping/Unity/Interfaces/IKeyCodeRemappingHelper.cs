namespace Birdhouse.Tools.Inputs.Remapping.Interfaces
{
    public interface IKeyCodeRemappingHelper<in TKey>
    {
        bool IsPressed(TKey key);
        bool IsHeld(TKey key);
        bool IsReleased(TKey key);
    }
}