using System;
using ESparrow.Utils.Exceptions;
using ESparrow.Utils.Tools.Tense.Expiration.Enums;
using ESparrow.Utils.Tools.Tense.Expiration.Interfaces;

namespace ESparrow.Utils.Tools.Tense.Expiration
{
    public abstract class TermBase : ITerm
    {
        protected TermBase(ITermInfo info)
        {
            _info = info;
        }

        protected TermBase(ITermInfo info, DateTime lastRequestDate) : this(info)
        {
            _lastRequestDate = lastRequestDate;
        }
        
        private readonly ITermInfo _info;

        private DateTime _lastRequestDate;

        protected abstract DateTime GetCurrentDate();

        public void Initialize()
        {
            _lastRequestDate = GetCurrentDate();
        }
        
        public bool Check()
        {
            var now = GetCurrentDate();

            switch (_info.Type)
            {
                case ETermType.AbsoluteExpiration:
                    return AbsoluteExpired(now);
                case ETermType.SlidingExpiration:
                    return SlidingExpired(now);
                case ETermType.Combined:
                    return AbsoluteExpired(now) || SlidingExpired(now);
                case ETermType.Eternal:
                    return false;
                default:
                    throw new WtfException("Unknown term type!", this);
            }
        }

        private bool AbsoluteExpired(DateTime now)
        {
            return now >= _info.AbsoluteExpiration;
        }
        
        private bool SlidingExpired(DateTime now)
        {
            bool isExpired = _lastRequestDate.Add(_info.SlidingExpiration) <= now;
            if (!isExpired)
            {
                _lastRequestDate = now;
            }

            return isExpired;
        }

        public DateTime LastRequestDate => _lastRequestDate;
        
        public bool IsEternal => _info.Type == ETermType.Eternal;
    }
}