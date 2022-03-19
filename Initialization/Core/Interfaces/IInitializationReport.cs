using System;

namespace ESparrow.ZenjectUtils.Initialization.Core.Interfaces
{
    public interface IInitializationReport
    {
        string GetInitializationStartReport();
        string GetInitializationEndReport(TimeSpan elapsedTime);
    }
    
    public interface IInitializationReport<in T>
    {
        string GetInitializationStartReport(T subject);
        string GetInitializationEndReport(T subject, TimeSpan elapsedTime);
    }

    public interface IInitializationReport<in T1, in T2>
    {
        string GetInitializationStartReport(T1 subject1, T2 subject2);
        string GetInitializationEndReport(T1 subject1, T2 subject2, TimeSpan elapsedTime);
    }
}