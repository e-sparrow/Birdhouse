using System.Threading.Tasks;
using Birdhouse.Features.Decisions.Interfaces;

namespace Birdhouse.Features.Decisions
{
    public static class DecisionsExtensions
    {
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