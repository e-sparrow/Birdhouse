using System;
using Birdhouse.Abstractions.Builders;

namespace Birdhouse.Collections.Registries.Abstractions
{
    public interface IFluentRegistrationBuilder<in TIn>
        : IBuilder<IFluentRegistrationBuilder<TIn>, IDisposable>
    {
        IFluentRegistrationBuilder<TIn> RegisterAndAppend(TIn input);
    }
}