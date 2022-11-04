using System;
using Birdhouse.Features.BuildConfiguration.Interfaces;
using UnityEditor;
using UnityEngine;

namespace Birdhouse.Features.BuildConfiguration
{
    [Serializable]
    public class SerializableBuildConfiguration : IBuildConfiguration
    {
        [SerializeField] private string name;
        
        public void Build()
        {
            
        }

        public string Name => name;
    }
}