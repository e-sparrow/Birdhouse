using UnityEngine;

namespace ESparrow.Utils.Logging.Interfaces
{
    public interface IUnityLogger
    {
        void LogMessage(string message, Object context);
        void LogWarning(string message, Object context);
        void LogError(string message, Object context);
    }
}
