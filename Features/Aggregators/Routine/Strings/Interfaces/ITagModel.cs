using System.Collections.Generic;

namespace Birdhouse.Features.Aggregators.Routine.Strings.Interfaces
{
    public interface ITagModel
    {
        string Name
        {
            get;
        }

        IEnumerable<TagArgumentModel> Arguments
        {
            get;
        }

        string Process(string value, IDictionary<string, string> arguments);
    }
}