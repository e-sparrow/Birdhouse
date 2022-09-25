using System;

namespace Birdhouse.Tools.Easing.Interfaces
{
    public interface IEaseApplier<out T>
    {
        event Action<T> OnValueChanged;
    }
}