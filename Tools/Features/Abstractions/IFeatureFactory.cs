using System;

namespace Birdhouse.Tools.Features.Abstractions
{
    public interface IFeatureFactory<out TResult>
        : IFeatureContainer, IDisposable
    {
        TResult Register(Type type, Func<object> value);
    }

    public interface IFeatureFactory
        : IFeatureFactory<IDisposable>
    {
        
    }
}