using UnityEditor;

namespace Birdhouse.Features.Builds.Interfaces
{
    public interface IBuildPlatform
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