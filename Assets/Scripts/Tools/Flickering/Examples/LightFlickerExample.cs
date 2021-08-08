using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace ESparrow.Utils.Tools.Flickering.Examples
{
    public class LightFlickerExample : Flicker
    {
        [SerializeField] private Light targetLight;

        [SerializeField] private List<CharIntensityPair> charIntensityPairs;

        protected override List<CharActionPair> DefaultPairs => GetDefaultPairs();

        private List<CharActionPair> GetDefaultPairs()
        {
            var pairs = charIntensityPairs.Select(value => GetPairByCharAndIntensity(value.character, value.intensity));

            return pairs.ToList();

            CharActionPair GetPairByCharAndIntensity(char character, float intensity)
            {
                return new CharActionPair(character, SetIntensity);

                void SetIntensity()
                {
                    targetLight.intensity = intensity;
                }
            }
        }

        [Serializable]
        private struct CharIntensityPair
        {
            public char character;
            public float intensity;

            public CharIntensityPair(char character, float intensity)
            {
                this.character = character;
                this.intensity = intensity;
            }
        }
    }
}
