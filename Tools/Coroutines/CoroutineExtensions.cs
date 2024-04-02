using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Birdhouse.Tools.Coroutines.Interfaces;

namespace Birdhouse.Tools.Coroutines
{
    public static class CoroutineExtensions
    {
        public static ICompositeInstructionWrapper Append<TFrom>
        (
            this IInstructionWrapper self,
            IInstructionWrapper other
        )
        {
            var result = new CompositeInstructionWrapper()
                .Append(self)
                .Append(other);

            return result;
        }

        public static IEnumerator<ICoroutineInstruction> Append
        (
            this IEnumerator<ICoroutineInstruction> self,
            IEnumerator<ICoroutineInstruction> other
        )
        {
            yield return self.AsInstruction();
            yield return other.AsInstruction();
        }
        
        public static IEnumerator<ICoroutineInstruction> PutFirst
        (
            this IEnumerator<ICoroutineInstruction> self,
            IEnumerator<ICoroutineInstruction> other
        )
        {
            yield return other.AsInstruction();
            yield return self.AsInstruction();
        }

        public static ICoroutineInstruction AsInstruction(this IEnumerator<ICoroutineInstruction> self)
        {
            var result = new CoroutineRunner(self);
            return result;
        }

        public static IEnumerator Measure(this IEnumerator self, Action<Stopwatch> callback)
        {
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            yield return self;
            stopwatch.Stop();
            
            callback.Invoke(stopwatch);
        }

        public static IEnumerator<ICoroutineInstruction> Measure(this IEnumerator<ICoroutineInstruction> self, Action<Stopwatch> callback)
        {
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            yield return self.AsInstruction();
            stopwatch.Stop();
            
            callback.Invoke(stopwatch);
        }
    }
}