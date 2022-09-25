using Birdhouse.Tools.Initialization.Reports.Enums;

namespace Birdhouse.Tools.Initialization.Reports.Interfaces
{
    public interface IInitializationReporter
    {
        public void Report(EInitializationReportType type);
    }
}