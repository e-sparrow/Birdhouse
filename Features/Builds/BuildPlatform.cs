using Birdhouse.Features.Builds.Interfaces;
using UnityEditor;

namespace Birdhouse.Features.Builds
{
    public readonly struct BuildPlatform : IBuildPlatform
    {
        public BuildPlatform(BuildTargetGroup group, BuildTarget target)
        {
            Group = group;
            Target = target;
        }

        public BuildTargetGroup Group
        {
            get;
        }

        public BuildTarget Target
        {
            get;
        }
    }
}