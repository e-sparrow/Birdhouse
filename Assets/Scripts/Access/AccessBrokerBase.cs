using ESparrow.Utils.Access.Interfaces;

namespace ESparrow.Utils.Access
{
    public abstract class AccessBrokerBase<T> : IAccessBroker<T>
    {
        protected AccessBrokerBase(Getter<T> getter, Setter<T> setter)
        {
            _getter = getter;
            _setter = setter;
        }

        private readonly Getter<T> _getter;
        private readonly Setter<T> _setter;

        public void Set(T value)
        {
            _setter.Invoke(value);
        }

        public T Get()
        {
            return _getter.Invoke();
        }
    }
}