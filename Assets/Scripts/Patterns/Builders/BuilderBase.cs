using System;
using ESparrow.Utils.Patterns.Builders.Interfaces;

namespace ESparrow.Utils.Patterns.Builders
{
    public abstract class BuilderBase<T> : IBuilder<T>
    {
        protected BuilderBase(T value)
        {
            Value = value;
        }

        protected BuilderBase(Func<T> constructor) : this(constructor.Invoke())
        {
            
        }

        public T Build()
        {
            return Value;
        }

        protected T Value
        {
            get;
        }
    }
}