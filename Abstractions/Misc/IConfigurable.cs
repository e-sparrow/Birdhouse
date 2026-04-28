namespace Birdhouse.Abstractions.Misc
{
    public interface IConfigurable<in TConfiguration>
    {
        void Configure(TConfiguration configuration);
    }
}