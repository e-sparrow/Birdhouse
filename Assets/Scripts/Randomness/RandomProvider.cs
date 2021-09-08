using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Extensions;
using Random = UnityEngine.Random;

namespace ESparrow.Utils.Randomness
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

        public static bool GetRandomWithChances<T>(IEnumerable<RandomnessElement<T>> elements, out T result)
        {
            float sum = elements.Sum(value => value.Chance);
            if (sum > 1f)
            {
                throw new Exception($"Sum of element's chances is more than 1");
            }

            float emptiness = 1f - sum;
            var emptyElement = new RandomnessElement<T>(default, emptiness);

            var collection = elements.Concat(emptyElement.AsSingleCollection());
            var randomElement = collection.GetWeighedRandom(value => value.Chance);

            result = randomElement.Element;

            return randomElement != emptyElement;
        }
    }
}
