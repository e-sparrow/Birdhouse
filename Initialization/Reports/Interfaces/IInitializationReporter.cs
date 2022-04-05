using ESparrow.Utils.Initialization.Reports.Enums;

namespace ESparrow.Utils.Initialization.Reports.Interfaces
{
    public interface IInitializationReporter
    {
        public void Report(EInitializationReportType type);
    }
}