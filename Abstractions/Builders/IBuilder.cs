﻿namespace Birdhouse.Abstractions.Builders
{
    public interface IBuilder<out TSelf, out TResult>
        : IBuilder<TResult>
        where TSelf : IBuilder<TSelf, TResult>
    {
        
    }

    public interface IBuilder<out TResult>
    {
        TResult Build();
    }
}