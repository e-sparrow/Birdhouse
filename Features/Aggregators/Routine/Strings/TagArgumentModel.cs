namespace Birdhouse.Features.Aggregators.Routine.Strings
{
    public readonly struct TagArgumentModel
    {
        public TagArgumentModel(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
        }
    }
}