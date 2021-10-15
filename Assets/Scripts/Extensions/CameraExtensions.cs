using UnityEngine;

namespace ESparrow.Utils.Extensions
{
    public static class CameraExtensions
    {
        /// <summary>
        /// Gets rect of a camera.
        /// </summary>
        /// <param name="camera">Camera to get a rect</param>
        /// <returns>Rect of a camera in world space</returns>
        public static Rect GetWorldRect(this Camera camera)
        {
            var leftDownCorner = camera.ViewportToWorldPoint(Vector2.zero);
            var rectSize = camera.ViewportToWorldPoint(Vector2.one) - leftDownCorner;

            return new Rect(leftDownCorner, rectSize);
        }

        /// <summary>
        /// Returns world center of camera's rect.
        /// </summary>
        /// <param name="camera">Camera to get a center</param>
        /// <returns>World center of a camera's rect</returns>
        public static Vector2 GetWorldCenter(this Camera camera)
        {
            return camera.GetWorldRect().center;
        }
    }
}
