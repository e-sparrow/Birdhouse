namespace Birdhouse.Tools.Conditions.Interfaces
{
    public interface ICondition<in T>
    {
        bool Fit(T value);
    }
}