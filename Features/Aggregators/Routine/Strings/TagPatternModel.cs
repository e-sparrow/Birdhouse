namespace Birdhouse.Features.Aggregators.Routine.Strings
{
    public readonly struct TagPatternModel
    {
        public TagPatternModel(TagBracketModel startsWith, TagBracketModel endsWith)
        {
            StartsWith = startsWith;
            EndsWith = endsWith;
        }

        public TagBracketModel StartsWith
        {
            get;
        }
        
        public TagBracketModel EndsWith
        {
            get;
        }
    }
}