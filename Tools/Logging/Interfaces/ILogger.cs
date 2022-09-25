using Birdhouse.Tools.Logging.Enums;

namespace Birdhouse.Tools.Logging.Interfaces
{
    public interface ILogger
    {
        void Log(string message, ELogType type);
    }
}