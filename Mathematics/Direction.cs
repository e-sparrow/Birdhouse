using System;
using System.Linq;
using UnityEngine;

namespace ESparrow.Utils.Mathematics
{
    [Serializable]
    public readonly struct Direction
    {
        /// <summary>
        /// Creates direction by vector.
        /// </summary>
        /// <param name="vector">Vector to create direction</param>
        public Direction(Vector3 vector)
        {
            Vector = vector.normalized;
        }
        
        public static readonly Direction Up = new Direction(Vector3.up);
        public static readonly Direction Down = new Direction(Vector3.down);
        public static readonly Direction Left = new Direction(Vector3.left);
        public static readonly Direction Right = new Direction(Vector3.right);
        public static readonly Direction Forward = new Direction(Vector3.forward);
        public static readonly Direction Back = new Direction(Vector3.back);
        
        /// <summary>
        /// Gets all directions in 2D space.
        /// </summary>
        public static readonly Direction[] Directions2d = new Direction[]
        {
            Up,
            Down,
            Left,
            Right
        };

        /// <summary>
        /// Gets all directions in 3D space.
        /// </summary>
        public static readonly Direction[] Directions = new Direction[]
        {
            Up,
            Down,
            Left,
            Right,
            Forward,
            Back
        };
        
        /// <summary>
        /// Gets average direction between two ones.
        /// </summary>
        /// <param name="from">Start direction</param>
        /// <param name="to">End direction</param>
        /// <returns>Average direction between two arguments</returns>
        public static Direction GetAverage(Direction from, Direction to)
        {
            return Lerp(from, to, 0.5f);
        }

        /// <summary>
        /// Gets average direction between all the parameters.
        /// </summary>
        /// <param name="directions">Directions to get average</param>
        /// <returns>Average direction</returns>
        public static Direction GetAverage(params Direction[] directions)
        {
            var current = directions.First();
            foreach (var direction in directions)
            {
                current = GetAverage(current, direction);
            }

            return current;
        }

        /// <summary>
        /// Linear interpolates between from and to by progress.
        /// </summary>
        /// <param name="from">Start point</param>
        /// <param name="to">End point</param>
        /// <param name="progress">Progress to interpolate</param>
        /// <returns>Interpolated value</returns>
        public static Direction Lerp(Direction from, Direction to, float progress)
        {
            var fromRotation = Quaternion.FromToRotation(Vector3.zero, from.Vector);
            var toRotation = Quaternion.FromToRotation(Vector3.zero, to.Vector);

            var currentRotation = Quaternion.Lerp(fromRotation, toRotation, progress);
            var currentVector = currentRotation * Vector3.forward;

            return new Direction(currentVector);
        }

        /// <summary>
        /// Reversed direction.
        /// </summary>
        public Direction Reverse => new Direction(-Vector);

        /// <summary>
        /// Directly vector of direction.
        /// </summary>
        public Vector3 Vector
        {
            get;
        }
    }
}
