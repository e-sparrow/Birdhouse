namespace Birdhouse.Mechanics.Mixing.Interfaces
{
    public interface IMixingPart<out T>
    {
        T Value
        {
            get;
        }

        float Proportion
        {
            get;
        }
    }
}
