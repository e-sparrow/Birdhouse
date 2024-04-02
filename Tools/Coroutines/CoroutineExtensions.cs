using Birdhouse.Tools.Coroutines.Interfaces;

namespace Birdhouse.Tools.Coroutines
{
    public static class CoroutineExtensions
    {
        public static ICompositeInstructionWrapper Append<TFrom>
        (
            this IInstructionWrapper self,
            IInstructionWrapper other
        )
        {
            var result = new CompositeInstructionWrapper()
                .Append(self)
                .Append(other);

            return result;
        }
    }
}