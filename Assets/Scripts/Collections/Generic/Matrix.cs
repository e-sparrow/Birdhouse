using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace ESparrow.Utils.Collections.Generic
{
    public class Matrix<T> : StandardEnumerable<T>
    {
        protected override T[] Array => List.Select(value => value.value).ToArray();

        private readonly List<Element> _list = new List<Element>();
        protected virtual List<Element> List => _list;

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
            get => this[(Vector3Int) index];
            set => this[(Vector3Int) index] = value;
        }

        public T this[int x, int y, int z = 0]
        {
            get => this[new Vector3Int(x, y, z)];
            set => this[new Vector3Int(x, y, z)] = value;
        }

        public Matrix()
        {

        }

        public void Clear()
        {
            _list.Clear();
        }

        public void Fill(Vector3Int from, Vector3Int to, Func<Vector3Int, T> func)
        {
            for (int x = from.x; x != to.x; x += Math.Sign(to.x - from.x))
            {
                for (int y = from.y; y != to.y; y += Math.Sign(to.y - from.y))
                {
                    for (int z = from.z; z != to.z; z += Math.Sign(to.z - from.z))
                    {
                        var index = new Vector3Int(x, y, z);
                        this[index] = func.Invoke(index);
                    }
                }
            }
        }

        public T[] GetNeighboursGroupWhere(T element, Func<T, bool> func, T[] except = null)
        {
            return GetNeighboursGroupWhere(IndexOf(element), func, except);
        }

        public T[] GetNeighboursGroupWhere(Vector3Int index, Func<T, bool> func, T[] except = null)
        {
            if (except == null) except = new T[0];

            var neighbours = GetNeighboursGroup(index).Where(func).Except(except);
            var without = neighbours.Concat(except).ToArray();
            var groups = neighbours.SelectMany(value => GetNeighboursGroupWhere(value, func, without));
            var array = neighbours.Concat(groups).ToArray();

            return array;
        }

        public T[] GetNeighboursGroup(T element)
        {
            return GetNeighboursGroup(IndexOf(element));
        }

        public T[] GetNeighboursGroup(Vector3Int index)
        {
            return GetNeighboursGroupWhere(index, value => true);
        }

        public T[] GetNeighbours(T element)
        {
            return GetNeighbours(IndexOf(element));
        }

        public T[] GetNeighbours(Vector3Int index)
        {
            var neighbours = _list.Where(value => (value.index - index).magnitude == 1);
            return neighbours.Select(value => value.value).ToArray();
        }

        public Vector3Int IndexOf(T element)
        {
            var first = List.FirstOrDefault(value => value.value.Equals(element));
            if (first != null)
            {
                return List.FirstOrDefault(value => value.value.Equals(element)).index;
            }
            else
            {
                return default;
            }
        }

        public void Remove(T element)
        {
            List.Remove(List.FirstOrDefault(value => value.value.Equals(element)));
        }

        public void Remove(Vector3Int index)
        {
            var removeElement = List.FirstOrDefault(value => value.index == index);
            int removeIndex = List.IndexOf(removeElement);

            List.RemoveAt(removeIndex);
        }

        public void Remove(Vector2Int index)
        {
            Remove((Vector3Int)index);
        }

        private Element Get(Vector3Int index)
        {
            return List.FirstOrDefault(value => value.index == index);
        }

        private void Set(Vector3Int index, T value)
        {
            var first = List.FirstOrDefault(value => value.index == index);
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

            List.Add(element);
        }

        protected class Element
        {
            public T value;
            public Vector3Int index;
        }
    }
}
