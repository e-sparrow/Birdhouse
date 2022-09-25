using System;
using Birdhouse.Common.Extensions;
using UnityEngine;

namespace Birdhouse.Common.Mathematics
{
    [Serializable]
    public readonly struct Polar
    {
        /// <summary>
        /// Creates polar coordinates from radius and angle.
        /// </summary>
        /// <param name="radius">Radius of coordinates</param>
        /// <param name="angle">Angle at which coordinates are rotated</param>
        public Polar(float angle, float radius)
        {
            Angle = angle;
            Radius = radius;
        }

        /// <summary>
        /// Creates polar coordinates from Cartesian coordinates.
        /// </summary>
        /// <param name="vector">Vector in Cartesian coordinates</param>
        public Polar(Vector2 vector)
        {
            Angle = Mathf.Atan2(vector.y, vector.x);
            Radius = vector.magnitude;
        }

        /// <summary>
        /// Creates polar coordinates from polar coordinates.
        /// </summary>
        /// <param name="direction">Direction of coordinates</param>
        /// <param name="radius">Radius of polar coordinates</param>
        public Polar(Direction direction, float radius) : this(direction.Vector * radius)
        {
            
        }

        /// <summary>
        /// Converts polar coordinates to Cartesian.
        /// </summary>
        /// <returns>Cartesian coordinates</returns>
        public Vector2 ToVector2()
        {
            return new Vector2(Mathf.Cos(Angle) * Radius, Mathf.Sin(Angle) * Radius);
        }

        /// <summary>
        /// Converts polar coordinates to Cartesian.
        /// </summary>
        /// <returns>Cartesian coordinates</returns>
        public Vector3 ToVector3()
        {
            return ToVector2().ToVector3();
        }

        /// <summary>
        /// Angle of coordinates property.
        /// </summary>
        public float Angle
        {
            get;
        }
        
        /// <summary>
        /// Radius of coordinates property.
        /// </summary>
        public float Radius
        {
            get;
        }
    }
}
