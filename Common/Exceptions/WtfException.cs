using System;
using Birdhouse.Common.Extensions;
using UnityEngine;

namespace Birdhouse.Common.Exceptions
{
    public class WtfException : Exception
    {
        public WtfException(string reason, object target = null)
        {
            _reason = reason;
        }

        private readonly string _reason;
        
        public sealed override string Message => $"The worst thing that could happen - Wtf Exception thrown".WithColor(Color.red).Bold() + $"\nInfo:\n{_reason}";
    }
}
