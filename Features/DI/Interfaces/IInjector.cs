namespace Birdhouse.Features.DI.Interfaces
{
    public interface IInjector
    {
        void Install(IContainer container);
    }

    public interface IInjector<in TIn>
    {
        void Install(IContainer container, TIn argument);
    }
}