using System;
using Birdhouse.Features.DI.Interfaces;

namespace Birdhouse.Features.DI
{
    public abstract class ContainerBase
        : IContainer
    {
        public IDisposable RegisterInjectable<T>(Injectable<T> injectable)
        {
            throw new NotImplementedException();
        }

        public IResolver<TResult> GetResolver<TResult>()
        {
            throw new System.NotImplementedException();
        }

        public IResolver<TResult, TParameter> GetResolver<TResult, TParameter>(TParameter parameter)
        {
            throw new System.NotImplementedException();
        }
    }
}