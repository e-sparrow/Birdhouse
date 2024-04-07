using System;
using Birdhouse.Abstractions.Providers;
using UnityEditor;

namespace Birdhouse.Common.Builds.Unity
{
    public static class UnityBuildHelper
    {
        private static readonly Lazy<IProvider<bool, BuildPlayerOptions, BuildPlayerOptions>> LazyDefaultOptionsProvider
            = new Lazy<IProvider<bool, BuildPlayerOptions, BuildPlayerOptions>>(() => new DefaultBuildPlayerOptionsProvider());
        
        public static IProvider<bool, BuildPlayerOptions, BuildPlayerOptions> DefaultOptionsProvider 
            => LazyDefaultOptionsProvider.Value;
    }
}