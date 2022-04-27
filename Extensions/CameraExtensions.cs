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

        public static void DrawRectOnCameraScreen(this Camera camera, Rect rect, float range = 1f)
        {
            var minX = rect.xMin;
            var minY = rect.yMin;
            var maxX = rect.xMax;
            var maxY = rect.yMax;

            var topLeft = camera.ScreenToWorldPoint(new Vector3(minX, maxY, range));
            var topRight = camera.ScreenToWorldPoint(new Vector3(maxX, maxY, range));
            var lowerRight = camera.ScreenToWorldPoint(new Vector3(maxX, minY, range));
            var lowerLeft = camera.ScreenToWorldPoint(new Vector3(minX, minY, range));
            
            Gizmos.DrawLine(topLeft, topRight);
            Gizmos.DrawLine(topRight, lowerRight);
            Gizmos.DrawLine(lowerRight, lowerLeft);
            Gizmos.DrawLine(lowerLeft, topLeft);
        }
    }
}
