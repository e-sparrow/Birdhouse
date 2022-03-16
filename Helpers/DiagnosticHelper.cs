using System;
using System.Diagnostics;

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

        private static Stopwatch MeasureExecution(Action action)
        {
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            action.Invoke();
            stopwatch.Stop();

            return stopwatch;
        }
    }
}