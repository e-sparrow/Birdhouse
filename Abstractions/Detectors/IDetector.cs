using System;
using System.Collections.Generic;

namespace Birdhouse.Abstractions.Detectors
{
    public interface IDetector<T> 
        : IDisposable
    {
        IDisposable RegisterBanValue(T value);
        IDisposable RegisterBanRule(Predicate<T> rule);
        
        IDisposable RegisterExceptionValue(T value);
        IDisposable RegisterExceptionRule(Predicate<T> rule);
        
        bool TryDetect(out IEnumerable<T> output);
    }
}