using System.Collections;

namespace ESparrow.Utils.Tools.Graduating.Interfaces
{
    public interface IGradual
    {
        IEnumerator Graduate(IGradualSettings settings);
    }
}
