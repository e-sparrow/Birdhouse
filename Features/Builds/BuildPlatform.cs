using Birdhouse.Features.Builds.Interfaces;
using UnityEditor;

namespace Birdhouse.Features.Builds
{
    public readonly struct BuildTarget : IBuildTarget
    {
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