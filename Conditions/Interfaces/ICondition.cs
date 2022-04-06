namespace ESparrow.Utils.Conditions.Interfaces
{
    public interface ICondition<in T>
    {
        bool Fit(T value);
    }
}