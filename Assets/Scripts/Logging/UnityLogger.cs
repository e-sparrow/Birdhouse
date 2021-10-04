using UnityEngine;
using ILogger = ESparrow.Utils.Logging.Interfaces.ILogger;

namespace ESparrow.Utils.Logging
{
    public class UnityLogger : ILogger
    {
        public void Log(string message)
        {
            Debug.Log(message);
        }

        public void ThrowError(string message)
        {
            Debug.LogError(message);
        }

        public void ThrowWarning(string message)
        {
            Debug.LogWarning(message);
        }
    }
}
