using System;
using System.Collections;
using Birdhouse.Common.Coroutines;
using Birdhouse.Common.Extensions;

namespace Birdhouse.Common.Helpers
{
    public static class MonoHelper
    {
        public static void ExecuteNextFrame(Action action)
        {
            ExecuteNextFrameCoroutine(action).Start();
        }

        private static IEnumerator ExecuteNextFrameCoroutine(Action action)
        {
            yield return null;
            action.Invoke();
        }
    }
}