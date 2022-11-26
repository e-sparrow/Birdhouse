namespace Birdhouse.Abstractions.Entries.Interfaces
{
    public interface IEntry
    {
        void Enter();
    }

    public interface IEntry<in TArgument>
    {
        void Enter(TArgument argument);
    }
}
