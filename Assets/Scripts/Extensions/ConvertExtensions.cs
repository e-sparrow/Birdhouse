using System;
using UnityEngine;

namespace ESparrow.Utils.Extensions
{
    public static class ConvertExtensions
    {
        public static double ToDouble(this float self)
        {
            return Convert.ToDouble(self);
        }

        public static double ToDouble(this int self)
        {
            return Convert.ToDouble(self);
        }

        public static float ToFloat(this double self)
        {
            return (float) self;
        }

        public static float ToFloat(this int self)
        {
            return self;
        }

        public static Vector2 ToVector2(this Vector3 self)
        {
            return self;
        }

        public static Vector2 ToVector2(this Vector4 self)
        {
            return self;
        }

        public static Vector2 ToVector2(this Vector2Int self)
        {
            return self;
        }

        public static Vector2 ToVector2(this Vector3Int self)
        {
            return (Vector2Int) self;
        }

        public static Vector3 ToVector3(this Vector2 self)
        {
            return self;
        }

        public static Vector3 ToVector3(this Vector4 self)
        {
            return self;
        }

        public static Vector3 ToVector3(this Vector2Int self)
        {
            return (Vector3Int) self;
        }

        public static Vector3 ToVector3(this Vector3Int self)
        {
            return self;
        }

        public static Vector4 ToVector4(this Vector2 self)
        {
            return self;
        }

        public static Vector4 ToVector4(this Vector3 self)
        {
            return self;
        }

        public static Vector4 ToVector4(this Vector2Int self)
        {
            return new Vector4(self.x, self.y, 0, 0);
        }

        public static Vector4 ToVector4(this Vector3Int self)
        {
            return new Vector4(self.x, self.y, self.z, 0);
        }

        public static Vector4 ToVector4(this Color self)
        {
            return new Vector4(self.r, self.g, self.b, self.a);
        }

        public static Vector4 ToVector4(this Quaternion self)
        {
            return new Vector4(self.x, self.y, self.z, self.w);
        }

        public static Vector2Int ToVector2Int(this Vector2 self)
        {
            return new Vector2Int((int) self.x, (int) self.y);
        }

        public static Vector2Int ToVector2Int(this Vector3 self)
        {
            return new Vector2Int((int) self.x, (int) self.y);
        }

        public static Vector2Int ToVector2Int(this Vector4 self)
        {
            return new Vector2Int((int) self.x, (int) self.y);
        }

        public static Vector2Int ToVector2Int(this Vector3Int self)
        {
            return (Vector2Int) self;
        }

        public static Vector3Int ToVector3Int(this Vector2 self)
        {
            return new Vector3Int((int) self.x, (int) self.y, 0);
        }

        public static Vector3Int ToVector3Int(this Vector3 self)
        {
            return new Vector3Int((int) self.x, (int) self.y, (int) self.z);
        }

        public static Vector3Int ToVector3Int(this Vector2Int self)
        {
            return new Vector3Int(self.x, self.y, 0);
        }

        public static Color ToColor(this Vector4 self)
        {
            return new Color(self.x, self.y, self.z, self.w);
        }

        public static Color ToColor(this Quaternion self)
        {
            return new Color(self.x, self.y, self.z, self.w);
        }

        public static Quaternion ToQuaternion(this Vector4 self)
        {
            return new Quaternion(self.x, self.y, self.z, self.w);
        }

        public static Quaternion ToQuaternion(this Color self)
        {
            return new Quaternion(self.r, self.g, self.b, self.a);
        }
    }
}
