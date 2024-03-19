using System;
using Birdhouse.Common.Engines;
using Birdhouse.Common.Engines.Enums;
using Birdhouse.Tools.Ticks.Interfaces;
using Birdhouse.Tools.Ticks.Unity;

namespace Birdhouse.Tools.Ticks
{
    public static class TickHelper
    {
        // TODO: 
        public static ITickProvider GetDefaultTickProvider()
        {
            if (EngineHelper.GetCurrentEngine() == EEngine.Unity)
            {
                var unityUpdateProvider = UnityTicksHelper.UpdateProvider;
                return unityUpdateProvider;
            }

            throw new ArgumentException($"Can't find correct tick provider for your engine");
        }
    }
}