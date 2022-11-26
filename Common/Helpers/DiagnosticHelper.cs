using System;
using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;
using Birdhouse.Common.Coroutines;
using Birdhouse.Common.Extensions;

namespace Birdhouse.Common.Helpers
{
    public static class DiagnosticHelper
    {
        public static TimeSpan MeasureExecutionTime(Action action)
        {
            var stopwatch = MeasureExecution(action);

            var result = stopwatch.Elapsed;
            return result;
        }
        
        public static async Task<TimeSpan> MeasureAsyncExecutionTime(Task task)
        {
            var stopwatch = await MeasureAsyncExecution(task);

            var result = stopwatch.Elapsed;
            return result;
        }
        
        public static async Task<TimeSpan> MeasureCoroutineExecutionTime(IEnumerator coroutine)
        {
            var stopwatch = await MeasureCoroutineExecution(coroutine);

            var result = stopwatch.Elapsed;
            return result;
        }

        private static Stopwatch MeasureExecution(Action action)
        {
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            action.Invoke();
            stopwatch.Stop();

            return stopwatch;
        }

        private static async Task<Stopwatch> MeasureAsyncExecution(Task task)
        {
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            await task;
            stopwatch.Stop();

            return stopwatch;
        }

        private static async Task<Stopwatch> MeasureCoroutineExecution(IEnumerator coroutine)
        {
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            await coroutine.StartAsync();
            stopwatch.Stop();

            return stopwatch;
        }
    }
}