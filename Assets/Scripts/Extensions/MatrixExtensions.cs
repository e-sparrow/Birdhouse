using System;
using UnityEngine;

namespace ESparrow.Utils.Extensions
{
    public static class MatrixExtensions
    {
        /// <summary>
        /// ���������� ������� �������.
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
        /// ���������� ������� �������.
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
        /// ���������� ������ �������.
        /// </summary>
        public static Vector3 GetScale(this Matrix4x4 matrix)
        {
            Vector3 scale;
            scale.x = new Vector4(matrix.m00, matrix.m10, matrix.m20, matrix.m30).magnitude;
            scale.y = new Vector4(matrix.m01, matrix.m11, matrix.m21, matrix.m31).magnitude;
            scale.z = new Vector4(matrix.m02, matrix.m12, matrix.m22, matrix.m32).magnitude;

            return scale;
        }
    }
}