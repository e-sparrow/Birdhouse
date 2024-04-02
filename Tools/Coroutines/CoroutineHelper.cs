using System;
using System.Collections.Generic;
using Birdhouse.Tools.Coroutines.Interfaces;
using Birdhouse.Tools.Ticks;

namespace Birdhouse.Tools.Coroutines
{
    public static class CoroutineHelper
    {
        private static readonly Lazy<ICoroutineStarter<IEnumerator<ICoroutineInstruction>>> LazyCoroutineStarter
            = new Lazy<ICoroutineStarter<IEnumerator<ICoroutineInstruction>>>(CreateCoroutineStarter);
        
        public static ICoroutineStarter<IEnumerator<ICoroutineInstruction>> CoroutineStarter 
            => LazyCoroutineStarter.Value;

        private static ICoroutineStarter<IEnumerator<ICoroutineInstruction>> CreateCoroutineStarter()
        {
            var result = new TickCoroutineStarter(TickHelper.GetDefaultTickProvider());
            return result;
        }
    }
}