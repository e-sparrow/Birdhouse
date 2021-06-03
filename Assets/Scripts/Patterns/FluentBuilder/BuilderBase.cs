using System;

namespace ESparrow.Utils.Patterns.FluentBuilder
{
    /// <summary>
    ///  ласс, позвол€ющий упростить инициализацию комплексных классов, не использу€ огромные конструкторы.
    /// </summary>
    public abstract class BuilderBase<T> where T : new()
    {
        protected virtual event Action OnBuilderCreated;
        protected virtual event Action<T> OnInstanceBuilded;

        protected T _instance;

        public BuilderBase()
        {
            _instance = new T();

            OnBuilderCreated?.Invoke();
        }

        public T Build()
        {
            OnInstanceBuilded?.Invoke(_instance);

            return _instance;
        }
    }
}
