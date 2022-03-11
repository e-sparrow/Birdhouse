using System.Collections.Generic;

namespace ESparrow.Utils.Tools.Interpolation.Mixing.Interfaces 
{
    public interface IMixer<TPart>
    {
        TPart Mix(IEnumerable<IMixingPart<TPart>> parts);
    }
}
