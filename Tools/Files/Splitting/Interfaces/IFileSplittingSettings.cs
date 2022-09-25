using System;

namespace Birdhouse.Tools.Files.Splitting.Interfaces
{
    public interface IFileSplittingSettings
    {
        string Directory
        {
            get;
        }

        string FileName
        {
            get;
        }

        Func<int, string> NamingMethod
        {
            get;
        }

        int MaxFileSize
        {
            get;
        }
    }
}