using Birdhouse.Tools.Validators.Abstractions;

namespace Birdhouse.Tools.Validators
{
    public abstract class ValidatorBase<TIn, TOut>
        : IValidator<TIn, TOut>
    {
        public abstract TOut Validate(TIn input);
    }
    
    public abstract class ValidatorBase<TIn1, TIn2, TOut>
        : IValidator<TIn1, TIn2, TOut>
    {
        public abstract TOut Validate(TIn1 input1, TIn2 input2);
    }
}