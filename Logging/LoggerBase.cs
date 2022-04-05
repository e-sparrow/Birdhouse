using System;
using ESparrow.Utils.Logging.Enums;
using UnityEngine;
using ILogger = ESparrow.Utils.Logging.Interfaces.ILogger;

namespace ESparrow.Utils.Logging
{
    public abstract class LoggerBase : ILogger
    {
        protected abstract Exception GetException(string message);
        
        public void Log(string message, ELogType type)
        {
            switch (type)
            {
                case ELogType.Message:
                    Debug.Log(message);
                    break;
                case ELogType.Warning:
                    Debug.LogWarning(message);
                    break;
                case ELogType.Error:
                    Debug.LogError(message);
                    break;
                case ELogType.Exception:
                    Debug.LogException(GetException(message));
                    break;
            }
        }
    }
}   