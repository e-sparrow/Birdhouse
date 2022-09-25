using System.Collections.Generic;

namespace Birdhouse.Mechanics.Mixing.Interfaces 
{
    public interface IMixer<TPart>
    {
        TPart Mix(IEnumerable<IMixingPart<TPart>> parts);
    }
}
