using System;

namespace Birdhouse.Features.DI.Interfaces
{
    public interface IContainer
    {
        IDisposable RegisterInjectable<T>(Injectable<T> injectable);
        
        IResolver<TResult> GetResolver<TResult>();
        IResolver<TResult, TParameter> GetResolver<TResult, TParameter>(TParameter parameter);
    }
}