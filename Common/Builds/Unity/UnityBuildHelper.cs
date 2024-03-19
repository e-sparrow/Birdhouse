using System;
using Birdhouse.Abstractions.Providers.Interfaces;
using UnityEditor;

namespace Birdhouse.Common.Builds.Unity
{
    public static class UnityBuildHelper
    {
        private static readonly Lazy<IProvider<bool, BuildPlayerOptions, BuildPlayerOptions>> LazyDefaultOptionsProvider
            = new Lazy<IProvider<bool, BuildPlayerOptions, BuildPlayerOptions>>();
        
        public static IProvider<bool, BuildPlayerOptions, BuildPlayerOptions> DefaultOptionsProvider 
            => LazyDefaultOptionsProvider.Value;
    }
}