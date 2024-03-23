namespace Birdhouse.Features.Aggregators
{
    public delegate T Aggregation<T>(T value);
    public delegate T Aggregation<in TParameter, T>(T value, TParameter parameter);

    public delegate bool ConditionalAggregation<T>(T value, out T result);
    public delegate bool ConditionalAggregation<in TParameter, T>(T value, TParameter parameter, out T result);
}