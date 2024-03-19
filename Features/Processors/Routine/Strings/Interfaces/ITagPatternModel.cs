using System.Collections.Generic;

namespace Birdhouse.Features.Processors.Routine.Strings.Interfaces
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