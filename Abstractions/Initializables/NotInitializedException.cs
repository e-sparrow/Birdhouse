using System;

namespace Birdhouse.Abstractions.Initializables
{
    public class NotInitializedException
        : Exception
    {
        public NotInitializedException(object target)
        {
            Target = target;
        }

        public NotInitializedException(object target, string message)
        {
            Target = target;
            Message = message;
        }
        
        public object Target
        {
            get;
        }

        public override string Message
        {
            get;
        }
    }
}