using System;

namespace Birdhouse.Tools.Strings.Abstractions
{
    public interface IWriteOnlyTagProcessor
    {
        IDisposable RegisterTag(string name, ITag tag);
    }
}