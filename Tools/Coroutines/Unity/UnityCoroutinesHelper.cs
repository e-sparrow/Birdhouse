using System;
using System.Collections;
using Birdhouse.Tools.Coroutines.Interfaces;

namespace Birdhouse.Tools.Coroutines.Unity
{
    public static class UnityCoroutinesHelper
    {
        private static readonly CoroutineWrapper UnityCoroutineWrapper 
            = new CoroutineWrapper(new UnityInstructionWrapper());
        
        private static readonly Lazy<ICoroutineStarter<IEnumerator>> LazyCoroutineStarter
            = new Lazy<ICoroutineStarter<IEnumerator>>(CreateUnityCoroutineStarter);
        
        public static ICoroutineStarter<IEnumerator> CoroutineStarter => LazyCoroutineStarter.Value;

        private static ICoroutineStarter<IEnumerator> CreateUnityCoroutineStarter()
        {
            var result = new CoroutineStarterWrapper<IEnumerator>(CoroutinesHelper.CoroutineStarter, UnityCoroutineWrapper);
            return result;
        }
    }
}