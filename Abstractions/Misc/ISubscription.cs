using System;

namespace Birdhouse.Abstractions.Misc
{
    public interface ISubscription
    {
        IDisposable Subscribe();
    }
    
    public interface ISubscription<in TIn>
    {
        IDisposable Subscribe(TIn input);
    }
}