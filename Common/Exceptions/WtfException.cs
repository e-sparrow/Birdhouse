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
            _target = target;
        }

        private readonly string _reason;
        private readonly object _target;

        public sealed override string Message => $"The worst thing that could happen - Wtf Exception thrown".WithColor(Color.red).Bold() + $"\nInfo:\n{_reason}. Target: {_target}";
    }
}
