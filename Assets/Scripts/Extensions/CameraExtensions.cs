using UnityEngine;

namespace ESparrow.Utils.Extensions
{
    public static class CameraExtensions
    {
        public static Rect GetWorldRect(this Camera camera)
        {
            var leftDownCorner = camera.ViewportToWorldPoint(Vector2.zero);
            var rectSize = camera.ViewportToWorldPoint(Vector2.one) - leftDownCorner;

            return new Rect(leftDownCorner, rectSize);
        }

        public static Vector2 GetWorldCenter(this Camera camera)
        {
            return camera.GetWorldRect().center;
        }
    }
}
