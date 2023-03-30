using System;

namespace Birdhouse.Common.Reflection.Generators.Interfaces
{
    public interface IGenerator
    {
        bool TryGenerate(Type type, out object result);
    }
}