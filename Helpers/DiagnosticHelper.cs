using System;
using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ESparrow.Utils.Extensions
{
    public static class DiagnosticHelper
    {
        public static double MeasureExecutionMilliseconds(Action action)
        {
            var stopwatch = MeasureExecution(action);
            return stopwatch.ElapsedMilliseconds;
        }
        
        public static double MeasureExecutionTicks(Action action)
        {
            var stopwatch = MeasureExecution(action);
            return stopwatch.ElapsedTicks;
        }
        
        public static async Task<double> MeasureAsyncExecutionMilliseconds(Task task)
        {
            var stopwatch = await MeasureAsyncExecution(task);
            return stopwatch.ElapsedMilliseconds;
        }
        
        public static async Task<double> MeasureAsyncExecutionTicks(Task task)
        {
            var stopwatch = await MeasureAsyncExecution(task);
            return stopwatch.ElapsedTicks;
        }
        
        public static async Task<double> MeasureCoroutineExecutionMilliseconds(IEnumerator coroutine)
        {
            var stopwatch = await MeasureCoroutineExecution(coroutine);
            return stopwatch.ElapsedMilliseconds;
        }
        
        public static async Task<double> MeasureCoroutineExecutionTicks(IEnumerator coroutine)
        {
            var stopwatch = await MeasureCoroutineExecution(coroutine);
            return stopwatch.ElapsedTicks;
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