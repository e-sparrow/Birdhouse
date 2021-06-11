using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace ESparrow.Utils.Collections.Generic
{
    public class Matrix<T> : StandardEnumerable<T>
    {
        protected override T[] Array => _list.Select(value => value.value).ToArray();

        private readonly List<Element> _list = new List<Element>();

        public T this[Vector3Int index]
        {
            get
            {
                var get = Get(index);
                if (get != null)
                {
                    return get.value;
                }

                return default;
            }

            set => Set(index, value);
        }

        public T this[Vector2Int index]
        {
            get => this[(Vector3Int)index];
            set => this[(Vector3Int)index] = value;
        }

        public T this[int x, int y, int z = 0]
        {
            get => this[new Vector3Int(x, y, z)];
            set => this[new Vector3Int(x, y, z)] = value;
        }

        public Matrix()
        {

        }

        public Vector3Int IndexOf(T element)
        {
            return _list.FirstOrDefault(value => value.value.Equals(element)).index;
        }

        public void Remove(Vector3Int index)
        {
            var removeElement = _list.FirstOrDefault(value => value.index == index);
            int removeIndex = _list.IndexOf(removeElement);

            _list.RemoveAt(removeIndex);
        }

        public void Remove(Vector2Int index)
        {
            Remove((Vector3Int)index);
        }

        private Element Get(Vector3Int index)
        {
            return _list.FirstOrDefault(value => value.index == index);
        }

        private void Set(Vector3Int index, T value)
        {
            var first = _list.FirstOrDefault(value => value.index == index);
            if (first != null)
            {
                first.value = value;
            }
            else
            {
                Create(index, value);
            }
        }

        private void Create(Vector3Int index, T value)
        {
            var element = new Element();

            element.index = index;
            element.value = value;

            _list.Add(element);
        }

        private class Element
        {
            public T value;
            public Vector3Int index;
        }
    }
}