using System;
using System.Collections.Generic;
using Birdhouse.Abstractions.Composites.Abstractions;

namespace Birdhouse.Abstractions.Disposables
{
    public class CompositeDisposable 
        : ICreatableComposite<CompositeDisposable, IDisposable>, IDisposable
    {
        public CompositeDisposable()
        {
            _disposables = new List<IDisposable>();
        }

        public CompositeDisposable(IEnumerable<IDisposable> disposables)
        {
            _disposables = new List<IDisposable>(disposables);
        }
        
        private readonly ICollection<IDisposable> _disposables;

        public CompositeDisposable Append(IDisposable other)
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