using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ESparrow.Utils.Extensions
{
    public static class UIExtensions
    {
        /// <summary>
        /// Sets specified alpha channel value to image.
        /// </summary>
        /// <param name="image">Image to change alpha</param>
        /// <param name="alpha">Specified alpha channel value</param>
        public static void SetAlpha(this Image image, float alpha)
        {
            image.color = image.color.SetAlpha(alpha);
        }
    }
}
