using System.Collections.Generic;

namespace Birdhouse.Features.Mixing.Interfaces 
{
    public interface IMixer<TPart>
    {
        TPart Mix(IEnumerable<IMixingPart<TPart>> parts);
    }
}
