using System;

namespace Birdhouse.Abstractions.Initializables
{
    public class AlreadyInitializedException 
        : Exception
    {
        public AlreadyInitializedException(object target)
        {
            Target = target;
        }

        public AlreadyInitializedException(object target, string message)
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