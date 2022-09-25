using System;

namespace Birdhouse.Tools.Logging
{
    public class Logger : LoggerBase
    {
        protected override Exception GetException(string message)
        {
            return new Exception(message);
        }
    }
}