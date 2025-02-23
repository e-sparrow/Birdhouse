using Birdhouse.Tools.Updatables.Abstractions;

namespace Birdhouse.Tools.Updatables
{
    public sealed class UpdatableValue<T>
        : UpdatableValueBase<T>
    {
        public UpdatableValue(T value) 
            : base(value)
        {
            
        }
    }
}