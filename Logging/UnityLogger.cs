using UnityEngine;
using ESparrow.Utils.Logging.Interfaces;
using ILogger = ESparrow.Utils.Logging.Interfaces.ILogger;

namespace ESparrow.Utils.Logging
{
    public class UnityLogger : IUnityLogger, ILogger
    {
        public void LogMessage(string message, Object context)
        {
            Debug.Log(message, context);
        }

        public void LogError(string message, Object context)
        {
            Debug.LogError(message, context);
        }

        public void LogWarning(string message, Object context)
        {
            Debug.LogWarning(message, context);
        }

        public void LogMessage(string message)
        {
            Debug.Log(message);
        }

        public void LogError(string message)
        {
            Debug.LogError(message);
        }

        public void LogWarning(string message)
        {
            Debug.LogWarning(message);
        }
    }
}
