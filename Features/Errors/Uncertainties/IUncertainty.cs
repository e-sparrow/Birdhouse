namespace Birdhouse.Features.Errors
{
    public interface IUncertainty<out T>
    {
        T Perturb();
    }
}