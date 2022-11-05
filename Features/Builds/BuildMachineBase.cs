using System;
using Birdhouse.Common.Extensions;
using Birdhouse.Features.Builds.Interfaces;
using UnityEditor;
using UnityEngine;

namespace Birdhouse.Features.Builds
{
    public abstract class BuildMachineBase<TKey> : IBuildMachine<IBuildPlatform, TKey>
    {
        protected abstract IBuildConfiguration GetBuildConfiguration(IBuildPlatform platform, TKey key);
        
        public void Build(IBuildPlatform platform, TKey key)
        {
            if (BuildHelper.GetCurrentBuildTargetGroup() != platform.Group)
            {
                var message = $"{"BuildMachine throws an exception:".Bold().WithColor(Color.red)} can't build application to {platform.Group}. Change current build target group in PlayerSettings";
                throw new ArgumentException(message);
            }

            var configuration = GetBuildConfiguration(platform, key);
        }
    }
}