using System;

namespace Birdhouse.Tools.Updatables.Abstractions
{
    public interface IUpdatableValue<T>
        : IUpdatableValueWriter<T>, IReadOnlyUpdatableValue<T>
    {
        
    }

    public interface IUpdatableValueWriter<in T>
    {
        void Update(T value);
    }
    
    public interface IReadOnlyUpdatableValue<out T>
    {
        event Action<T> OnUpdate;

        T Value
        {
            get;
        }
    }
}