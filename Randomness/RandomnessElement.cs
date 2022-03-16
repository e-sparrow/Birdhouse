using System;
using UnityEngine;

namespace ESparrow.Utils.Randomness
{
    [Serializable]
    public class RandomnessElement<T>
    {
        [SerializeField] private T element;
        [SerializeField] private float chance;
    
        public T Element
        {
            get => element;
            set => element = value;
        }

        public float Chance
        {
            get => chance;
            set => chance = value;
        }

        public RandomnessElement(T element, float chance)
        {
            this.element = element;
            this.chance = chance;
        }
    }
}
