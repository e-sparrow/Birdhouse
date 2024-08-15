namespace Birdhouse.Abstractions.Factories
{
    public interface IFactory<in TIn, out TOut>
    {
        TOut Create(TIn input);
    }

    public interface IFactory<in TIn1, in TIn2, out TOut>
    {
        TOut Create(TIn1 input1, TIn2 input2);
    }

    public interface IFactory<in TIn1, in TIn2, in TIn3, out TOut>
    {
        TOut Create(TIn1 input1, TIn2 input2, TIn3 input3);
    }
    
    public interface IFactory
        : IFactory<object[], object>
    {
        
    }
}