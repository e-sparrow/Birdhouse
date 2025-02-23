using System;
using Birdhouse.Tools.Updatables.Abstractions;

namespace Birdhouse.Tools.Updatables
{
    public sealed class ObservableUpdatableValueDecorator<T>
        : IUpdatableValue<T>
    {
        public ObservableUpdatableValueDecorator(IUpdatableValue<T> inner)
        {
            _inner = inner;
        }

        public event Action OnRequestValue = () => { };
        
        public event Action<T> OnUpdate = _ => { };
        
        private readonly IUpdatableValue<T> _inner;

        public T Value
        {
            get
            {
                var result = _inner.Value;
                OnRequestValue.Invoke();
                return result;
            }
        }
        
        public void Update(T value)
        {
            _inner.Update(value);
            OnUpdate.Invoke(value);
        }
    }
}