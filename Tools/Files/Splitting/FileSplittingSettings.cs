using System;
using Birdhouse.Tools.Files.Splitting.Interfaces;

namespace Birdhouse.Tools.Files.Splitting
{
    public readonly struct FileSplittingSettings : IFileSplittingSettings
    {
        public FileSplittingSettings(string directory, string fileName, Func<int, string> namingMethod, int maxFileSize)
        {
            Directory = directory;
            FileName = fileName;
            NamingMethod = namingMethod;
            MaxFileSize = maxFileSize;
        }

        public string Directory
        {
            get;
        }

        public string FileName
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