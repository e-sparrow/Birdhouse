using System;

namespace ESparrow.Utils.Tools.Easing.Interfaces
{
    public interface IEaseApplier<out T>
    {
        event Action<T> OnValueChanged;
    }
}