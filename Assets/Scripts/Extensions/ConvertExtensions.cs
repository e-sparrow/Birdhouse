using System;
using UnityEngine;

namespace ESparrow.Utils.Extensions
{
    public static class ConvertExtensions
    {
        /// <summary>
        /// Converts decimal to double.
        /// </summary>
        /// <param name="self">Decimal to convert</param>
        /// <returns>Decimal converted to double</returns>
        public static double ToDouble(this decimal self)
        {
            return Convert.ToDouble(self);
        }
        
        /// <summary>
        /// Converts float to double
        /// </summary>
        /// <param name="self">Float to convert</param>
        /// <returns>Float converted to double</returns>
        public static double ToDouble(this float self)
        {
            return Convert.ToDouble(self);
        }

        /// <summary>
        /// Converts int to double.
        /// </summary>
        /// <param name="self">Int to convert</param>
        /// <returns>Int converted to double</returns>
        public static double ToDouble(this int self)
        {
            return Convert.ToDouble(self);
        }

        /// <summary>
        /// Converts double to float.
        /// </summary>
        /// <param name="self">Double to convert</param>
        /// <returns>Double converted to float</returns>
        public static float ToFloat(this double self)
        {
            return (float) self;
        }

        /// <summary>
        /// Converts int to float.
        /// </summary>
        /// <param name="self">Int to convert</param>
        /// <returns>Int converted to float</returns>
        public static float ToFloat(this int self)
        {
            return self;
        }

        /// <summary>
        /// Converts Vector3 to Vector2.
        /// </summary>
        /// <param name="self">Vector3 to convert</param>
        /// <returns>Vector3 converted to Vector2</returns>
        public static Vector2 ToVector2(this Vector3 self)
        {
            return self;
        }

        /// <summary>
        /// Converts Vector4 to Vector2.
        /// </summary>
        /// <param name="self">Vector4 to convert</param>
        /// <returns>Vector4 converted to Vector2</returns>
        public static Vector2 ToVector2(this Vector4 self)
        {
            return self;
        }

        /// <summary>
        /// Converts Vector2Int to Vector2.
        /// </summary>
        /// <param name="self">Vector2Int to convert</param>
        /// <returns>Vector2Int converted to Vector2</returns>
        public static Vector2 ToVector2(this Vector2Int self)
        {
            return self;
        }

        /// <summary>
        /// Converts Vector3Int to Vector2.
        /// </summary>
        /// <param name="self">Vector3Int to convert</param>
        /// <returns>Vector3Int converted to Vector2</returns>
        public static Vector2 ToVector2(this Vector3Int self)
        {
            return (Vector2Int) self;
        }

        /// <summary>
        /// Converts Vector2 to Vector3.
        /// </summary>
        /// <param name="self">Vector2 to convert</param>
        /// <returns>Vector2 converted to Vector3</returns>
        public static Vector3 ToVector3(this Vector2 self)
        {
            return self;
        }

        /// <summary>
        /// Converts Vector4 to Vector3.
        /// </summary>
        /// <param name="self">Vector4 to convert</param>
        /// <returns>Vector4 converted to Vector3</returns>
        public static Vector3 ToVector3(this Vector4 self)
        {
            return self;
        }

        /// <summary>
        /// Converts Vector2Int to Vector3
        /// </summary>
        /// <param name="self">Vector2Int to convert</param>
        /// <returns>Vector2Int converted to Vector3</returns>
        public static Vector3 ToVector3(this Vector2Int self)
        {
            return (Vector3Int) self;
        }

        /// <summary>
        /// Converts Vector3Int to Vector3.
        /// </summary>
        /// <param name="self">Vector3Int to convert</param>
        /// <returns>Vector3Int converted to Vector3</returns>
        public static Vector3 ToVector3(this Vector3Int self)
        {
            return self;
        }

        /// <summary>
        /// Converts Vector2 to Vector4.
        /// </summary>
        /// <param name="self">Vector2 to convert</param>
        /// <returns>Vector2 converted to Vector4</returns>
        public static Vector4 ToVector4(this Vector2 self)
        {
            return self;
        }
        
        /// <summary>
        /// Converts Vector3 to Vector4.
        /// </summary>
        /// <param name="self">Vector3 to convert</param>
        /// <returns>Vector3 converted to Vector4</returns>
        public static Vector4 ToVector4(this Vector3 self)
        {
            return self;
        }

        /// <summary>
        /// Converts Vector2Int to Vector4.
        /// </summary>
        /// <param name="self">Vector2Int to convert</param>
        /// <returns>Vector2Int converted to Vector4</returns>
        public static Vector4 ToVector4(this Vector2Int self)
        {
            return new Vector4(self.x, self.y, 0, 0);
        }

