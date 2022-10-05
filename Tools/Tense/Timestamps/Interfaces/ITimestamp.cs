namespace Birdhouse.Tools.Tense.Timestamps.Interfaces
{
    public interface ITimestamp<out T>
    {
        T Stamp();
    }
}