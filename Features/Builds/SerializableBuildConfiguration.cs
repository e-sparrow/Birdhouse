using System;
using Birdhouse.Features.Builds.Interfaces;
using UnityEngine;

namespace Birdhouse.Features.Builds
{
    [Serializable]
    public class SerializableBuildConfiguration : IBuildConfiguration
    {
        [SerializeField] private string name;
        
        public string Name => name;
    }
}