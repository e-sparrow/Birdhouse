using System;
using System.Collections.Generic;
using Birdhouse.Tools.Coroutines.Interfaces;
using Birdhouse.Tools.Ticks;
using UnityEngine;

namespace Birdhouse.Tools.Coroutines
{
    public static class CoroutinesHelper
    {
        private static readonly Lazy<TickCoroutineStarter> LazyCoroutineStarter 
            = new Lazy<TickCoroutineStarter>(CreateCoroutineStarter);

        private static readonly Lazy<TickCoroutineStarter> LazyRuntimeCoroutineStarter
            = new Lazy<TickCoroutineStarter>(CreateRuntimeCoroutineStarter);

        public static ICoroutineStarter<IEnumerator<ICoroutineInstruction>, IDisposable> TokenCoroutineStarter 
            => LazyCoroutineStarter.Value;

        public static ICoroutineStarter<IEnumerator<ICoroutineInstruction>> CoroutineStarter 
            => LazyCoroutineStarter.Value;

        public static ICoroutineStarter<IEnumerator<ICoroutineInstruction>, IDisposable> TokenRuntimeCoroutineStarter 
            => LazyRuntimeCoroutineStarter.Value;

        public static ICoroutineStarter<IEnumerator<ICoroutineInstruction>> RuntimeCoroutineStarter =>
            LazyRuntimeCoroutineStarter.Value;
        
        private static TickCoroutineStarter CreateCoroutineStarter()
        {
            var result = new TickCoroutineStarter(TickHelper.GetDefaultTickProvider());
            return result;
        }
        
        private static TickCoroutineStarter CreateRuntimeCoroutineStarter()
        {
            var result = new TickCoroutineStarter(TickHelper.GetDefaultTickProvider());
            
            Application.quitting += HandleQuit;
            
            return result;

            void HandleQuit()
            {
                Application.quitting -= HandleQuit;
                result.Dispose();
            }
        }
    }
}