using System.Collections;

namespace Birdhouse.Tools.Graduating.Interfaces
{
    public interface IGradual
    {
        IEnumerator Graduate(IGradualSettings settings);
    }
}
