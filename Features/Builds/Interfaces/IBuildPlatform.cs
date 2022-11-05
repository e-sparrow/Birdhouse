using UnityEditor;

namespace Birdhouse.Features.Builds.Interfaces
{
    public interface IBuildTarget
    {
        BuildTargetGroup Group
        {
            get;
        }

        BuildTarget Target
        {
            get;
        }
    }
}