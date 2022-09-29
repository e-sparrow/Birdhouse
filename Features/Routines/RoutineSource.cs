using System.Collections.Generic;
using System.Threading.Tasks;
using Birdhouse.Features.Routines.Interfaces;

namespace Birdhouse.Features.Routines
{
    public class RoutineSource : IAsyncEnumerator<IRoutineInstruction>
    {
        public ValueTask DisposeAsync()
        {
            
        }

        public ValueTask<bool> MoveNextAsync()
        {
            
        }

        public IRoutineInstruction Current { get; }
    }
}