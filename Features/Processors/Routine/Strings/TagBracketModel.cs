namespace Birdhouse.Features.Processors.Routine.Strings
{
    public readonly struct TagBracketModel
    {
        public TagBracketModel(string startsWith, string endsWith)
        {
            StartsWith = startsWith;
            EndsWith = endsWith;
        }

        public string StartsWith
        {
            get;
        }

        public string EndsWith
        {
            get;
        }
    }
}