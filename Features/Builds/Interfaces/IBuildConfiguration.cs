namespace Birdhouse.Features.BuildConfiguration.Interfaces
{
    public interface IBuildConfiguration
    {
        void Build();
        
        string Name
        {
            get;
        }
    }
}