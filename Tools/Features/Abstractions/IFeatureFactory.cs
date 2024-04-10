using System;

namespace Birdhouse.Tools.Features.Abstractions
{
    public interface IFeatureFactory
        : IFeatureContainer, IDisposable
    {
        IDisposable RegisterParameter(Type type, object parameter);
    }
}