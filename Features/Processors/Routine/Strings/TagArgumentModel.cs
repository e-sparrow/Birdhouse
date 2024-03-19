namespace Birdhouse.Features.Processors.Routine.Strings
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