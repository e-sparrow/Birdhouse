namespace ESparrow.Utils.Logging.Interfaces
{
    public interface ILogger
    {
        void Log(string message);
        void ThrowWarning(string message);
        void ThrowError(string message);
    }
}
