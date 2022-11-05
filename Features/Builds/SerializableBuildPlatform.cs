using System;
using Birdhouse.Features.Builds.Interfaces;
using UnityEditor;
using UnityEngine;

namespace Birdhouse.Features.Builds
{
    [Serializable]
    public struct SerializableBuildPlatform : IBuildPlatform
    {
        [field: SerializeField]
        public BuildTargetGroup Group
        {
            get;
            private set;
        }

        [field: SerializeField]
        public BuildTarget Target
        {
            get;
            private set;
        }
    }
}