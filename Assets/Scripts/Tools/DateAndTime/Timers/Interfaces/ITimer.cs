using System;

namespace ESparrow.Utils.Tools.DateAndTime.Timers.Interfaces
{
    public interface ITimer
    {
        event Action OnTimerStopped;
        
        event Action<TimeSpan> OnTimerTicked;
        event Action<TimeSpan> OnTimerPaused;
        
        void Start();
        void Pause();
        void Stop();
        
        TimeSpan TimeLeft
        {
            get;
        }
    }
}