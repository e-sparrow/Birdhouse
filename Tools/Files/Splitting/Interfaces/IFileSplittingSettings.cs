using System;

namespace Birdhouse.Tools.Files.Splitting.Interfaces
{
    public interface IFileSplittingSettings
    {
        string Path
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