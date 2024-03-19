using System.Collections.Generic;
using System.Threading.Tasks;
using Birdhouse.Features.Decisions.Interfaces;

namespace Birdhouse.Features.Decisions
{
    public static class DecisionsExtensions
    {
        public static IDecider<TTo> Remap<TFrom, TTo>(this IDecider<TFrom> self, IDictionary<TFrom, TTo> dictionary)
        {
            var result = new RemappedDecider<TFrom, TTo>(self, dictionary);
            return result;
        }

        public static ICompositeDecider<TOut> Append<TOut>(this IDecider<TOut> self, IDecider<TOut> other)
        {
            var result = new CompositeDecider<TOut>()
                .Append(self)
                .Append(other);

            return result;
        }

        public static Task<TOut> WaitForDecision<TOut>(this IDecider<TOut> self)
        {
            var source = new TaskCompletionSource<TOut>();

            self.OnDecide += Decide;

            var result = source.Task;
            return result;

            void Decide(TOut value)
            {
                self.OnDecide -= Decide;
                
                source.SetResult(value);
            }
        }
    }
}