using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace ESparrow.Utils.Extensions
{
    public static class VectorExtensions
    {
        public static Vector2Int ModifyMatching(this Vector2Int vector, Vector2Int vectorToMatch, Func<int, int, int> func)
        {
            vector.x = func(vector.x, vectorToMatch.x);
            vector.y = func(vector.y, vectorToMatch.y);

            return vector;
        }

        public static Vector2Int ModifyMatching(this Vector2Int vector, Vector2Int left, Vector2Int right, Func<int, int, int, int> func)
        {
            vector.x = func(vector.x, left.x, right.x);
            vector.y = func(vector.y, left.y, right.y);

            return vector;
        }

        public static Vector2Int ModifyAllDimensions(this Vector2Int vector, Func<int, int> func)
        {
            vector.x = func(vector.x);
            vector.y = func(vector.y);

            return vector;
        }

        public static Vector3Int ModifyMatching(this Vector3Int vector, Vector3Int vectorToMatch, Func<int, int, int> func)
        {
            vector.x = func(vector.x, vectorToMatch.x);
            vector.y = func(vector.y, vectorToMatch.y);
            vector.z = func(vector.z, vectorToMatch.z);

            return vector;
        }

        public static Vector3Int ModifyMatching(this Vector3Int vector, Vector3Int left, Vector3Int right, Func<int, int, int, int> func)
        {
            vector.x = func(vector.x, left.x, right.x);
            vector.y = func(vector.y, left.y, right.y);
            vector.z = func(vector.z, left.z, right.z);

            return vector;
        }

        public static Vector3Int ModifyAllDimensions(this Vector3Int vector, Func<int, int> func)
        {
            vector.x = func(vector.x);
            vector.y = func(vector.y);
            vector.z = func(vector.z);

            return vector;
        }

        public static Vector2 ModifyMatching(this Vector2 vector, Vector2 vectorToMatch, Func<float, float, float> func)
        {
            vector.x = func(vector.x, vectorToMatch.x);
            vector.y = func(vector.y, vectorToMatch.y);

            return vector;
        }

        public static Vector2 ModifyMatching(this Vector2 vector, Vector2 left, Vector2 right, Func<float, float, float, float> func)
        {
            vector.x = func(vector.x, left.x, right.x);
            vector.y = func(vector.y, left.y, right.y);

            return vector;
        }

        public static Vector2 ModifyAllDimensions(this Vector2 vector, Func<float, float> func)
        {
            vector.x = func(vector.x);
            vector.y = func(vector.y);

            return vector;
        }

        public static Vector3 ModifyMatching(this Vector3 vector, Vector3 vectorToMatch, Func<float, float, float> func)
        {
            vector.x = func(vector.x, vectorToMatch.x);
            vector.y = func(vector.y, vectorToMatch.y);
            vector.z = func(vector.z, vectorToMatch.z);

            return vector;
        }

        public static Vector3 ModifyMatching(this Vector3 vector, Vector3 left, Vector3 right, Func<float, float, float, float> func)
        {
            vector.x = func(vector.x, left.x, right.x);
            vector.y = func(vector.y, left.y, right.y);
            vector.z = func(vector.z, left.z, right.z);

            return vector;
        }

        public static Vector3 ModifyAllDimensions(this Vector3 vector, Func<float, float> func)
        {
            vector.x = func(vector.x);
            vector.y = func(vector.y);
            vector.z = func(vector.z);

            return vector;
        }

        public static Vector4 ModifyMatching(this Vector4 vector, Vector4 vectorToMatch, Func<float, float, float> func)
        {
            vector.x = func(vector.x, vectorToMatch.x);
            vector.y = func(vector.y, vectorToMatch.y);
            vector.z = func(vector.z, vectorToMatch.z);
            vector.w = func(vector.w, vectorToMatch.w);

            return vector;
        }

        public static Vector4 ModifyMatching(this Vector4 vector, Vector4 left, Vector4 right, Func<float, float, float, float> func)
        {
            vector.x = func(vector.x, left.x, right.x);
            vector.y = func(vector.y, left.y, right.y);
            vector.z = func(vector.z, left.z, right.z);
            vector.w = func(vector.w, left.w, right.w);

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

        public static Vector2Int Multiply(this Vector2Int vector, Vector2Int multiplier)
        {
            return vector.ModifyMatching(multiplier, (left, right) => left * right);
        }

        public static Vector2Int Divide(this Vector2Int vector, Vector2Int divider)
        {
            return vector.ModifyMatching(divider, (left, right) => left / right);
        }

        public static Vector2Int Mod(this Vector2Int vector, Vector2Int mod)
        {
            return vector.ModifyMatching(mod, (left, right) => left % right);
        }

        public static Vector2Int Mod(this Vector2Int vector, int mod)
        {
            return vector.ModifyAllDimensions(value => value % mod);
        }

        public static Vector2Int LoopBetween(this Vector2Int vector, Vector2Int min, Vector2Int max)
        {
            return vector.ModifyMatching(min, max, (self, min, max) => self.LoopBetween(min, max));
        }

        public static Vector3Int Multiply(this Vector3Int vector, Vector3Int multiplier)
        {
            return vector.ModifyMatching(multiplier, (left, right) => left * right);
        }

        public static Vector3Int Divide(this Vector3Int vector, Vector3Int divider)
        {
            return vector.ModifyMatching(divider, (left, right) => left / right);
        }

        public static Vector3Int Mod(this Vector3Int vector, Vector3Int mod)
        {
            return vector.ModifyMatching(mod, (left, right) => left % right);
        }

        public static Vector3Int Mod(this Vector3Int vector, int mod)
        {
            return vector.ModifyAllDimensions(value => value % mod);
        }

        public static Vector3Int LoopBetween(this Vector3Int vector, Vector3Int min, Vector3Int max)
        {
            return vector.ModifyMatching(min, max, (self, min, max) => self.LoopBetween(min, max));
        }

        public static Vector2 Multiply(this Vector2 vector, Vector2 multiplier)
        {
            return vector.ModifyMatching(multiplier, (left, right) => left * right);
        }

        public static Vector2 Divide(this Vector2 vector, Vector2 divider)
        {
            return vector.ModifyMatching(divider, (left, right) => left / right);
        }

        public static Vector2 Mod(this Vector2 vector, Vector2 mod)
        {
            return vector.ModifyMatching(mod, (left, right) => left % right);
        }

        public static Vector2 Mod(this Vector2 vector, float mod)
        {
            return vector.ModifyAllDimensions(value => value % mod);
        }

        public static Vector2 LoopBetween(this Vector2 vector, Vector2 min, Vector2 max)
        {
            return vector.ModifyMatching(min, max, (self, min, max) => self.LoopBetween(min, max));
        }

        public static Vector3 Multiply(this Vector3 vector, Vector3 multiplier)
        {
            return vector.ModifyMatching(multiplier, (left, right) => left * right);
        }

        public static Vector3 Divide(this Vector3 vector, Vector3 divider)
        {
            return vector.ModifyMatching(divider, (left, right) => left / right);
        }

        public static Vector3 Mod(this Vector3 vector, Vector3 mod)
        {
            return vector.ModifyMatching(mod, (left, right) => left % right);
        }

        public static Vector3 Mod(this Vector3 vector, float mod)
        {
            return vector.ModifyAllDimensions(value => value % mod);
        }

        public static Vector3 LoopBetween(this Vector3 vector, Vector3 min, Vector3 max)
        {
            return vector.ModifyMatching(min, max, (self, min, max) => self.LoopBetween(min, max));
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

        public static Vector4 LoopBetween(this Vector4 vector, Vector4 min, Vector4 max)
        {
            return vector.ModifyMatching(min, max, (self, min, max) => self.LoopBetween(min, max));
        }

        public static Vector2 Sum(this IEnumerable<Vector2> vectors)
        {
            return vectors.Select(value => (Vector4)value).Sum();
        }

        public static Vector3 Sum(this IEnumerable<Vector3> vectors)
        {
            return vectors.Select(value => (Vector4)value).Sum();
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

        public static Vector2Int Sum(this IEnumerable<Vector2Int> vectors)
        {
            var sum = Vector2Int.zero;

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