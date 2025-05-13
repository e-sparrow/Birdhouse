using System.Collections.Generic;

namespace Birdhouse.Tools.Strings.Abstractions
{
    public interface ITag
    {
        string Process(string input, IDictionary<string, string> parameters = null);
    }
}