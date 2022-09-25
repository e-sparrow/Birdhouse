using System;
using Birdhouse.Tools.Tense.Expiration.Interfaces;

namespace Birdhouse.Tools.Tense.Expiration
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