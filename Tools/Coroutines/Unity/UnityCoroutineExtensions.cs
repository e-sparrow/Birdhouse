using System.Collections;
using System.Threading.Tasks;
using Birdhouse.Tools.Coroutines.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Coroutines.Unity
{
    public static class UnityCoroutineExtensions
    {
        public static Task StartAsync(this IEnumerator self)
        {
            var source = new TaskCompletionSource<bool>();
            
            self.Append(Complete()).Start();

            return source.Task;
            
            IEnumerator Complete()
            {
                source.SetResult(true);
                yield break;
            }
        }

        public static void Start(this IEnumerator self)
        {
            UnityCoroutinesHelper
                .CoroutineStarter
                .Start(self);
        }

        public static IEnumerator Append(this IEnumerator self, IEnumerator other)
        {
            yield return self;
            yield return other;
        }

        public static CustomYieldInstruction ToUnityInstruction(this ICoroutineInstruction self)
        {
            var result = new ToUnityCoroutineInstructionAdapter(self);
            return result;
        }
        
        public static ICoroutineInstruction FromUnityInstruction(this CustomYieldInstruction self)
        {
            var result = new FromUnityCoroutineInstructionAdapter(self);
            return result;
        }
    }
}