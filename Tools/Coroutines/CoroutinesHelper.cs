using System;
using System.Collections.Generic;
using Birdhouse.Tools.Coroutines.Interfaces;
using Birdhouse.Tools.Ticks;

namespace Birdhouse.Tools.Coroutines
{
    public static class CoroutinesHelper
    {
        private static readonly Lazy<TickCoroutineStarter> LazyCoroutineStarter 
            = new Lazy<TickCoroutineStarter>(CreateCoroutineStarter);

        public static ICoroutineStarter<IEnumerator<ICoroutineInstruction>, IDisposable> TokenCoroutineStarter 
            => LazyCoroutineStarter.Value;

        public static ICoroutineStarter<IEnumerator<ICoroutineInstruction>> CoroutineStarter 
            => LazyCoroutineStarter.Value;

        private static TickCoroutineStarter CreateCoroutineStarter()
        {
            var result = new TickCoroutineStarter(TickHelper.GetDefaultTickProvider());
            return result;
        }
    }
}