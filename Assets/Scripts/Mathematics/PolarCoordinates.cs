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

        public float Radius
        {
            get => _radius;
            set => _radius = value;
        }

        public float Angle
        {
            get => _angle;
            set => _angle = value;
        }

        public PolarCoordinates(float radius, float angle)
        {
            _radius = radius;
            _angle = angle;
        }

        public PolarCoordinates(Vector2 vector)
        {
            _radius = vector.magnitude;
            _angle = Mathf.Atan2(vector.y, vector.x);
        }

        public Vector2 ToVector2()
        {
            return new Vector2(Mathf.Cos(_angle) * _radius, Mathf.Sin(_angle) * _radius);
        }

        public Vector3 ToVector3()
        {
            return ToVector2().ToVector3();
        }
    }
}
