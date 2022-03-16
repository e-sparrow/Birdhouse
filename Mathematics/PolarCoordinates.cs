using System;
using UnityEngine;
using ESparrow.Utils.Extensions;

namespace ESparrow.Utils.Mathematics
{
    [Serializable]
    public struct PolarCoordinates
    {
        private float _radius;
        private float _angle;

        /// <summary>
        /// Radius of coordinates property.
        /// </summary>
        public float Radius
        {
            get => _radius;
            set => _radius = value;
        }

        /// <summary>
        /// Angle of coordinates property.
        /// </summary>
        public float Angle
        {
            get => _angle;
            set => _angle = value;
        }

        /// <summary>
        /// Creates polar coordinates from radius and angle.
        /// </summary>
        /// <param name="radius">Radius of coordinates</param>
        /// <param name="angle">Angle at which coordinates are rotated</param>
        public PolarCoordinates(float radius, float angle)
        {
            _radius = radius;
            _angle = angle;
        }

        /// <summary>
        /// Creates polar coordinates from Cartesian coordinates.
        /// </summary>
        /// <param name="vector">Vector in Cartesian coordinates</param>
        public PolarCoordinates(Vector2 vector)
        {
            _radius = vector.magnitude;
            _angle = Mathf.Atan2(vector.y, vector.x);
        }

        /// <summary>
        /// Converts polar coordinates to Cartesian.
        /// </summary>
        /// <returns>Cartesian coordinates</returns>
        public Vector2 ToVector2()
        {
            return new Vector2(Mathf.Cos(_angle) * _radius, Mathf.Sin(_angle) * _radius);
        }

        /// <summary>
        /// Converts polar coordinates to Cartesian.
        /// </summary>
        /// <returns>Cartesian coordinates</returns>
        public Vector3 ToVector3()
        {
            return ToVector2().ToVector3();
        }
    }
}
