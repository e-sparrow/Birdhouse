using System;
using ESparrow.Utils.Tools.DateAndTime.Expiration.Interfaces;

namespace ESparrow.Utils.Tools.DateAndTime.Expiration
{
    // TODO:
    public abstract class TermControllerBase : ITermController
    {
        protected TermControllerBase(DateTime expiration)
        {
            _expiration = expiration;
        }
        
        public event Action OnExpired = () => { };

        private readonly DateTime _expiration;
    }
}