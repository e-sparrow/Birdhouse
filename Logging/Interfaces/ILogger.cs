using ESparrow.Utils.Logging.Enums;

namespace ESparrow.Utils.Logging.Interfaces
{
    public interface ILogger
    {
        void Log(string message, ELogType type);
    }
}