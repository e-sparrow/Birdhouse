using System;

namespace Birdhouse.Tools.Strings.Abstractions
{
    public interface ITagPreprocessor
    {
        IDisposable RegisterTag(string name, ITag tag);

        string Process(string input);
    }
}