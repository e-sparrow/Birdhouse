using System;
using System.Linq;
using UnityEngine;

namespace ESparrow.Utils.Mathematics
{
    [Serializable]
    public struct Direction
    {
        public static readonly Direction up = new Direction(Vector3.up);
        public static readonly Direction down = new Direction(Vector3.down);
        public static readonly Direction left = new Direction(Vector3.left);
        public static readonly Direction right = new Direction(Vector3.right);
        public static readonly Direction forward = new Direction(Vector3.forward);
        public static readonly Direction back = new Direction(Vector3.back);

        public static readonly Direction[] directions2d = new Direction[]
        {
            up,
            down,
            left,
            right
        };

        public static readonly Direction[] directions = new Direction[]
        {
            forward,
            back
        }.Concat(directions2d).ToArray();

        public Vector3 vector;

        public Direction Reverse => new Direction(-vector);

        public Direction(Vector3 vector)
        {
            this.vector = vector.normalized;
        }

        public static Direction GetAverage(Direction from, Direction to)
        {
            return Lerp(from, to, 0.5f);
        }

        public static Direction Lerp(Direction from, Direction to, float t)
        {
            var fromRotation = Quaternion.FromToRotation(Vector3.zero, from.vector);
            var toRotation = Quaternion.FromToRotation(Vector3.zero, to.vector);

            var currentRotation = Quaternion.Lerp(fromRotation, toRotation, t);
            var currentVector = currentRotation * Vector3.forward;

            return new Direction(currentVector);
        }
    }
}
