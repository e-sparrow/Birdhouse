namespace Birdhouse.Common.Delegates
{
    public delegate bool ConditionalFunc<in TIn, TOut>
        (TIn parameter, out TOut result);
    
    public delegate bool ConditionalFunc<in TIn1, in TIn2, TOut>
        (TIn1 parameter1, TIn2 parameter2, out TOut result);
    
    public delegate bool ConditionalFunc<in TIn1, in TIn2, in TIn3, TOut>
        (TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, out TOut result);
}