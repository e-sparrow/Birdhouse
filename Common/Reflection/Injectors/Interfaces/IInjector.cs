using System;

namespace Birdhouse.Common.Reflection.Injectors.Interfaces
{
    public interface IInjector
    {
        bool TryInject(Type type, out object result);
    }
}