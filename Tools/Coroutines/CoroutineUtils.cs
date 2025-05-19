using System;
using System.Collections.Generic;
using Birdhouse.Tools.Coroutines.Instructions;
using Birdhouse.Tools.Coroutines.Interfaces;

namespace Birdhouse.Tools.Coroutines
{
    public static class CoroutineUtils
    {
        public static void CallAfterFrame(Action callback)
        {
            CoroutinesHelper.CoroutineStarter.Start(Coroutine());
            
            IEnumerator<ICoroutineInstruction> Coroutine()
            {
                yield return new WaitForFrameInstruction();
                callback.Invoke();
            }
        }
        
        public static void DelayedCall(Action callback, float delay)
        {
            CoroutinesHelper.CoroutineStarter.Start(Coroutine());
            
            IEnumerator<ICoroutineInstruction> Coroutine()
            {
                yield return new WaitForSecondsInstruction(delay);
                callback.Invoke();
            }
        }
    }
}