using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Mathematics;

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

        public T[] GetNeighbours(T element)
        {
            return GetNeighbours(IndexOf(element));
        }

        public T[] GetNeighbours(Vector3Int index)
        {
            var neighbours = _list.Where(value => (value.index - index).magnitude == 1);
            return neighbours.Select(value => value.value).ToArray();
        }

        public T[] GetNeighbours(Vector2Int index)
        {
            return GetNeighboursWhere(index, _ => true);
        }

        public T[] GetNeighboursWhere(T element, Func<T, bool> func)
        {
            return GetNeighboursWhere(IndexOf(element), func);
        }

        public T[] GetNeighboursWhere2D(T element, Func<T, bool> func)
        {
            return GetNeighboursWhere(IndexOf(element).ToVector2Int(), func);
        }

        public T[] GetNeighboursWhere(Vector3Int index, Func<T, bool> func)
        {
            var array = Direction.directions.Select(value => value.vector.ToVector3Int()).ToArray();
            return GetNeighboursInWhere(index, array, func);
        }

        public T[] GetNeighboursWhere(Vector2Int index, Func<T, bool> func)
        {
            var array = Direction.directions2d.Select(value => value.vector.ToVector3Int()).ToArray();
            return GetNeighboursInWhere(index.ToVector3Int(), array, func);
        }

        public T[] GetNeighboursGroupWhere(Vector3Int index, Func<T, bool> func, T[] except = null)
        {
            return GetNeighboursGroupWhereIn(index, GetNeighbours, func, except);
        }

        public T[] GetNeighboursGroupWhere(Vector2Int index, Func<T, bool> func, T[] except = null)
        {
            return GetNeighboursGroupWhereIn(index.ToVector3Int(), GetNeighbours, func, except);
        }

        public T[] GetNeighboursGroupWhere(T element, Func<T, bool> func, T[] except = null)
        {
            return GetNeighboursGroupWhere(IndexOf(element), func, except);
        }

        public T[] GetNeighboursGroup(T element)
        {
            return GetNeighboursGroup(IndexOf(element));
        }

        public T[] GetNeighboursGroup(Vector3Int index)
        {
            return GetNeighboursGroupWhere(index, value => true);
        }

        public T[] GetNeighboursGroup(Vector2Int index)
        {
            return GetNeighboursGroup(index.ToVector3Int());
        }

        public Vector3Int Delta(T first, T second)
        {
            return IndexOf(second) - IndexOf(first);
        }

        public float DistanceBetween(T first, T second)
        {
            return Delta(first, second).magnitude;
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

        private T[] GetNeighboursInWhere(Vector3Int index, Vector3Int[] directions, Func<T, bool> func)
        {
            var list = new List<T>();

            foreach (var direction in directions)
            {
                if (Check(direction, out var element))
                {
                    list.Add(element);
                }
            }

            return list.ToArray();

            bool Check(Vector3Int direction, out T element)
            {
                element = this[index + direction];
                return !element.Equals(default) && func.Invoke(element);
            }
        }

        private T[] GetNeighboursGroupWhereIn(Vector3Int index, Func<Vector3Int, T[]> getNeighbours, Func<T, bool> func, T[] except = null)
        {
            if (except == null) except = new T[0];

            var neighbours = getNeighbours.Invoke(index).Except(except);
            neighbours = neighbours.Where(func);

            var exceptArray = neighbours.Concat(except).ToArray();
            var selectMany = neighbours.SelectMany(value => GetNeighboursGroupWhere(value, func, exceptArray));
            var concat = neighbours.Concat(selectMany);
            var array = concat.ToArray();

            return array;
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
