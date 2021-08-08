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
            return vectors.Select(value => (Vector4)value).Sum();
        }

        public static Vector2 Sum(this IEnumerable<Vector2> vectors)
        {
            return vectors.Select(value => (Vector4)value).Sum();
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

        public static float DistanceTo(this Vector2 self, Vector2 other)
        {
            return Vector2.Distance(self, other);
        }

        public static float DistanceTo(this Vector3 self, Vector3 other)
        {
            return Vector3.Distance(self, other);
        }

        public static float DistanceTo(this Vector4 self, Vector4 other)
        {
            return Vector4.Distance(self, other);
        }

        public static float DistanceTo(this Vector2Int self, Vector2Int other)
        {
            return Vector2Int.Distance(self, other);
        }

        public static float DistanceTo(this Vector3Int self, Vector3Int other)
        {
            return Vector3Int.Distance(self, other);
        }

        public static float TargetAngle(this Vector2 self, Vector2 to)
        {
            var atan = Mathf.Atan2(-self.y + to.y, -self.x + to.x);
            var angle = -atan * Mathf.Rad2Deg + 90.0f;

            return angle;
        }
    }
}