using System.Collections.Generic;
using UnityEngine;

namespace ESparrow.Utils.Extensions
{
    public static class VectorExtensions
    {
        public static Vector4 Sum(this IEnumerable<Vector4> vectors)
        {
            var sum = Vector4.zero;

            foreach (var vector in vectors)
            {
                sum += vector;
            }

            return sum;
        }

        public static Vector3 Sum(this IEnumerable<Vector3> vectors)
        {
            var sum = Vector3.zero;

            foreach (var vector in vectors)
            {
                sum += vector;
            }

            return sum;
        }

        public static Vector2 Sum(this IEnumerable<Vector2> vectors)
        {
            var sum = Vector2.zero;

            foreach (var vector in vectors)
            {
                sum += vector;
            }

            return sum;
        }

        public static Vector3Int Sum(this IEnumerable<Vector3Int> vectors)
        {
            var sum = Vector3Int.zero;

            foreach (var vector in vectors)
            {
                sum += vector;
            }

            return sum;
        }

        public static Vector2Int Sum(this IEnumerable<Vector2Int> vectors)
        {
            var sum = Vector2Int.zero;

            foreach (var vector in vectors)
            {
                sum += vector;
            }

            return sum;
        }
    }
}
