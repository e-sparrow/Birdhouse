using System.Linq;
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
            return vectors.Select(value => (Vector4) value).Sum();
        }

        public static Vector2 Sum(this IEnumerable<Vector2> vectors)
        {
            return vectors.Select(value => (Vector4) value).Sum();
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

        public static float ScalarProduct(this IEnumerable<Vector4> vectors)
        {
            var product = vectors.Aggregate((left, right) => left.Product(right));

            return product.x + product.y + product.z + product.w;
        }

        public static Vector4 Product(this Vector4 left, Vector4 right)
        {
            float xProduct = left.x * right.x;
            float yProduct = left.y * right.y;
            float zProduct = left.z * right.z;
            float wProduct = left.w * right.w;

            return new Vector4(xProduct, yProduct, zProduct, wProduct);
        }
    }
}
