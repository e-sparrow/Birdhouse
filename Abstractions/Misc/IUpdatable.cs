namespace Birdhouse.Abstractions.Misc
{
    public interface IUpdatable
    {
        void Update();
    }

    public interface IUpdatable<in T>
    {
        void Update(T input);
    }
}