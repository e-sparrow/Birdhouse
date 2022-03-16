using System;
using System.Collections;

namespace ESparrow.Utils.Collections.Generic
{
    public abstract class StandardEnumerable : IEnumerable
    {
        protected abstract Array Array
        {
            get;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(Array);
        }

        private class Enumerator : IEnumerator
        {
            private readonly Array _array;

            private int _current = -1;

            public Enumerator(Array array)
            {
                _array = array;
            }

            object IEnumerator.Current => _array.GetValue(_current);

            bool IEnumerator.MoveNext()
            {
                if (_current < _array.Length - 1)
                {
                    _current++;
                    return true;
                }
                else
                    return false;
            }

            void IEnumerator.Reset()
            {
                _current = -1;
            }
        }
    }
}
