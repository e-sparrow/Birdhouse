using System;

namespace ESparrow.Utils.Logging
{
    public class Logger : LoggerBase
    {
        protected override Exception GetException(string message)
        {
            return new Exception(message);
        }
    }
}