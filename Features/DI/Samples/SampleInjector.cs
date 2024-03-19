using Birdhouse.Features.DI.Interfaces;
using Birdhouse.Features.DI.Unity;

namespace Birdhouse.Features.DI.Samples
{
    public class SampleInjector
        : MonoInjectorBase
    {
        protected override IContainer GetContainer()
        {
            throw new System.NotImplementedException();
        }

        public override void Install(IContainer container)
        {
            throw new System.NotImplementedException();
        }
    }
}