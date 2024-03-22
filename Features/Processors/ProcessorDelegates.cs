namespace Birdhouse.Features.Processors
{
    public delegate T Aggregator<T>(T value);
    public delegate T Evaluator<in TParameter, T>(T value, TParameter parameter);

    public delegate bool ConditionalEvaluator<T>(T value, out T result);
    public delegate bool ConditionalEvaluator<in TParameter, T>(T value, TParameter parameter, out T result);
}