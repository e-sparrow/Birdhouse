using UnityEngine;
using ESparrow.Utils.Tools.Errors.Adapters;
using ESparrow.Utils.Tools.Errors.Interfaces;

namespace ESparrow.Utils.Extensions
{
    public static class ErrorsExtensions
    {
        public static IErroneous<double> AsErroneous(this double value)
        {
            return new DoubleToErroneousAdapter(value);
        }

        public static IErroneous<float> AsErroneous(this float value)
        {
            return new FloatToErroneousAdapter(value);
        }

        public static IErroneous<Vector2> AsErroneous(this Vector2 value)
        {
            return new Vector2ToErroneousAdapter(value);
        }

        public static IErroneous<Vector3> AsErroneous(this Vector3 value)
        {
            return new Vector3ToErroneousAdapter(value);
        }

        public static IErroneous<Vector4> AsErroneous(this Vector4 value)
        {
            return new Vector4ToErroneousAdapter(value);
        }

        public static IErroneous<Quaternion> AsErroneous(this Quaternion value)
        {
            return new QuaternionToErroneousAdapter(value);
        }

        public static IErroneous<Color> AsErroneous(this Color value)
        {
            return new ColorToErroneousAdapter(value);
        }
    }
}
