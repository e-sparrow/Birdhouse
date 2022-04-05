using System;
using System.Collections;
using ESparrow.Utils.Extensions;

namespace ESparrow.Utils.Helpers
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