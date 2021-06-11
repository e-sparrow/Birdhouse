using System;
using System.Collections;
using System.Collections.Generic;

namespace ESparrow.Utils.Collections.Generic
{
    public abstract class StandardEnumerable<T> : IEnumerable<T>
    {
        protected abstract T[] Array
        {
            get;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator(Array);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(Array);
        }

        private class Enumerator : IEnumerator<T>
        {
            private readonly T[] _array;

            private int _current = -1;

            public Enumerator(T[] array)
            {
                _array = array;
            }

            T IEnumerator<T>.Current => _array[_current];

            object IEnumerator.Current => _array[_current];

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

            void IDisposable.Dispose()
            {

            }
        }
    }
}
