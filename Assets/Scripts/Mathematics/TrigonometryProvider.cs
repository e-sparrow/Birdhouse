using UnityEngine;

namespace ESparrow.Utils.Mathematics
{
    public static class TrigonometryProvider
    {
        public static float SinBetween(float min, float max, float t)
        {
            return Mathf.Lerp(min, max, (Mathf.Sin(t) + 1) / 2);
        }

        public static float SinFromZeroToOne(float t)
        {
            return SinBetween(0f, 1f, t); 
        }
    }
}
