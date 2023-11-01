using System;
using System.Collections.Generic;
using Birdhouse.Abstractions.Disposables.Interfaces;

namespace Birdhouse.Abstractions.Disposables
{
    public class CompositeDisposable 
        : ICompositeDisposable
    {
        public CompositeDisposable(ICollection<IDisposable> disposables)
        {
            _disposables = disposables;
        }

        private readonly ICollection<IDisposable> _disposables;

        public ICompositeDisposable Append(IDisposable other)
        {
            _disposables.Add(other);
            return this;
        }

        public void Dispose()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}