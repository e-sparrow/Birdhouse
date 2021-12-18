using System;

namespace ESparrow.Utils.Tools.DateAndTime.Pendulums
{
    public interface IPendulum
    {
        /// <summary>
        /// Executes when specified time is passed tick is performed.
        /// </summary>
        event Action OnTickPerformed;

        /// <summary>
        /// Period of ticks.
        /// </summary>
        TimeSpan Period
        {
            get;
        }
    }
}
