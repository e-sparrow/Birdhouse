using System;
using System.Collections;
using Birdhouse.Tools.Coroutines.Interfaces;

namespace Birdhouse.Tools.Coroutines.Unity
{
    public static class UnityCoroutinesHelper
    {
        private static readonly Lazy<IInstructionWrapper> LazyInstructionWrapper 
            = new Lazy<IInstructionWrapper>(() => new UnityInstructionWrapper());

        private static readonly Lazy<ICoroutineWrapper<IEnumerator>> LazyCoroutineWrapper
            = new Lazy<ICoroutineWrapper<IEnumerator>>(() => new CoroutineWrapper(InstructionWrapper));
        
        private static readonly Lazy<ICoroutineStarter<IEnumerator>> LazyCoroutineStarter
            = new Lazy<ICoroutineStarter<IEnumerator>>(CreateUnityCoroutineStarter);
        
        public static IInstructionWrapper InstructionWrapper => LazyInstructionWrapper.Value;
        public static ICoroutineWrapper<IEnumerator> CoroutineWrapper => LazyCoroutineWrapper.Value;
        public static ICoroutineStarter<IEnumerator> CoroutineStarter => LazyCoroutineStarter.Value;

        private static ICoroutineStarter<IEnumerator> CreateUnityCoroutineStarter()
        {
            var result = new CoroutineStarterWrapper<IEnumerator>(CoroutinesHelper.CoroutineStarter, new CoroutineWrapper(InstructionWrapper));
            return result;
        }
    }
}