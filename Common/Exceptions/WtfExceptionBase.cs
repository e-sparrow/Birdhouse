using System;
using Birdhouse.Common.Exceptions.Interfaces;
using Birdhouse.Common.Extensions;
using UnityEngine;

namespace Birdhouse.Common.Exceptions
{
    public abstract class WtfExceptionBase : Exception, IWtfException
    {
        protected WtfExceptionBase(string reason, object target)
        {
            Reason = reason;
            Target = target;
        }
        
        public sealed override string Message => $"The worst thing that could happen - Wtf Exception thrown".WithColor(Color.red).Bold() + $"\nInfo:\n{Reason}";
        
        public string Reason
        {
            get;
        }

        public object Target
        {
            get;
        }
    }
}
