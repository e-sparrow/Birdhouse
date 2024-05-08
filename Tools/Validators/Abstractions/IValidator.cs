namespace Birdhouse.Tools.Validators.Abstractions
{
    public interface IValidator<in TIn, out TOut>
    {
        TOut Validate(TIn input);
    }

    public interface IValidator<in TIn>
        : IValidator<TIn, bool>
    {
        
    }

    public interface IValidator<in TIn1, in TIn2, out TOut>
    {
        TOut Validate(TIn1 input1, TIn2 input2);
    }
}