        /// <summary>
        /// Converts Vector3Int to Vector4.
        /// </summary>
        /// <param name="self">Vector3Int to convert</param>
        /// <returns>Vector3Int converted to Vector4</returns>
        public static Vector4 ToVector4(this Vector3Int self)
        {
            return new Vector4(self.x, self.y, self.z, 0);
        }

        /// <summary>
        /// Converts Color to Vector4.
        /// </summary>
        /// <param name="self">Color to convert</param>
        /// <returns>Color converted to Vector4</returns>
        public static Vector4 ToVector4(this Color self)
        {
            return new Vector4(self.r, self.g, self.b, self.a);
        }

        /// <summary>
        /// Converts Quaternion to Vector4.
        /// </summary>
        /// <param name="self">Quaternion to convert</param>
        /// <returns>Quaternion converted to Vector4</returns>
        public static Vector4 ToVector4(this Quaternion self)
        {
            return new Vector4(self.x, self.y, self.z, self.w);
        }

        /// <summary>
        /// Converts Vector2 to Vector2Int.
        /// </summary>
        /// <param name="self">Vector2 to convert</param>
        /// <returns>Vector2 converted to Vector2Int</returns>
        public static Vector2Int ToVector2Int(this Vector2 self)
        {
            return new Vector2Int((int) self.x, (int) self.y);
        }

        /// <summary>
        /// Converts Vector3 to Vector2Int.
        /// </summary>
        /// <param name="self">Vector3 to convert</param>
        /// <returns>Vector3 converted to Vector2Int</returns>
        public static Vector2Int ToVector2Int(this Vector3 self)
        {
            return new Vector2Int((int) self.x, (int) self.y);
        }

        /// <summary>
        /// Converts Vector4 to Vector2Int.
        /// </summary>
        /// <param name="self">Vector4 to convert</param>
        /// <returns>Vector4 converted to Vector2Int</returns>
        public static Vector2Int ToVector2Int(this Vector4 self)
        {
            return new Vector2Int((int) self.x, (int) self.y);
        }

        /// <summary>
        /// Converts Vector3Int to Vector2Int.
        /// </summary>
        /// <param name="self">Vector3Int to convert</param>
        /// <returns>Vector3Int converted to Vector2Int</returns>
        public static Vector2Int ToVector2Int(this Vector3Int self)
        {
            return (Vector2Int) self;
        }

        /// <summary>
        /// Converts Vector2 to Vector3Int.
        /// </summary>
        /// <param name="self">Vector2 to convert</param>
        /// <returns>Vector2 converted to Vector3Int</returns>
        public static Vector3Int ToVector3Int(this Vector2 self)
        {
            return new Vector3Int((int) self.x, (int) self.y, 0);
        }

        /// <summary>
        /// Converts Vector3 to Vector3Int.
        /// </summary>
        /// <param name="self">Vector3 to convert</param>
        /// <returns>Vector3 converted to Vector3Int</returns>
        public static Vector3Int ToVector3Int(this Vector3 self)
        {
            return new Vector3Int((int) self.x, (int) self.y, (int) self.z);
        }

        /// <summary>
        /// Converts Vector2Int to Vector3Int.
        /// </summary>
        /// <param name="self">Vector2Int to convert</param>
        /// <returns>Vector2Int converted Vector3Int</returns>
        public static Vector3Int ToVector3Int(this Vector2Int self)
        {
            return new Vector3Int(self.x, self.y, 0);
        }

        /// <summary>
        /// Converts Vector4 to Color.
        /// </summary>
        /// <param name="self">Vector4 to convert</param>
        /// <returns>Vector4 converted to Color</returns>
        public static Color ToColor(this Vector4 self)
        {
            return new Color(self.x, self.y, self.z, self.w);
        }

        /// <summary>
        /// Converts Quaternion to Color.
        /// </summary>
        /// <param name="self">Quaternion to convert</param>
        /// <returns>Quaternion converted to Color</returns>
        public static Color ToColor(this Quaternion self)
        {
            return new Color(self.x, self.y, self.z, self.w);
        }

        /// <summary>
        /// Converts Vector4 to Quaternion.
        /// </summary>
        /// <param name="self">Vector4 to convert</param>
        /// <returns>Vector4 converted to Quaternion</returns>
        public static Quaternion ToQuaternion(this Vector4 self)
        {
            return new Quaternion(self.x, self.y, self.z, self.w);
        }

        /// <summary>
        /// Converts Color to Quaternion.
        /// </summary>
        /// <param name="self">Color to convert</param>
        /// <returns>Color converted to Quaternion</returns>
        public static Quaternion ToQuaternion(this Color self)
        {
            return new Quaternion(self.r, self.g, self.b, self.a);
        }
    }
}
