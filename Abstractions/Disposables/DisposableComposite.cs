using System;
using System.Collections.Generic;

namespace Birdhouse.Abstractions.Disposables
{
    public class DisposableComposite : IDisposable
    {
        public DisposableComposite(IEnumerable<IDisposable> disposables)
        {
            _disposables = disposables;
        }

        private readonly IEnumerable<IDisposable> _disposables;

        public void Dispose()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}