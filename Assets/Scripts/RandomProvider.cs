using UnityEngine;

namespace ESparrow.Utils
{
    public static class RandomProvider
    {
        /// <summary>
        /// Возвращает true с указанным в аргументе шансом в процентах.
        /// </summary>
        public static bool TryLuck(int chance)
        {
            if (chance < 0 || chance > 100)
            {
                Debug.LogWarning($"Chance is outside the bounds of the array.");
            }

            return Random.Range(0, 100) <= chance;
        }

        /// <summary>
        /// Возвращает true с указанным в аргументе шансом в долях (от 0 до 1).
        /// </summary>
        public static bool TryLuck(float chance)
        {
            if (chance < 0f || chance > 1f)
            {
                Debug.LogWarning($"Chance is outside the bounds of the array.");
            }

            return Random.Range(0f, 1f) <= chance;
        }
    }
}
