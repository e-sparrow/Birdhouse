namespace Birdhouse.Abstractions.Adapters.Interfaces
{
    public interface IAdapter<TTo>
    {
        bool TryAdapt(object value, out TTo result);
    }

    public interface IAdapter<in TIn, TTo>
    {
        bool TryAdapt(TIn value, out TTo result);
    }
}