using UnityEngine;

namespace ESparrow.Utils.Extensions
{
    public static class MatrixExtensions
    {
        /// <summary>
        /// ¬озвращает позицию матрицы.
        /// </summary>
        public static Vector3 GetPosition(this Matrix4x4 matrix)
        {
            Vector3 position;
            position.x = matrix.m03;
            position.y = matrix.m13;
            position.z = matrix.m23;

            return position;
        }

        /// <summary>
        /// ¬озвращает поворот матрицы.
        /// </summary>
        public static Quaternion GetRotation(this Matrix4x4 matrix)
        {
            Vector3 forward;
            forward.x = matrix.m02;
            forward.y = matrix.m12;
            forward.z = matrix.m22;

            Vector3 upwards;
            upwards.x = matrix.m01;
            upwards.y = matrix.m11;
            upwards.z = matrix.m21;

            return Quaternion.LookRotation(forward, upwards);
        }

        /// <summary>
        /// ¬озвращает размер матрицы.
        /// </summary>
        public static Vector3 GetScale(this Matrix4x4 matrix)
        {
            Vector3 scale;
            scale.x = new Vector4(matrix.m00, matrix.m10, matrix.m20, matrix.m30).magnitude;
            scale.y = new Vector4(matrix.m01, matrix.m11, matrix.m21, matrix.m31).magnitude;
            scale.z = new Vector4(matrix.m02, matrix.m12, matrix.m22, matrix.m32).magnitude;

            return scale;
        }

        /// <summary>
        /// ”станавливает матрице позицию и возвращает получившуюс€ матрицу.
        /// </summary>
        public static Matrix4x4 SetPosition(this Matrix4x4 matrix, Vector3 position)
        {
            matrix.m03 = position.x;
            matrix.m13 = position.y;
            matrix.m23 = position.z;

            return matrix;
        }

        /// <summary>
        /// ”станавливает матрице поворот и возвращает получившуюс€ матрицу.
        /// </summary>
        public static Matrix4x4 SetRotation(this Matrix4x4 matrix, Quaternion rotation)
        {
            Vector3 forward = rotation * Vector3.forward;
            matrix.m02 = forward.x;
            matrix.m12 = forward.y;
            matrix.m22 = forward.z;

            Vector3 upwards = rotation * Vector3.up;
            matrix.m01 = upwards.x;
            matrix.m11 = upwards.y;
            matrix.m21 = upwards.z;

            return matrix;
        }

        /// <summary>
        /// ”станавливает матрице размер и возвращает получившуюс€ матрицу.
        /// </summary>
        public static Matrix4x4 SetScale(this Matrix4x4 matrix, Vector3 scale)
        {
            matrix = Matrix4x4.TRS(matrix.GetPosition(), matrix.GetRotation(), scale);

            return matrix;
        }
    }
}
