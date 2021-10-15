using System;
using UnityEngine;
using ESparrow.Utils.Generalization.Errors.Adapters;
using ESparrow.Utils.Generalization.Errors.Interfaces;

namespace ESparrow.Utils.Extensions
{
    public static class ErrorsExtensions
    {
        /// <summary>
        /// Converts decimal to erroneous interface.
        /// </summary>
        /// <param name="value">Decimal to convert</param>
        /// <returns>Erroneous interface</returns>
        public static IErroneous<decimal> AsErroneous(this decimal value)
        {
            return new DecimalToErroneousAdapter(value);
        }

        /// <summary>
        /// Converts double to erroneous interface.
        /// </summary>
        /// <param name="value">Double to convert</param>
        /// <returns>Erroneous interface</returns>
        public static IErroneous<double> AsErroneous(this double value)
        {
            return new DoubleToErroneousAdapter(value);
        }

        /// <summary>
        /// Converts float to erroneous interface.
        /// </summary>
        /// <param name="value">Float to convert</param>
        /// <returns>Erroneous interface</returns>
        public static IErroneous<float> AsErroneous(this float value)
        {
            return new FloatToErroneousAdapter(value);
        }

        /// <summary>
        /// Converts Vector2 to erroneous interface.
        /// </summary>
        /// <param name="value">Vector2 to convert</param>
        /// <returns>Erroneous interface</returns>
        public static IErroneous<Vector2> AsErroneous(this Vector2 value)
        {
            return new Vector2ToErroneousAdapter(value);
        }

        /// <summary>
        /// Converts Vector3 to erroneous interface.
        /// </summary>
        /// <param name="value">Vector3 to convert</param>
        /// <returns>Erroneous interface</returns>
        public static IErroneous<Vector3> AsErroneous(this Vector3 value)
        {
            return new Vector3ToErroneousAdapter(value);
        }

        /// <summary>
        /// Converts Vector4 to erroneous interface.
        /// </summary>
        /// <param name="value">Vector4 to convert</param>
        /// <returns>Erroneous interface</returns>
        public static IErroneous<Vector4> AsErroneous(this Vector4 value)
        {
            return new Vector4ToErroneousAdapter(value);
        }

        /// <summary>
        /// Converts Quaternion to erroneous interface.
        /// </summary>
        /// <param name="value">Quaternion to convert</param>
        /// <returns>Erroneous interface</returns>
        public static IErroneous<Quaternion> AsErroneous(this Quaternion value)
        {
            return new QuaternionToErroneousAdapter(value);
        }

        /// <summary>
        /// Converts Color to erroneous interface.
        /// </summary>
        /// <param name="value">Color to convert</param>
        /// <returns>Erroneous interface</returns>
        public static IErroneous<Color> AsErroneous(this Color value)
        {
            return new ColorToErroneousAdapter(value);
        }
        
        /// <summary>
        /// Compares values with default error of interface.
        /// </summary>
        /// <param name="self">Self erroneous interface inheritor</param>
        /// <param name="other">Another value</param>
        /// <typeparam name="TErroneous">Erroneous interface inheritor</typeparam>
        /// <typeparam name="TOther">Another value of type erroneous interface inheritor</typeparam>
        /// <returns>True if compare is successful and false otherwise</returns>
        public static bool CompareWithDefaultError<TErroneous, TOther>(this TErroneous self, TOther other) 
            where TErroneous : IErroneous<TOther>
        {
            return self.CompareWithError(other, self.DefaultError);
        }
    }
}
