using System;

namespace ESparrow.Utils.Tools
{
    public class Reference<T>
    {
        private readonly Func<T> _get;
        private readonly Action<T> _set;

        public T Value
        {
            get => _get.Invoke();
            set => _set.Invoke(value);
        }

        public Reference(Func<T> get, Action<T> set)
        {
            _get = get;
            _set = set;
        }
    }
}
