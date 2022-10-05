namespace Birdhouse.Tools.Tense.Controllers.Interfaces
{
    public interface ITenseProvider<out TTense>
    {
        TTense Now();
    }
}
