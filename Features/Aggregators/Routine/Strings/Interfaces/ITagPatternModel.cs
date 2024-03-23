using System.Collections.Generic;

namespace Birdhouse.Features.Aggregators.Routine.Strings.Interfaces
{
    public interface ITagPatternModel
    {
        TagBracketModel StartsWith
        {
            get;
        }
        
        TagBracketModel EndsWith
        {
            get;
        }
        
        bool TryParseArguments(string startBracket, string endBracket, out IDictionary<string, string> result);
    }
}