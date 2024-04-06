using System;
using Birdhouse.Abstractions.Builders.Abstractions;

namespace Birdhouse.Features.Registries.Interfaces
{
    public interface IFluentRegistrationBuilder<in TIn>
        : IBuilder<IFluentRegistrationBuilder<TIn>, IDisposable>
    {
        IFluentRegistrationBuilder<TIn> RegisterAndAppend(TIn input);
    }
}