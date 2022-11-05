using UnityEditor;

namespace Birdhouse.Features.Builds
{
    public static class BuildHelper
    {
        public static BuildTargetGroup GetCurrentBuildTargetGroup()
        {
            var target = EditorUserBuildSettings.activeBuildTarget;
            
            var group = BuildPipeline.GetBuildTargetGroup(target);
            return group;
        }
    }
}