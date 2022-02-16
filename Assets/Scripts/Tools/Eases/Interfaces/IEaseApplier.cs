namespace ESparrow.Utils.Tools.Eases.Interfaces
{
    public interface IEaseApplier<out T>
    {
        T Evaluate(float progress);
    }

    public interface IEaseApplier : IEaseApplier<object>
    {
        
    }
}
