using Random = System.Random;

namespace Birdhouse.Features.Errors
{
    public static class ErrorProviderFactory
    {
        public static IErrorProvider Create(ErrorProviderSettings settings, Random random = null) 
            => settings.Type switch
        {
            EErrorProvider.Uniform => new UniformErrorProvider(random),
            EErrorProvider.Normal => new NormalErrorProvider(settings.Sigma, random),
            EErrorProvider.Triangle => new TriangleErrorProvider(settings.Peak, random),
            EErrorProvider.Exponential => new ExponentialErrorProvider(settings.Lambda, random),
            EErrorProvider.Custom => new CustomErrorProvider(settings.Curve, random),
            _ => new UniformErrorProvider(random)
        };
    }
}