using System;
using Birdhouse.Tools.Files.Splitting.Interfaces;

namespace Birdhouse.Tools.Files.Splitting
{
    public readonly struct FileSplittingSettings : IFileSplittingSettings
    {
        public FileSplittingSettings(string path, Func<int, string> namingMethod, int maxFileSize)
        {
            Path = path;
            NamingMethod = namingMethod;
            MaxFileSize = maxFileSize;
        }

        public string Path
        {
            get;
        }

        public Func<int, string> NamingMethod
        {
            get;
        }

        public int MaxFileSize
        {
            get;
        }
    }
}