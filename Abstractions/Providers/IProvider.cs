namespace Birdhouse.Abstractions.Providers
{
    public interface IProvider<out TOut>
    {
        TOut GetValue();
    }

    public interface IProvider<in TIn, out TOut>
    {
        TOut GetValue(TIn parameter);
    }

    public interface IProvider<in TIn1, in TIn2, out TOut>
    {
        TOut GetValue(TIn1 parameter1, TIn2 parameter2);
    }
}