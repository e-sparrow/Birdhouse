namespace Birdhouse.Features.Builds.Interfaces
{
    public interface IBuildMachine<in TPlatform, in TKey>
    {
        void Build(TPlatform platform, TKey key);
    }
}