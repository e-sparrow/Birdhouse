using System;
using ESparrow.Utils.Tools.DateAndTime.Expiration.Interfaces;

namespace ESparrow.Utils.Tools.DateAndTime.Expiration
{
    public class Term : TermBase
    {
        public Term(ITermInfo info) 
            : base(info)
        {
            
        }

        public Term(ITermInfo info, Func<DateTime> getCurrentDate) 
            : this(info)
        {
            _getCurrentDate = getCurrentDate;
        }

        public Term(ITermInfo info, DateTime lastRequestDate) 
            : base(info, lastRequestDate)
        {
            
        }

        public Term(ITermInfo info, DateTime lastRequestDate, Func<DateTime> getCurrentDate)
            : this(info, lastRequestDate)
        {
            _getCurrentDate = getCurrentDate;
        }

        private readonly Func<DateTime> _getCurrentDate = () => DateTime.UtcNow;

        protected override DateTime GetCurrentDate()
        {
            return _getCurrentDate.Invoke();
        }
    }
}