namespace Birdhouse.Tools.Tense.Providers.Interfaces
{
    public interface ITenseProvider<out TTense>
    {
        TTense Now();
    }
}
