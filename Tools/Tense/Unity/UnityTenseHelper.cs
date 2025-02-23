using System;
using Birdhouse.Tools.Tense.Providers;
using Birdhouse.Tools.Tense.Providers.Interfaces;

namespace Birdhouse.Tools.Tense.Unity
{
    public static class UnityTenseHelper
    {
        public static readonly Lazy<ITenseProvider<float>> InGameTenseProvider 
            = new Lazy<ITenseProvider<float>>(() => new UnityTimeTenseProvider());

        public static readonly Lazy<ITenseProvider<float>> RealtimeTenseProvider
            = new Lazy<ITenseProvider<float>>(() => new UnityRealtimeTenseProvider());
    }
}