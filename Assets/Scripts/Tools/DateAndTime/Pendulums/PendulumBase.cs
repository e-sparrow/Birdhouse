using System;

namespace ESparrow.Utils.Tools.DateAndTime.Pendulums
{
    public abstract class PendulumBase : IPendulum
    {
        protected PendulumBase(TimeSpan period)
        {
            Period = period;
        }
        
        public event Action OnTickPerformed = () => { };

        protected void Tick()
        {
            OnTickPerformed.Invoke();
        }

        public TimeSpan Period
        {
            get;
        }
    }
}