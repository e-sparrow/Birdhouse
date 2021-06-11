    using System;
    using System.Linq;
    using System.Collections.Generic;
    using UnityEngine;

    namespace ESparrow.Utils.Extensions
    {
        public static class VectorExtensions
        {
            public static Vector4 ModifyMatching(this Vector4 vector, Vector4 vectorToMatch, Func<float, float, float> func)
            {
                vector.x = func(vector.x, vectorToMatch.x);
                vector.y = func(vector.y, vectorToMatch.y);
                vector.z = func(vector.z, vectorToMatch.z);
                vector.w = func(vector.w, vectorToMatch.w);

                return vector;
            }

            public static Vector4 ModifyAllDimensions(this Vector4 vector, Func<float, float> func)
            {
                vector.x = func(vector.x);
                vector.y = func(vector.y);
                vector.z = func(vector.z);
                vector.w = func(vector.w);

                return vector;
            }

            public static Vector4 Multiply(this Vector4 vector, Vector4 multiplier)
            {
                return vector.ModifyMatching(multiplier, (left, right) => left * right);
            }

            public static Vector4 Divide(this Vector4 vector, Vector4 divider)
            {
                return vector.ModifyMatching(divider, (left, right) => left / right);
            }

            public static Vector4 Mod(this Vector4 vector, Vector4 mod)
            {
                return vector.ModifyMatching(mod, (left, right) => left % right);
            }

            public static Vector4 Mod(this Vector4 vector, float mod)
            {
                return vector.ModifyAllDimensions(value => value % mod);
            }

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
