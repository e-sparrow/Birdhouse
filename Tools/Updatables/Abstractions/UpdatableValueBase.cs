using System;

namespace Birdhouse.Tools.Updatables.Abstractions
{
    public abstract class UpdatableValueBase<T>
        : IUpdatableValue<T>
    {
        protected UpdatableValueBase(T value)
        {
            Value = value;
        }

        public event Action<T> OnUpdate = _ => { };

        public T Value
        {
            get;
            private set;
        }

        public void Update(T value)
        {
            Value = value;
            OnUpdate.Invoke(value);
        }
    }
}