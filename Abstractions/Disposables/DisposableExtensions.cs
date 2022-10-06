using System;
using Birdhouse.Common.Extensions;

namespace Birdhouse.Abstractions.Disposables
{
    public static class DisposableExtensions
    {
        public static IDisposable Combine(this IDisposable self, IDisposable other)
        {
            var disposables = self.ConcatWith(other);
            
            var composite = new DisposableComposite(disposables);
            return composite;
        }
    }
}