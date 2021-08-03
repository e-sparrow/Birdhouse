using System.Linq;
using UnityEngine;

namespace ESparrow.Utils.Mathematics
{
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
    }
}
