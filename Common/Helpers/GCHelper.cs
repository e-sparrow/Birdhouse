using System;

namespace Birdhouse.Common.Helpers
{
    public static class GCHelper
    {
        public static void TriggerGC()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}